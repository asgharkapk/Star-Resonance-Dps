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
            SortToggleButton = new AntdUI.Button();
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

            // -----------------------------
            // Form (base)
            // -----------------------------
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(540, 468);                       // slightly larger to avoid clipping
            Font = new Font("HarmonyOS Sans SC", 8F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "DpsStatisticsForm";
            Radius = 6;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "别查我DPS";
            BackColor = Color.FromArgb(24, 24, 26);                // dark base
            ForeColor = Color.White;

            // -----------------------------
            // PageHeader (glassy top bar)
            // -----------------------------
            pageHeader1.BackColor = Color.FromArgb(160, 18, 18, 20); // semi-transparent dark (alpha, r,g,b)
            pageHeader1.ColorScheme = TAMode.Dark;
            pageHeader1.Dock = DockStyle.Top;
            pageHeader1.Size = new Size(ClientSize.Width, 36);
            pageHeader1.Padding = new Padding(8, 4, 8, 4);
            pageHeader1.DividerShow = true;
            pageHeader1.DividerThickness = 1.5F;
            pageHeader1.Font = new Font("SAO Welcome TT", 9F, FontStyle.Bold);
            pageHeader1.ForeColor = Color.White;
            pageHeader1.Mode = TAMode.Dark;
            pageHeader1.Name = "pageHeader1";
            pageHeader1.SubFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            pageHeader1.SubGap = 0;
            pageHeader1.SubText = "当前伤害";
            pageHeader1.TabIndex = 16;
            pageHeader1.Text = " ";

            // LEFT controls (dock left so they stay visible)
            BattleTimeText.Dock = DockStyle.Left;
            BattleTimeText.Font = new Font("Alimama ShuHeiTi", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            BattleTimeText.Size = new Size(88, 28);
            BattleTimeText.Text = "00:00";
            BattleTimeText.ForeColor = Color.White;
            BattleTimeText.MouseDown += HeaderPanel_MouseDown;

            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Alimama ShuHeiTi", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Size = new Size(60, 28);
            label1.Text = "";
            label1.ForeColor = Color.White;
            label1.MouseDown += HeaderPanel_MouseDown;

            button3.Dock = DockStyle.Left;
            button3.Ghost = true;
            button3.Icon = Properties.Resources.handoff_normal;
            button3.IconHover = Properties.Resources.handoff_hover;
            button3.IconRatio = 0.8F;
            button3.Size = new Size(28, 28);
            button3.Margin = new Padding(6, 0, 0, 0);
            button3.TabIndex = 19;
            button3.Click += button3_Click;
            button3.MouseEnter += button3_MouseEnter;

            // RIGHT controls (dock right in order)
            button_Settings.Dock = DockStyle.Right;
            button_Settings.Ghost = true;
            button_Settings.Icon = Properties.Resources.setting_hover;
            button_Settings.IconRatio = 1F;
            button_Settings.Size = new Size(30, 28);
            button_Settings.Click += button_Settings_Click;
            button_Settings.Visible = true;

            button1.Dock = DockStyle.Right;
            button1.Ghost = true;
            button1.Size = new Size(28, 28);
            button1.IconRatio = 0.8F;
            button1.Click += button1_Click;
            button1.MouseEnter += button1_MouseEnter;
            button1.Visible = true;

            button_AlwaysOnTop.Dock = DockStyle.Right;
            button_AlwaysOnTop.Ghost = true;
            button_AlwaysOnTop.Size = new Size(28, 28);
            button_AlwaysOnTop.IconRatio = 0.8F;
            button_AlwaysOnTop.Click += button_AlwaysOnTop_Click;
            button_AlwaysOnTop.Visible = true;

            button_ThemeSwitch.Dock = DockStyle.Right;
            button_ThemeSwitch.Ghost = true;
            button_ThemeSwitch.IconRatio = 0.8F;
            button_ThemeSwitch.IconSvg = "SunOutlined";
            button_ThemeSwitch.ToggleIconSvg = "MoonOutlined";
            button_ThemeSwitch.Size = new Size(28, 28);
            button_ThemeSwitch.Click += button_ThemeSwitch_Click;
            button_ThemeSwitch.MouseEnter += button_ThemeSwitch_MouseEnter;
            button_ThemeSwitch.Visible = true;

            button2.Dock = DockStyle.Right;
            button2.Ghost = true;
            button2.Size = new Size(26, 28);
            button2.IconRatio = 0.8F;
            button2.IconSvg = resources.GetString("button2.IconSvg");
            button2.Click += button2_Click_1;
            button2.MouseEnter += button2_MouseEnter;
            button2.Visible = true;

            // Damage label and checkbox (right side)
            label2.Dock = DockStyle.Right;
            label2.Size = new Size(140, 28);
            label2.Font = new Font("Alimama ShuHeiTi", 9F, FontStyle.Bold);
            label2.Text = "";
            label2.ForeColor = Color.White;
            label2.MouseDown += HeaderPanel_MouseDown;

            PilingModeCheckbox.Dock = DockStyle.Right;
            PilingModeCheckbox.AutoSizeMode = TAutoSize.Width;
            PilingModeCheckbox.Size = new Size(100, 28);
            PilingModeCheckbox.Font = new Font("Alimama ShuHeiTi", 9F, FontStyle.Bold);
            PilingModeCheckbox.ForeColor = Color.White;
            PilingModeCheckbox.Text = "打桩模式";
            PilingModeCheckbox.TextAlign = ContentAlignment.MiddleCenter;
            PilingModeCheckbox.CheckedChanged += PilingModeCheckbox_CheckedChanged;
            PilingModeCheckbox.Visible = true; // restored visibility

            // Add in correct visual order
            pageHeader1.Controls.Clear();
            pageHeader1.Controls.AddRange(new Control[] {
                // left side (added first so they appear left)
                BattleTimeText,
                label1,
                button3,
                // fill area is left blank intentionally
                // right side (added last since they are Dock=Right)
                label2,
                PilingModeCheckbox,
                button2,
                button_ThemeSwitch,
                button_AlwaysOnTop,
                button1,
                button_Settings
            });

            // -----------------------------
            // Panel2: mode buttons row (glassy)
            // -----------------------------
            panel2.Dock = DockStyle.Top;
            panel2.BackColor = Color.FromArgb(110, 30, 30, 34); // semi-transparent dark glass
            panel2.Size = new Size(ClientSize.Width, 56);
            panel2.Padding = new Padding(8, 8, 8, 8);
            panel2.Shadow = 6;
            panel2.ShadowAlign = TAlignMini.Bottom;
            panel2.Name = "panel2";

            // Button baseline sizes
            int modeBtnH = 36;
            int x = 10;
            int gap = 8;

            TotalDamageButton.Size = new Size(72, modeBtnH);
            TotalDamageButton.Location = new Point(x, 10);
            TotalDamageButton.Radius = 4;
            TotalDamageButton.DefaultBack = Color.FromArgb(36, 40, 44);
            TotalDamageButton.ForeColor = Color.White;
            TotalDamageButton.Text = "DPS";
            TotalDamageButton.Click += DamageType_Click;
            TotalDamageButton.Visible = true;

            x += TotalDamageButton.Width + gap;

            TotalTreatmentButton.Size = new Size(86, modeBtnH);
            TotalTreatmentButton.Location = new Point(x, 10);
            TotalTreatmentButton.Radius = 4;
            TotalTreatmentButton.DefaultBack = Color.FromArgb(36, 40, 44);
            TotalTreatmentButton.ForeColor = Color.White;
            TotalTreatmentButton.Text = "HEALING";
            TotalTreatmentButton.Click += DamageType_Click;
            TotalTreatmentButton.Visible = true;

            x += TotalTreatmentButton.Width + gap;

            AlwaysInjuredButton.Size = new Size(86, modeBtnH);
            AlwaysInjuredButton.Location = new Point(x, 10);
            AlwaysInjuredButton.Radius = 4;
            AlwaysInjuredButton.DefaultBack = Color.FromArgb(36, 40, 44);
            AlwaysInjuredButton.ForeColor = Color.White;
            AlwaysInjuredButton.Text = "TANKING";
            AlwaysInjuredButton.Click += DamageType_Click;
            AlwaysInjuredButton.Visible = true;

            x += AlwaysInjuredButton.Width + gap;

            NpcTakeDamageButton.Size = new Size(100, modeBtnH);
            NpcTakeDamageButton.Location = new Point(x, 10);
            NpcTakeDamageButton.Radius = 4;
            NpcTakeDamageButton.DefaultBack = Color.FromArgb(36, 40, 44);
            NpcTakeDamageButton.ForeColor = Color.White;
            NpcTakeDamageButton.Text = "NPCTANKING";
            NpcTakeDamageButton.Click += DamageType_Click;
            NpcTakeDamageButton.Visible = true;

            x += NpcTakeDamageButton.Width + gap;

            SortToggleButton.Size = new Size(86, modeBtnH);
            SortToggleButton.Location = new Point(x, 10);
            SortToggleButton.Radius = 4;
            SortToggleButton.DefaultBack = Color.FromArgb(40, 90, 160); // subtle accent
            SortToggleButton.ForeColor = Color.White;
            SortToggleButton.Text = "Sort[Σ]";
            SortToggleButton.Click += SortToggleButton_Click;
            SortToggleButton.Visible = true;

            // Add to panel2
            panel2.Controls.Clear();
            panel2.Controls.AddRange(new Control[] {
                TotalDamageButton,
                TotalTreatmentButton,
                AlwaysInjuredButton,
                NpcTakeDamageButton,
                SortToggleButton
            });

            // -----------------------------
            // sortedProgressBarList1 (main list)
            // -----------------------------
            sortedProgressBarList1.Dock = DockStyle.Fill;
            sortedProgressBarList1.Margin = new Padding(10, 12, 10, 12);
            sortedProgressBarList1.BackColor = Color.FromArgb(20, 20, 22); // deep dark so glass panels float above it
            sortedProgressBarList1.OrderColor = Color.White;               // ensure order text visible
            sortedProgressBarList1.OrderFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
            sortedProgressBarList1.ScrollBarWidth = 8;
            sortedProgressBarList1.SeletedItemColor = Color.FromArgb(86, 156, 214);
            sortedProgressBarList1.Load += sortedProgressBarList1_Load;

            // -----------------------------
            // Timers
            // -----------------------------
            timer_RefreshRunningTime.Enabled = true;
            timer_RefreshRunningTime.Interval = 10;
            timer_RefreshRunningTime.Tick += timer_RefreshRunningTime_Tick;
            timer1.Tick += timer1_Tick;

            // -----------------------------
            // Final control ordering (drop-in)
            // -----------------------------
            Controls.Clear();
            Controls.Add(sortedProgressBarList1);
            Controls.Add(panel2);
            Controls.Add(pageHeader1);

            // Keep optional bottom panel if you need it later (not shown to keep glass clean)
            // panel1 settings (kept but not added so it doesn't cover glass)
            panel1.BackColor = Color.Transparent;
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, ClientSize.Height - 38);
            panel1.Name = "panel1";
            panel1.Radius = 3;
            panel1.Shadow = 3;
            panel1.ShadowAlign = TAlignMini.Top;
            panel1.Size = new Size(ClientSize.Width, 34);
            panel1.TabIndex = 17;
            panel1.Text = "panel1";

            // Tooltip style
            tooltip.ArrowAlign = TAlign.TL;
            tooltip.Font = new Font("HarmonyOS Sans SC", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);

            // Events kept
            Load += DpsStatistics_Load;
            Shown += DpsStatisticsForm_Shown;
            FormClosing += DpsStatisticsForm_FormClosing;
            ForeColorChanged += DpsStatisticsForm_ForeColorChanged;

            pageHeader1.ResumeLayout(false);
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
        private AntdUI.Button SortToggleButton;
    }
}