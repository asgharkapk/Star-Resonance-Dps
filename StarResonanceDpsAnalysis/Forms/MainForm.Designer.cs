namespace StarResonanceDpsAnalysis.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        // ─────────────────────────────────────────────────────────────
        // redesigned initialize
        // ─────────────────────────────────────────────────────────────
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(MainForm));

            // ─────────────────────────────────────────────────────────
            // Controls
            // ─────────────────────────────────────────────────────────
            pageHeader = new AntdUI.PageHeader();
            buttonTheme = new AntdUI.Button();
            layoutPanel = new TableLayoutPanel();
            pictureIcon = new PictureBox();
            labelName = new Label();
            labelVersionTip = new Label();
            labelVersion = new Label();
            labelDevTip = new Label();
            labelDevelopers = new Label();
            labelIntro = new Label();
            separator = new Label();
            labelOpen1 = new Label();
            linkGitHub = new LinkLabel();
            labelOpen2 = new Label();
            linkQQ = new LinkLabel();
            labelThanks1 = new Label();
            linkNodeJs = new LinkLabel();
            labelThanks2 = new Label();
            labelCopyright = new Label();

            SuspendLayout();

            // ─────────────────────────────────────────────────────────
            // PageHeader (TOP bar)
            // ─────────────────────────────────────────────────────────
            pageHeader.Dock = DockStyle.Top;
            pageHeader.Height = 40;
            pageHeader.DividerShow = true;
            pageHeader.Text = "Don't check my DPS";
            pageHeader.Icon = (Image)resources.GetObject("pageHeader_MainHeader.Icon");
            pageHeader.Font = new Font("Alimama ShuHeiTi", 9F, FontStyle.Bold);
            pageHeader.ShowButton = true;

            // Theme switch button
            buttonTheme.Dock = DockStyle.Right;
            buttonTheme.Size = new Size(40, 40);
            buttonTheme.Ghost = true;
            buttonTheme.IconSvg = resources.GetString("button_ThemeSwitch.IconSvg");
            buttonTheme.ToggleIconSvg = "MoonOutlined";
            buttonTheme.Click += button_ThemeSwitch_Click;
            pageHeader.Controls.Add(buttonTheme);

            // ─────────────────────────────────────────────────────────
            // Main layout container
            // ─────────────────────────────────────────────────────────
            layoutPanel.Dock = DockStyle.Fill;
            layoutPanel.BackColor = Color.Transparent;
            layoutPanel.Padding = new Padding(20);
            layoutPanel.ColumnCount = 2;
            layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
            layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            layoutPanel.RowCount = 12;

            for (int i = 0; i < 12; i++)
                layoutPanel.RowStyles.Add(new RowStyle());

            // ─────────────────────────────────────────────────────────
            // App Icon
            // ─────────────────────────────────────────────────────────
            pictureIcon.Size = new Size(90, 90);
            pictureIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureIcon.Anchor = AnchorStyles.Left | AnchorStyles.Top;

            // ─────────────────────────────────────────────────────────
            // Text sections
            // ─────────────────────────────────────────────────────────
            labelName.Text = "Don't check my DPS";
            labelName.Font = new Font("HarmonyOS Sans SC", 12F, FontStyle.Bold);

            labelVersionTip.Text = "Current version:";
            labelVersionTip.Font = new Font("HarmonyOS Sans SC", 9F, FontStyle.Bold);

            labelVersion.Text = "-.-.-";
            labelVersion.Font = new Font("HarmonyOS Sans SC", 9F);

            labelDevTip.Text = "Current version developers:";
            labelDevTip.Font = new Font("HarmonyOS Sans SC", 9F, FontStyle.Bold);

            labelDevelopers.Text =
                "Amazing Cat Box (anying1073: Project Initiator)\r\n" +
                "Lu Shi (Rocy-June)\r\n" +
                "Qinglan Sect Wang Teng\r\n" +
                "Translated by DannyDog";
            labelDevelopers.Font = new Font("HarmonyOS Sans SC", 9F);

            labelIntro.Text =
                "A combat statistics tool for *Star Resonance*. No modification to the game " +
                "client, compliant with game ToS. Helps players understand combat data, " +
                "reduce ineffective boosts, and improve experience.";
            labelIntro.Font = new Font("HarmonyOS Sans SC", 9F);
            labelIntro.MaximumSize = new Size(700, 0);
            labelIntro.AutoSize = true;

            separator.Height = 1;
            separator.BackColor = Color.Silver;
            separator.Dock = DockStyle.Fill;
            separator.Margin = new Padding(0, 10, 0, 10);

            labelOpen1.Text = "This project is open-source on";
            labelOpen1.Font = new Font("HarmonyOS Sans SC", 8F);

            linkGitHub.Text = "GitHub";
            linkGitHub.Font = new Font("HarmonyOS Sans SC", 8F);
            linkGitHub.LinkClicked += linkLabel_GitHub_LinkClicked;

            labelOpen2.Text = "Join our group:";
            labelOpen2.Font = new Font("HarmonyOS Sans SC", 8F);

            linkQQ.Text = "678150498";
            linkQQ.Font = new Font("HarmonyOS Sans SC", 8F);
            linkQQ.LinkClicked += linkLabel_QQGroup_LinkClicked;

            labelThanks1.Text = "Thanks to:";
            labelThanks1.Font = new Font("HarmonyOS Sans SC", 8F);

            linkNodeJs.Text = "dmlgzs/StarResonanceDamageCounter";
            linkNodeJs.Font = new Font("HarmonyOS Sans SC", 8F);
            linkNodeJs.LinkClicked += linkLabel_NodeJsProject_LinkClicked;

            labelThanks2.Text = "for related support.";
            labelThanks2.Font = new Font("HarmonyOS Sans SC", 8F);

            labelCopyright.Text =
                "Copyright (C) 2025 StarResonanceDps Team\r\n" +
                "Powered by .NET 8 | Licensed under AGPL-3.0";
            labelCopyright.Font = new Font("HarmonyOS Sans SC", 8F);

            // ─────────────────────────────────────────────────────────
            // Add controls to grid
            // ─────────────────────────────────────────────────────────
            layoutPanel.Controls.Add(pictureIcon,                  0, 0);
            layoutPanel.SetRowSpan(pictureIcon, 3);

            layoutPanel.Controls.Add(labelName,                    1, 0);
            layoutPanel.Controls.Add(labelVersionTip,              1, 1);
            layoutPanel.Controls.Add(labelVersion,                 1, 2);

            layoutPanel.Controls.Add(labelDevTip,                  1, 3);
            layoutPanel.Controls.Add(labelDevelopers,              1, 4);

            layoutPanel.Controls.Add(labelIntro,                   1, 5);
            layoutPanel.Controls.Add(separator,                    1, 6);

            layoutPanel.Controls.Add(labelOpen1,                   1, 7);
            layoutPanel.Controls.Add(linkGitHub,                   1, 8);

            layoutPanel.Controls.Add(labelOpen2,                   1, 9);
            layoutPanel.Controls.Add(linkQQ,                       1, 10);

            layoutPanel.Controls.Add(labelThanks1,                 1, 11);
            layoutPanel.Controls.Add(linkNodeJs,                   1, 12);
            layoutPanel.Controls.Add(labelThanks2,                 1, 13);

            layoutPanel.Controls.Add(labelCopyright,               1, 14);

            // ─────────────────────────────────────────────────────────
            // Add to form
            // ─────────────────────────────────────────────────────────
            Controls.Add(layoutPanel);
            Controls.Add(pageHeader);

            // ─────────────────────────────────────────────────────────
            // MainForm settings
            // ─────────────────────────────────────────────────────────
            BackColor = Color.White;
            ForeColor = Color.Black;
            Mode = AntdUI.TAMode.Dark;
            Dark = true;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DPS Statistics Tool";
            Icon = (Icon)resources.GetObject("$this.Icon");
            ClientSize = new Size(900, 600);

            ResumeLayout(false);
        }

        // ─────────────────────────────────────────────────────────────
        // fields
        // ─────────────────────────────────────────────────────────────
        private AntdUI.PageHeader pageHeader;
        private AntdUI.Button buttonTheme;
        private TableLayoutPanel layoutPanel;
        private PictureBox pictureIcon;
        private Label labelName;
        private Label labelVersionTip;
        private Label labelVersion;
        private Label labelDevTip;
        private Label labelDevelopers;
        private Label labelIntro;
        private Label separator;
        private Label labelOpen1;
        private LinkLabel linkGitHub;
        private Label labelOpen2;
        private LinkLabel linkQQ;
        private Label labelThanks1;
        private LinkLabel linkNodeJs;
        private Label labelThanks2;
        private Label labelCopyright;
    }
}
