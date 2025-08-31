using AntdUI;

namespace StarResonanceDpsAnalysis.Forms
{
    partial class DpsStatisticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DpsStatisticsForm));
            pageHeader1 = new PageHeader();
            PilingModeCheckbox = new Checkbox();
            button_ThemeSwitch = new AntdUI.Button();
            button2 = new AntdUI.Button();
            button3 = new AntdUI.Button();
            button_AlwaysOnTop = new AntdUI.Button();
            button1 = new AntdUI.Button();
            button_Settings = new AntdUI.Button();
            panel1 = new AntdUI.Panel();
            label2 = new AntdUI.Label();
            BattleTimeText = new AntdUI.Label();
            label1 = new AntdUI.Label();
            timer_RefreshRunningTime = new System.Windows.Forms.Timer(components);
            timer1 = new System.Windows.Forms.Timer(components);
            sortedProgressBarList1 = new StarResonanceDpsAnalysis.Control.SortedProgressBarList();
            panel2 = new AntdUI.Panel();
            NpcTakeDamageButton = new AntdUI.Button();
            AlwaysInjuredButton = new AntdUI.Button();
            TotalTreatmentButton = new AntdUI.Button();
            TotalDamageButton = new AntdUI.Button();
            tooltip = new TooltipComponent();
            pageHeader1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pageHeader1
            // 
            pageHeader1.BackColor = Color.FromArgb(178, 178, 178);
            pageHeader1.ColorScheme = TAMode.Dark;
            pageHeader1.Controls.Add(PilingModeCheckbox);
            pageHeader1.Controls.Add(button_ThemeSwitch);
            pageHeader1.Controls.Add(button2);
            pageHeader1.Controls.Add(button3);
            pageHeader1.Controls.Add(button_AlwaysOnTop);
            pageHeader1.Controls.Add(button1);
            pageHeader1.Controls.Add(button_Settings);
            pageHeader1.DividerShow = true;
            pageHeader1.DividerThickness = 2F;
            pageHeader1.Dock = DockStyle.Top;
            pageHeader1.Font = new Font("SAO Welcome TT", 8.999999F, FontStyle.Bold);
            pageHeader1.ForeColor = Color.White;
            pageHeader1.Location = new Point(0, 0);
            pageHeader1.Margin = new Padding(2);
            pageHeader1.MaximizeBox = false;
            pageHeader1.MinimizeBox = false;
            pageHeader1.Mode = TAMode.Dark;
            pageHeader1.Name = "pageHeader1";
            pageHeader1.Size = new Size(527, 25);
            pageHeader1.SubFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            pageHeader1.SubGap = 0;
            pageHeader1.SubText = "当前伤害";
            pageHeader1.TabIndex = 16;
            pageHeader1.Text = "DPS Damage Statistics Table  ";
            // 
            // PilingModeCheckbox
            // 
            PilingModeCheckbox.AutoSizeMode = TAutoSize.Width;
            PilingModeCheckbox.BackColor = Color.Transparent;
            PilingModeCheckbox.Dock = DockStyle.Right;
            PilingModeCheckbox.Font = new Font("Alimama ShuHeiTi", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            PilingModeCheckbox.ForeColor = Color.White;
            PilingModeCheckbox.Location = new Point(305, 0);
            PilingModeCheckbox.Name = "PilingModeCheckbox";
            PilingModeCheckbox.Size = new Size(100, 25);
            PilingModeCheckbox.TabIndex = 17;
            PilingModeCheckbox.Text = "打桩模式";
            PilingModeCheckbox.TextAlign = ContentAlignment.MiddleCenter;
            PilingModeCheckbox.Visible = false;
            PilingModeCheckbox.CheckedChanged += PilingModeCheckbox_CheckedChanged;
            // 
            // button_ThemeSwitch
            // 
            button_ThemeSwitch.ColorScheme = TAMode.Dark;
            button_ThemeSwitch.Dock = DockStyle.Right;
            button_ThemeSwitch.Ghost = true;
            button_ThemeSwitch.IconRatio = 0.8F;
            button_ThemeSwitch.IconSvg = "SunOutlined";
            button_ThemeSwitch.Location = new Point(405, 0);
            button_ThemeSwitch.Margin = new Padding(2);
            button_ThemeSwitch.Name = "button_ThemeSwitch";
            button_ThemeSwitch.Size = new Size(33, 25);
            button_ThemeSwitch.TabIndex = 21;
            button_ThemeSwitch.ToggleIconSvg = "MoonOutlined";
            button_ThemeSwitch.Click += button_ThemeSwitch_Click;
            button_ThemeSwitch.MouseEnter += button_ThemeSwitch_MouseEnter;
            // 
            // button2
            // 
            button2.ColorScheme = TAMode.Dark;
            button2.Dock = DockStyle.Right;
            button2.Ghost = true;
            button2.IconRatio = 0.8F;
            button2.IconSvg = resources.GetString("button2.IconSvg");
            button2.Location = new Point(438, 0);
            button2.Name = "button2";
            button2.Size = new Size(20, 25);
            button2.TabIndex = 20;
            button2.ToggleIconSvg = "";
            button2.Click += button2_Click_1;
            button2.MouseEnter += button2_MouseEnter;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Left;
            button3.Ghost = true;
            button3.Icon = Properties.Resources.handoff_normal;
            button3.IconHover = Properties.Resources.handoff_hover;
            button3.IconRatio = 0.8F;
            button3.Location = new Point(227, 0);
            button3.Name = "button3";
            button3.Size = new Size(23, 25);
            button3.TabIndex = 19;
            button3.Click += button3_Click;
            button3.MouseEnter += button3_MouseEnter;
            // 
            // button_AlwaysOnTop
            // 
            button_AlwaysOnTop.ColorScheme = TAMode.Dark;
            button_AlwaysOnTop.Dock = DockStyle.Right;
            button_AlwaysOnTop.Ghost = true;
            button_AlwaysOnTop.IconRatio = 0.8F;
            button_AlwaysOnTop.IconSvg = resources.GetString("button_AlwaysOnTop.IconSvg");
            button_AlwaysOnTop.Location = new Point(458, 0);
            button_AlwaysOnTop.Name = "button_AlwaysOnTop";
            button_AlwaysOnTop.Size = new Size(22, 25);
            button_AlwaysOnTop.TabIndex = 5;
            button_AlwaysOnTop.ToggleIconSvg = resources.GetString("button_AlwaysOnTop.ToggleIconSvg");
            button_AlwaysOnTop.Click += button_AlwaysOnTop_Click;
            button_AlwaysOnTop.MouseEnter += button_AlwaysOnTop_MouseEnter;
            // 
            // button1
            // 
            button1.ColorScheme = TAMode.Dark;
            button1.Dock = DockStyle.Right;
            button1.Ghost = true;
            button1.IconRatio = 0.8F;
            button1.IconSvg = resources.GetString("button1.IconSvg");
            button1.Location = new Point(480, 0);
            button1.Name = "button1";
            button1.Size = new Size(20, 25);
            button1.TabIndex = 4;
            button1.ToggleIconSvg = "";
            button1.Click += button1_Click;
            button1.MouseEnter += button1_MouseEnter;
            // 
            // button_Settings
            // 
            button_Settings.BackActive = Color.Transparent;
            button_Settings.BackColor = Color.Transparent;
            button_Settings.ColorScheme = TAMode.Dark;
            button_Settings.DefaultBack = Color.Transparent;
            button_Settings.Dock = DockStyle.Right;
            button_Settings.Ghost = true;
            button_Settings.Icon = Properties.Resources.setting_hover;
            button_Settings.IconRatio = 1F;
            button_Settings.IconSvg = "";
            button_Settings.Location = new Point(500, 0);
            button_Settings.Name = "button_Settings";
            button_Settings.Size = new Size(27, 25);
            button_Settings.TabIndex = 3;
            button_Settings.ToggleIconSvg = "";
            button_Settings.Click += button_Settings_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(BattleTimeText);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 408);
            panel1.Name = "panel1";
            panel1.Radius = 3;
            panel1.Shadow = 3;
            panel1.ShadowAlign = TAlignMini.Top;
            panel1.Size = new Size(527, 34);
            panel1.TabIndex = 17;
            panel1.Text = "panel1";
            // 
            // label2
            // 
            label2.Dock = DockStyle.Right;
            label2.Font = new Font("Alimama ShuHeiTi", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label2.Location = new Point(394, 3);
            label2.Name = "label2";
            label2.Size = new Size(133, 31);
            label2.TabIndex = 20;
            label2.Text = "";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // BattleTimeText
            // 
            BattleTimeText.Dock = DockStyle.Left;
            BattleTimeText.Font = new Font("Alimama ShuHeiTi", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            BattleTimeText.Location = new Point(38, 3);
            BattleTimeText.Margin = new Padding(2);
            BattleTimeText.Name = "BattleTimeText";
            BattleTimeText.Size = new Size(98, 31);
            BattleTimeText.TabIndex = 18;
            BattleTimeText.Text = "00:00";
            // 
            // label1
            // 
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Alimama ShuHeiTi", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(0, 3);
            label1.Margin = new Padding(2);
            label1.Name = "label1";
            label1.Size = new Size(38, 31);
            label1.TabIndex = 19;
            label1.Text = "";
            // 
            // timer_RefreshRunningTime
            // 
            timer_RefreshRunningTime.Enabled = true;
            timer_RefreshRunningTime.Interval = 10;
            timer_RefreshRunningTime.Tick += timer_RefreshRunningTime_Tick;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // sortedProgressBarList1
            // 
            sortedProgressBarList1.AnimationQuality = Effects.Enum.Quality.Medium;
            sortedProgressBarList1.BackColor = Color.WhiteSmoke;
            sortedProgressBarList1.Dock = DockStyle.Fill;
            sortedProgressBarList1.Location = new Point(0, 80);
            sortedProgressBarList1.Margin = new Padding(8, 6, 8, 6);
            sortedProgressBarList1.Name = "sortedProgressBarList1";
            sortedProgressBarList1.OrderColor = Color.Black;
            sortedProgressBarList1.OrderFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            sortedProgressBarList1.OrderImageAlign = Control.GDI.RenderContent.ContentAlign.MiddleLeft;
            sortedProgressBarList1.OrderImageRenderSize = new Size(0, 0);
            sortedProgressBarList1.OrderImages = null;
            sortedProgressBarList1.ScrollBarWidth = 8;
            sortedProgressBarList1.ScrollOffsetY = 0F;
            sortedProgressBarList1.SeletedItemColor = Color.FromArgb(86, 156, 214);
            sortedProgressBarList1.Size = new Size(527, 328);
            sortedProgressBarList1.TabIndex = 18;
            sortedProgressBarList1.Load += sortedProgressBarList1_Load;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(NpcTakeDamageButton);
            panel2.Controls.Add(AlwaysInjuredButton);
            panel2.Controls.Add(TotalTreatmentButton);
            panel2.Controls.Add(TotalDamageButton);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 25);
            panel2.Name = "panel2";
            panel2.Shadow = 3;
            panel2.ShadowAlign = TAlignMini.Bottom;
            panel2.Size = new Size(527, 55);
            panel2.TabIndex = 21;
            panel2.Text = "panel2";
            // 
            // NpcTakeDamageButton
            // 
            NpcTakeDamageButton.Anchor = AnchorStyles.Top;
            NpcTakeDamageButton.DefaultBack = Color.FromArgb(247, 247, 247);
            NpcTakeDamageButton.DefaultBorderColor = Color.Wheat;
            NpcTakeDamageButton.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            NpcTakeDamageButton.Icon = (Image)resources.GetObject("NpcTakeDamageButton.Icon");
            NpcTakeDamageButton.IconRatio = 0.8F;
            NpcTakeDamageButton.Location = new Point(372, 8);
            NpcTakeDamageButton.Name = "NpcTakeDamageButton";
            NpcTakeDamageButton.Radius = 3;
            NpcTakeDamageButton.Size = new Size(112, 38);
            NpcTakeDamageButton.TabIndex = 4;
            NpcTakeDamageButton.Text = "承伤";
            NpcTakeDamageButton.Click += DamageType_Click;
            // 
            // AlwaysInjuredButton
            // 
            AlwaysInjuredButton.Anchor = AnchorStyles.Top;
            AlwaysInjuredButton.DefaultBack = Color.FromArgb(247, 247, 247);
            AlwaysInjuredButton.DefaultBorderColor = Color.Wheat;
            AlwaysInjuredButton.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            AlwaysInjuredButton.Icon = (Image)resources.GetObject("AlwaysInjuredButton.Icon");
            AlwaysInjuredButton.Location = new Point(262, 8);
            AlwaysInjuredButton.Margin = new Padding(4);
            AlwaysInjuredButton.Name = "AlwaysInjuredButton";
            AlwaysInjuredButton.Radius = 3;
            AlwaysInjuredButton.Size = new Size(112, 38);
            AlwaysInjuredButton.TabIndex = 3;
            AlwaysInjuredButton.Text = "总承伤";
            AlwaysInjuredButton.Click += DamageType_Click;
            // 
            // TotalTreatmentButton
            // 
            TotalTreatmentButton.Anchor = AnchorStyles.Top;
            TotalTreatmentButton.DefaultBack = Color.FromArgb(247, 247, 247);
            TotalTreatmentButton.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            TotalTreatmentButton.Icon = (Image)resources.GetObject("TotalTreatmentButton.Icon");
            TotalTreatmentButton.Location = new Point(148, 8);
            TotalTreatmentButton.Margin = new Padding(4);
            TotalTreatmentButton.Name = "TotalTreatmentButton";
            TotalTreatmentButton.Radius = 3;
            TotalTreatmentButton.Size = new Size(112, 38);
            TotalTreatmentButton.TabIndex = 2;
            TotalTreatmentButton.Text = "总治疗";
            TotalTreatmentButton.Click += DamageType_Click;
            // 
            // TotalDamageButton
            // 
            TotalDamageButton.Anchor = AnchorStyles.Top;
            TotalDamageButton.DefaultBack = Color.FromArgb(223, 223, 223);
            TotalDamageButton.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            TotalDamageButton.Icon = (Image)resources.GetObject("TotalDamageButton.Icon");
            TotalDamageButton.Location = new Point(38, 8);
            TotalDamageButton.Name = "TotalDamageButton";
            TotalDamageButton.Radius = 3;
            TotalDamageButton.Size = new Size(112, 38);
            TotalDamageButton.TabIndex = 1;
            TotalDamageButton.Text = "总伤害";
            TotalDamageButton.Click += DamageType_Click;
            // 
            // tooltip
            // 
            tooltip.ArrowAlign = TAlign.TL;
            tooltip.Font = new Font("HarmonyOS Sans SC", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            // 
            // DpsStatisticsForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            BorderWidth = 0;
            ClientSize = new Size(527, 442);
            Controls.Add(sortedProgressBarList1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pageHeader1);
            Font = new Font("HarmonyOS Sans SC", 8F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "DpsStatisticsForm";
            Radius = 3;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "别查我DPS";
            FormClosing += DpsStatisticsForm_FormClosing;
            Load += DpsStatistics_Load;
            Shown += DpsStatisticsForm_Shown;
            ForeColorChanged += DpsStatisticsForm_ForeColorChanged;
            pageHeader1.ResumeLayout(false);
            pageHeader1.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.PageHeader pageHeader1;
        private AntdUI.Button button_Settings;
        private AntdUI.Button button1;
        private AntdUI.Button button_AlwaysOnTop;
        private AntdUI.Button button3;
        private AntdUI.Button button2;
        private AntdUI.Checkbox PilingModeCheckbox;
        private AntdUI.Panel panel1;
        private AntdUI.Label BattleTimeText;
        private System.Windows.Forms.Timer timer_RefreshRunningTime;
        private System.Windows.Forms.Timer timer1;
        private Control.SortedProgressBarList sortedProgressBarList1;
        private AntdUI.Label label1;
        private AntdUI.Label label2;
        private AntdUI.Panel panel2;
        private AntdUI.Button TotalDamageButton;
        private AntdUI.Button TotalTreatmentButton;
        private AntdUI.Button AlwaysInjuredButton;
        private AntdUI.Button NpcTakeDamageButton;
        private AntdUI.Button button_ThemeSwitch;
        private AntdUI.TooltipComponent tooltip;
    }
}