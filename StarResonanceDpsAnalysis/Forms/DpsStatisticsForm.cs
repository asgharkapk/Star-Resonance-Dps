using System;
using System.Drawing;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks; // 引用异步任务支持（Task/async/await）
using System.Windows.Forms;

using AntdUI; // 引用 AntdUI 组件库（第三方 UI 控件/样式）
using StarResonanceDpsAnalysis.Control; // 引用项目内的 UI 控制/辅助类命名空间
using StarResonanceDpsAnalysis.Effects;
using StarResonanceDpsAnalysis.Forms.PopUp; // 引用弹窗相关窗体/组件命名空间
using StarResonanceDpsAnalysis.Plugin; // 引用项目插件层通用命名空间
using StarResonanceDpsAnalysis.Plugin.DamageStatistics; // 引用伤害统计插件命名空间（含 FullRecord、StatisticData 等）
using StarResonanceDpsAnalysis.Plugin.LaunchFunction; // 引用启动相关功能（加载技能配置等）
using StarResonanceDpsAnalysis.Properties; // 引用资源（图标/本地化字符串等）

using static StarResonanceDpsAnalysis.Control.SkillDetailForm;
using System.Security.Cryptography.Xml;
using Button = AntdUI.Button;
using DocumentFormat.OpenXml.Office2010.Excel;
using Color = System.Drawing.Color;
using StarResonanceDpsAnalysis.Forms.ModuleForm;

namespace StarResonanceDpsAnalysis.Forms // 定义命名空间：窗体相关代码所在位置
{ // 命名空间开始
    public partial class DpsStatisticsForm : BorderlessForm // 定义无边框窗体的局部类（与 Designer 生成的部分合并）
    { // 类开始
        // # 导航
        // # 本文件职责：
        // #   1) 窗体构造与启动流程（初始化 UI/钩子/配置/设备/技能配置）。
        // #   2) 列表交互（选择条目 → 打开技能详情窗口）。
        // #   3) 顶部操作（置顶、设置菜单、提示气泡）。
        // #   4) 统计视图切换（单次/全程 + 左右切换指标）。
        // #   5) 定时刷新（战斗时长、榜单数据刷新）。
        // #   6) 清空/打桩模式（定时器与上传流程）。
        // #   7) 主题切换（前景色变化时的控件背景适配）。
        // #   8) 全局热键钩子（安装/卸载/按键路由）。
        // #   9) 窗口控制（鼠标穿透、透明度切换）。

        // # 构造与启动流程
        public DpsStatisticsForm() // 构造函数：创建窗体实例时执行一次
        {
            // 构造函数开始
            InitializeComponent(); // 初始化设计器生成的控件与布局


            Text = FormManager.APP_NAME;

            FormGui.SetDefaultGUI(this); // 统一设置窗体默认 GUI 风格（字体、间距、阴影等）

            //ApplyResolutionScale(); // 可选：根据屏幕分辨率对整体界面进行缩放（当前禁用，仅保留调用）

            // 从资源文件设置字体
            SetDefaultFontFromResources();

            // 加载钩子
            RegisterKeyboardHook(); // 安装键盘钩子，用于全局热键监听与处理

            // 首次启动时初始化基础配置
            InitTableColumnsConfigAtFirstRun(); // 首次运行初始化表格列配置（列宽/显示项等）

            // 加载网卡
            LoadNetworkDevices(); // 加载/枚举网络设备（抓包设备列表）

            FormGui.SetColorMode(this, AppConfig.IsLight);//设置窗体颜色 // 根据配置设置窗体的颜色主题（明亮/深色）

            // 加载技能配置
            StartupInitializer.LoadFromEmbeddedSkillConfig(); // 从内置资源读取并加载技能数据（元数据/图标/映射）


            sortedProgressBarList1.SelectionChanged += (s, i, d) => // 订阅进度条列表的选择变化事件（点击条目）
            { // 事件处理开始
                // # UI 列表交互：当用户点击列表项时触发（i 为索引，d 为 ProgressBarData）
                if (i < 0 || d == null) // 若未选中有效项或数据为空
                { // 条件分支开始
                    return; // 直接返回，不做任何处理
                } // 条件分支结束
                  // # 将选中项的 UID 传入详情窗口刷新
                sortedProgressBarList_SelectionChanged((ulong)d.ID); // 将条目 ID 转为 UID 并调用详情刷新逻辑
            }; // 事件处理结束并解除与下一语句的关联

            SetStyle(); // 设置/应用本窗体的个性化样式（定义在同类/局部类的其他部分）
            ApplyLocalization();
        } // 构造函数结束


        // # 屏幕分辨率缩放判定
        private static float GetPrimaryResolutionScale() // 依据主屏高度返回推荐缩放比例
        {
            try // 防御：获取屏幕信息可能在某些环境异常
            { // try 开始
                var bounds = Screen.PrimaryScreen?.Bounds ?? new Rectangle(0, 0, 1920, 1080); // 获取主屏尺寸，失败则默认 1080p
                if (bounds.Height >= 2160) return 2.0f;       // 4K 屏：建议缩放 2.0
                if (bounds.Height >= 1440) return 1.3333f;    // 2K 屏：建议缩放 1.3333
                return 1.0f;                                   // 1080p：不缩放
            } // try 结束
            catch // 捕获任何异常
            { // catch 开始
                return 1.0f; // 异常时安全返回 1.0（不缩放）
            } // catch 结束
        }

        // # 窗体加载事件：启动抓包
        private void DpsStatistics_Load(object sender, EventArgs e) // 窗体 Load 事件处理
        {
            //开启默认置顶

            StartCapture(); // 启动网络抓包/数据采集（核心运行入口之一）

            // 重置为上次关闭前的位置与大小
            SetStartupPositionAndSize();

            EnsureTopMost();
        }

        // # 列表选择变更 → 打开技能详情
        private void sortedProgressBarList_SelectionChanged(ulong uid) // 列表项选择回调：传入选中玩家 UID
        {
            // 如果当前是“NPC承伤”视图：点击 NPC 行切换到“打这个NPC的玩家排名”
            if (FormManager.currentIndex == 3)
            {
                // 全程显示：直接刷新为该NPC的攻击者榜
                _npcDetailMode = true;
                _npcFocusId = uid;

                // 立刻刷新该 NPC 的攻击者榜（当前/全程均已在方法内部自动分流）
                RefreshNpcAttackers(_npcFocusId);
                // 可选：更新标题
                pageHeader1.SubText = FormManager.showTotal
                    ? string.Format(Properties.Strings.Header_NpcAttackers_FullRecord, uid)
                    : string.Format(Properties.Strings.Header_NpcAttackers_Current, uid);
                return;
            }

            // ……下面是你原来的玩家技能详情逻辑……
            if (FormManager.skillDetailForm == null || FormManager.skillDetailForm.IsDisposed)
                FormManager.skillDetailForm = new SkillDetailForm();

            SkillTableDatas.SkillTable.Clear();

            FormManager.skillDetailForm.Uid = uid;
            var info = StatisticData._manager.GetPlayerBasicInfo(uid);
            FormManager.skillDetailForm.GetPlayerInfo(info.Nickname, info.CombatPower, info.Profession);

            if (FormManager.showTotal) { FormManager.skillDetailForm.ContextType = DetailContextType.FullRecord; FormManager.skillDetailForm.SnapshotStartTime = null; }
            else { FormManager.skillDetailForm.ContextType = DetailContextType.Current; FormManager.skillDetailForm.SnapshotStartTime = null; }

            FormManager.skillDetailForm.SelectDataType();
            if (!FormManager.skillDetailForm.Visible) FormManager.skillDetailForm.Show(); else FormManager.skillDetailForm.Activate();
        }

        // # 顶部：置顶窗口按钮
        private void button_AlwaysOnTop_Click(object sender, EventArgs e) // 置顶按钮点击事件
        {
            TopMost = !TopMost; // 简化切换
            FormManager.skillDetailForm.TopMost = TopMost;

            button_AlwaysOnTop.Toggle = TopMost; // 同步按钮的视觉状态
        }

        #region 切换显示类型（支持单次/全程伤害） // 折叠：视图标签与切换逻辑


        // # 头部标题文本刷新：依据 showTotal & currentIndex
        private void UpdateHeaderText() // 根据当前模式与索引更新顶部标签文本
        {

            if (FormManager.showTotal)
            {
                pageHeader1.SubText = FormManager.currentIndex switch
                {
                    1 => Properties.Strings.Header_FullRecord_Healing,
                    2 => Properties.Strings.Header_FullRecord_Taken,
                    3 => Properties.Strings.Header_FullRecord_NpcTaken,
                    _ => Properties.Strings.Header_FullRecord_Damage
                };
            }
            else
            {
                pageHeader1.SubText = FormManager.currentIndex switch
                {
                    1 => Properties.Strings.Header_Current_Healing,
                    2 => Properties.Strings.Header_Current_Taken,
                    3 => Properties.Strings.Header_Current_NpcTaken,
                    _ => Properties.Strings.Header_Current_Damage
                };
            }
        }



        // 单次/全程切换
        private void button3_Click(object sender, EventArgs e) // 单次/全程切换按钮事件
        {
            FormManager.showTotal = !FormManager.showTotal; // 取反：在单次与全程之间切换
            UpdateHeaderText(); // 切换后刷新顶部文本
        }
        #endregion

        // # 定时刷新：战斗时长显示 + 榜单刷新
        private void timer_RefreshRunningTime_Tick(object sender, EventArgs e) // 定时器：周期刷新（UI 绑定）
        {
            if (FormManager.currentIndex == 3)
            {
                // NPC 承伤页
                if (_npcDetailMode && _npcFocusId != 0)
                {
                    // 正在查看某个 NPC 的攻击者榜 —— 保持停留在详情页并刷新该榜单
                    RefreshNpcAttackers((ulong)_npcFocusId);

                    // （可选健壮性）该 NPC 若已消失/无数据，可自动退出详情回到总览
                    // 你可以在 RefreshNpcAttackers 内部判空时自动调用 ExitNpcDetailMode() + RefreshNpcOverview()
                }
                else
                {
                    // 非详情模式：刷新 NPC 承伤总览（当前/全程在方法内部已自行处理）
                    RefreshNpcOverview();
                }
            }
            else
            {
                var source = FormManager.showTotal ? SourceType.FullRecord : SourceType.Current;
                var metric = FormManager.currentIndex switch
                {
                    1 => MetricType.Healing,
                    2 => MetricType.Taken,
                    3 => MetricType.NpcTaken,   // ★ 保留：其他地方如果有用到
                    _ => MetricType.Damage
                };
                RefreshDpsTable(source, metric);
            }

            var duration = StatisticData._manager.GetFormattedCombatDuration();
            if (FormManager.showTotal) duration = FullRecord.GetEffectiveDurationString();
            BattleTimeText.Text = duration;
        }


        /// <summary>
        /// 清空当前数据数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e) // 清空按钮点击：触发清空逻辑
        {
            // # 清空：触发 HandleClearData（停止图表刷新→清空数据→重置图表）
            HandleClearData(); // 调用清空处理
        }


        // # 设置按钮 → 右键菜单
        private void button_Settings_Click(object sender, EventArgs e) // 设置按钮点击：弹出右键菜单
        {


            var menulist = new IContextMenuStripItem[] // 构建右键菜单项数组
             { // 数组开始
                    new ContextMenuStripItem(Properties.Strings.Menu_HistoricalBattles) // 一级菜单：历史战斗
                    { // 配置开始
                        IconSvg = Resources.historicalRecords, // 图标
                    }, // 一级菜单配置结束
                    new ContextMenuStripItem(Properties.Strings.Menu_Settings){ IconSvg = Resources.set_up}, // 一级菜单：基础设置
                    new ContextMenuStripItem(Properties.Strings.Menu_MainForm){ IconSvg = Resources.HomeIcon, }, // 一级菜单：主窗体
                    new ContextMenuStripItem(Properties.Strings.Menu_ModuleConfig){ IconSvg= Resources.moduleIcon }, // 一级菜单：数据显示设置
                    //new ContextMenuStripItem("技能循环监测"), // 一级菜单：技能循环监测
                    //new ContextMenuStripItem(""){ IconSvg = Resources.userUid, }, // 示例：用户 UID（暂不用）
                    new ContextMenuStripItem(Properties.Strings.Menu_DeathStatistics){ IconSvg = Resources.exclude, }, // 一级菜单：统计排除
                    new ContextMenuStripItem(Properties.Strings.Menu_SkillDiary){ IconSvg = Resources.diaryIcon, },
                    new ContextMenuStripItem(Properties.Strings.Menu_DamageReference){ IconSvg = Resources.reference, },
                    new ContextMenuStripItem(Properties.Strings.Menu_PilingMode){ IconSvg = Resources.Stakes }, // 一级菜单：打桩模式
                    new ContextMenuStripItem(Properties.Strings.Menu_Exit){ IconSvg = Resources.quit, }, // 一级菜单：退出
             } // 数组结束
            ; // 语句结束（分号保持）

            AntdUI.ContextMenuStrip.open(this, it => // 打开右键菜单并处理点击回调（it 为被点击项）
            {



                // 回调开始
                // # 菜单点击回调：根据 Text 执行对应动作
                switch (it.Text) // 分支根据菜单文本
                {
                    case var s when s == Properties.Strings.Menu_HistoricalBattles:
                        if (FormManager.historicalBattlesForm == null || FormManager.historicalBattlesForm.IsDisposed)
                        {
                            FormManager.historicalBattlesForm = new HistoricalBattlesForm();
                        }
                        FormManager.historicalBattlesForm.Show();
                        break;
                    // switch 开始
                    case var s when s == Properties.Strings.Menu_Settings: // 点击“基础设置”
                        OpenSettingsDialog(); // 打开设置面板
                        break; // 跳出 switch
                    case var s when s == Properties.Strings.Menu_MainForm: // 点击“主窗体”
                        if (FormManager.mainForm == null || FormManager.mainForm.IsDisposed) // 若主窗体不存在或已释放
                        {
                            FormManager.mainForm = new MainForm(); // 创建主窗体
                        }
                        FormManager.mainForm.Show(); // 显示主窗体
                        break; // 跳出 switch
                    case var s when s == Properties.Strings.Menu_ModuleConfig:
                        if (FormManager.moduleCalculationForm == null || FormManager.moduleCalculationForm.IsDisposed) // 若主窗体不存在或已释放
                        {
                            FormManager.moduleCalculationForm = new ModuleCalculationForm(); // 创建主窗体
                        }
                        FormManager.moduleCalculationForm.Show(); // 显示主窗体
                        break;

                    case var s when s == Properties.Strings.Menu_DeathStatistics:
                        if (FormManager.deathStatisticsForm == null || FormManager.deathStatisticsForm.IsDisposed)
                        {
                            FormManager.deathStatisticsForm = new DeathStatisticsForm();
                        }
                        FormManager.deathStatisticsForm.Show();
                        break;
                    case var s when s == Properties.Strings.Menu_SkillDiary:
                        if (FormManager.skillDiary == null || FormManager.skillDiary.IsDisposed)
                        {
                            FormManager.skillDiary = new SkillDiary();
                        }
                        FormManager.skillDiary.Show();
                        break;
                    case "技能循环监测": // 点击“技能循环监测”
                        if (FormManager.skillRotationMonitorForm == null || FormManager.skillRotationMonitorForm.IsDisposed) // 若监测窗体不存在或已释放
                        {
                            FormManager.skillRotationMonitorForm = new SkillRotationMonitorForm(); // 创建窗口
                        }
                        FormManager.skillRotationMonitorForm.Show(); // 显示窗口
                        //FormGui.SetColorMode(FormManager.skillRotationMonitorForm, AppConfig.IsLight); // 同步主题（明/暗）
                        break; // 跳出 switch
                    case "数据显示设置": // 点击“数据显示设置”（当前仅保留占位）
                        //dataDisplay(); 
                        break; // 占位：后续实现
                    case var s when s == Properties.Strings.Menu_DamageReference:
                        if (FormManager.rankingsForm == null || FormManager.rankingsForm.IsDisposed) // 若监测窗体不存在或已释放
                        {
                            FormManager.rankingsForm = new RankingsForm(); // 创建窗口
                        }
                        FormManager.rankingsForm.Show(); // 显示窗口
                        break;
                    case "统计排除": // 点击“统计排除”
                        break; // 占位：后续实现
                    case var s when s == Properties.Strings.Menu_PilingMode: // 点击“打桩模式”
                        PilingModeCheckbox.Visible = !PilingModeCheckbox.Visible;
                        break; // 跳出 switch
                    case var s when s == Properties.Strings.Menu_Exit: // 点击“退出”
                        System.Windows.Forms.Application.Exit(); // 结束应用程序
                        break; // 跳出 switch
                } // switch 结束
            }, menulist); // 打开菜单并传入菜单项
        }

        /// <summary>
        /// 打开基础设置面板
        /// </summary>
        private void OpenSettingsDialog() // 打开基础设置窗体
        {
            if (FormManager.settingsForm == null || FormManager.settingsForm.IsDisposed) // 若设置窗体不存在或已释放
            {
                FormManager.settingsForm = new SettingsForm(); // 创建设置窗体
            }
            FormManager.settingsForm.Show(); // 显示设置窗体（或置顶）

        }

        // # 按钮提示气泡（置顶）
        private void button_AlwaysOnTop_MouseEnter(object sender, EventArgs e) // 鼠标进入置顶按钮时显示提示
        {
            ToolTip(button_AlwaysOnTop, Properties.Strings.Tooltip_AlwaysOnTop); // 显示“置顶窗口”的气泡提示
        }

        // # 通用提示气泡工具

        private void ToolTip(System.Windows.Forms.Control control, string text) // 通用封装：在指定控件上显示提示文本
        {
            tooltip.SetTip(control, text); // 在目标控件上显示指定文本提示
        }

        // # 按钮提示气泡（清空）
        private void button1_MouseEnter(object sender, EventArgs e) // 鼠标进入“清空”按钮时显示提示
        {
            ToolTip(button1, Properties.Strings.Tooltip_ClearData); // 显示“清空当前数据”的气泡提示
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            ToolTip(button2, Properties.Strings.Tooltip_Minimize);
        }

        // # 按钮提示气泡（单次/全程切换）
        private void button3_MouseEnter(object sender, EventArgs e) // 鼠标进入“单次/全程切换”按钮时显示提示
        {
            ToolTip(button3, Properties.Strings.Tooltip_SwitchSingleTotal); // 显示切换提示（原文如此，保留）
        }

        private void button_ThemeSwitch_MouseEnter(object sender, EventArgs e)
        {
            ToolTip(button_ThemeSwitch, Properties.Strings.Tooltip_SwitchTheme);
        }

        // 打桩模式定时逻辑
        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (PilingModeCheckbox.Checked)
            {
                if (AppConfig.Uid == 0)
                {

                    PilingModeCheckbox.Checked = false;
                    timer1.Enabled = false;
                    var _ = AppMessageBox.ShowMessage(Properties.Strings.Msg_UidNotFound, this);
                    return;
                }
                TimeSpan duration = StatisticData._manager.GetCombatDuration();
                if (duration >= TimeSpan.FromMinutes(3))
                {
                    PilingModeCheckbox.Checked = false;
                    timer1.Enabled = false;

                    var snapshot = StatisticData._manager.TakeSnapshotAndGet();
                    var result = AppMessageBox.ShowMessage(Properties.Strings.Msg_PilingComplete, this);

                    if (result == DialogResult.OK)
                    {
                        bool data = await Common.AddUserDps(snapshot);
                        if (data)
                        {
                            AntdUI.Modal.open(new AntdUI.Modal.Config(this, Properties.Strings.Msg_UploadSuccess, Properties.Strings.Msg_UploadSuccess)
                            {
                                CloseIcon = true,
                                Keyboard = false,
                                MaskClosable = false,
                            });
                        }
                        else
                        {
                            AntdUI.Modal.open(new AntdUI.Modal.Config(this, Properties.Strings.Msg_UploadFail, Properties.Strings.Msg_UploadFailDetail)
                            {
                                CloseIcon = true,
                                Keyboard = false,
                                MaskClosable = false,
                            });
                        }
                    }
                }
            }
        }

        // 打桩模式勾选变化
        private void PilingModeCheckbox_CheckedChanged(object sender, BoolEventArgs e)
        {
            TimeSpan duration = StatisticData._manager.GetCombatDuration(); // 保留获取以与原逻辑一致

            if (e.Value)
            {
                var result = AppMessageBox.ShowMessage(Properties.Strings.Msg_PilingModeInfo, this);
                if (result == DialogResult.OK)
                {
                    DpsTableDatas.DpsTable.Clear();
                    StatisticData._manager.ClearAll();
                    SkillTableDatas.SkillTable.Clear();
                    Task.Delay(200);
                    AppConfig.PilingMode = true;
                    timer1.Enabled = true;
                }
                else
                {
                    PilingModeCheckbox.Checked = false;
                }
            }
            else
            {
                AppConfig.PilingMode = false;
                timer1.Enabled = false;
            }
        }

        // 主题切换
        private void DpsStatisticsForm_ForeColorChanged(object sender, EventArgs e)
        {
            List<Button> buttonList = new List<Button>() { TotalDamageButton, TotalTreatmentButton, AlwaysInjuredButton, NpcTakeDamageButton };

            if (Config.IsLight)
            {
                sortedProgressBarList1.BackColor = ColorTranslator.FromHtml("#F5F5F5");
                AppConfig.colorText = Color.Black;
                sortedProgressBarList1.OrderColor = Color.Black;
                panel1.Back = ColorTranslator.FromHtml("#F5F5F5"); //bottom
                panel2.Back = ColorTranslator.FromHtml("#F5F5F5"); //top

                TotalDamageButton.Icon = Common.BytesToImage(Properties.Resources.伤害);
                TotalTreatmentButton.Icon = Common.BytesToImage(Properties.Resources.治疗);
                AlwaysInjuredButton.Icon = Common.BytesToImage(Properties.Resources.承伤);
                NpcTakeDamageButton.Icon = Common.BytesToImage(Properties.Resources.Npc);
                Color colorWhite = Color.FromArgb(223, 223, 223);
                foreach (var item in buttonList)
                {
                    item.DefaultBack = Color.FromArgb(247, 247, 247);
                    if (item.Name == "TotalDamageButton" && FormManager.currentIndex == 0)
                    {
                        item.DefaultBack = colorWhite;
                    }
                    if (item.Name == "TotalTreatmentButton" && FormManager.currentIndex == 1)
                    {
                        item.DefaultBack = colorWhite;
                    }
                    if (item.Name == "AlwaysInjuredButton" && FormManager.currentIndex == 2)
                    {
                        item.DefaultBack = colorWhite;
                    }
                    if (item.Name == "NpcTakeDamageButton" && FormManager.currentIndex == 3)
                    {
                        item.DefaultBack = colorWhite;
                    }

                }

            }
            else
            {
                sortedProgressBarList1.BackColor = ColorTranslator.FromHtml("#252527");
                panel1.Back = ColorTranslator.FromHtml("#252527");
                panel2.Back = ColorTranslator.FromHtml("#252527");

                AppConfig.colorText = Color.White;
                sortedProgressBarList1.OrderColor = Color.White;
                TotalDamageButton.Icon = Common.BytesToImage(Properties.Resources.伤害白色);
                TotalTreatmentButton.Icon = Common.BytesToImage(Properties.Resources.治疗白色);
                AlwaysInjuredButton.Icon = Common.BytesToImage(Properties.Resources.承伤白色);
                NpcTakeDamageButton.Icon = Common.BytesToImage(Properties.Resources.NpcWhite);
                Color colorBack = Color.FromArgb(60, 60, 60);
                foreach (var item in buttonList)
                {
                    item.DefaultBack = Color.FromArgb(27, 27, 27);
                    if (item.Name == "TotalDamageButton" && FormManager.currentIndex == 0)
                    {
                        item.DefaultBack = colorBack;
                    }
                    if (item.Name == "TotalTreatmentButton" && FormManager.currentIndex == 1)
                    {
                        item.DefaultBack = colorBack;
                    }
                    if (item.Name == "AlwaysInjuredButton" && FormManager.currentIndex == 2)
                    {
                        item.DefaultBack = colorBack;
                    }
                    if (item.Name == "NpcTakeDamageButton" && FormManager.currentIndex == 3)
                    {
                        item.DefaultBack = colorBack;
                    }

                }
            }

            SetSortedProgressBarListForeColor();
        }

        private void SetSortedProgressBarListForeColor()
        {
            if (sortedProgressBarList1.Data == null) return;

            lock (sortedProgressBarList1.Data)
            {
                foreach (var data in sortedProgressBarList1.Data)
                {
                    if (data.ContentList == null) continue;

                    foreach (var content in data.ContentList)
                    {
                        if (content.Type != Control.GDI.RenderContent.ContentType.Text) continue;

                        content.ForeColor = AppConfig.colorText;
                    }
                }
            }
        }

        private void SetDefaultFontFromResources()
        {
            pageHeader1.Font = AppConfig.SaoFont;
            pageHeader1.SubFont = AppConfig.ContentFont;
            PilingModeCheckbox.Font = AppConfig.ContentFont;
            label2.Font = label1.Font = AppConfig.ContentFont;

            TotalDamageButton.Font = AppConfig.BoldHarmonyFont;
            TotalTreatmentButton.Font = AppConfig.BoldHarmonyFont;
            AlwaysInjuredButton.Font = AppConfig.BoldHarmonyFont;
            NpcTakeDamageButton.Font = AppConfig.BoldHarmonyFont;
        }

        private void SetStartupPositionAndSize()
        {
            var startupRect = AppConfig.StartUpState;
            if (startupRect != null && startupRect != Rectangle.Empty)
            {
                Left = startupRect.Value.Left;
                Top = startupRect.Value.Top;
                Width = startupRect.Value.Width;
                Height = startupRect.Value.Height;
            }
        }

        #region 钩子
        private KeyboardHook KbHook { get; } = new();
        public void RegisterKeyboardHook()
        {
            KbHook.SetHook();
            KbHook.OnKeyDownEvent += kbHook_OnKeyDownEvent;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            try { KbHook?.UnHook(); }
            catch (Exception ex) { Console.WriteLine($"窗体关闭清理时出错: {ex.Message}"); }
            base.OnFormClosed(e);
        }

        public void kbHook_OnKeyDownEvent(object? sender, KeyEventArgs e)
        {
            if (e.KeyData == AppConfig.MouseThroughKey) { HandleMouseThrough(); }
            //else if (e.KeyData == AppConfig.FormTransparencyKey) { HandleFormTransparency(); }
            //else if (e.KeyData == AppConfig.WindowToggleKey) { }
            else if (e.KeyData == AppConfig.ClearDataKey) { HandleClearData(); }
            else if (e.KeyData == AppConfig.ClearHistoryKey)
            {
                StatisticData._manager.ClearSnapshots();//清空快照
                StarResonanceDpsAnalysis.Plugin.DamageStatistics.FullRecord.ClearSessionHistory();//清空全程快照

            }
        }

        private void HandleMouseThrough()
        {
            if (!MousePenetrationHelper.IsPenetrating(this.Handle))
            {
                // 方案 O：AppConfig.Transparency 现在表示“不透明度百分比”
                MousePenetrationHelper.SetMousePenetrate(this, enable: true, opacityPercent: AppConfig.Transparency);
            }
            else
            {
                MousePenetrationHelper.SetMousePenetrate(this, enable: false);
            }
        }

        // 配置变化时实时刷新不透明度（不改变穿透开关）
        private void ApplyOpacityFromConfig()
        {
            MousePenetrationHelper.UpdateOpacityPercent(this.Handle, AppConfig.Transparency);
        }


        bool hyaline = false;

        #endregion



        private void button2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void DpsStatisticsForm_Shown(object sender, EventArgs e)
        {

        }

        private void EnsureTopMost()
        {
            TopMost = false;   // 先关再开，强制触发样式刷新
            TopMost = true;
            Activate();
            BringToFront();
            button_AlwaysOnTop.Toggle = TopMost; // 同步你的按钮状态
        }

        private void DamageType_Click(object sender, EventArgs e)
        {
            ExitNpcDetailMode(); // 退出详情模式
            Button button = (Button)sender;
            List<Button> buttonList = new List<Button>() { TotalDamageButton, TotalTreatmentButton, AlwaysInjuredButton, NpcTakeDamageButton };
            Color colorBack = Color.FromArgb(60, 60, 60);
            Color colorWhite = Color.FromArgb(223, 223, 223);
            foreach (Button btn in buttonList)
            {
                if (btn.Name == button.Name)
                {
                    if (Config.IsLight)
                    {
                        btn.DefaultBack = colorWhite;
                    }
                    else
                    {
                        btn.DefaultBack = colorBack;
                    }

                }
                else
                {
                    if (Config.IsLight)
                    {
                        btn.DefaultBack = Color.FromArgb(247, 247, 247);
                    }
                    else
                    {
                        btn.DefaultBack = Color.FromArgb(27, 27, 27);
                    }

                }

            }

            switch (button.Name)
            {
                //总伤害
                case "TotalDamageButton":
                    FormManager.currentIndex = 0;
                    break;
                //总治疗
                case "TotalTreatmentButton":
                    FormManager.currentIndex = 1;
                    break;
                //总承伤
                case "AlwaysInjuredButton":
                    FormManager.currentIndex = 2;
                    break;
                //NPC承伤
                case "NpcTakeDamageButton":
                    FormManager.currentIndex = 3;
                    break;
            }

            UpdateHeaderText(); // 刷新顶部文本

        }

        private void DpsStatisticsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppConfig.StartUpState = new Rectangle(Left, Top, Width, Height);
        }

        /// <summary>
        /// 退出详情模式
        /// </summary>
        private void ExitNpcDetailMode()
        {
            _npcDetailMode = false;
            _npcFocusId = 0;
        }

        private void button_ThemeSwitch_Click(object sender, EventArgs e)
        {
            AppConfig.IsLight = !AppConfig.IsLight; // # 状态翻转：明/暗

            button_ThemeSwitch.Toggle = !AppConfig.IsLight; // # UI同步：按钮切换状态

            FormGui.SetColorMode(this, AppConfig.IsLight);
            FormGui.SetColorMode(FormManager.skillDiary, AppConfig.IsLight);
            FormGui.SetColorMode(FormManager.mainForm, AppConfig.IsLight);//设置窗体颜色
            FormGui.SetColorMode(FormManager.skillDetailForm, AppConfig.IsLight);//设置窗体颜色
            FormGui.SetColorMode(FormManager.settingsForm, AppConfig.IsLight);//设置窗体颜色
            FormGui.SetColorMode(FormManager.dpsStatistics, AppConfig.IsLight);//设置窗体颜色
            FormGui.SetColorMode(FormManager.rankingsForm, AppConfig.IsLight);//设置窗体颜色
            FormGui.SetColorMode(FormManager.historicalBattlesForm, AppConfig.IsLight);//设置窗体颜色
            FormGui.SetColorMode(FormManager.moduleCalculationForm, AppConfig.IsLight);//设置窗体颜色
        }
        public void ApplyLocalization()
        {
            // Page header
            // pageHeader1.Text = Properties.Strings.Header_DpsStatistics_Title;
            pageHeader1.SubText = Properties.Strings.Header_DpsStatistics_Subtitle;

            // Buttons
            TotalDamageButton.Text = Properties.Strings.TotalDamageLabel;
            TotalTreatmentButton.Text = Properties.Strings.TotalTreatmentLabel;
            AlwaysInjuredButton.Text = Properties.Strings.AlwaysInjuredLabel;
            NpcTakeDamageButton.Text = Properties.Strings.NpcTakeDamageLabel;

            // Checkbox
            PilingModeCheckbox.Text = Properties.Strings.PilingModeCheckboxLabel;
        }

        private void sortedProgressBarList1_Load(object sender, EventArgs e)
        {

        }
    }
}
