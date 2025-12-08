namespace StarResonanceDpsAnalysis.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                components?.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));

            components = new System.ComponentModel.Container();

            // === HEADER ===
            pageHeader_MainHeader = new AntdUI.PageHeader
            {
                Dock = DockStyle.Top,
                Height = 40,
                DividerShow = true,
                DividerThickness = 2f,
                Font = new Font("Alimama ShuHeiTi", 10f, FontStyle.Bold),
                Icon = (Image)resources.GetObject("pageHeader_MainHeader.Icon"),
                Text = "Don't check my DPS",
                ShowButton = true
            };

            button_ThemeSwitch = new AntdUI.Button
            {
                Dock = DockStyle.Right,
                Width = 40,
                Ghost = true,
                IconSvg = resources.GetString("button_ThemeSwitch.IconSvg"),
                ToggleIconSvg = "MoonOutlined"
            };
            button_ThemeSwitch.Click += button_ThemeSwitch_Click;

            pageHeader_MainHeader.Controls.Add(button_ThemeSwitch);

            // === MAIN LAYOUT (AUTO) ===
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 1,
                Padding = new Padding(20),
                AutoScroll = true
            };

            // === ABOUT GROUP ===
            groupBox_About = new GroupBox
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Font = new Font("HarmonyOS Sans SC", 12f, FontStyle.Bold),
                Text = "About",
                Padding = new Padding(20)
            };

            // inner layout
            var aboutLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                ColumnCount = 2,
                AutoSize = true
            };
            aboutLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            aboutLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            aboutLayout.RowStyles.Clear();

            pictureBox_AppIcon = new PictureBox
            {
                Size = new Size(92, 92),
                SizeMode = PictureBoxSizeMode.Zoom,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            aboutLayout.Controls.Add(pictureBox_AppIcon, 0, 0);
            aboutLayout.SetRowSpan(pictureBox_AppIcon, 2);

            label_AppName = NewLabelBold("Don't check my DPS");
            aboutLayout.Controls.Add(label_AppName, 1, 0);

            label_SelfIntroduce = NewLabelWrap(
                "A combat data statistics tool designed for *Star Resonance*. " +
                "This tool requires no modification to the game client and does not violate the game's terms. " +
                "Its purpose is to help players understand combat data and improve performance responsibly.");
            aboutLayout.Controls.Add(label_SelfIntroduce, 1, 1);

            // === VERSION ===
            label_NowVersionTip = NewLabelBold("Current version number:");
            label_NowVersionNumber = NewLabel("-.-.-");

            aboutLayout.Controls.Add(label_NowVersionTip, 0, 2);
            aboutLayout.Controls.Add(label_NowVersionNumber, 1, 2);

            // === DEVELOPERS ===
            label_NowVersionDevelopersTip = NewLabelBold("Current version developers:");
            label_NowVersionDevelopers = NewLabelWrap(
                "Amazing Cat Box (anying1073: Project Initiator)\r\n" +
                "Lu Shi (Rocy-June)\r\n" +
                "Qinglan Sect Wang Teng\r\n" +
                "Translated by DannyDog");

            aboutLayout.Controls.Add(label_NowVersionDevelopersTip, 0, 3);
            aboutLayout.Controls.Add(label_NowVersionDevelopers, 1, 3);

            // === OPEN SOURCE & GROUP ===
            var openSourcePanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                Dock = DockStyle.Top,
                AutoSize = true
            };

            label_OpenSourceTip_1 = NewLabel("This project was");
            linkLabel_GitHub = NewLink("GitHub", linkLabel_GitHub_LinkClicked);
            label_OpenSourceTip_2 = NewLabelWrap(
                "This is an open-source project. If you encounter issues or want teammates, join group:");
            linkLabel_QQGroup = NewLink("678150498", linkLabel_QQGroup_LinkClicked);

            openSourcePanel.Controls.Add(label_OpenSourceTip_1);
            openSourcePanel.Controls.Add(linkLabel_GitHub);
            openSourcePanel.Controls.Add(label_OpenSourceTip_2);
            openSourcePanel.Controls.Add(linkLabel_QQGroup);

            aboutLayout.Controls.Add(openSourcePanel, 0, 4);
            aboutLayout.SetColumnSpan(openSourcePanel, 2);

            // === THANKS ===
            var thanksPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                Dock = DockStyle.Top,
                AutoSize = true
            };

            label_ThankHelpFromTip_1 = NewLabel("Thank you.");
            linkLabel_NodeJsProject = NewLink(
                "dmlgzs/StarResonanceDamageCounter", linkLabel_NodeJsProject_LinkClicked);
            label_ThankHelpFromTip_2 = NewLabel("for support and contributions.");

            thanksPanel.Controls.Add(label_ThankHelpFromTip_1);
            thanksPanel.Controls.Add(linkLabel_NodeJsProject);
            thanksPanel.Controls.Add(label_ThankHelpFromTip_2);

            aboutLayout.Controls.Add(thanksPanel, 0, 5);
            aboutLayout.SetColumnSpan(thanksPanel, 2);

            // === COPYRIGHT ===
            label_Copyright = NewLabelWrap(
                "Copyright (C) 2025 anying1073/StarResonanceDps Team\r\n" +
                "Powered by .NET 8, Licensed under AGPL v3.");

            aboutLayout.Controls.Add(label_Copyright, 0, 6);
            aboutLayout.SetColumnSpan(label_Copyright, 2);

            groupBox_About.Controls.Add(aboutLayout);
            layout.Controls.Add(groupBox_About);

            // === MAIN FORM ===
            SuspendLayout();
            BackColor = Color.White;
            ForeColor = Color.Black;
            AutoScaleMode = AutoScaleMode.Font;
            AutoScaleDimensions = new SizeF(8F, 20F);
            ClientSize = new Size(900, 600);

            Controls.Add(layout);
            Controls.Add(pageHeader_MainHeader);

            Icon = (Icon)resources.GetObject("$this.Icon");
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "DPS Statistics Tool";

            ResumeLayout(false);
        }

        // === Helper Builders ===
        private Label NewLabel(string text) =>
            new Label
            {
                Text = text,
                AutoSize = true,
                Font = new Font("HarmonyOS Sans SC", 8f)
            };

        private Label NewLabelBold(string text) =>
            new Label
            {
                Text = text,
                AutoSize = true,
                Font = new Font("HarmonyOS Sans SC", 9f, FontStyle.Bold)
            };

        private Label NewLabelWrap(string text) =>
            new Label
            {
                Text = text,
                AutoSize = true,
                MaximumSize = new Size(600, 0),
                Font = new Font("HarmonyOS Sans SC", 8f)
            };

        private LinkLabel NewLink(string text, LinkLabelLinkClickedEventHandler handler)
        {
            var link = new LinkLabel
            {
                Text = text,
                AutoSize = true,
                Font = new Font("HarmonyOS Sans SC", 8f),
            };
            link.LinkClicked += handler;
            return link;
        }

        private AntdUI.PageHeader pageHeader_MainHeader;
        private AntdUI.Button button_ThemeSwitch;
        private PictureBox pictureBox_AppIcon;
        private GroupBox groupBox_About;

        private Label label_AppName;
        private Label label_NowVersionTip;
        private Label label_NowVersionNumber;

        private Label label_NowVersionDevelopersTip;
        private Label label_NowVersionDevelopers;

        private Label label_SelfIntroduce;

        private Label label_OpenSourceTip_1;
        private Label label_OpenSourceTip_2;
        private LinkLabel linkLabel_GitHub;

        private LinkLabel linkLabel_QQGroup;

        private Label label_ThankHelpFromTip_1;
        private LinkLabel linkLabel_NodeJsProject;
        private Label label_ThankHelpFromTip_2;

        private Label label_Copyright;
    }
}
