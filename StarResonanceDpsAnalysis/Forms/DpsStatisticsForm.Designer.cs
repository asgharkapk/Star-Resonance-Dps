using AntdUI;

namespace StarResonanceDpsAnalysis.Forms
{
    partial class DpsStatisticsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DpsStatisticsForm));

            // ===== Page Header =====
            pageHeader1 = new PageHeader
            {
                BackColor = Color.Transparent,
                ColorScheme = TAMode.Dark,
                DividerShow = true,
                DividerThickness = 2F,
                Dock = DockStyle.Top,
                Font = new Font("SAO Welcome TT", 9F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(0, 0),
                MaximizeBox = false,
                MinimizeBox = false,
                Mode = TAMode.Dark,
                Name = "pageHeader1",
                Size = new Size(527, 25),
                SubFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold),
                SubGap = 0,
                SubText = "当前伤害",
                TabIndex = 16,
                Text = " "
            };

            // Left side labels & buttons
            label1 = new AntdUI.Label { Dock = DockStyle.Left, Font = new Font("Alimama ShuHeiTi", 9F, FontStyle.Bold), Size = new Size(50, 36), MouseDown += HeaderPanel_MouseDown };
            BattleTimeText = new AntdUI.Label { Dock = DockStyle.Left, Font = new Font("Alimama ShuHeiTi", 9F, FontStyle.Bold), Size = new Size(98, 31), Text = "00:00", MouseDown += HeaderPanel_MouseDown };
            button3 = new AntdUI.Button { Dock = DockStyle.Left, Ghost = true, Icon = Properties.Resources.handoff_normal, IconHover = Properties.Resources.handoff_hover, IconRatio = 0.8F, Size = new Size(23, 25) };
            button3.Click += button3_Click;
            button3.MouseEnter += button3_MouseEnter;

            // Right side controls
            PilingModeCheckbox = new Checkbox
            {
                AutoSizeMode = TAutoSize.Width,
                BackColor = Color.Transparent,
                Dock = DockStyle.Right,
                Font = new Font("Alimama ShuHeiTi", 9F, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(100, 25),
                Text = "打桩模式",
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false
            };
            PilingModeCheckbox.CheckedChanged += PilingModeCheckbox_CheckedChanged;

            button_Settings = new Button
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Right,
                Ghost = true,
                Icon = Properties.Resources.setting_hover,
                IconRatio = 1F,
                Size = new Size(27, 25)
            };
            button_Settings.Click += button_Settings_Click;

            button1 = new Button { Dock = DockStyle.Right, Ghost = true, IconRatio = 0.8F, Size = new Size(20, 25) };
            button1.Click += button1_Click;
            button1.MouseEnter += button1_MouseEnter;

            button_AlwaysOnTop = new Button { Dock = DockStyle.Right, Ghost = true, IconRatio = 0.8F, Size = new Size(22, 25) };
            button_AlwaysOnTop.Click += button_AlwaysOnTop_Click;
            button_AlwaysOnTop.MouseEnter += button_AlwaysOnTop_MouseEnter;

            button2 = new Button { Dock = DockStyle.Right, Ghost = true, IconRatio = 0.8F, Size = new Size(20, 25), IconSvg = resources.GetString("button2.IconSvg") };
            button2.Click += button2_Click_1;
            button2.MouseEnter += button2_MouseEnter;

            button_ThemeSwitch = new Button { Dock = DockStyle.Right, Ghost = true, IconRatio = 0.8F, IconSvg = "SunOutlined", ToggleIconSvg = "MoonOutlined", Size = new Size(33, 25) };
            button_ThemeSwitch.Click += button_ThemeSwitch_Click;
            button_ThemeSwitch.MouseEnter += button_ThemeSwitch_MouseEnter;

            label2 = new Label { Dock = DockStyle.Right, Font = new Font("Alimama ShuHeiTi", 9F, FontStyle.Bold), Size = new Size(133, 31) };
            label2.MouseDown += HeaderPanel_MouseDown;

            pageHeader1.Controls.AddRange(new Control[] { BattleTimeText, label1, button3, label2, PilingModeCheckbox, button2, button_ThemeSwitch, button_AlwaysOnTop, button1, button_Settings });

            // ===== Bottom Panel =====
            panel1 = new Panel
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Bottom,
                Radius = 3,
                Shadow = 3,
                ShadowAlign = TAlignMini.Top,
                Size = new Size(527, 34)
            };

            // ===== Buttons Panel =====
            panel2 = new Panel
            {
                Dock = DockStyle.Top,
                BackColor = Color.Transparent,
                Shadow = 3,
                ShadowAlign = TAlignMini.Bottom,
                Size = new Size(527, 55)
            };

            // Damage type buttons
            TotalDamageButton = CreateButton("DPS", 60, 35, DamageType_Click, (Image)resources.GetObject("TotalDamageButton.Icon"));
            TotalTreatmentButton = CreateButton("HEALING", 80, 35, DamageType_Click, (Image)resources.GetObject("TotalTreatmentButton.Icon"));
            AlwaysInjuredButton = CreateButton("TANKING", 80, 35, DamageType_Click, (Image)resources.GetObject("AlwaysInjuredButton.Icon"));
            NpcTakeDamageButton = CreateButton("NPCTANKING", 80, 35, DamageType_Click, (Image)resources.GetObject("NpcTakeDamageButton.Icon"));

            SortToggleButton = new Button
            {
                Text = "Sort[Σ]",
                Size = new Size(80, 32),
                Font = new Font("Segoe UI Emoji", 10f, FontStyle.Regular, GraphicsUnit.Pixel),
                Radius = 3,
                Ghost = true,
                BackColor = Color.FromArgb(50, 150, 250)
            };
            SortToggleButton.Click += SortToggleButton_Click;

            panel2.Controls.AddRange(new Control[] { TotalDamageButton, TotalTreatmentButton, AlwaysInjuredButton, NpcTakeDamageButton, SortToggleButton });

            // ===== Sorted Progress Bar =====
            sortedProgressBarList1 = new Control.SortedProgressBarList
            {
                AnimationQuality = Effects.Enum.Quality.Medium,
                BackColor = Color.WhiteSmoke,
                Dock = DockStyle.Fill,
                OrderColor = Color.Black,
                OrderFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold),
                ScrollBarWidth = 8
            };
            sortedProgressBarList1.Load += sortedProgressBarList1_Load;

            // ===== Timers =====
            timer_RefreshRunningTime = new System.Windows.Forms.Timer(components) { Enabled = true, Interval = 10 };
            timer_RefreshRunningTime.Tick += timer_RefreshRunningTime_Tick;

            timer1 = new System.Windows.Forms.Timer(components);
            timer1.Tick += timer1_Tick;

            // ===== Form =====
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            BorderWidth = 0;
            ClientSize = new Size(527, 442);
            Controls.Add(sortedProgressBarList1);
            Controls.Add(panel2);
            Controls.Add(pageHeader1);
            Font = new Font("HarmonyOS Sans SC", 8F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DpsStatisticsForm";
            Radius = 3;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "别查我DPS";
            FormClosing += DpsStatisticsForm_FormClosing;
            Load += DpsStatistics_Load;
            Shown += DpsStatisticsForm_Shown;
            ForeColorChanged += DpsStatisticsForm_ForeColorChanged;
        }

        private Button CreateButton(string text, int width, int height, EventHandler clickHandler, Image icon = null)
        {
            var btn = new Button
            {
                Text = text,
                Size = new Size(width, height),
                Radius = 3,
                Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold),
                Icon = icon,
                IconRatio = 0.7F,
                Ghost = true
            };
            btn.Click += clickHandler;
            return btn;
        }

        #endregion

        private PageHeader pageHeader1;
        private Button button_Settings, button1, button_AlwaysOnTop, button3, button2, button_ThemeSwitch, SortToggleButton;
        private Checkbox PilingModeCheckbox;
        private Panel panel1, panel2;
        private Label BattleTimeText, label1, label2;
        private System.Windows.Forms.Timer timer_RefreshRunningTime, timer1;
        private Control.SortedProgressBarList sortedProgressBarList1;
        private Button TotalDamageButton, TotalTreatmentButton, AlwaysInjuredButton, NpcTakeDamageButton;
    }
}
