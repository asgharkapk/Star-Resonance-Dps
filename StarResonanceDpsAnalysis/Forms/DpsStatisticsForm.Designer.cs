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
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(DpsStatisticsForm));

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

            // =====================================================================
            // PAGE HEADER (TOP BAR)
            // =====================================================================

            pageHeader1.BackColor = Color.Transparent;
            pageHeader1.ColorScheme = TAMode.Dark;
            pageHeader1.Dock = DockStyle.Top;
            pageHeader1.Size = new Size(527, 32);                     // ↑ taller & cleaner
            pageHeader1.Padding = new Padding(6, 3, 6, 3);            // ↑ breathing space
            pageHeader1.DividerThickness = 2F;
            pageHeader1.Name = "pageHeader1";

            // LEFT → BattleTime, PlayerCount, Switch Button
            pageHeader1.Controls.Add(BattleTimeText);
            pageHeader1.Controls.Add(label1);
            pageHeader1.Controls.Add(button3);

            // RIGHT → DPS label, checkbox, icons
            pageHeader1.Controls.Add(label2);
            pageHeader1.Controls.Add(PilingModeCheckbox);
            pageHeader1.Controls.Add(button2);
            pageHeader1.Controls.Add(button_ThemeSwitch);
            pageHeader1.Controls.Add(button_AlwaysOnTop);
            pageHeader1.Controls.Add(button1);
            pageHeader1.Controls.Add(button_Settings);

            // Button sizing improvements
            Size headerBtnSmall = new Size(26, 26);
            Size headerBtnNormal = new Size(30, 26);

            button_Settings.Size = headerBtnNormal;
            button1.Size = headerBtnSmall;
            button_AlwaysOnTop.Size = headerBtnSmall;
            button2.Size = headerBtnSmall;
            button_ThemeSwitch.Size = headerBtnSmall;
            button3.Size = headerBtnSmall;

            // Checkbox
            PilingModeCheckbox.Size = new Size(110, 26);
            PilingModeCheckbox.Margin = new Padding(0, 0, 6, 0);

            BattleTimeText.Size = new Size(90, 26);
            label1.Size = new Size(55, 26);
            label2.Size = new Size(140, 26);

            // =====================================================================
            // PANEL2 (Mode Buttons Row)
            // =====================================================================

            panel2.Dock = DockStyle.Top;
            panel2.BackColor = Color.Transparent;
            panel2.Size = new Size(527, 50);                    // ↑ cleaner compact panel
            panel2.Padding = new Padding(10, 8, 10, 4);         // ↑ symmetric padding
            panel2.Shadow = 3;
            panel2.ShadowAlign = TAlignMini.Bottom;

            int modeBtnW = 90;
            int modeBtnH = 34;

            TotalDamageButton.Size = new Size(modeBtnW - 20, modeBtnH);
            TotalDamageButton.Location = new Point(10, 8);

            TotalTreatmentButton.Size = new Size(modeBtnW, modeBtnH);
            TotalTreatmentButton.Location = new Point(75, 8);

            AlwaysInjuredButton.Size = new Size(modeBtnW, modeBtnH);
            AlwaysInjuredButton.Location = new Point(170, 8);

            NpcTakeDamageButton.Size = new Size(modeBtnW + 10, modeBtnH);
            NpcTakeDamageButton.Location = new Point(265, 8);

            SortToggleButton.Size = new Size(90, 34);
            SortToggleButton.Location = new Point(365, 8);

            panel2.Controls.Add(NpcTakeDamageButton);
            panel2.Controls.Add(AlwaysInjuredButton);
            panel2.Controls.Add(TotalTreatmentButton);
            panel2.Controls.Add(TotalDamageButton);
            panel2.Controls.Add(SortToggleButton);

            // =====================================================================
            // DPS LIST AREA (sortedProgressBarList1)
            // =====================================================================

            sortedProgressBarList1.Dock = DockStyle.Fill;
            sortedProgressBarList1.Margin = new Padding(10, 10, 10, 10);
            sortedProgressBarList1.BackColor = Color.WhiteSmoke;

            // =====================================================================
            // FINAL FORM SETTINGS
            // =====================================================================

            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(527, 450);                       // ↑ improved space
            Controls.Add(sortedProgressBarList1);
            Controls.Add(panel2);
            Controls.Add(pageHeader1);

            Name = "DpsStatisticsForm";
            Radius = 3;

            Load += DpsStatistics_Load;
            Shown += DpsStatisticsForm_Shown;
            FormClosing += DpsStatisticsForm_FormClosing;

            pageHeader1.ResumeLayout(false);
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