using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StarResonanceDpsAnalysis.Control.GDI;
using StarResonanceDpsAnalysis.Effects;
using StarResonanceDpsAnalysis.Effects.Enum;

using static StarResonanceDpsAnalysis.Control.GDI.RenderContent;

namespace StarResonanceDpsAnalysis.Control
{
    public partial class SortedProgressBarList
    {
        private static readonly Dictionary<Quality, int> _animationFpsQuality = new()
        {
            { Quality.VeryLow, 10 },
            { Quality.Low, 20 },
            { Quality.Medium, 30 },
            { Quality.High, 60 },
            { Quality.VeryHigh, 120 },
            { Quality.Extreme, 160 },
            { Quality.AlmostAccurate, 999 }
        };
        private readonly PeriodicTimer _animationPeriodicTimer;
        private readonly CubicBezier _moveAnimationCubicBezier;
        private readonly CubicBezier _fadeAnimationCubicBezier;

        private readonly object _lock = new();
        private readonly Dictionary<long, GDI_ProgressBar> _gdiProgressBarDict = [];
        private readonly DrawInfo _drawInfo = new();
        private readonly ProgressBarPrivateData _progressBarPrivateData = new();
        private readonly List<RenderContent> _renderContentBuffer = [];

        private Pen? _selectionBorderPen = null;
        private readonly SolidBrush _scrollBarBrush = new(Color.FromArgb(0xB2, 0xB2, 0xB2));

        private readonly Stopwatch _animationWatch = new();
        private bool _animating = false;
        private List<long> _prevIdOrder = [];
        private List<SortAnimatingInfo> _animatingInfoBuffer = [];

        private CancellationTokenSource? _animationCancellation = null;

        public void Redraw(PaintEventArgs e)
        {
            if (Width == 0 || Height == 0) return;

            lock (_lock)
            {
                var g = e.Graphics;

                g.Clear(BackColor);

                var aniMs = _animationWatch.ElapsedMilliseconds;

                if (_animating && aniMs > AnimationDuration)
                {
                    _animating = false;
                    // Console.WriteLine($"动画结束");
                }

                if (!_animating)
                {
                    var flag = Resort();
                    if (flag)
                    {
                        _prevIdOrder = [.. _animatingInfoBuffer.Select(e => e.ID)];

                        _animationWatch.Restart();

                        _animating = true;
                        //Console.WriteLine($"动画启动");
                    }
                }

                var staticDraw = aniMs >= AnimationDuration;

                // 绘制进度条内容
                foreach (var data in _animatingInfoBuffer)
                {
                    var outOfHeightIndex = (Height / ProgressBarHeight) + 1;
                    var fromIndex = data.FromIndex == -1
                        ? outOfHeightIndex
                        : data.FromIndex;
                    var toIndex = data.ToIndex == -1
                        ? outOfHeightIndex
                        : data.ToIndex;
                    var top = 1f * fromIndex * ProgressBarHeight - ScrollOffsetY;

                    _progressBarPrivateData.OrderAlign = OrderAlign;
                    _progressBarPrivateData.OrderColor = OrderColor;
                    _progressBarPrivateData.OrderFont = OrderFont;
                    _progressBarPrivateData.OrderOffset = OrderOffset;
                    _progressBarPrivateData.OrderImageAlign = OrderImageAlign;
                    _progressBarPrivateData.OrderImageOffset = OrderImageOffset;

                    _progressBarPrivateData.OrderString = OrderCallback == null
                        ? null
                        : OrderCallback(data.ToIndex + 1);

                    _progressBarPrivateData.OrderImage = OrderImages == null || data.ToIndex < 0 || data.ToIndex >= OrderImages.Count
                        ? null
                        : OrderImages[data.ToIndex];
                    _progressBarPrivateData.OrderImageRenderSize =
                        _progressBarPrivateData.OrderImage != null && (OrderImageRenderSize.Width == 0 || OrderImageRenderSize.Height == 0)
                        ? _progressBarPrivateData.OrderImage.Size
                        : OrderImageRenderSize;

                    if (data.FromIndex == data.ToIndex || staticDraw)
                    {
                        _progressBarPrivateData.Top = top;
                        _progressBarPrivateData.Opacity = 255;

                        if (top < -ProgressBarHeight || top > Height)
                        {
                            continue;
                        }

                        DrawProgressBar(g, data.Data, _progressBarPrivateData);
                    }
                    else
                    {
                        var timePersent = 1f * aniMs / AnimationDuration;
                        var moveBezier = _moveAnimationCubicBezier.GetProximateBezierValue(timePersent);
                        var fadeBezier = _fadeAnimationCubicBezier.GetProximateBezierValue(timePersent);

                        var opacity = byte.MaxValue;

                        if (data.FromIndex == -1)
                        {
                            opacity = (byte)(opacity * fadeBezier);
                        }
                        else if (data.ToIndex == -1)
                        {
                            opacity = (byte)(255 - opacity * fadeBezier);
                        }

                        top += ProgressBarHeight * (toIndex - fromIndex) * moveBezier;

                        _progressBarPrivateData.Top = top;
                        _progressBarPrivateData.Opacity = opacity;

                        if (top < -ProgressBarHeight || top > Height)
                        {
                            continue;
                        }

                        DrawProgressBar(g, data.Data, _progressBarPrivateData);
                    }
                }

                // 绘制选取框
                if (_selectedIndex != null)
                {
                    var borderWidth = 2;
                    var halfWidth = borderWidth / 2;
                    var top = _selectedIndex.Value * ProgressBarHeight - ScrollOffsetY + halfWidth;
                    if (top > -ProgressBarHeight && top < Height)
                    {

                        _selectionBorderPen ??= new Pen(_seletedItemColor, borderWidth);

                        g.InterpolationMode = InterpolationMode.Low;
                        g.SmoothingMode = SmoothingMode.HighSpeed;
                        g.PixelOffsetMode = PixelOffsetMode.None;

                        g.DrawRectangle(_selectionBorderPen, halfWidth, top, Width - borderWidth - ScrollBarWidth, ProgressBarHeight - halfWidth);
                    }
                }

                // 绘制滚动条
                var totalHeight = Padding.Top + Padding.Bottom + _animatingInfoBuffer.Count * ProgressBarHeight;
                var scrollBarSizePersent = Math.Min(1f * Height / totalHeight, 1);
                var offsetYPersent = (1f - scrollBarSizePersent) * ScrollOffsetY / (totalHeight - Height);

                _scrollBarRect.X = Width - ScrollBarWidth - ScrollBarPadding;
                _scrollBarRect.Y = Height * offsetYPersent;
                _scrollBarRect.Width = ScrollBarWidth - ScrollBarPadding * 2;
                _scrollBarRect.Height = Height * scrollBarSizePersent;

                GDI_Base.RenderRoundedCornerRectangle(
                    g,
                    _scrollBarRect,
                    new Padding(ScrollBarPadding),
                    99,
                    _scrollBarBrush);
            }
        }

        private bool Resort()
        {
            var result = false;

            // 已经经过消失动画的, 移除
            var removeCount = _animatingInfoBuffer.RemoveAll(a => a.ToIndex == -1);
            if (removeCount > 0)
            {
                // 记录有变更
                result = true;
            }

            // 更新ToIndex
            for (var i = 0; i < _animatingInfoBuffer.Count; ++i)
            {
                var info = _animatingInfoBuffer[i];
                info.FromIndex = info.ToIndex;

                // 如果数据已经不存在, 则动画消失
                if (!_dataDict.ContainsKey(info.ID))
                {
                    info.ToIndex = -1;

                    // 记录有变更
                    result = true;
                }

                _animatingInfoBuffer[i] = info;
            }
            foreach (var data in _dataDict)
            {
                if (!_animatingInfoBuffer.Any(e => e.ID == data.Key))
                {
                    _animatingInfoBuffer.Add(new SortAnimatingInfo
                    {
                        ID = data.Key,
                        FromIndex = -1,
                        ToIndex = 0,
                        Data = data.Value
                    });

                    // 记录有变更
                    result = true;
                }
            }

            // 这里会删除ToIndex = -1, TODO
            var tmpIndex = 0;
            _animatingInfoBuffer = [.. _animatingInfoBuffer
                .OrderByDescending(e => (e.Data.OrderValue.HasValue ? e.Data.OrderValue.Value : e.Data.ProgressBarValue))
                .Select(e =>
                {
                    if (e.ToIndex == -1) return e;

                    e.ToIndex = tmpIndex++;
                    return e;
                })];

            return result || CompareOrder();
        }
        private bool CompareOrder()
        {
            if (_animatingInfoBuffer.Count != _prevIdOrder.Count) return true;

            for (var i = 0; i < _prevIdOrder.Count; ++i)
            {
                if (_animatingInfoBuffer[i].ID != _prevIdOrder[i]) return true;
            }

            return false;
        }

        private void InitAnimation()
        {
            _animationCancellation?.Cancel();
            _animationCancellation = new CancellationTokenSource();

            Task.Run(async () =>
            {
                // TODO: 最需要优化的地方

                while (await _animationPeriodicTimer.WaitForNextTickAsync(_animationCancellation.Token).ConfigureAwait(false))
                {
                    Invalidate();
                }
            });
        }

        private void DrawProgressBar(Graphics g, ProgressBarData data, ProgressBarPrivateData privateData)
        {
            var flag = _gdiProgressBarDict.TryGetValue(data.ID, out var gdiProgressBar);
            if (!flag || gdiProgressBar == null)
            {
                gdiProgressBar = new GDI_ProgressBar();

                _gdiProgressBarDict[data.ID] = gdiProgressBar;
            }

            _drawInfo.Width = Width - ScrollBarWidth;
            _drawInfo.Height = ProgressBarHeight;
            _drawInfo.BackColor = BackColor;
            _drawInfo.ProgressBarColor = Color.FromArgb(privateData.Opacity, data.ProgressBarColor);
            _drawInfo.ProgressBarValue = data.ProgressBarValue;
            _drawInfo.ProgressBarCornerRadius = data.ProgressBarCornerRadius;
            _drawInfo.Padding = data.ProgressBarPadding;
            _drawInfo.Top = privateData.Top;

            if (privateData.OrderImage == null && privateData.OrderString == null)
            {
                _drawInfo.ContentList = data.ContentList;
            }
            else
            {
                _renderContentBuffer.Clear();

                if (privateData.OrderImage != null)
                {
                    _renderContentBuffer.Add(new RenderContent
                    {
                        Type = ContentType.Image,
                        Align = privateData.OrderImageAlign,
                        Offset = privateData.OrderImageOffset,
                        Image = privateData.OrderImage,
                        ImageRenderSize = privateData.OrderImageRenderSize
                    });
                }

                if (!string.IsNullOrEmpty(privateData.OrderString))
                {
                    _renderContentBuffer.Add(new RenderContent
                    {
                        Type = ContentType.Text,
                        Align = privateData.OrderAlign,
                        Offset = privateData.OrderOffset,
                        Text = privateData.OrderString,
                        ForeColor = privateData.OrderColor,
                        Font = privateData.OrderFont,
                    });
                }

                if (data.ContentList != null)
                {
                    _renderContentBuffer.AddRange(data.ContentList);
                }

                _drawInfo.ContentList = _renderContentBuffer;
            }



            gdiProgressBar.Draw(g, _drawInfo);
        }

        private class ProgressBarPrivateData
        {
            public float Top { get; set; }
            public byte Opacity { get; set; }
            public ContentAlign OrderAlign { get; set; } = ContentAlign.MiddleLeft;
            public ContentOffset OrderOffset { get; set; } = new ContentOffset { X = 0, Y = 0 };
            public string? OrderString { get; set; }
            public Color OrderColor { get; set; } = Color.Black;
            public Font OrderFont { get; set; } = SystemFonts.DefaultFont;
            public Image? OrderImage { get; set; } = null;
            public ContentAlign OrderImageAlign { get; set; } = ContentAlign.MiddleLeft;
            public ContentOffset OrderImageOffset { get; set; } = new ContentOffset { X = 0, Y = 0 };
            public Size OrderImageRenderSize { get; set; } = new Size(0, 0);
        }

        private struct SortAnimatingInfo
        {
            public long ID { get; set; }
            public int FromIndex { get; set; }
            public int ToIndex { get; set; }
            public ProgressBarData Data { get; set; }
        }
    }

    public class ProgressBarData
    {
        public long ID { get; set; }
        public double ProgressBarValue { get; set; }
        public double? OrderValue { get; set; }   // <-- new: null means "use ProgressBarValue"
        public Color ProgressBarColor { get; set; } = Color.FromArgb(0x56, 0x9C, 0xD6);
        public int ProgressBarCornerRadius { get; set; }
        public List<RenderContent>? ContentList { get; set; }
        public Padding ProgressBarPadding { get; set; } = new(3, 3, 3, 3);
    }
}
