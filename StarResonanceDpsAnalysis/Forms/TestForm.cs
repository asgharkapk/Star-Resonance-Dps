using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using StarResonanceDpsAnalysis.Control;
using StarResonanceDpsAnalysis.Control.GDI;
using StarResonanceDpsAnalysis.Effects;
using StarResonanceDpsAnalysis.Effects.Enum;
using StarResonanceDpsAnalysis.Extends;
using StarResonanceDpsAnalysis.Properties;

namespace StarResonanceDpsAnalysis.Forms
{
    public partial class TestForm : Form
    {
        int id = 0;
        List<ProgressBarData> data = [];
        List<byte[]> images =
        [
            Resources.冰魔导师,
            Resources.巨刃守护者,
            Resources.森语者,
            Resources.灵魂乐手,
            Resources.神射手,
            Resources.雷影剑士,
            Resources.青岚骑士
        ];
        Random rd = new();

        public TestForm()
        {
            InitializeComponent();

            sortedProgressBarList1.AnimationDuration = 1000;
            sortedProgressBarList1.AnimationQuality = Quality.High;
            sortedProgressBarList1.ProgressBarHeight = 50;
            sortedProgressBarList1.OrderOffset = new RenderContent.ContentOffset { X = 45, Y = 0 };
            sortedProgressBarList1.OrderCallback = (i) => $"{i:d2}";
            sortedProgressBarList1.OrderColor = Color.Fuchsia;
            sortedProgressBarList1.OrderFont = new Font("平方韶华体", 24f, FontStyle.Bold, GraphicsUnit.Pixel);
            sortedProgressBarList1.OrderImages = null;
        //    [
        //        new Bitmap(new MemoryStream(Resources.皇冠)),
        //        new Bitmap(new MemoryStream(Resources.皇冠白))
         //   ];
            sortedProgressBarList1.OrderImageOffset = new RenderContent.ContentOffset { X = 0, Y = 0 };
            //sortedProgressBarList1.OrderImageRenderSize = new Size(32, 32);

            numericUpDown1.Minimum = -1;
            numericUpDown2.Minimum = -1;

            button1.Click += (s, e) =>
            {
                if (numericUpDown1.Value > data.Count) return;

                if (numericUpDown1.Value <= 0)
                {
                    ++id;

                    data.Add(new ProgressBarData
                    {
                        ID = id,
                        ProgressBarCornerRadius = 5,
                        ProgressBarColor = Color.FromArgb(0xF5, 0xEB, 0xAE),
                        ProgressBarValue = (double)numericUpDown2.Value / 100d,
                        ContentList =
                        [
                            new RenderContent
                            {
                                Type = RenderContent.ContentType.Image,
                                Align = RenderContent.ContentAlign.MiddleLeft,
                                Offset = new RenderContent.ContentOffset { X = 48, Y = 0 },
                                Image = new Bitmap(new MemoryStream(images[rd.Next(images.Count)])),
                                ImageRenderSize = new Size(32, 32)
                            },
                            new RenderContent
                            {
                                Type = RenderContent.ContentType.Text,
                                Align = RenderContent.ContentAlign.MiddleLeft,
                                Offset = new RenderContent.ContentOffset { X = 90, Y = 0 },
                                Text = $"{RandomName()}({id:d5})",
                                ForeColor = Color.Black,
                                Font = new Font("Microsoft YaHei UI", 24f, FontStyle.Regular, GraphicsUnit.Pixel),
                            },
                            new RenderContent
                            {
                                Type = RenderContent.ContentType.Text,
                                Align = RenderContent.ContentAlign.MiddleRight,
                                Offset = new RenderContent.ContentOffset { X = -70, Y = 4 },
                                Text = $"3.0万(1.4w)",
                                ForeColor = Color.Black,
                                Font = new Font("Microsoft YaHei UI", 16f, FontStyle.Regular, GraphicsUnit.Pixel),
                            },
                            new RenderContent
                            {
                                Type = RenderContent.ContentType.Text,
                                Align = RenderContent.ContentAlign.MiddleRight,
                                Offset = new RenderContent.ContentOffset { X = 0, Y = 0 },
                                Text = $"{numericUpDown2.Value:f2}%",
                                ForeColor = Color.Black,
                                Font = new Font("Segoe UI Emoji", 24f, FontStyle.Regular, GraphicsUnit.Pixel), // supports emoji
                                //BackColor = Color.FromArgb(128, 128, 128, 128) // transparent gray (A=128, R=128, G=128, B=128)
                            },
                        ],
                    });
                }
                else
                {
                    var index = (int)numericUpDown1.Value - 1;
                    data[index].ProgressBarValue = (double)numericUpDown2.Value / 100d;
                    data[index].ContentList![3].Text = $"{numericUpDown2.Value:f2}%";
                }

                sortedProgressBarList1.Data = data;
            };

            button2.Click += (s, e) =>
            {
                if (numericUpDown1.Value == numericUpDown2.Value && numericUpDown2.Value == -1)
                {
                    data.Clear();
                    sortedProgressBarList1.Data = data;
                    return;
                }

                if (numericUpDown1.Value < 0) return;

                var index = data.FindIndex(e => e.ID == (int)numericUpDown1.Value);
                if (index < 0) return;

                data.RemoveAt(index);

                sortedProgressBarList1.Data = data;
            };

            sortedProgressBarList1.SelectionChanged += (s, i, d) =>
            {
                if (i < 0 || d == null)
                {
                    Console.WriteLine("Nothing Clicked.");
                    return;
                }

                Console.WriteLine($"ProgressBar Clicked: ID={d.ID}, Index={i}");
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void TestForm_Load(object sender, EventArgs e)
        {

        }

        private string RandomName()
        {
            var sb = new StringBuilder();

            // 随机长度 2~10
            int len = rd.Next(2, 11);

            for (int i = 0; i < len; ++i)
            {
                int code = rd.Next(0x4E00, 0x9FFF + 1);
                sb.Append((char)code);
            }

            return sb.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            AAA();
        }
        public static double GetScaling()
        {
            Screen screen = Screen.PrimaryScreen;
            Rectangle workingArea = screen.WorkingArea;
            Rectangle bounds = screen.Bounds;
            double scale = (double)workingArea.Width / bounds.Width;

            return scale;
        }

        public static void AAA()
        {
            double scale = GetScaling();
            Console.WriteLine(scale.ToString());
        }
    }
}
