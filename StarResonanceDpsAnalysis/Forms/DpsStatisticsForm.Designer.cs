// Redesigned DpsStatisticsForm.Designer.cs
// Clean layout, fixed docking, consistent style, no dead code, no overlap issues

using AntdUI;
using System.Windows.Forms;
using System.Drawing;

namespace StarResonanceDpsAnalysis.Forms
{
    partial class DpsStatisticsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(DpsStatisticsForm));

            // ---------------- HEADER ----------------
            pageHeader1 = new PageHeader()
            {
                Dock = DockStyle.Top,
                Height = 28,
                BackColor = Color.Transparent,
                ColorScheme = TAMode.Dark,
                DividerShow = true,
                DividerThickness = 2f,
                Font = new Font("SAO Welcome TT", 9F, FontStyle.Bold),
                ForeColor = Color.White,
                SubFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold),
                SubText = "当前伤害",
            };

            // LEFT HEADER CONTROLS
            label1 = new Label()
            {
                Text = "",
                Dock = DockStyle.Left,
                Width = 45,
                Font = new Font("Alimama ShuHeiTi", 9F, FontStyle.Bold),
            };
            label1.MouseDown += HeaderPanel_MouseDown;

            BattleTimeText = new Label()
            {
                Text = "00:00",
                Dock = DockStyle.Left,
                Width = 90,
                Font = new Font("Alimama ShuHeiTi", 9F, FontStyle.Bold),
            };
            BattleTimeText.MouseDown += HeaderPanel_MouseDown;

            button3 = new AntdUI.Button()
            {
                Dock = DockStyle.Left,
                Width = 26,
                Ghost = true,
                Icon = Properties.Resources.handoff_normal,
                IconHover = Properties.Resources.handoff_hover,
                IconRatio = 0.85f,
            };
            button3.Click += button3_Click;

            // RIGHT HEADER CONTROLS
            PilingModeCheckbox = new Checkbox()
            {
                Dock = DockStyle.Right,
                Width = 90,
                Text = "打桩模式",
                Visible = false,
                Font = new Font("Alimama ShuHeiTi", 9F, FontStyle.Bold),
            };
            PilingModeCheckbox.CheckedChanged += PilingModeCheckbox_CheckedChanged;

            button_ThemeSwitch = new AntdUI.Button()
            {
                Dock = DockStyle.Right,
                Width = 32,
                Ghost = true,
                IconSvg = "SunOutlined",
                ToggleIconSvg = "MoonOutlined",
                IconRatio = 0.8f,
            };
            button_ThemeSwitch.Click += button_ThemeSwitch_Click;

            button2 = new AntdUI.Button()
            {
                Dock = DockStyle.Right,
                Width = 20,
                Ghost = true,
                IconSvg = resources.GetString("button2.IconSvg"),
                IconRatio = 0.8f,
            };
            button2.Click += button2_Click_1;

            button_AlwaysOnTop = new AntdUI.Button()
            {
                Dock = DockStyle.Right,
                Width = 22,
                Ghost = true,
                IconSvg = resources.GetString("button_AlwaysOnTop.IconSvg"),
                ToggleIconSvg = resources.GetString("button_AlwaysOnTop.ToggleIconSvg"),
                IconRatio = 0.8f,
            };
            button_AlwaysOnTop.Click += button_AlwaysOnTop_Click;

            button1 = new AntdUI.Button()
            {
                Dock = DockStyle.Right,
                Width = 22,
                Ghost = true,
                IconSvg = resources.GetString("button1.IconSvg"),
                IconRatio = 0.8f,
            };
            button1.Click += button1_Click;

            button_Settings = new AntdUI.Button()
            {
                Dock = DockStyle.Right,
                Width = 26,
                Ghost = true,
                Icon = Properties.Resources.setting_hover,
                IconRatio = 1f,
            };
            button_Settings.Click += button_Settings_Click;

            label2 = new Label()
            {
                Dock = DockStyle.Right,
                Width = 120,
                Text = "",
                Font = new Font("Alimama ShuHeiTi", 9F, FontStyle.Bold),
            };
            label2.MouseDown += HeaderPanel_MouseDown;

            // Add header controls
            pageHeader1.Controls.Add(label2);
            pageHeader1.Controls.Add(PilingModeCheckbox);
            pageHeader1.Controls.Add(button2);
            pageHeader1.Controls.Add(button_ThemeSwitch);
            pageHeader1.Controls.Add(button_AlwaysOnTop);
            pageHeader1.Controls.Add(button1);
            pageHeader1.Controls.Add(button_Settings);
            pageHeader1.Controls.Add(button3);
            pageHeader1.Controls.Add(BattleTimeText);
            pageHeader1.Controls.Add(label1);

            // ---------------- TOP BUTTON BAR ----------------
            panel2 = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 55,
                BackColor = Color.Transparent,
                Shadow = 3,
                ShadowAlign = TAlignMini.Bottom,
            };

            TotalDamageButton = MakeTopButton("DPS", (Image)resources.GetObject("TotalDamageButton.Icon"), new Size(60, 35), 10);
            TotalTreatmentButton = MakeTopButton("HEALING", (Image)resources.GetObject("TotalTreatmentButton.Icon"));
            AlwaysInjuredButton = MakeTopButton("TANKING", (Image)resources.GetObject("AlwaysInjuredButton.Icon"));
            NpcTakeDamageButton = MakeTopButton("NPCTANKING", (Image)resources.GetObject("NpcTakeDamageButton.Icon"));

            SortToggleButton = new AntdUI.Button()
            {
                Width = 85,
                Height = 35,
                Radius = 4,
                Text = "Sort[Σ]",
                Font = new Font("Segoe UI Emoji", 10f),
                DefaultBack = Color.FromArgb(245, 245, 245),
                BackColor = Color.FromArgb(60, 150, 250),
                Location = new Point(350, 10),
                Ghost = true,
            };
            SortToggleButton.Click += SortToggleButton_Click;

            panel2.Controls.Add(TotalDamageButton);
            panel2.Controls.Add(TotalTreatmentButton);
            panel2.Controls.Add(AlwaysInjuredButton);
            panel2.Controls.Add(NpcTakeDamageButton);
            panel2.Controls.Add(SortToggleButton);

            // ---------------- MAIN LIST ----------------
            sortedProgressBarList1 = new Control.SortedProgressBarList()
            {
                Dock = DockStyle.Fill,
                AnimationQuality = Effects.Enum.Quality.Medium,
                BackColor = Color.WhiteSmoke,
                ScrollBarWidth = 8,
                SeletedItemColor = Color.FromArgb(86, 156, 214),
            };

            // ---------------- TIMERS ----------------
            timer_RefreshRunningTime = new Timer(components) { Interval = 10, Enabled = true };
            timer_RefreshRunningTime.Tick += timer_RefreshRunningTime_Tick;

            timer1 = new Timer(components);
            timer1.Tick += timer1_Tick;

            tooltip = new TooltipComponent()
            {
                ArrowAlign = TAlign.TL,
                Font = new Font("HarmonyOS Sans SC", 7.8f),
            };

            // ---------------- FORM ----------------
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            BorderWidth = 0;
            ClientSize = new Size(530, 440);

            Controls.Add(sortedProgressBarList1);
            Controls.Add(panel2);
            Controls.Add(pageHeader1);

            Font = new Font("HarmonyOS Sans SC", 8F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DpsStatisticsForm";
            Radius = 3;
            Text = "别查我DPS";
            StartPosition = FormStartPosition.CenterScreen;

            Load += DpsStatistics_Load;
            Shown += DpsStatisticsForm_Shown;
            ForeColorChanged += DpsStatisticsForm_ForeColorChanged;
            FormClosing += DpsStatisticsForm_FormClosing;
        }
        #endregion

        // Helper to create top buttons cleanly
        private AntdUI.Button MakeTopButton(string text, Image icon, Size? size = null, int x = 0)
        {
            var btn = new AntdUI.Button()
            {
                Text = text,
                Icon = icon,
                IconRatio = 0.75f,
                Radius = 4,
                DefaultBack = Color.FromArgb(247, 247, 247),
                DefaultBorderColor = Color.Wheat,
                Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold),
                Size = size ?? new Size(80, 35),
                Location = new Point(x, 10),
            };
            btn.Click += DamageType_Click;
            return btn;
        }
    }
}
