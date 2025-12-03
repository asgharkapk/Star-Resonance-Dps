using SharpPcap;
using StarResonanceDpsAnalysis.Core;
using StarResonanceDpsAnalysis.Core.TabelJson;
using StarResonanceDpsAnalysis.Extends;
using StarResonanceDpsAnalysis.Forms;
using StarResonanceDpsAnalysis.Plugin.DamageStatistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarResonanceDpsAnalysis.Plugin.LaunchFunction
{
    public class StartupInitializer
    {

        #region InitTableColumnsConfigAtFirstRun() 首次运行时初始化表头配置

        private void InitTableColumnsConfigAtFirstRun()
        {
            if (AppConfig.GetConfigExists())
            {
                AppConfig.NickName = AppConfig.GetValue("UserConfig", "NickName", "unknown昵称");
                AppConfig.Uid = (ulong)AppConfig.GetValue("UserConfig", "Uid", "0").ToInt();
                AppConfig.Profession = AppConfig.GetValue("UserConfig", "Profession", "unknown职业");
                AppConfig.CombatPower = AppConfig.GetValue("UserConfig", "CombatPower", "0").ToInt();
                StatisticData._manager.SetNickname(AppConfig.Uid, AppConfig.NickName);
                StatisticData._manager.SetProfession(AppConfig.Uid, AppConfig.Profession);
                StatisticData._manager.SetCombatPower(AppConfig.Uid, AppConfig.CombatPower);

                return;
            }



        }

        #endregion

        #region 预装技能加载
        /// <summary>
        /// 软件开启后读取技能列表
        /// </summary>
        public static void LoadFromEmbeddedSkillConfig()
        {
            // 1) 先用 int 键的表（已经解析过字符串）
            foreach (var kv in EmbeddedSkillConfig.AllByInt)
            {
                var id = (ulong)kv.Key;
                var def = kv.Value;

                // 将一条技能元数据（SkillMeta）写入 SkillBook 的全局字典中
                // 这里用的是整条更新（SetOrUpdate），如果该技能 ID 已存在则覆盖，不存在则添加
                SkillBook.SetOrUpdate(new SkillMeta
                {
                    Id = id,                         // 技能 ID（唯一标识一个技能）
                    Name = def.Name,                 // 技能名称（字符串，例如 "火球术"）
                    //School = def.Element.ToString(), // 技能所属元素或流派（枚举转字符串）
                    //Type = def.Type,                 // 技能类型（Damage/Heal/其他）——用于区分伤害技能和治疗技能
                   // Element = def.Element            // 技能元素类型（枚举，例如 火/冰/雷）
                });


            }

            // 2) 有些 ID 可能超出 int 或不在 AllByInt，可以再兜底遍历字符串键
            foreach (var kv in EmbeddedSkillConfig.AllByString)
            {
                if (ulong.TryParse(kv.Key, out var id))
                {
                    // 如果 int 表已覆盖，这里会覆盖同名；没关系，等价
                    var def = kv.Value;
                    // 将一条技能元数据（SkillMeta）写入 SkillBook 的全局字典中
                    // 这里用的是整条更新（SetOrUpdate），如果该技能 ID 已存在则覆盖，不存在则添加
                    SkillBook.SetOrUpdate(new SkillMeta
                    {
                        Id = id,                         // 技能 ID（唯一标识一个技能）
                        Name = def.Name,                 // 技能名称（字符串，例如 "火球术"）
                        //School = def.Element.ToString(), // 技能所属元素或流派（枚举转字符串）
                        //Type = def.Type,                 // 技能类型（Damage/Heal/其他）——用于区分伤害技能和治疗技能
                        //Element = def.Element            // 技能元素类型（枚举，例如 火/冰/雷）
                    });

                }
            }

           // MonsterNameResolver.Initialize(AppConfig.MonsterNames);//初始化怪物ID与名称的映射关系

        

            // 你也可以在这里写日志：加载了多少条技能
            // Console.WriteLine($"SkillBook loaded {EmbeddedSkillConfig.AllByInt.Count} + {EmbeddedSkillConfig.AllByString.Count} entries.");
        }
        #endregion


        /// <summary>
        /// 更新网卡设置提示的显示状态
        /// </summary>
        private static  void UpdateNetworkCardSettingTip()
        {
            try
            {
                // 检查网卡是否已经正确设置
                bool isNetworkCardSet = false;

                if (AppConfig.NetworkCard >= 0)
                {
                    var devices = CaptureDeviceList.Instance;
                    if (devices != null && devices.Count > 0 && AppConfig.NetworkCard < devices.Count)
                    {
                        // 网卡索引有效，认为已经设置
                        isNetworkCardSet = true;
                    
                    }
                }
           

            }
            catch (Exception ex)
            {
                Console.WriteLine($"更新网卡设置提示时出错: {ex.Message}");
            }
        }

        /// <summary>
        /// 公共方法：供外部调用来更新网卡设置提示
        /// </summary>
        public static void RefreshNetworkCardSettingTip()
        {
            UpdateNetworkCardSettingTip(); // # 对外入口：复用内部逻辑
        }

        #region ========== 启用新分析 ==========


        #endregion




    }
}
