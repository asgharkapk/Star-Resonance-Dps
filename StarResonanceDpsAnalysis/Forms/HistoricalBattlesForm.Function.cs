using StarResonanceDpsAnalysis.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarResonanceDpsAnalysis.Forms
{
    public partial class HistoricalBattlesForm
    {
        public void ToggleTableView()
        {

            table_DpsDetailDataTable.Columns.Clear();

            table_DpsDetailDataTable.Columns = new AntdUI.ColumnCollection
            {
              new AntdUI.Column("Uid", "UID"),
                new AntdUI.Column("NickName", "UserName"),
                new AntdUI.Column("Profession", "Class"),
                new AntdUI.Column("CombatPower", "AbolityScore"),
                new AntdUI.Column("TotalDamage", "TotalDamage"),
                new AntdUI.Column("TotalDps", "TotalDps"),
                new AntdUI.Column("CritRate", "CritRate"),
                new AntdUI.Column("LuckyRate", "LuckyRate"),
                new AntdUI.Column("CriticalDamage", "CriticalDamage"),
                new AntdUI.Column("LuckyDamage", "LuckyDamage"),
                new AntdUI.Column("CritLuckyDamage", "CritLuckyDamage"),
                new AntdUI.Column("MaxInstantDps", "MaxInstantDps"),

                new AntdUI.Column("TotalHealingDone", "TotalHealingDone"),
                new AntdUI.Column("TotalHps", "TotalHps"),
                new AntdUI.Column("CriticalHealingDone", "CriticalHealingDone"),
                new AntdUI.Column("LuckyHealingDone", "LuckyHealingDone"),
                new AntdUI.Column("CritLuckyHealingDone", "CritLuckyHealingDone"),
                new AntdUI.Column("MaxInstantHps", "MaxInstantHps"),
                new AntdUI.Column("DamageTaken", "DamageTaken"),
               // new AntdUI.Column("Share","Share"),
                new AntdUI.Column("DmgShare","DmgShare"),
            };

            table_DpsDetailDataTable.Binding(DpsTableDatas.DpsTable);


        }
    }


}
