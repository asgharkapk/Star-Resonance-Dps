using AntdUI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StarResonanceDpsAnalysis.Plugin
{
    public class FormGui
    {

        public static void SetDefaultGUI(BorderlessForm BorderlessForm, bool AutoHandDpi = false)
        {
            BorderlessForm.AutoHandDpi = AutoHandDpi; //自动处理DPi

            // Compact Theme Settings
            BorderlessForm.Radius = 3;         // was 6 → tighter corners
            BorderlessForm.Shadow = 4;         // was 10 → thinner shadow
            BorderlessForm.BorderWidth = 0; //边框宽度
            BorderlessForm.UseDwm = false; //关闭系统窗口预览
            //BorderlessForm.Opacity = AppConfig.Transparency / 100;

            //BorderlessForm.BorderColor = Color.FromArgb(246, 248, 250);

        }

        /// <summary>
        /// 设置明暗颜色
        /// </summary>
        /// <param name="window">父窗口</param>
        /// <param name="isLight">是否亮色</param>
        public static void SetColorMode(AntdUI.BorderlessForm window, bool isLight)
        {
            if (window == null || window.IsDisposed) return;
            if (isLight)
            {
                //亮色
                Config.IsLight = true;
                window.BackColor = Color.White;
                window.ForeColor = Color.Black;

            }
            else
            {
                Config.IsDark = true;// 设置为深色模式
                window.BackColor = Color.FromArgb(31, 31, 31);
                window.ForeColor = Color.White;
            }
           

        }

        /// <summary>
        /// 弹窗提示
        /// </summary>
        /// <param name="from"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="type"></param>
        public static void Modal(Form from, string title, string content, string okText = "确定", string cancelText = "取消", TType type = TType.Info)
        {
            AntdUI.Modal.open(new Modal.Config(from, title, content)
            {
                CloseIcon = true,
                Icon = type,
                CancelText = cancelText,
                OkText = okText,
                MaskClosable = false,
            });

        }
    }
}
