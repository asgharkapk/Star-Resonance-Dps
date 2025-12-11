namespace StarResonanceDpsAnalysis.Core
{
    // Auto-generated from skill_config.json (v2.0.1)
    public enum SkillType
    {
        Damage,
        Heal,
        Unknown
    }

    public enum ElementType
    {
        Dark,
        Earth,
        Fire,
        Ice,
        Light,
        Thunder,
        Wind,
        Physics,   // ← 新增
        Unknown
    }

    public sealed class SkillDefinition
    {
        public string Name              { get; set; }  = "";
        public SkillType Type           { get; set; }  = SkillType.Unknown;
        public ElementType Element      { get; set; }  = ElementType.Unknown;
        public string Description       { get; set; }  = "";
        public string NameKey           { get; set; }  = "";
        public string DescriptionKey    { get; set; }  = "";
    }

    public sealed class ElementInfo
    {
        public string Color { get; set; }   = "#FFFFFF";
        public string Icon  { get; set; }   = "";
    }

    public static class EmbeddedSkillConfig
    {
        public static readonly string Version       = "2.0.1";      // ← 更新
        public static readonly string LastUpdated   = "2025-01-20"; // ← 更新

        // 与 skill_config.json 的 elements 完全一致
        public static readonly Dictionary<ElementType, ElementInfo> Elements = new()
        {
            [ElementType.Fire]      = new ElementInfo { Color = "#ff6b6b", Icon = "🔥" },
            [ElementType.Ice]       = new ElementInfo { Color = "#74c0fc", Icon = "❄️" },
            [ElementType.Thunder]   = new ElementInfo { Color = "#ffd43b", Icon = "⚡" },
            [ElementType.Earth]     = new ElementInfo { Color = "#8ce99a", Icon = "🍀" }, // ← 图标从🌍改为🍀
            [ElementType.Wind]      = new ElementInfo { Color = "#91a7ff", Icon = "💨" },
            [ElementType.Light]     = new ElementInfo { Color = "#fff3bf", Icon = "✨" },
            [ElementType.Dark]      = new ElementInfo { Color = "#9775fa", Icon = "🌙" },
            [ElementType.Physics]   = new ElementInfo { Color = "#91a7ff", Icon = "⚔️" }  // ← 新增
        };

        public static SkillDefinition GetLocalizedSkillDefinition(string id)
        {
            if (!SkillsById.TryGetValue(id, out var def))
                return new SkillDefinition { NameKey = id, DescriptionKey = id, Type = SkillType.Unknown, Element = ElementType.Unknown };

            return new SkillDefinition
            {
                NameKey             = def.NameKey,
                DescriptionKey      = def.DescriptionKey,
                Type                = def.Type,
                Element             = def.Element,
                Name                = Properties.Skills.ResourceManager.GetString(def.NameKey)          ?? def.NameKey,
                Description         = Properties.Skills.ResourceManager.GetString(def.DescriptionKey)   ?? def.DescriptionKey
            };
        }

        public static readonly Dictionary<string, SkillDefinition> SkillsById = new()
        {
            ["1401"]       = new SkillDefinition { NameKey = "Skill_1401_Name",       DescriptionKey = "Skill_1401_Desc",       Type = SkillType.Damage, Element = ElementType.Wind },
            ["1402"]       = new SkillDefinition { NameKey = "Skill_1402_Name",       DescriptionKey = "Skill_1402_Desc",       Type = SkillType.Damage, Element = ElementType.Wind },
            ["1409"]       = new SkillDefinition { NameKey = "Skill_1409_Name",       DescriptionKey = "Skill_1409_Desc",       Type = SkillType.Damage, Element = ElementType.Wind },
            ["1403"]       = new SkillDefinition { NameKey = "Skill_1403_Name",       DescriptionKey = "Skill_1403_Desc",       Type = SkillType.Damage, Element = ElementType.Wind },
            ["1404"]       = new SkillDefinition { NameKey = "Skill_1404_Name",       DescriptionKey = "Skill_1404_Desc",       Type = SkillType.Damage, Element = ElementType.Wind },
            ["1420"]       = new SkillDefinition { NameKey = "Skill_1420_Name",       DescriptionKey = "Skill_1420_Desc",       Type = SkillType.Damage, Element = ElementType.Wind },
            ["2031104"]    = new SkillDefinition { NameKey = "Skill_2031104_Name",    DescriptionKey = "Skill_2031104_Desc",    Type = SkillType.Damage, Element = ElementType.Light },
            ["1418"]       = new SkillDefinition { NameKey = "Skill_1418_Name",       DescriptionKey = "Skill_1418_Desc",       Type = SkillType.Damage, Element = ElementType.Wind },
            ["1421"]       = new SkillDefinition { NameKey = "Skill_1421_Name",       DescriptionKey = "Skill_1421_Desc",       Type = SkillType.Damage, Element = ElementType.Wind },
            ["1434"]       = new SkillDefinition { NameKey = "Skill_1434_Name",       DescriptionKey = "Skill_1434_Desc",       Type = SkillType.Damage, Element = ElementType.Wind },
            ["140301"]     = new SkillDefinition { NameKey = "Skill_140301_Name",     DescriptionKey = "Skill_140301_Desc",     Type = SkillType.Damage, Element = ElementType.Wind },
            ["1422"]       = new SkillDefinition { NameKey = "Skill_1422_Name",       DescriptionKey = "Skill_1422_Desc",       Type = SkillType.Damage, Element = ElementType.Wind },
            ["1427"]       = new SkillDefinition { NameKey = "Skill_1427_Name",       DescriptionKey = "Skill_1427_Desc",       Type = SkillType.Damage, Element = ElementType.Wind },
            ["31901"]      = new SkillDefinition { NameKey = "Skill_31901_Name",      DescriptionKey = "Skill_31901_Desc",      Type = SkillType.Damage, Element = ElementType.Wind },
            ["2205450"]    = new SkillDefinition { NameKey = "Skill_2205450_Name",    DescriptionKey = "Skill_2205450_Desc",    Type = SkillType.Damage, Element = ElementType.Wind },
            ["1411"]       = new SkillDefinition { NameKey = "Skill_1411_Name",       DescriptionKey = "Skill_1411_Desc",       Type = SkillType.Damage, Element = ElementType.Wind },
            ["1435"]       = new SkillDefinition { NameKey = "Skill_1435_Name",       DescriptionKey = "Skill_1435_Desc",       Type = SkillType.Damage, Element = ElementType.Wind },
            ["140401"]     = new SkillDefinition { NameKey = "Skill_140401_Name",     DescriptionKey = "Skill_140401_Desc",     Type = SkillType.Damage, Element = ElementType.Wind },
            ["2205071"]    = new SkillDefinition { NameKey = "Skill_2205071_Name",    DescriptionKey = "Skill_2205071_Desc",    Type = SkillType.Damage, Element = ElementType.Wind },
            ["149901"]     = new SkillDefinition { NameKey = "Skill_149901_Name",     DescriptionKey = "Skill_149901_Desc",     Type = SkillType.Damage, Element = ElementType.Wind },
            ["1419"]       = new SkillDefinition { NameKey = "Skill_1419_Name",       DescriptionKey = "Skill_1419_Desc",       Type = SkillType.Damage, Element = ElementType.Wind },
            ["1424"]       = new SkillDefinition { NameKey = "Skill_1424_Name",       DescriptionKey = "Skill_1424_Desc",       Type = SkillType.Damage, Element = ElementType.Wind },
            ["1425"]       = new SkillDefinition { NameKey = "Skill_1425_Name",       DescriptionKey = "Skill_1425_Desc",       Type = SkillType.Damage, Element = ElementType.Wind },
            ["149905"]     = new SkillDefinition { NameKey = "Skill_149905_Name",     DescriptionKey = "Skill_149905_Desc",     Type = SkillType.Damage, Element = ElementType.Wind },
            ["1433"]       = new SkillDefinition { NameKey = "Skill_1433_Name",       DescriptionKey = "Skill_1433_Desc",       Type = SkillType.Damage, Element = ElementType.Wind },
            ["149906"]     = new SkillDefinition { NameKey = "Skill_149906_Name",     DescriptionKey = "Skill_149906_Desc",     Type = SkillType.Damage, Element = ElementType.Wind },
            ["149907"]     = new SkillDefinition { NameKey = "Skill_149907_Name",     DescriptionKey = "Skill_149907_Desc",     Type = SkillType.Damage, Element = ElementType.Wind },
            ["1431"]       = new SkillDefinition { NameKey = "Skill_1431_Name",       DescriptionKey = "Skill_1431_Desc",       Type = SkillType.Damage, Element = ElementType.Wind },
            ["149902"]     = new SkillDefinition { NameKey = "Skill_149902_Name",     DescriptionKey = "Skill_149902_Desc",     Type = SkillType.Damage, Element = ElementType.Wind },
            ["140501"]     = new SkillDefinition { NameKey = "Skill_140501_Name",     DescriptionKey = "Skill_140501_Desc",     Type = SkillType.Damage, Element = ElementType.Wind },
            // -----------------------------
            // Thunder Skills (Damage)
            // -----------------------------
            ["1701"]      = new SkillDefinition { NameKey = "Skill_1701_Name",      DescriptionKey = "Skill_1701_Desc",      Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1702"]      = new SkillDefinition { NameKey = "Skill_1702_Name",      DescriptionKey = "Skill_1702_Desc",      Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1703"]      = new SkillDefinition { NameKey = "Skill_1703_Name",      DescriptionKey = "Skill_1703_Desc",      Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1704"]      = new SkillDefinition { NameKey = "Skill_1704_Name",      DescriptionKey = "Skill_1704_Desc",      Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1713"]      = new SkillDefinition { NameKey = "Skill_1713_Name",      DescriptionKey = "Skill_1713_Desc",      Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1728"]      = new SkillDefinition { NameKey = "Skill_1728_Name",      DescriptionKey = "Skill_1728_Desc",      Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1714"]      = new SkillDefinition { NameKey = "Skill_1714_Name",      DescriptionKey = "Skill_1714_Desc",      Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1717"]      = new SkillDefinition { NameKey = "Skill_1717_Name",      DescriptionKey = "Skill_1717_Desc",      Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1718"]      = new SkillDefinition { NameKey = "Skill_1718_Name",      DescriptionKey = "Skill_1718_Desc",      Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1735"]      = new SkillDefinition { NameKey = "Skill_1735_Name",      DescriptionKey = "Skill_1735_Desc",      Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1736"]      = new SkillDefinition { NameKey = "Skill_1736_Name",      DescriptionKey = "Skill_1736_Desc",      Type = SkillType.Damage, Element = ElementType.Thunder },
            ["155101"]    = new SkillDefinition { NameKey = "Skill_155101_Name",    DescriptionKey = "Skill_155101_Desc",    Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1715"]      = new SkillDefinition { NameKey = "Skill_1715_Name",      DescriptionKey = "Skill_1715_Desc",      Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1719"]      = new SkillDefinition { NameKey = "Skill_1719_Name",      DescriptionKey = "Skill_1719_Desc",      Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1724"]      = new SkillDefinition { NameKey = "Skill_1724_Name",      DescriptionKey = "Skill_1724_Desc",      Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1705"]      = new SkillDefinition { NameKey = "Skill_1705_Name",      DescriptionKey = "Skill_1705_Desc",      Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1732"]      = new SkillDefinition { NameKey = "Skill_1732_Name",      DescriptionKey = "Skill_1732_Desc",      Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1737"]      = new SkillDefinition { NameKey = "Skill_1737_Name",      DescriptionKey = "Skill_1737_Desc",      Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1738"]      = new SkillDefinition { NameKey = "Skill_1738_Name",      DescriptionKey = "Skill_1738_Desc",      Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1739"]      = new SkillDefinition { NameKey = "Skill_1739_Name",      DescriptionKey = "Skill_1739_Desc",      Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1740"]      = new SkillDefinition { NameKey = "Skill_1740_Name",      DescriptionKey = "Skill_1740_Desc",      Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1741"]      = new SkillDefinition { NameKey = "Skill_1741_Name",      DescriptionKey = "Skill_1741_Desc",      Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1742"]      = new SkillDefinition { NameKey = "Skill_1742_Name",      DescriptionKey = "Skill_1742_Desc",      Type = SkillType.Damage, Element = ElementType.Thunder },
            ["44701"]     = new SkillDefinition { NameKey = "Skill_44701_Name",     DescriptionKey = "Skill_44701_Desc",     Type = SkillType.Damage, Element = ElementType.Thunder },
            ["179908"]    = new SkillDefinition { NameKey = "Skill_179908_Name",    DescriptionKey = "Skill_179908_Desc",    Type = SkillType.Damage, Element = ElementType.Thunder },
            ["179906"]    = new SkillDefinition { NameKey = "Skill_179906_Name",    DescriptionKey = "Skill_179906_Desc",    Type = SkillType.Damage, Element = ElementType.Thunder },

            // -----------------------------
            // Light Skills (Damage)
            // -----------------------------
            ["2031101"]   = new SkillDefinition { NameKey = "Skill_2031101_Name",   DescriptionKey = "Skill_2031101_Desc",   Type = SkillType.Damage, Element = ElementType.Light },

            // -----------------------------
            // Fire Skills (Damage / Heal / Unknown)
            // -----------------------------
            ["2330"]      = new SkillDefinition { NameKey = "Skill_2330_Name",      DescriptionKey = "Skill_2330_Desc",      Type = SkillType.Unknown, Element = ElementType.Unknown }, // Special/Unknown
            ["55314"]     = new SkillDefinition { NameKey = "Skill_55314_Name",     DescriptionKey = "Skill_55314_Desc",     Type = SkillType.Heal,    Element = ElementType.Fire },    // Heal
            ["230101"]    = new SkillDefinition { NameKey = "Skill_230101_Name",    DescriptionKey = "Skill_230101_Desc",    Type = SkillType.Heal,    Element = ElementType.Fire },    // Heal
            ["230401"]    = new SkillDefinition { NameKey = "Skill_230401_Name",    DescriptionKey = "Skill_230401_Desc",    Type = SkillType.Damage,  Element = ElementType.Fire },
            ["230501"]    = new SkillDefinition { NameKey = "Skill_230501_Name",    DescriptionKey = "Skill_230501_Desc",    Type = SkillType.Damage,  Element = ElementType.Fire },
            ["2031111"]   = new SkillDefinition { NameKey = "Skill_2031111_Name",   DescriptionKey = "Skill_2031111_Desc",   Type = SkillType.Damage,  Element = ElementType.Light },
            ["2306"]      = new SkillDefinition { NameKey = "Skill_2306_Name",      DescriptionKey = "Skill_2306_Desc",      Type = SkillType.Damage,  Element = ElementType.Fire },
            ["2317"]      = new SkillDefinition { NameKey = "Skill_2317_Name",      DescriptionKey = "Skill_2317_Desc",      Type = SkillType.Damage,  Element = ElementType.Fire },
            ["2321"]      = new SkillDefinition { NameKey = "Skill_2321_Name",      DescriptionKey = "Skill_2321_Desc",      Type = SkillType.Damage,  Element = ElementType.Fire },
            ["2322"]      = new SkillDefinition { NameKey = "Skill_2322_Name",      DescriptionKey = "Skill_2322_Desc",      Type = SkillType.Damage,  Element = ElementType.Fire },
            ["2323"]      = new SkillDefinition { NameKey = "Skill_2323_Name",      DescriptionKey = "Skill_2323_Desc",      Type = SkillType.Damage,  Element = ElementType.Fire },
            ["2324"]      = new SkillDefinition { NameKey = "Skill_2324_Name",      DescriptionKey = "Skill_2324_Desc",      Type = SkillType.Damage,  Element = ElementType.Fire },
            // -----------------------------
            // Fire Skills - Unknown
            // -----------------------------
            ["2331"]      = new SkillDefinition { NameKey = "Skill_2331_Name",      DescriptionKey = "Skill_2331_Desc",      Type = SkillType.Unknown, Element = ElementType.Unknown }, // Special / Unknown
            ["2335"]      = new SkillDefinition { NameKey = "Skill_2335_Name",      DescriptionKey = "Skill_2335_Desc",      Type = SkillType.Unknown, Element = ElementType.Unknown }, // Special / Unknown

            // -----------------------------
            // Fire Skills - Damage
            // -----------------------------
            ["230102"]    = new SkillDefinition { NameKey = "Skill_230102_Name",    DescriptionKey = "Skill_230102_Desc",    Type = SkillType.Damage, Element = ElementType.Fire },
            ["230103"]    = new SkillDefinition { NameKey = "Skill_230103_Name",    DescriptionKey = "Skill_230103_Desc",    Type = SkillType.Damage, Element = ElementType.Fire },

            // -----------------------------
            // Fire Skills - Damage
            // -----------------------------
            ["230104"] = new SkillDefinition { NameKey = "Skill_230104_Name", DescriptionKey = "Skill_230104_Desc", Type = SkillType.Damage, Element = ElementType.Fire },
            ["230105"] = new SkillDefinition { NameKey = "Skill_230105_Name", DescriptionKey = "Skill_230105_Desc", Type = SkillType.Damage, Element = ElementType.Fire },

            
            ["230106"]    = new SkillDefinition { NameKey = "Skill_230106_Name",    DescriptionKey = "Skill_230106_Desc",    Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["231001"]    = new SkillDefinition { NameKey = "Skill_231001_Name",    DescriptionKey = "Skill_231001_Desc",    Type = SkillType.Damage,  Element = ElementType.Fire },
            ["55301"]     = new SkillDefinition { NameKey = "Skill_55301_Name",     DescriptionKey = "Skill_55301_Desc",     Type = SkillType.Heal,    Element = ElementType.Fire },
            ["55311"]     = new SkillDefinition { NameKey = "Skill_55311_Name",     DescriptionKey = "Skill_55311_Desc",     Type = SkillType.Heal,    Element = ElementType.Fire },
            ["55341"]     = new SkillDefinition { NameKey = "Skill_55341_Name",     DescriptionKey = "Skill_55341_Desc",     Type = SkillType.Heal,    Element = ElementType.Fire },
            ["55346"]     = new SkillDefinition { NameKey = "Skill_55346_Name",     DescriptionKey = "Skill_55346_Desc",     Type = SkillType.Heal,    Element = ElementType.Fire },
            ["55355"]     = new SkillDefinition { NameKey = "Skill_55355_Name",     DescriptionKey = "Skill_55355_Desc",     Type = SkillType.Heal,    Element = ElementType.Fire },
            ["2207141"]   = new SkillDefinition { NameKey = "Skill_2207141_Name",   DescriptionKey = "Skill_2207141_Desc",   Type = SkillType.Heal,    Element = ElementType.Fire },
            ["2207151"]   = new SkillDefinition { NameKey = "Skill_2207151_Name",   DescriptionKey = "Skill_2207151_Desc",   Type = SkillType.Heal,    Element = ElementType.Fire },
            ["2207431"]   = new SkillDefinition { NameKey = "Skill_2207431_Name",   DescriptionKey = "Skill_2207431_Desc",   Type = SkillType.Heal,    Element = ElementType.Fire },
            ["2301"]      = new SkillDefinition { NameKey = "Skill_2301_Name",      DescriptionKey = "Skill_2301_Desc",      Type = SkillType.Damage,  Element = ElementType.Fire },
            ["2302"]      = new SkillDefinition { NameKey = "Skill_2302_Name",      DescriptionKey = "Skill_2302_Desc",      Type = SkillType.Damage,  Element = ElementType.Fire },
            ["2303"]      = new SkillDefinition { NameKey = "Skill_2303_Name",      DescriptionKey = "Skill_2303_Desc",      Type = SkillType.Damage,  Element = ElementType.Fire },
            ["2304"]      = new SkillDefinition { NameKey = "Skill_2304_Name",      DescriptionKey = "Skill_2304_Desc",      Type = SkillType.Damage,  Element = ElementType.Fire },
            ["2312"]      = new SkillDefinition { NameKey = "Skill_2312_Name",      DescriptionKey = "Skill_2312_Desc",      Type = SkillType.Damage,  Element = ElementType.Fire },
            ["2313"]      = new SkillDefinition { NameKey = "Skill_2313_Name",      DescriptionKey = "Skill_2313_Desc",      Type = SkillType.Damage,  Element = ElementType.Fire },
            ["2332"]      = new SkillDefinition { NameKey = "Skill_2332_Name",      DescriptionKey = "Skill_2332_Desc",      Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2336"]      = new SkillDefinition { NameKey = "Skill_2336_Name",      DescriptionKey = "Skill_2336_Desc",      Type = SkillType.Damage,  Element = ElementType.Fire },
            ["2366"]      = new SkillDefinition { NameKey = "Skill_2366_Name",      DescriptionKey = "Skill_2366_Desc",      Type = SkillType.Damage,  Element = ElementType.Fire },
            ["55302"]     = new SkillDefinition { NameKey = "Skill_55302_Name",     DescriptionKey = "Skill_55302_Desc",     Type = SkillType.Heal,    Element = ElementType.Fire },
            ["55304"]     = new SkillDefinition { NameKey = "Skill_55304_Name",     DescriptionKey = "Skill_55304_Desc",     Type = SkillType.Heal,    Element = ElementType.Fire },
            ["55339"]     = new SkillDefinition { NameKey = "Skill_55339_Name",     DescriptionKey = "Skill_55339_Desc",     Type = SkillType.Heal,    Element = ElementType.Fire },
            ["55342"]     = new SkillDefinition { NameKey = "Skill_55342_Name",     DescriptionKey = "Skill_55342_Desc",     Type = SkillType.Heal,    Element = ElementType.Fire },
            ["2207620"]   = new SkillDefinition { NameKey = "Skill_2207620_Name",   DescriptionKey = "Skill_2207620_Desc",   Type = SkillType.Heal,    Element = ElementType.Fire },

            ["1501"] = new SkillDefinition { NameKey = "Skill_1501_Name", DescriptionKey = "Skill_1501_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["1502"] = new SkillDefinition { NameKey = "Skill_1502_Name", DescriptionKey = "Skill_1502_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["1503"] = new SkillDefinition { NameKey = "Skill_1503_Name", DescriptionKey = "Skill_1503_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["1504"] = new SkillDefinition { NameKey = "Skill_1504_Name", DescriptionKey = "Skill_1504_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["1509"] = new SkillDefinition { NameKey = "Skill_1509_Name", DescriptionKey = "Skill_1509_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["1518"] = new SkillDefinition { NameKey = "Skill_1518_Name", DescriptionKey = "Skill_1518_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["1529"] = new SkillDefinition { NameKey = "Skill_1529_Name", DescriptionKey = "Skill_1529_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["1550"] = new SkillDefinition { NameKey = "Skill_1550_Name", DescriptionKey = "Skill_1550_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["1551"] = new SkillDefinition { NameKey = "Skill_1551_Name", DescriptionKey = "Skill_1551_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["1560"] = new SkillDefinition { NameKey = "Skill_1560_Name", DescriptionKey = "Skill_1560_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["20301"] = new SkillDefinition { NameKey = "Skill_20301_Name", DescriptionKey = "Skill_20301_Desc", Type = SkillType.Heal, Element = ElementType.Earth },
            ["21402"] = new SkillDefinition { NameKey = "Skill_21402_Name", DescriptionKey = "Skill_21402_Desc", Type = SkillType.Heal, Element = ElementType.Earth },
            ["21404"] = new SkillDefinition { NameKey = "Skill_21404_Name", DescriptionKey = "Skill_21404_Desc", Type = SkillType.Heal, Element = ElementType.Earth },
            ["21406"] = new SkillDefinition { NameKey = "Skill_21406_Name", DescriptionKey = "Skill_21406_Desc", Type = SkillType.Heal, Element = ElementType.Earth },
            ["21414"] = new SkillDefinition { NameKey = "Skill_21414_Name", DescriptionKey = "Skill_21414_Desc", Type = SkillType.Heal, Element = ElementType.Earth },
            ["21427"] = new SkillDefinition { NameKey = "Skill_21427_Name", DescriptionKey = "Skill_21427_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["21428"] = new SkillDefinition { NameKey = "Skill_21428_Name", DescriptionKey = "Skill_21428_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["21429"] = new SkillDefinition { NameKey = "Skill_21429_Name", DescriptionKey = "Skill_21429_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["21430"] = new SkillDefinition { NameKey = "Skill_21430_Name", DescriptionKey = "Skill_21430_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["150103"] = new SkillDefinition { NameKey = "Skill_150103_Name", DescriptionKey = "Skill_150103_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["150104"] = new SkillDefinition { NameKey = "Skill_150104_Name", DescriptionKey = "Skill_150104_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["150106"] = new SkillDefinition { NameKey = "Skill_150106_Name", DescriptionKey = "Skill_150106_Desc", Type = SkillType.Heal, Element = ElementType.Earth },
            ["150107"] = new SkillDefinition { NameKey = "Skill_150107_Name", DescriptionKey = "Skill_150107_Desc", Type = SkillType.Heal, Element = ElementType.Earth },
            ["2031005"] = new SkillDefinition { NameKey = "Skill_2031005_Name", DescriptionKey = "Skill_2031005_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2202091"] = new SkillDefinition { NameKey = "Skill_2202091_Name", DescriptionKey = "Skill_2202091_Desc", Type = SkillType.Heal, Element = ElementType.Earth },
            ["2202311"] = new SkillDefinition { NameKey = "Skill_2202311_Name", DescriptionKey = "Skill_2202311_Desc", Type = SkillType.Heal, Element = ElementType.Earth },
            ["1541"] = new SkillDefinition { NameKey = "Skill_1541_Name", DescriptionKey = "Skill_1541_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["1561"] = new SkillDefinition { NameKey = "Skill_1561_Name", DescriptionKey = "Skill_1561_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["21423"] = new SkillDefinition { NameKey = "Skill_21423_Name", DescriptionKey = "Skill_21423_Desc", Type = SkillType.Heal, Element = ElementType.Earth },
            ["21424"] = new SkillDefinition { NameKey = "Skill_21424_Name", DescriptionKey = "Skill_21424_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["150101"] = new SkillDefinition { NameKey = "Skill_150101_Name", DescriptionKey = "Skill_150101_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["150110"] = new SkillDefinition { NameKey = "Skill_150110_Name", DescriptionKey = "Skill_150110_Desc", Type = SkillType.Heal, Element = ElementType.Earth },
            ["2031105"] = new SkillDefinition { NameKey = "Skill_2031105_Name", DescriptionKey = "Skill_2031105_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["220101"] = new SkillDefinition { NameKey = "Skill_220101_Name", DescriptionKey = "Skill_220101_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["220103"] = new SkillDefinition { NameKey = "Skill_220103_Name", DescriptionKey = "Skill_220103_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["220104"] = new SkillDefinition { NameKey = "Skill_220104_Name", DescriptionKey = "Skill_220104_Desc", Type = SkillType.Damage, Element = ElementType.Wind },
            ["2295"] = new SkillDefinition { NameKey = "Skill_2295_Name", DescriptionKey = "Skill_2295_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2291"] = new SkillDefinition { NameKey = "Skill_2291_Name", DescriptionKey = "Skill_2291_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2289"] = new SkillDefinition { NameKey = "Skill_2289_Name", DescriptionKey = "Skill_2289_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["2233"] = new SkillDefinition { NameKey = "Skill_2233_Name", DescriptionKey = "Skill_2233_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2288"] = new SkillDefinition { NameKey = "Skill_2288_Name", DescriptionKey = "Skill_2288_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["220102"] = new SkillDefinition { NameKey = "Skill_220102_Name", DescriptionKey = "Skill_220102_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["220108"] = new SkillDefinition { NameKey = "Skill_220108_Name", DescriptionKey = "Skill_220108_Desc", Type = SkillType.Damage, Element = ElementType.Fire },
            ["220109"] = new SkillDefinition { NameKey = "Skill_220109_Name", DescriptionKey = "Skill_220109_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["1700820"] = new SkillDefinition { NameKey = "Skill_1700820_Name", DescriptionKey = "Skill_1700820_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["1700827"] = new SkillDefinition { NameKey = "Skill_1700827_Name", DescriptionKey = "Skill_1700827_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["2292"] = new SkillDefinition { NameKey = "Skill_2292_Name", DescriptionKey = "Skill_2292_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["2203512"] = new SkillDefinition { NameKey = "Skill_2203512_Name", DescriptionKey = "Skill_2203512_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["55231"] = new SkillDefinition { NameKey = "Skill_55231_Name", DescriptionKey = "Skill_55231_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["220110"] = new SkillDefinition { NameKey = "Skill_220110_Name", DescriptionKey = "Skill_220110_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2203291"] = new SkillDefinition { NameKey = "Skill_2203291_Name", DescriptionKey = "Skill_2203291_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["220113"] = new SkillDefinition { NameKey = "Skill_220113_Name", DescriptionKey = "Skill_220113_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2203621"] = new SkillDefinition { NameKey = "Skill_2203621_Name", DescriptionKey = "Skill_2203621_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2203622"] = new SkillDefinition { NameKey = "Skill_2203622_Name", DescriptionKey = "Skill_2203622_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["220112"] = new SkillDefinition { NameKey = "Skill_220112_Name", DescriptionKey = "Skill_220112_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["220106"] = new SkillDefinition { NameKey = "Skill_220106_Name", DescriptionKey = "Skill_220106_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2203521"] = new SkillDefinition { NameKey = "Skill_2203521_Name", DescriptionKey = "Skill_2203521_Desc", Type = SkillType.Damage, Element = ElementType.Thunder },
            ["2203181"] = new SkillDefinition { NameKey = "Skill_2203181_Name", DescriptionKey = "Skill_2203181_Desc", Type = SkillType.Damage, Element = ElementType.Thunder },
            ["2294"] = new SkillDefinition { NameKey = "Skill_2294_Name", DescriptionKey = "Skill_2294_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["220111"] = new SkillDefinition { NameKey = "Skill_220111_Name", DescriptionKey = "Skill_220111_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["220203"] = new SkillDefinition { NameKey = "Skill_220203_Name", DescriptionKey = "Skill_220203_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2031109"] = new SkillDefinition { NameKey = "Skill_2031109_Name", DescriptionKey = "Skill_2031109_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["220301"] = new SkillDefinition { NameKey = "Skill_220301_Name", DescriptionKey = "Skill_220301_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2352"] = new SkillDefinition { NameKey = "Skill_2352_Name", DescriptionKey = "Skill_2352_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["120401"] = new SkillDefinition { NameKey = "Skill_120401_Name", DescriptionKey = "Skill_120401_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["1203"] = new SkillDefinition { NameKey = "Skill_1203_Name", DescriptionKey = "Skill_1203_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["120501"] = new SkillDefinition { NameKey = "Skill_120501_Name", DescriptionKey = "Skill_120501_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["120201"] = new SkillDefinition { NameKey = "Skill_120201_Name", DescriptionKey = "Skill_120201_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["120301"] = new SkillDefinition { NameKey = "Skill_120301_Name", DescriptionKey = "Skill_120301_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["2031102"] = new SkillDefinition { NameKey = "Skill_2031102_Name", DescriptionKey = "Skill_2031102_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["1248"] = new SkillDefinition { NameKey = "Skill_1248_Name", DescriptionKey = "Skill_1248_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["1263"] = new SkillDefinition { NameKey = "Skill_1263_Name", DescriptionKey = "Skill_1263_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["120902"] = new SkillDefinition { NameKey = "Skill_120902_Name", DescriptionKey = "Skill_120902_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["1262"] = new SkillDefinition { NameKey = "Skill_1262_Name", DescriptionKey = "Skill_1262_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["121501"] = new SkillDefinition { NameKey = "Skill_121501_Name", DescriptionKey = "Skill_121501_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["1216"] = new SkillDefinition { NameKey = "Skill_1216_Name", DescriptionKey = "Skill_1216_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["1257"] = new SkillDefinition { NameKey = "Skill_1257_Name", DescriptionKey = "Skill_1257_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["1250"] = new SkillDefinition { NameKey = "Skill_1250_Name", DescriptionKey = "Skill_1250_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["2204081"] = new SkillDefinition { NameKey = "Skill_2204081_Name", DescriptionKey = "Skill_2204081_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["121302"] = new SkillDefinition { NameKey = "Skill_121302_Name", DescriptionKey = "Skill_121302_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["1259"] = new SkillDefinition { NameKey = "Skill_1259_Name", DescriptionKey = "Skill_1259_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["120901"] = new SkillDefinition { NameKey = "Skill_120901_Name", DescriptionKey = "Skill_120901_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["2204241"] = new SkillDefinition { NameKey = "Skill_2204241_Name", DescriptionKey = "Skill_2204241_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["1261"] = new SkillDefinition { NameKey = "Skill_1261_Name", DescriptionKey = "Skill_1261_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["2401"] = new SkillDefinition { NameKey = "Skill_2401_Name", DescriptionKey = "Skill_2401_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2402"] = new SkillDefinition { NameKey = "Skill_2402_Name", DescriptionKey = "Skill_2402_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2403"] = new SkillDefinition { NameKey = "Skill_2403_Name", DescriptionKey = "Skill_2403_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2404"] = new SkillDefinition { NameKey = "Skill_2404_Name", DescriptionKey = "Skill_2404_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2416"] = new SkillDefinition { NameKey = "Skill_2416_Name", DescriptionKey = "Skill_2416_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2417"] = new SkillDefinition { NameKey = "Skill_2417_Name", DescriptionKey = "Skill_2417_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2407"] = new SkillDefinition { NameKey = "Skill_2407_Name", DescriptionKey = "Skill_2407_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2031110"] = new SkillDefinition { NameKey = "Skill_2031110_Name", DescriptionKey = "Skill_2031110_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2405"] = new SkillDefinition { NameKey = "Skill_2405_Name", DescriptionKey = "Skill_2405_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2450"] = new SkillDefinition { NameKey = "Skill_2450_Name", DescriptionKey = "Skill_2450_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2410"] = new SkillDefinition { NameKey = "Skill_2410_Name", DescriptionKey = "Skill_2410_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2451"] = new SkillDefinition { NameKey = "Skill_2451_Name", DescriptionKey = "Skill_2451_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2452"] = new SkillDefinition { NameKey = "Skill_2452_Name", DescriptionKey = "Skill_2452_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2412"] = new SkillDefinition { NameKey = "Skill_2412_Name", DescriptionKey = "Skill_2412_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2413"] = new SkillDefinition { NameKey = "Skill_2413_Name", DescriptionKey = "Skill_2413_Desc", Type = SkillType.Damage, Element = ElementType.Fire },
            ["240101"] = new SkillDefinition { NameKey = "Skill_240101_Name", DescriptionKey = "Skill_240101_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2206401"] = new SkillDefinition { NameKey = "Skill_2206401_Name", DescriptionKey = "Skill_2206401_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["55421"] = new SkillDefinition { NameKey = "Skill_55421_Name", DescriptionKey = "Skill_55421_Desc", Type = SkillType.Heal, Element = ElementType.Light },
            ["55404"] = new SkillDefinition { NameKey = "Skill_55404_Name", DescriptionKey = "Skill_55404_Desc", Type = SkillType.Heal, Element = ElementType.Light },
            ["2406"] = new SkillDefinition { NameKey = "Skill_2406_Name", DescriptionKey = "Skill_2406_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2421"] = new SkillDefinition { NameKey = "Skill_2421_Name", DescriptionKey = "Skill_2421_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["240102"] = new SkillDefinition { NameKey = "Skill_240102_Name", DescriptionKey = "Skill_240102_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["55412"] = new SkillDefinition { NameKey = "Skill_55412_Name", DescriptionKey = "Skill_55412_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2206241"] = new SkillDefinition { NameKey = "Skill_2206241_Name", DescriptionKey = "Skill_2206241_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2206552"] = new SkillDefinition { NameKey = "Skill_2206552_Name", DescriptionKey = "Skill_2206552_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["1005240"] = new SkillDefinition { NameKey = "Skill_1005240_Name", DescriptionKey = "Skill_1005240_Desc", Type = SkillType.Damage, Element = ElementType.Dark },
            ["1006940"] = new SkillDefinition { NameKey = "Skill_1006940_Name", DescriptionKey = "Skill_1006940_Desc", Type = SkillType.Damage, Element = ElementType.Dark },
            ["391006"] = new SkillDefinition { NameKey = "Skill_391006_Name", DescriptionKey = "Skill_391006_Desc", Type = SkillType.Damage, Element = ElementType.Dark },
            ["1008440"] = new SkillDefinition { NameKey = "Skill_1008440_Name", DescriptionKey = "Skill_1008440_Desc", Type = SkillType.Damage, Element = ElementType.Wind },
            ["391301"] = new SkillDefinition { NameKey = "Skill_391301_Name", DescriptionKey = "Skill_391301_Desc", Type = SkillType.Damage, Element = ElementType.Thunder },
            ["3913001"] = new SkillDefinition { NameKey = "Skill_3913001_Name", DescriptionKey = "Skill_3913001_Desc", Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1008641"] = new SkillDefinition { NameKey = "Skill_1008641_Name", DescriptionKey = "Skill_1008641_Desc", Type = SkillType.Damage, Element = ElementType.Wind },
            ["3210081"] = new SkillDefinition { NameKey = "Skill_3210081_Name", DescriptionKey = "Skill_3210081_Desc", Type = SkillType.Damage, Element = ElementType.Thunder },
            ["391007"] = new SkillDefinition { NameKey = "Skill_391007_Name", DescriptionKey = "Skill_391007_Desc", Type = SkillType.Damage, Element = ElementType.Physics },
            ["391008"] = new SkillDefinition { NameKey = "Skill_391008_Name", DescriptionKey = "Skill_391008_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1700440"] = new SkillDefinition { NameKey = "Skill_1700440_Name", DescriptionKey = "Skill_1700440_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1222"] = new SkillDefinition { NameKey = "Skill_1222_Name", DescriptionKey = "Skill_1222_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["1241"] = new SkillDefinition { NameKey = "Skill_1241_Name", DescriptionKey = "Skill_1241_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["199902"] = new SkillDefinition { NameKey = "Skill_199902_Name", DescriptionKey = "Skill_199902_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["1240"] = new SkillDefinition { NameKey = "Skill_1240_Name", DescriptionKey = "Skill_1240_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["1242"] = new SkillDefinition { NameKey = "Skill_1242_Name", DescriptionKey = "Skill_1242_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["1243"] = new SkillDefinition { NameKey = "Skill_1243_Name", DescriptionKey = "Skill_1243_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["1245"] = new SkillDefinition { NameKey = "Skill_1245_Name", DescriptionKey = "Skill_1245_Desc", Type = SkillType.Heal, Element = ElementType.Ice },
            ["1246"] = new SkillDefinition { NameKey = "Skill_1246_Name", DescriptionKey = "Skill_1246_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["1247"] = new SkillDefinition { NameKey = "Skill_1247_Name", DescriptionKey = "Skill_1247_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["1249"] = new SkillDefinition { NameKey = "Skill_1249_Name", DescriptionKey = "Skill_1249_Desc", Type = SkillType.Damage, Element = ElementType.Ice },
            ["1405"] = new SkillDefinition { NameKey = "Skill_1405_Name", DescriptionKey = "Skill_1405_Desc", Type = SkillType.Damage, Element = ElementType.Wind },
            ["1406"] = new SkillDefinition { NameKey = "Skill_1406_Name", DescriptionKey = "Skill_1406_Desc", Type = SkillType.Damage, Element = ElementType.Wind },
            ["1407"] = new SkillDefinition { NameKey = "Skill_1407_Name", DescriptionKey = "Skill_1407_Desc", Type = SkillType.Damage, Element = ElementType.Wind },
            ["1410"] = new SkillDefinition { NameKey = "Skill_1410_Name", DescriptionKey = "Skill_1410_Desc", Type = SkillType.Damage, Element = ElementType.Wind },
            ["1426"] = new SkillDefinition { NameKey = "Skill_1426_Name", DescriptionKey = "Skill_1426_Desc", Type = SkillType.Damage, Element = ElementType.Wind },
            ["1430"] = new SkillDefinition { NameKey = "Skill_1430_Name", DescriptionKey = "Skill_1430_Desc", Type = SkillType.Damage, Element = ElementType.Wind },
            ["1517"] = new SkillDefinition { NameKey = "Skill_1517_Name", DescriptionKey = "Skill_1517_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["1527"] = new SkillDefinition { NameKey = "Skill_1527_Name", DescriptionKey = "Skill_1527_Desc", Type = SkillType.Heal, Element = ElementType.Earth },
            ["1556"] = new SkillDefinition { NameKey = "Skill_1556_Name", DescriptionKey = "Skill_1556_Desc", Type = SkillType.Heal, Element = ElementType.Earth },
            ["1562"] = new SkillDefinition { NameKey = "Skill_1562_Name", DescriptionKey = "Skill_1562_Desc", Type = SkillType.Heal, Element = ElementType.Earth },
            ["1711"] = new SkillDefinition { NameKey = "Skill_1711_Name", DescriptionKey = "Skill_1711_Desc", Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1712"] = new SkillDefinition { NameKey = "Skill_1712_Name", DescriptionKey = "Skill_1712_Desc", Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1716"] = new SkillDefinition { NameKey = "Skill_1716_Name", DescriptionKey = "Skill_1716_Desc", Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1720"] = new SkillDefinition { NameKey = "Skill_1720_Name", DescriptionKey = "Skill_1720_Desc", Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1721"] = new SkillDefinition { NameKey = "Skill_1721_Name", DescriptionKey = "Skill_1721_Desc", Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1722"] = new SkillDefinition { NameKey = "Skill_1722_Name", DescriptionKey = "Skill_1722_Desc", Type = SkillType.Damage, Element = ElementType.Thunder },
            ["1905"] = new SkillDefinition { NameKey = "Skill_1905_Name", DescriptionKey = "Skill_1905_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["1906"] = new SkillDefinition { NameKey = "Skill_1906_Name", DescriptionKey = "Skill_1906_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["1907"] = new SkillDefinition { NameKey = "Skill_1907_Name", DescriptionKey = "Skill_1907_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["1917"] = new SkillDefinition { NameKey = "Skill_1917_Name", DescriptionKey = "Skill_1917_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["1922"] = new SkillDefinition { NameKey = "Skill_1922_Name", DescriptionKey = "Skill_1922_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["1925"] = new SkillDefinition { NameKey = "Skill_1925_Name", DescriptionKey = "Skill_1925_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["1926"] = new SkillDefinition { NameKey = "Skill_1926_Name", DescriptionKey = "Skill_1926_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["1928"] = new SkillDefinition { NameKey = "Skill_1928_Name", DescriptionKey = "Skill_1928_Desc", Type = SkillType.Heal, Element = ElementType.Earth },
            ["1929"] = new SkillDefinition { NameKey = "Skill_1929_Name", DescriptionKey = "Skill_1929_Desc", Type = SkillType.Heal, Element = ElementType.Earth },
            ["1936"] = new SkillDefinition { NameKey = "Skill_1936_Name", DescriptionKey = "Skill_1936_Desc", Type = SkillType.Heal, Element = ElementType.Earth },
            ["1938"] = new SkillDefinition { NameKey = "Skill_1938_Name", DescriptionKey = "Skill_1938_Desc", Type = SkillType.Heal, Element = ElementType.Earth },
            ["1941"] = new SkillDefinition { NameKey = "Skill_1941_Name", DescriptionKey = "Skill_1941_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["1943"] = new SkillDefinition { NameKey = "Skill_1943_Name", DescriptionKey = "Skill_1943_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["2220"] = new SkillDefinition { NameKey = "Skill_2220_Name", DescriptionKey = "Skill_2220_Desc", Type = SkillType.Damage, Element = ElementType.Wind },
            ["2221"] = new SkillDefinition { NameKey = "Skill_2221_Name", DescriptionKey = "Skill_2221_Desc", Type = SkillType.Damage, Element = ElementType.Wind },
            ["2230"] = new SkillDefinition { NameKey = "Skill_2230_Name", DescriptionKey = "Skill_2230_Desc", Type = SkillType.Damage, Element = ElementType.Earth },
            ["2231"] = new SkillDefinition { NameKey = "Skill_2231_Name", DescriptionKey = "Skill_2231_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2232"] = new SkillDefinition { NameKey = "Skill_2232_Name", DescriptionKey = "Skill_2232_Desc", Type = SkillType.Damage, Element = ElementType.Wind },
            ["2234"] = new SkillDefinition { NameKey = "Skill_2234_Name", DescriptionKey = "Skill_2234_Desc", Type = SkillType.Damage, Element = ElementType.Light },
            ["2237"] = new SkillDefinition { NameKey = "Skill_2237_Name", DescriptionKey = "Skill_2237_Desc", Type = SkillType.Damage, Element = ElementType.Wind },
            ["2238"] = new SkillDefinition { NameKey = "Skill_2238_Name", DescriptionKey = "Skill_2238_Desc", Type = SkillType.Damage, Element = ElementType.Fire },
            ["1256"] = new SkillDefinition { NameKey = "Skill_1256_Name", DescriptionKey = "Skill_1256_Desc", Type = SkillType.Damage, Element = ElementType.Wind },
            
            // The following are placeholders

            ["1201"] = new SkillDefinition { NameKey = "Skill_1201_Name", DescriptionKey = "Skill_1201_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1202"] = new SkillDefinition { NameKey = "Skill_1202_Name", DescriptionKey = "Skill_1202_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1204"] = new SkillDefinition { NameKey = "Skill_1204_Name", DescriptionKey = "Skill_1204_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1210"] = new SkillDefinition { NameKey = "Skill_1210_Name", DescriptionKey = "Skill_1210_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1211"] = new SkillDefinition { NameKey = "Skill_1211_Name", DescriptionKey = "Skill_1211_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1219"] = new SkillDefinition { NameKey = "Skill_1219_Name", DescriptionKey = "Skill_1219_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1223"] = new SkillDefinition { NameKey = "Skill_1223_Name", DescriptionKey = "Skill_1223_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1238"] = new SkillDefinition { NameKey = "Skill_1238_Name", DescriptionKey = "Skill_1238_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1239"] = new SkillDefinition { NameKey = "Skill_1239_Name", DescriptionKey = "Skill_1239_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1244"] = new SkillDefinition { NameKey = "Skill_1244_Name", DescriptionKey = "Skill_1244_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1251"] = new SkillDefinition { NameKey = "Skill_1251_Name", DescriptionKey = "Skill_1251_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1258"] = new SkillDefinition { NameKey = "Skill_1258_Name", DescriptionKey = "Skill_1258_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1725"] = new SkillDefinition { NameKey = "Skill_1725_Name", DescriptionKey = "Skill_1725_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1726"] = new SkillDefinition { NameKey = "Skill_1726_Name", DescriptionKey = "Skill_1726_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1730"] = new SkillDefinition { NameKey = "Skill_1730_Name", DescriptionKey = "Skill_1730_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1731"] = new SkillDefinition { NameKey = "Skill_1731_Name", DescriptionKey = "Skill_1731_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1733"] = new SkillDefinition { NameKey = "Skill_1733_Name", DescriptionKey = "Skill_1733_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1734"] = new SkillDefinition { NameKey = "Skill_1734_Name", DescriptionKey = "Skill_1734_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1901"] = new SkillDefinition { NameKey = "Skill_1901_Name", DescriptionKey = "Skill_1901_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1902"] = new SkillDefinition { NameKey = "Skill_1902_Name", DescriptionKey = "Skill_1902_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1903"] = new SkillDefinition { NameKey = "Skill_1903_Name", DescriptionKey = "Skill_1903_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1904"] = new SkillDefinition { NameKey = "Skill_1904_Name", DescriptionKey = "Skill_1904_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1909"] = new SkillDefinition { NameKey = "Skill_1909_Name", DescriptionKey = "Skill_1909_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1912"] = new SkillDefinition { NameKey = "Skill_1912_Name", DescriptionKey = "Skill_1912_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1924"] = new SkillDefinition { NameKey = "Skill_1924_Name", DescriptionKey = "Skill_1924_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1927"] = new SkillDefinition { NameKey = "Skill_1927_Name", DescriptionKey = "Skill_1927_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1930"] = new SkillDefinition { NameKey = "Skill_1930_Name", DescriptionKey = "Skill_1930_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1931"] = new SkillDefinition { NameKey = "Skill_1931_Name", DescriptionKey = "Skill_1931_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1932"] = new SkillDefinition { NameKey = "Skill_1932_Name", DescriptionKey = "Skill_1932_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1933"] = new SkillDefinition { NameKey = "Skill_1933_Name", DescriptionKey = "Skill_1933_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1934"] = new SkillDefinition { NameKey = "Skill_1934_Name", DescriptionKey = "Skill_1934_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1935"] = new SkillDefinition { NameKey = "Skill_1935_Name", DescriptionKey = "Skill_1935_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1937"] = new SkillDefinition { NameKey = "Skill_1937_Name", DescriptionKey = "Skill_1937_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1939"] = new SkillDefinition { NameKey = "Skill_1939_Name", DescriptionKey = "Skill_1939_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1940"] = new SkillDefinition { NameKey = "Skill_1940_Name", DescriptionKey = "Skill_1940_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1942"] = new SkillDefinition { NameKey = "Skill_1942_Name", DescriptionKey = "Skill_1942_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1944"] = new SkillDefinition { NameKey = "Skill_1944_Name", DescriptionKey = "Skill_1944_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1999"] = new SkillDefinition { NameKey = "Skill_1999_Name", DescriptionKey = "Skill_1999_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2201"] = new SkillDefinition { NameKey = "Skill_2201_Name", DescriptionKey = "Skill_2201_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2209"] = new SkillDefinition { NameKey = "Skill_2209_Name", DescriptionKey = "Skill_2209_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2222"] = new SkillDefinition { NameKey = "Skill_2222_Name", DescriptionKey = "Skill_2222_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2224"] = new SkillDefinition { NameKey = "Skill_2224_Name", DescriptionKey = "Skill_2224_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2235"] = new SkillDefinition { NameKey = "Skill_2235_Name", DescriptionKey = "Skill_2235_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2239"] = new SkillDefinition { NameKey = "Skill_2239_Name", DescriptionKey = "Skill_2239_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2240"] = new SkillDefinition { NameKey = "Skill_2240_Name", DescriptionKey = "Skill_2240_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2241"] = new SkillDefinition { NameKey = "Skill_2241_Name", DescriptionKey = "Skill_2241_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2242"] = new SkillDefinition { NameKey = "Skill_2242_Name", DescriptionKey = "Skill_2242_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2290"] = new SkillDefinition { NameKey = "Skill_2290_Name", DescriptionKey = "Skill_2290_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2293"] = new SkillDefinition { NameKey = "Skill_2293_Name", DescriptionKey = "Skill_2293_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2296"] = new SkillDefinition { NameKey = "Skill_2296_Name", DescriptionKey = "Skill_2296_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2307"] = new SkillDefinition { NameKey = "Skill_2307_Name", DescriptionKey = "Skill_2307_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2308"] = new SkillDefinition { NameKey = "Skill_2308_Name", DescriptionKey = "Skill_2308_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2309"] = new SkillDefinition { NameKey = "Skill_2309_Name", DescriptionKey = "Skill_2309_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2310"] = new SkillDefinition { NameKey = "Skill_2310_Name", DescriptionKey = "Skill_2310_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2311"] = new SkillDefinition { NameKey = "Skill_2311_Name", DescriptionKey = "Skill_2311_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2314"] = new SkillDefinition { NameKey = "Skill_2314_Name", DescriptionKey = "Skill_2314_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2315"] = new SkillDefinition { NameKey = "Skill_2315_Name", DescriptionKey = "Skill_2315_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2316"] = new SkillDefinition { NameKey = "Skill_2316_Name", DescriptionKey = "Skill_2316_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2318"] = new SkillDefinition { NameKey = "Skill_2318_Name", DescriptionKey = "Skill_2318_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2319"] = new SkillDefinition { NameKey = "Skill_2319_Name", DescriptionKey = "Skill_2319_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2320"] = new SkillDefinition { NameKey = "Skill_2320_Name", DescriptionKey = "Skill_2320_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2329"] = new SkillDefinition { NameKey = "Skill_2329_Name", DescriptionKey = "Skill_2329_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2361"] = new SkillDefinition { NameKey = "Skill_2361_Name", DescriptionKey = "Skill_2361_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2362"] = new SkillDefinition { NameKey = "Skill_2362_Name", DescriptionKey = "Skill_2362_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2363"] = new SkillDefinition { NameKey = "Skill_2363_Name", DescriptionKey = "Skill_2363_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2364"] = new SkillDefinition { NameKey = "Skill_2364_Name", DescriptionKey = "Skill_2364_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2365"] = new SkillDefinition { NameKey = "Skill_2365_Name", DescriptionKey = "Skill_2365_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2399"] = new SkillDefinition { NameKey = "Skill_2399_Name", DescriptionKey = "Skill_2399_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2408"] = new SkillDefinition { NameKey = "Skill_2408_Name", DescriptionKey = "Skill_2408_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2409"] = new SkillDefinition { NameKey = "Skill_2409_Name", DescriptionKey = "Skill_2409_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2411"] = new SkillDefinition { NameKey = "Skill_2411_Name", DescriptionKey = "Skill_2411_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2414"] = new SkillDefinition { NameKey = "Skill_2414_Name", DescriptionKey = "Skill_2414_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2415"] = new SkillDefinition { NameKey = "Skill_2415_Name", DescriptionKey = "Skill_2415_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2419"] = new SkillDefinition { NameKey = "Skill_2419_Name", DescriptionKey = "Skill_2419_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2420"] = new SkillDefinition { NameKey = "Skill_2420_Name", DescriptionKey = "Skill_2420_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2425"] = new SkillDefinition { NameKey = "Skill_2425_Name", DescriptionKey = "Skill_2425_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["3698"] = new SkillDefinition { NameKey = "Skill_3698_Name", DescriptionKey = "Skill_3698_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["3901"] = new SkillDefinition { NameKey = "Skill_3901_Name", DescriptionKey = "Skill_3901_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["3925"] = new SkillDefinition { NameKey = "Skill_3925_Name", DescriptionKey = "Skill_3925_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["21418"] = new SkillDefinition { NameKey = "Skill_21418_Name", DescriptionKey = "Skill_21418_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["27009"] = new SkillDefinition { NameKey = "Skill_27009_Name", DescriptionKey = "Skill_27009_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["50036"] = new SkillDefinition { NameKey = "Skill_50036_Name", DescriptionKey = "Skill_50036_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["50037"] = new SkillDefinition { NameKey = "Skill_50037_Name", DescriptionKey = "Skill_50037_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["50049"] = new SkillDefinition { NameKey = "Skill_50049_Name", DescriptionKey = "Skill_50049_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["50068"] = new SkillDefinition { NameKey = "Skill_50068_Name", DescriptionKey = "Skill_50068_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["55235"] = new SkillDefinition { NameKey = "Skill_55235_Name", DescriptionKey = "Skill_55235_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["55236"] = new SkillDefinition { NameKey = "Skill_55236_Name", DescriptionKey = "Skill_55236_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["55238"] = new SkillDefinition { NameKey = "Skill_55238_Name", DescriptionKey = "Skill_55238_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["55239"] = new SkillDefinition { NameKey = "Skill_55239_Name", DescriptionKey = "Skill_55239_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["55240"] = new SkillDefinition { NameKey = "Skill_55240_Name", DescriptionKey = "Skill_55240_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["55328"] = new SkillDefinition { NameKey = "Skill_55328_Name", DescriptionKey = "Skill_55328_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["55335"] = new SkillDefinition { NameKey = "Skill_55335_Name", DescriptionKey = "Skill_55335_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["55344"] = new SkillDefinition { NameKey = "Skill_55344_Name", DescriptionKey = "Skill_55344_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["55417"] = new SkillDefinition { NameKey = "Skill_55417_Name", DescriptionKey = "Skill_55417_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["55431"] = new SkillDefinition { NameKey = "Skill_55431_Name", DescriptionKey = "Skill_55431_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["55432"] = new SkillDefinition { NameKey = "Skill_55432_Name", DescriptionKey = "Skill_55432_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["100730"] = new SkillDefinition { NameKey = "Skill_100730_Name", DescriptionKey = "Skill_100730_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["102640"] = new SkillDefinition { NameKey = "Skill_102640_Name", DescriptionKey = "Skill_102640_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["101112"] = new SkillDefinition { NameKey = "Skill_101112_Name", DescriptionKey = "Skill_101112_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["141104"] = new SkillDefinition { NameKey = "Skill_141104_Name", DescriptionKey = "Skill_141104_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["149904"] = new SkillDefinition { NameKey = "Skill_149904_Name", DescriptionKey = "Skill_149904_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["179904"] = new SkillDefinition { NameKey = "Skill_179904_Name", DescriptionKey = "Skill_179904_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["199903"] = new SkillDefinition { NameKey = "Skill_199903_Name", DescriptionKey = "Skill_199903_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["220105"] = new SkillDefinition { NameKey = "Skill_220105_Name", DescriptionKey = "Skill_220105_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["220107"] = new SkillDefinition { NameKey = "Skill_220107_Name", DescriptionKey = "Skill_220107_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["221101"] = new SkillDefinition { NameKey = "Skill_221101_Name", DescriptionKey = "Skill_221101_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["391001"] = new SkillDefinition { NameKey = "Skill_391001_Name", DescriptionKey = "Skill_391001_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["391002"] = new SkillDefinition { NameKey = "Skill_391002_Name", DescriptionKey = "Skill_391002_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["391003"] = new SkillDefinition { NameKey = "Skill_391003_Name", DescriptionKey = "Skill_391003_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["391004"] = new SkillDefinition { NameKey = "Skill_391004_Name", DescriptionKey = "Skill_391004_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["391005"] = new SkillDefinition { NameKey = "Skill_391005_Name", DescriptionKey = "Skill_391005_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["391401"] = new SkillDefinition { NameKey = "Skill_391401_Name", DescriptionKey = "Skill_391401_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["701001"] = new SkillDefinition { NameKey = "Skill_701001_Name", DescriptionKey = "Skill_701001_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["701002"] = new SkillDefinition { NameKey = "Skill_701002_Name", DescriptionKey = "Skill_701002_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1002440"] = new SkillDefinition { NameKey = "Skill_1002440_Name", DescriptionKey = "Skill_1002440_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1002830"] = new SkillDefinition { NameKey = "Skill_1002830_Name", DescriptionKey = "Skill_1002830_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1005940"] = new SkillDefinition { NameKey = "Skill_1005940_Name", DescriptionKey = "Skill_1005940_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1007601"] = new SkillDefinition { NameKey = "Skill_1007601_Name", DescriptionKey = "Skill_1007601_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1007602"] = new SkillDefinition { NameKey = "Skill_1007602_Name", DescriptionKey = "Skill_1007602_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1007741"] = new SkillDefinition { NameKey = "Skill_1007741_Name", DescriptionKey = "Skill_1007741_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1008040"] = new SkillDefinition { NameKey = "Skill_1008040_Name", DescriptionKey = "Skill_1008040_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1008140"] = new SkillDefinition { NameKey = "Skill_1008140_Name", DescriptionKey = "Skill_1008140_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1008540"] = new SkillDefinition { NameKey = "Skill_1008540_Name", DescriptionKey = "Skill_1008540_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1010440"] = new SkillDefinition { NameKey = "Skill_1010440_Name", DescriptionKey = "Skill_1010440_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1700824"] = new SkillDefinition { NameKey = "Skill_1700824_Name", DescriptionKey = "Skill_1700824_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1700825"] = new SkillDefinition { NameKey = "Skill_1700825_Name", DescriptionKey = "Skill_1700825_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["1700826"] = new SkillDefinition { NameKey = "Skill_1700826_Name", DescriptionKey = "Skill_1700826_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2001740"] = new SkillDefinition { NameKey = "Skill_2001740_Name", DescriptionKey = "Skill_2001740_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2002853"] = new SkillDefinition { NameKey = "Skill_2002853_Name", DescriptionKey = "Skill_2002853_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2031106"] = new SkillDefinition { NameKey = "Skill_2031106_Name", DescriptionKey = "Skill_2031106_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2031107"] = new SkillDefinition { NameKey = "Skill_2031107_Name", DescriptionKey = "Skill_2031107_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2031108"] = new SkillDefinition { NameKey = "Skill_2031108_Name", DescriptionKey = "Skill_2031108_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2110012"] = new SkillDefinition { NameKey = "Skill_2110012_Name", DescriptionKey = "Skill_2110012_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2110066"] = new SkillDefinition { NameKey = "Skill_2110066_Name", DescriptionKey = "Skill_2110066_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2110083"] = new SkillDefinition { NameKey = "Skill_2110083_Name", DescriptionKey = "Skill_2110083_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2110085"] = new SkillDefinition { NameKey = "Skill_2110085_Name", DescriptionKey = "Skill_2110085_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2110090"] = new SkillDefinition { NameKey = "Skill_2110090_Name", DescriptionKey = "Skill_2110090_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2110091"] = new SkillDefinition { NameKey = "Skill_2110091_Name", DescriptionKey = "Skill_2110091_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2110096"] = new SkillDefinition { NameKey = "Skill_2110096_Name", DescriptionKey = "Skill_2110096_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2110099"] = new SkillDefinition { NameKey = "Skill_2110099_Name", DescriptionKey = "Skill_2110099_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2201070"] = new SkillDefinition { NameKey = "Skill_2201070_Name", DescriptionKey = "Skill_2201070_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2201080"] = new SkillDefinition { NameKey = "Skill_2201080_Name", DescriptionKey = "Skill_2201080_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2201172"] = new SkillDefinition { NameKey = "Skill_2201172_Name", DescriptionKey = "Skill_2201172_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2201240"] = new SkillDefinition { NameKey = "Skill_2201240_Name", DescriptionKey = "Skill_2201240_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2201362"] = new SkillDefinition { NameKey = "Skill_2201362_Name", DescriptionKey = "Skill_2201362_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2201410"] = new SkillDefinition { NameKey = "Skill_2201410_Name", DescriptionKey = "Skill_2201410_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2201493"] = new SkillDefinition { NameKey = "Skill_2201493_Name", DescriptionKey = "Skill_2201493_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2201570"] = new SkillDefinition { NameKey = "Skill_2201570_Name", DescriptionKey = "Skill_2201570_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2202120"] = new SkillDefinition { NameKey = "Skill_2202120_Name", DescriptionKey = "Skill_2202120_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2202211"] = new SkillDefinition { NameKey = "Skill_2202211_Name", DescriptionKey = "Skill_2202211_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2202262"] = new SkillDefinition { NameKey = "Skill_2202262_Name", DescriptionKey = "Skill_2202262_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2202271"] = new SkillDefinition { NameKey = "Skill_2202271_Name", DescriptionKey = "Skill_2202271_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2202291"] = new SkillDefinition { NameKey = "Skill_2202291_Name", DescriptionKey = "Skill_2202291_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2002440"] = new SkillDefinition { NameKey = "Skill_2002440_Name", DescriptionKey = "Skill_2002440_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2202581"] = new SkillDefinition { NameKey = "Skill_2202581_Name", DescriptionKey = "Skill_2202581_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2202582"] = new SkillDefinition { NameKey = "Skill_2202582_Name", DescriptionKey = "Skill_2202582_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2203091"] = new SkillDefinition { NameKey = "Skill_2203091_Name", DescriptionKey = "Skill_2203091_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2203101"] = new SkillDefinition { NameKey = "Skill_2203101_Name", DescriptionKey = "Skill_2203101_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2203102"] = new SkillDefinition { NameKey = "Skill_2203102_Name", DescriptionKey = "Skill_2203102_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2203141"] = new SkillDefinition { NameKey = "Skill_2203141_Name", DescriptionKey = "Skill_2203141_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2203302"] = new SkillDefinition { NameKey = "Skill_2203302_Name", DescriptionKey = "Skill_2203302_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2203311"] = new SkillDefinition { NameKey = "Skill_2203311_Name", DescriptionKey = "Skill_2203311_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2204320"] = new SkillDefinition { NameKey = "Skill_2204320_Name", DescriptionKey = "Skill_2204320_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2406140"] = new SkillDefinition { NameKey = "Skill_2406140_Name", DescriptionKey = "Skill_2406140_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2206240"] = new SkillDefinition { NameKey = "Skill_2206240_Name", DescriptionKey = "Skill_2206240_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2207500"] = new SkillDefinition { NameKey = "Skill_2207500_Name", DescriptionKey = "Skill_2207500_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2207660"] = new SkillDefinition { NameKey = "Skill_2207660_Name", DescriptionKey = "Skill_2207660_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2207681"] = new SkillDefinition { NameKey = "Skill_2207681_Name", DescriptionKey = "Skill_2207681_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["2900540"] = new SkillDefinition { NameKey = "Skill_2900540_Name", DescriptionKey = "Skill_2900540_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["3001031"] = new SkillDefinition { NameKey = "Skill_3001031_Name", DescriptionKey = "Skill_3001031_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["3001170"] = new SkillDefinition { NameKey = "Skill_3001170_Name", DescriptionKey = "Skill_3001170_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["3081023"] = new SkillDefinition { NameKey = "Skill_3081023_Name", DescriptionKey = "Skill_3081023_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["3210021"] = new SkillDefinition { NameKey = "Skill_3210021_Name", DescriptionKey = "Skill_3210021_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["3210031"] = new SkillDefinition { NameKey = "Skill_3210031_Name", DescriptionKey = "Skill_3210031_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["3210051"] = new SkillDefinition { NameKey = "Skill_3210051_Name", DescriptionKey = "Skill_3210051_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["3210061"] = new SkillDefinition { NameKey = "Skill_3210061_Name", DescriptionKey = "Skill_3210061_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["3210092"] = new SkillDefinition { NameKey = "Skill_3210092_Name", DescriptionKey = "Skill_3210092_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["3210101"] = new SkillDefinition { NameKey = "Skill_3210101_Name", DescriptionKey = "Skill_3210101_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["3936001"] = new SkillDefinition { NameKey = "Skill_3936001_Name", DescriptionKey = "Skill_3936001_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
            ["10040102"] = new SkillDefinition { NameKey = "Skill_10040102_Name", DescriptionKey = "Skill_10040102_Desc", Type = SkillType.Unknown, Element = ElementType.Unknown },
        };

        // Exactly matches the skills in skill_config.json (overwrites the previous list)
        public static readonly Dictionary<string, SkillDefinition> SkillsByString = new()
        {
            ["1401"] = new SkillDefinition { Name = "Wind Elegance Soaring Dance", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Wind Elegance Soaring Dance" },
            ["1402"] = new SkillDefinition { Name = "Wind Elegance Soaring Dance", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Wind Elegance Soaring Dance" },
            ["1403"] = new SkillDefinition { Name = "Wind Elegance Soaring Dance", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Wind Elegance Soaring Dance" },
            ["1404"] = new SkillDefinition { Name = "Wind Elegance Soaring Dance", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Wind Elegance Soaring Dance" },
            ["1409"] = new SkillDefinition { Name = "Wind God·Wind of Breaking Formation", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Wind God·Wind of Breaking Formation" },
            ["1420"] = new SkillDefinition { Name = "Exceptional Grace", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Exceptional Grace" },
            ["2031104"] = new SkillDefinition { Name = "Lucky Strike (Spear)", Type = SkillType.Damage, Element = ElementType.Light, Description = "Lucky Strike (Spear)" },
            ["1418"] = new SkillDefinition { Name = "Gale Stab", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Gale Stab" },
            ["1421"] = new SkillDefinition { Name = "Spiral Thrust", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Spiral Thrust" },
            ["1434"] = new SkillDefinition { Name = "Divine Shadow Spiral", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Divine Shadow Spiral" },
            ["140301"] = new SkillDefinition { Name = "Divine Shadow Spiral", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Divine Shadow Spiral" },
            ["1422"] = new SkillDefinition { Name = "Breaking Chase", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Breaking Chase" },
            ["1427"] = new SkillDefinition { Name = "Breaking Chase", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Breaking Chase" },
            ["31901"] = new SkillDefinition { Name = "Courage Wind Ring", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Courage Wind Ring" },
            ["2205450"] = new SkillDefinition { Name = "Courage Wind Ring Lifesteal", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Courage Wind Ring Lifesteal" },
            ["1411"] = new SkillDefinition { Name = "Galloping Blade", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Galloping Blade" },
            ["1435"] = new SkillDefinition { Name = "Dragon Strike Cannon", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Dragon Strike Cannon" },
            ["140401"] = new SkillDefinition { Name = "Dragon Strike Cannon", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Dragon Strike Cannon" },
            ["2205071"] = new SkillDefinition { Name = "Rend", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Rend" },
            ["149901"] = new SkillDefinition { Name = "Wind Spiral / Spiral Detonation", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Wind Spiral / Spiral Detonation" },
            ["1419"] = new SkillDefinition { Name = "Soaring Return", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Soaring Return" },
            ["1424"] = new SkillDefinition { Name = "Instant", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Instant" },
            ["1425"] = new SkillDefinition { Name = "Bird Toss", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Bird Toss" },
            ["149905"] = new SkillDefinition { Name = "Bird Toss", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Bird Toss" },
            ["1433"] = new SkillDefinition { Name = "Ultimate·Storm Slash", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Ultimate·Storm Slash" },
            ["149906"] = new SkillDefinition { Name = "Ultimate·Storm Slash", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Ultimate·Storm Slash" },
            ["149907"] = new SkillDefinition { Name = "Sharp Impact (Wind God)", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Sharp Impact (Wind God)" },
            ["1431"] = new SkillDefinition { Name = "Sharp Impact (Wind God)", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Sharp Impact (Wind God)" },
            ["149902"] = new SkillDefinition { Name = "Spear Pierce", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Spear Pierce" },
            ["140501"] = new SkillDefinition { Name = "Tornado", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Tornado" },

            ["1701"] = new SkillDefinition { Name = "My Style Sword Technique·Punish Evil", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "My Style Sword Technique·Punish Evil" },
            ["1702"] = new SkillDefinition { Name = "My Style Sword Technique·Punish Evil", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "My Style Sword Technique·Punish Evil" },
            ["1703"] = new SkillDefinition { Name = "My Style Sword Technique·Punish Evil", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "My Style Sword Technique·Punish Evil" },
            ["1704"] = new SkillDefinition { Name = "My Style Sword Technique·Punish Evil", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "My Style Sword Technique·Punish Evil" },
            ["1713"] = new SkillDefinition { Name = "Ultimate·Great Destruction Combo", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Ultimate·Great Destruction Combo" },
            ["1728"] = new SkillDefinition { Name = "Ultimate·Great Destruction Combo (Talent)", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Ultimate·Great Destruction Combo (Talent)" },
            ["1714"] = new SkillDefinition { Name = "Iaido", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Iaido" },
            ["1717"] = new SkillDefinition { Name = "Flash", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Flash" },
            ["1718"] = new SkillDefinition { Name = "Flying Thunder God", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Flying Thunder God" },
            ["1735"] = new SkillDefinition { Name = "Falling Dragon Flash", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Falling Dragon Flash" },
            ["1736"] = new SkillDefinition { Name = "Divine Shadow Slash", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Divine Shadow Slash" },
            ["155101"] = new SkillDefinition { Name = "Thunder Slash", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Thunder Slash" },
            ["1715"] = new SkillDefinition { Name = "Moon Shadow", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Moon Shadow" },
            ["1719"] = new SkillDefinition { Name = "Scythe Car", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Scythe Car" },
            ["1724"] = new SkillDefinition { Name = "Thunder Combo", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Thunder Combo" },
            ["1705"] = new SkillDefinition { Name = "Super High Output", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Super High Output" },
            ["1732"] = new SkillDefinition { Name = "Intent of Thousand Lightning Flash Shadow", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Intent of Thousand Lightning Flash Shadow" },
            ["1737"] = new SkillDefinition { Name = "Scythe of Divine Punishment", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Scythe of Divine Punishment" },
            ["1738"] = new SkillDefinition { Name = "Confusing Cut", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Confusing Cut" },
            ["1739"] = new SkillDefinition { Name = "Perceive Slash", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Perceive Slash" },
            ["1740"] = new SkillDefinition { Name = "Scythe of Thunder (triggered by Thunder Rising Slash)", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Scythe of Thunder (triggered by Thunder Rising Slash)" },
            ["1741"] = new SkillDefinition { Name = "Scythe of Thunder", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Scythe of Thunder" },
            ["1742"] = new SkillDefinition { Name = "Thunder Rising Slash", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Thunder Rising Slash" },
            ["44701"] = new SkillDefinition { Name = "Moon Blade", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Moon Blade" },
            ["179908"] = new SkillDefinition { Name = "Thunder Strike", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Thunder Strike" },
            ["179906"] = new SkillDefinition { Name = "Moon Blade Spin", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Moon Blade Spin" },
            ["2031101"] = new SkillDefinition { Name = "Lucky Strike (Katana)", Type = SkillType.Damage, Element = ElementType.Light, Description = "Lucky Strike (Katana)" },
/*
            ["2330"] = new SkillDefinition { Name = "Pillar Fire Impact", Type = SkillType.Damage, Element = ElementType.Fire, Description = "Pillar Fire Impact" },
            ["55314"] = new SkillDefinition { Name = "Encore Healing", Type = SkillType.Heal, Element = ElementType.Fire, Description = "Encore Healing" },
            ["230101"] = new SkillDefinition { Name = "Aggregate Composition / Encore Healing Related", Type = SkillType.Heal, Element = ElementType.Fire, Description = "Aggregate Composition / Encore Healing Related" },
            ["230401"] = new SkillDefinition { Name = "Encore Damage", Type = SkillType.Damage, Element = ElementType.Fire, Description = "Encore Damage" },
            ["230501"] = new SkillDefinition { Name = "Infinite Encore Damage", Type = SkillType.Damage, Element = ElementType.Fire, Description = "Infinite Encore Damage" },
            ["2031111"] = new SkillDefinition { Name = "Lucky Strike (Soul Musician)", Type = SkillType.Damage, Element = ElementType.Light, Description = "Lucky Strike (Soul Musician)" },
            ["2306"] = new SkillDefinition { Name = "Amplify Beat", Type = SkillType.Damage, Element = ElementType.Fire, Description = "Amplify Beat" },
            ["2317"] = new SkillDefinition { Name = "Fierce Swing", Type = SkillType.Damage, Element = ElementType.Fire, Description = "Fierce Swing" },
            ["2321"] = new SkillDefinition { Name = "String Strike", Type = SkillType.Damage, Element = ElementType.Fire, Description = "String Strike" },
            ["2322"] = new SkillDefinition { Name = "String Strike", Type = SkillType.Damage, Element = ElementType.Fire, Description = "String Strike" },
            ["2323"] = new SkillDefinition { Name = "String Strike", Type = SkillType.Damage, Element = ElementType.Fire, Description = "String Strike" },
            ["2324"] = new SkillDefinition { Name = "String Strike", Type = SkillType.Damage, Element = ElementType.Fire, Description = "String Strike" },
            ["2331"] = new SkillDefinition { Name = "Sound Wave", Type = SkillType.Damage, Element = ElementType.Fire, Description = "Sound Wave" },
            ["2335"] = new SkillDefinition { Name = "Infinite Rhapsody Damage", Type = SkillType.Damage, Element = ElementType.Fire, Description = "Infinite Rhapsody Damage" },
            ["230102"] = new SkillDefinition { Name = "Aggregate Composition", Type = SkillType.Damage, Element = ElementType.Fire, Description = "Aggregate Composition" },
            ["230103"] = new SkillDefinition { Name = "Aggregate Composition", Type = SkillType.Damage, Element = ElementType.Fire, Description = "Aggregate Composition" },
            ["230104"] = new SkillDefinition { Name = "Aggregate Composition", Type = SkillType.Damage, Element = ElementType.Fire, Description = "Aggregate Composition" },
            ["230105"] = new SkillDefinition { Name = "Flame Rhythm Stomp Damage", Type = SkillType.Damage, Element = ElementType.Fire, Description = "Flame Rhythm Stomp Damage" },
            ["230106"] = new SkillDefinition { Name = "Blazing Note Damage", Type = SkillType.Damage, Element = ElementType.Fire, Description = "Blazing Note Damage" },
            ["231001"] = new SkillDefinition { Name = "Blazing Rhapsody Damage", Type = SkillType.Damage, Element = ElementType.Fire, Description = "Blazing Rhapsody Damage" },
            ["55301"] = new SkillDefinition { Name = "Blazing Rhapsody Healing", Type = SkillType.Heal, Element = ElementType.Fire, Description = "Blazing Rhapsody Healing" },
            ["55311"] = new SkillDefinition { Name = "Encore Conversion", Type = SkillType.Heal, Element = ElementType.Fire, Description = "Encore Conversion" },
            ["55341"] = new SkillDefinition { Name = "Brave Composition Healing", Type = SkillType.Heal, Element = ElementType.Fire, Description = "Brave Composition Healing" },
            ["55346"] = new SkillDefinition { Name = "Infinite Rhapsody Healing", Type = SkillType.Heal, Element = ElementType.Fire, Description = "Infinite Rhapsody Healing" },
            ["55355"] = new SkillDefinition { Name = "Resting Cure", Type = SkillType.Heal, Element = ElementType.Fire, Description = "Resting Cure" },
            ["2207141"] = new SkillDefinition { Name = "Note", Type = SkillType.Heal, Element = ElementType.Fire, Description = "Note" },
            ["2207151"] = new SkillDefinition { Name = "Blazing Healing", Type = SkillType.Heal, Element = ElementType.Fire, Description = "Blazing Healing" },
            ["2207431"] = new SkillDefinition { Name = "Flame Rhapsody Healing", Type = SkillType.Heal, Element = ElementType.Fire, Description = "Flame Rhapsody Healing" },
            ["2301"] = new SkillDefinition { Name = "String Pluck", Type = SkillType.Damage, Element = ElementType.Fire, Description = "String Pluck" },
            ["2302"] = new SkillDefinition { Name = "String Pluck", Type = SkillType.Damage, Element = ElementType.Fire, Description = "String Pluck" },
            ["2303"] = new SkillDefinition { Name = "String Pluck", Type = SkillType.Damage, Element = ElementType.Fire, Description = "String Pluck" },
            ["2304"] = new SkillDefinition { Name = "String Pluck", Type = SkillType.Damage, Element = ElementType.Fire, Description = "String Pluck" },
            ["2312"] = new SkillDefinition { Name = "Surging Quintet Damage", Type = SkillType.Damage, Element = ElementType.Fire, Description = "Surging Quintet Damage" },
            ["2313"] = new SkillDefinition { Name = "Passionate Swing", Type = SkillType.Damage, Element = ElementType.Fire, Description = "Passionate Swing" },
            ["2332"] = new SkillDefinition { Name = "Enhanced Passionate Swing", Type = SkillType.Damage, Element = ElementType.Fire, Description = "Enhanced Passionate Swing" },
            ["2336"] = new SkillDefinition { Name = "Touring Song Damage", Type = SkillType.Damage, Element = ElementType.Fire, Description = "Touring Song Damage" },
            ["2366"] = new SkillDefinition { Name = "Touring Song Damage", Type = SkillType.Damage, Element = ElementType.Fire, Description = "Touring Song Damage (Speaker Loop)" },
            ["55302"] = new SkillDefinition { Name = "Healing Beat", Type = SkillType.Heal, Element = ElementType.Fire, Description = "Healing Beat" },
            ["55304"] = new SkillDefinition { Name = "Surging Quintet Healing", Type = SkillType.Heal, Element = ElementType.Fire, Description = "Surging Quintet Healing" },
            ["55339"] = new SkillDefinition { Name = "Touring Song Healing", Type = SkillType.Heal, Element = ElementType.Fire, Description = "Touring Song Healing" },
            ["55342"] = new SkillDefinition { Name = "Healing Rhapsody", Type = SkillType.Heal, Element = ElementType.Fire, Description = "Healing Rhapsody" },
            ["2207620"] = new SkillDefinition { Name = "Vitality Release", Type = SkillType.Heal, Element = ElementType.Fire, Description = "Vitality Release" },
*/
            ["2330"] = new SkillDefinition { Name = "ضربه ستون آتش", Type = SkillType.Damage, Element = ElementType.Fire, Description = "ضربه ستون آتش" }, 
            ["55314"] = new SkillDefinition { Name = "شفای انکو", Type = SkillType.Heal, Element = ElementType.Fire, Description = "شفای انکو" }, 
            ["230101"] = new SkillDefinition { Name = "قطعه جمعی / مرتبط با شفای انکو", Type = SkillType.Heal, Element = ElementType.Fire, Description = "قطعه جمعی / مرتبط با شفای انکو" }, 
            ["230401"] = new SkillDefinition { Name = "آسیب انکو", Type = SkillType.Damage, Element = ElementType.Fire, Description = "آسیب انکو" }, 
            ["230501"] = new SkillDefinition { Name = "آسیب انکو با اجرا بی‌پایان", Type = SkillType.Damage, Element = ElementType.Fire, Description = "آسیب انکو با اجرا بی‌پایان" }, 
            ["2031111"] = new SkillDefinition { Name = "ضربه شانس (نوازنده روح)", Type = SkillType.Damage, Element = ElementType.Light, Description = "ضربه شانس (نوازنده روح)" }, 
            ["2306"] = new SkillDefinition { Name = "ضربان تقویت‌شده", Type = SkillType.Damage, Element = ElementType.Fire, Description = "ضربان تقویت‌شده" }, 
            ["2317"] = new SkillDefinition { Name = "ضربه شدید", Type = SkillType.Damage, Element = ElementType.Fire, Description = "ضربه شدید" }, 
            ["2321"] = new SkillDefinition { Name = "کوبش سیم‌های ساز", Type = SkillType.Damage, Element = ElementType.Fire, Description = "کوبش سیم‌های ساز" }, 
            ["2322"] = new SkillDefinition { Name = "کوبش سیم‌های ساز", Type = SkillType.Damage, Element = ElementType.Fire, Description = "کوبش سیم‌های ساز" }, 
            ["2323"] = new SkillDefinition { Name = "کوبش سیم‌های ساز", Type = SkillType.Damage, Element = ElementType.Fire, Description = "کوبش سیم‌های ساز" }, 
            ["2324"] = new SkillDefinition { Name = "کوبش سیم‌های ساز", Type = SkillType.Damage, Element = ElementType.Fire, Description = "کوبش سیم‌های ساز" }, 
            ["2331"] = new SkillDefinition { Name = "موج صوتی", Type = SkillType.Damage, Element = ElementType.Fire, Description = "موج صوتی" }, 
            ["2335"] = new SkillDefinition { Name = "آسیب خیال بی‌پایان", Type = SkillType.Damage, Element = ElementType.Fire, Description = "آسیب خیال بی‌پایان" }, 
            ["230102"] = new SkillDefinition { Name = "قطعه جمعی", Type = SkillType.Damage, Element = ElementType.Fire, Description = "قطعه جمعی" }, 
            ["230103"] = new SkillDefinition { Name = "قطعه جمعی", Type = SkillType.Damage, Element = ElementType.Fire, Description = "قطعه جمعی" }, 
            ["230104"] = new SkillDefinition { Name = "قطعه جمعی", Type = SkillType.Damage, Element = ElementType.Fire, Description = "قطعه جمعی" }, 
            ["230105"] = new SkillDefinition { Name = "آسیب رقص آتشین", Type = SkillType.Damage, Element = ElementType.Fire, Description = "آسیب رقص آتشین" }, 
            ["230106"] = new SkillDefinition { Name = "آسیب نت‌های شعله‌ور", Type = SkillType.Damage, Element = ElementType.Fire, Description = "آسیب نت‌های شعله‌ور" }, 
            ["231001"] = new SkillDefinition { Name = "آسیب خیال آتشین", Type = SkillType.Damage, Element = ElementType.Fire, Description = "آسیب خیال آتشین" }, 
            ["55301"] = new SkillDefinition { Name = "شفای خیال آتشین", Type = SkillType.Heal, Element = ElementType.Fire, Description = "شفای خیال آتشین" }, 
            ["55311"] = new SkillDefinition { Name = "تبدیل قطعه انکو", Type = SkillType.Heal, Element = ElementType.Fire, Description = "تبدیل قطعه انکو" }, 
            ["55341"] = new SkillDefinition { Name = "شفای قطعه شجاعانه", Type = SkillType.Heal, Element = ElementType.Fire, Description = "شفای قطعه شجاعانه" }, 
            ["55346"] = new SkillDefinition { Name = "شفای خیال بی‌پایان", Type = SkillType.Heal, Element = ElementType.Fire, Description = "شفای خیال بی‌پایان" }, 
            ["55355"] = new SkillDefinition { Name = "شفای استراحت", Type = SkillType.Heal, Element = ElementType.Fire, Description = "شفای استراحت" }, 
            ["2207141"] = new SkillDefinition { Name = "نت موسیقی", Type = SkillType.Heal, Element = ElementType.Fire, Description = "نت موسیقی" }, 
            ["2207151"] = new SkillDefinition { Name = "شفای شعله‌ور", Type = SkillType.Heal, Element = ElementType.Fire, Description = "شفای شعله‌ور" }, 
            ["2207431"] = new SkillDefinition { Name = "شفای رقص آتشین", Type = SkillType.Heal, Element = ElementType.Fire, Description = "شفای رقص آتشین" }, 
            ["2301"] = new SkillDefinition { Name = "نواختن سیم‌های ساز", Type = SkillType.Damage, Element = ElementType.Fire, Description = "نواختن سیم‌های ساز" }, 
            ["2302"] = new SkillDefinition { Name = "نواختن سیم‌های ساز", Type = SkillType.Damage, Element = ElementType.Fire, Description = "نواختن سیم‌های ساز" }, 
            ["2303"] = new SkillDefinition { Name = "نواختن سیم‌های ساز", Type = SkillType.Damage, Element = ElementType.Fire, Description = "نواختن سیم‌های ساز" }, 
            ["2304"] = new SkillDefinition { Name = "نواختن سیم‌های ساز", Type = SkillType.Damage, Element = ElementType.Fire, Description = "نواختن سیم‌های ساز" }, 
            ["2312"] = new SkillDefinition { Name = "آسیب پنج‌نوازی فوران", Type = SkillType.Damage, Element = ElementType.Fire, Description = "آسیب پنج‌نوازی فوران" }, 
            ["2313"] = new SkillDefinition { Name = "پاشیدن شور و شوق", Type = SkillType.Damage, Element = ElementType.Fire, Description = "پاشیدن شور و شوق" }, 
            ["2332"] = new SkillDefinition { Name = "تقویت پاشیدن شور و شوق", Type = SkillType.Damage, Element = ElementType.Fire, Description = "تقویت پاشیدن شور و شوق" }, 
            ["2336"] = new SkillDefinition { Name = "آسیب قطعه تورنئو", Type = SkillType.Damage, Element = ElementType.Fire, Description = "آسیب قطعه تورنئو" }, 
            ["2366"] = new SkillDefinition { Name = "آسیب قطعه تورنئو", Type = SkillType.Damage, Element = ElementType.Fire, Description = "آسیب قطعه تورنئو (تکرار بلندگو)" }, 
            ["55302"] = new SkillDefinition { Name = "شفای ضربان", Type = SkillType.Heal, Element = ElementType.Fire, Description = "شفای ضربان" }, 
            ["55304"] = new SkillDefinition { Name = "شفای پنج‌نوازی فوران", Type = SkillType.Heal, Element = ElementType.Fire, Description = "شفای پنج‌نوازی فوران" }, 
            ["55339"] = new SkillDefinition { Name = "شفای قطعه تورنئو", Type = SkillType.Heal, Element = ElementType.Fire, Description = "شفای قطعه تورنئو" }, 
            ["55342"] = new SkillDefinition { Name = "شفای قطعه جمعی", Type = SkillType.Heal, Element = ElementType.Fire, Description = "شفای قطعه جمعی" }, 
            ["2207620"] = new SkillDefinition { Name = "آزادسازی انرژی", Type = SkillType.Heal, Element = ElementType.Fire, Description = "آزادسازی انرژی" },

            ["1501"] = new SkillDefinition { Name = "Vine Mastery", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Vine Mastery" },
            ["1502"] = new SkillDefinition { Name = "Vine Mastery", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Vine Mastery" },
            ["1503"] = new SkillDefinition { Name = "Vine Mastery", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Vine Mastery" },
            ["1504"] = new SkillDefinition { Name = "Vine Mastery", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Vine Mastery" },
            ["1509"] = new SkillDefinition { Name = "Hope Barrier Damage", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Hope Barrier Damage" },
            ["1518"] = new SkillDefinition { Name = "Wild Bloom", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Wild Bloom" },
            ["1529"] = new SkillDefinition { Name = "Full Bloom Infusion (Damage & Healing)", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Full Bloom Infusion (Damage & Healing)" },
            ["1550"] = new SkillDefinition { Name = "Unbridled Seed", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Unbridled Seed" },
            ["1551"] = new SkillDefinition { Name = "Wild Seed", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Wild Seed" },
            ["1560"] = new SkillDefinition { Name = "Regeneration Pulse", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Regeneration Pulse" },
            ["20301"] = new SkillDefinition { Name = "Life Bloom", Type = SkillType.Heal, Element = ElementType.Earth, Description = "Life Bloom" },
            ["21402"] = new SkillDefinition { Name = "Wild Bloom Healing", Type = SkillType.Heal, Element = ElementType.Earth, Description = "Wild Bloom Healing" },
            ["21404"] = new SkillDefinition { Name = "Nourishment", Type = SkillType.Heal, Element = ElementType.Earth, Description = "Nourishment" },
            ["21406"] = new SkillDefinition { Name = "Forest's Prayer", Type = SkillType.Heal, Element = ElementType.Earth, Description = "Forest's Prayer" },
            ["21414"] = new SkillDefinition { Name = "Hope Barrier Duration (Damage & Healing)", Type = SkillType.Heal, Element = ElementType.Earth, Description = "Hope Barrier Duration (Damage & Healing)" },
            ["21427"] = new SkillDefinition { Name = "Resting Healing", Type = SkillType.Heal, Element = ElementType.Earth, Description = "Resting Healing" },
            ["21428"] = new SkillDefinition { Name = "Resting Healing", Type = SkillType.Heal, Element = ElementType.Earth, Description = "Resting Healing" },
            ["21429"] = new SkillDefinition { Name = "Resting Healing", Type = SkillType.Heal, Element = ElementType.Earth, Description = "Resting Healing" },
            ["21430"] = new SkillDefinition { Name = "Resting Healing", Type = SkillType.Heal, Element = ElementType.Earth, Description = "Resting Healing" },
            ["150103"] = new SkillDefinition { Name = "Unbridled Seed", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Unbridled Seed" },
            ["150104"] = new SkillDefinition { Name = "Unbridled Seed", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Unbridled Seed" },
            ["150106"] = new SkillDefinition { Name = "Infusion", Type = SkillType.Heal, Element = ElementType.Earth, Description = "Infusion" },
            ["150107"] = new SkillDefinition { Name = "Infusion", Type = SkillType.Heal, Element = ElementType.Earth, Description = "Infusion" },
            ["2031005"] = new SkillDefinition { Name = "Lucky Strike (Forest Whisperer)", Type = SkillType.Damage, Element = ElementType.Light, Description = "Lucky Strike (Forest Whisperer)" },
            ["2202091"] = new SkillDefinition { Name = "Healing Link", Type = SkillType.Heal, Element = ElementType.Earth, Description = "Healing Link" },
            ["2202311"] = new SkillDefinition { Name = "Seed of Nourishment", Type = SkillType.Heal, Element = ElementType.Earth, Description = "Seed of Nourishment" },
            ["1541"] = new SkillDefinition { Name = "Wild Bloom", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Wild Bloom" },
            ["1561"] = new SkillDefinition { Name = "Regeneration Pulse (Damage & Healing)", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Regeneration Pulse (Damage & Healing)" },
            ["21423"] = new SkillDefinition { Name = "Symbiosis Mark", Type = SkillType.Heal, Element = ElementType.Earth, Description = "Symbiosis Mark" },
            ["21424"] = new SkillDefinition { Name = "Thorns", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Thorns" },
            ["150101"] = new SkillDefinition { Name = "Deer Rush", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Deer Rush" },
            ["150110"] = new SkillDefinition { Name = "Infusion", Type = SkillType.Heal, Element = ElementType.Earth, Description = "Infusion" },

            ["2031105"] = new SkillDefinition { Name = "Lucky Strike (Judgment)", Type = SkillType.Damage, Element = ElementType.Light, Description = "Lucky Strike (Judgment)" },
            ["220101"] = new SkillDefinition { Name = "Unerring Shot", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Unerring Shot" },
            ["220103"] = new SkillDefinition { Name = "Unerring Shot", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Unerring Shot" },
            ["220104"] = new SkillDefinition { Name = "Storm Arrows", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Storm Arrows" },
            ["2295"] = new SkillDefinition { Name = "Sharp Eye · Light Energy Giant Arrow", Type = SkillType.Damage, Element = ElementType.Light, Description = "Sharp Eye · Light Energy Giant Arrow" },
            ["2291"] = new SkillDefinition { Name = "Sharp Eye · Light Energy Giant Arrow (Talent)", Type = SkillType.Damage, Element = ElementType.Light, Description = "Sharp Eye · Light Energy Giant Arrow (Talent)" },
            ["2289"] = new SkillDefinition { Name = "Arrow Rain", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Arrow Rain" },
            ["2233"] = new SkillDefinition { Name = "Concentrated Shot", Type = SkillType.Damage, Element = ElementType.Light, Description = "Concentrated Shot" },
            ["2288"] = new SkillDefinition { Name = "Light Energy Bombardment", Type = SkillType.Damage, Element = ElementType.Light, Description = "Light Energy Bombardment" },
            ["220102"] = new SkillDefinition { Name = "Raging Shot", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Raging Shot" },
            ["220108"] = new SkillDefinition { Name = "Explosive Arrow", Type = SkillType.Damage, Element = ElementType.Fire, Description = "Explosive Arrow" },
            ["220109"] = new SkillDefinition { Name = "Deterrent Shot", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Deterrent Shot" },
            ["1700820"] = new SkillDefinition { Name = "Wolf Coordinated Attack", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Wolf Coordinated Attack" },
            ["1700827"] = new SkillDefinition { Name = "Wolf Normal Attack", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Wolf Normal Attack" },
            ["2292"] = new SkillDefinition { Name = "Pounce", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Pounce" },
            ["2203512"] = new SkillDefinition { Name = "Stomp", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Stomp" },
            ["55231"] = new SkillDefinition { Name = "Explosive Shot", Type = SkillType.Damage, Element = ElementType.Fire, Description = "Explosive Shot" },
            ["220110"] = new SkillDefinition { Name = "Explosive Arrow Detonation", Type = SkillType.Damage, Element = ElementType.Fire, Description = "Explosive Arrow Detonation" },
            ["2203291"] = new SkillDefinition { Name = "Falcon Strike", Type = SkillType.Damage, Element = ElementType.Light, Description = "Falcon Strike" },
            ["220113"] = new SkillDefinition { Name = "Phantom Falcon", Type = SkillType.Damage, Element = ElementType.Light, Description = "Phantom Falcon" },
            ["2203621"] = new SkillDefinition { Name = "Prism", Type = SkillType.Damage, Element = ElementType.Light, Description = "Prism" },
            ["2203622"] = new SkillDefinition { Name = "Prism Splash", Type = SkillType.Damage, Element = ElementType.Light, Description = "Prism Splash" },
            ["220112"] = new SkillDefinition { Name = "Light Rift", Type = SkillType.Damage, Element = ElementType.Light, Description = "Light Rift" },
            ["220106"] = new SkillDefinition { Name = "Double Shot", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Double Shot" },
            ["2203521"] = new SkillDefinition { Name = "Implosion (Steel Beak Trigger)", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Implosion (Steel Beak Trigger)" },
            ["2203181"] = new SkillDefinition { Name = "Lightning Strike", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Lightning Strike" },
            ["2294"] = new SkillDefinition { Name = "Light Intent · Quad Shot", Type = SkillType.Damage, Element = ElementType.Light, Description = "Light Intent · Quad Shot" },
            ["220111"] = new SkillDefinition { Name = "Light Intent · Quad Shot", Type = SkillType.Damage, Element = ElementType.Light, Description = "Light Intent · Quad Shot" },
            ["220203"] = new SkillDefinition { Name = "Light Intent · Quad Shot", Type = SkillType.Damage, Element = ElementType.Light, Description = "Light Intent · Quad Shot" },
            ["2031109"] = new SkillDefinition { Name = "Lucky Strike (Archer)", Type = SkillType.Damage, Element = ElementType.Light, Description = "Lucky Strike (Archer)" },
            ["220301"] = new SkillDefinition { Name = "Sharp Eye · Light Energy Giant Arrow", Type = SkillType.Damage, Element = ElementType.Light, Description = "Sharp Eye · Light Energy Giant Arrow" },
            ["2352"] = new SkillDefinition { Name = "Celestial Eagle", Type = SkillType.Damage, Element = ElementType.Light, Description = "Celestial Eagle" },

            ["120401"] = new SkillDefinition { Name = "Rain Strikes the Rising Tide", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Rain Strikes the Rising Tide" },
            ["1203"] = new SkillDefinition { Name = "Rain Strikes the Rising Tide", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Rain Strikes the Rising Tide" },
            ["120501"] = new SkillDefinition { Name = "Rain Strikes the Rising Tide", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Rain Strikes the Rising Tide" },
            ["120201"] = new SkillDefinition { Name = "Rain Strikes the Rising Tide", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Rain Strikes the Rising Tide" },
            ["120301"] = new SkillDefinition { Name = "Rain Strikes the Rising Tide", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Rain Strikes the Rising Tide" },
            ["2031102"] = new SkillDefinition { Name = "Lucky Strike (Ice Mage)", Type = SkillType.Damage, Element = ElementType.Light, Description = "Lucky Strike (Ice Mage)" },
            ["1248"] = new SkillDefinition { Name = "Extreme Cold · Ice and Snow Hymn", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Extreme Cold · Ice and Snow Hymn" },
            ["1263"] = new SkillDefinition { Name = "Extreme Cold · Ice and Snow Hymn", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Extreme Cold · Ice and Snow Hymn" },
            ["120902"] = new SkillDefinition { Name = "Ice Spear", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Ice Spear" },
            ["1262"] = new SkillDefinition { Name = "Meteor Storm", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Meteor Storm" },
            ["121501"] = new SkillDefinition { Name = "Clear Flood Encircling Pearl", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Clear Flood Encircling Pearl" },
            ["1216"] = new SkillDefinition { Name = "Enhanced Clear Flood Encircling Pearl", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Enhanced Clear Flood Encircling Pearl" },
            ["1257"] = new SkillDefinition { Name = "Frost Storm", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Frost Storm" },
            ["1250"] = new SkillDefinition { Name = "Water Vortex", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Water Vortex" },
            ["2204081"] = new SkillDefinition { Name = "Ice Arrow Explosion", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Ice Arrow Explosion" },
            ["121302"] = new SkillDefinition { Name = "Ice Arrow", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Ice Arrow" },
            ["1259"] = new SkillDefinition { Name = "Frost Comet", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Frost Comet" },
            ["120901"] = new SkillDefinition { Name = "Piercing Ice Spear", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Piercing Ice Spear" },
            ["2204241"] = new SkillDefinition { Name = "Frost Impact", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Frost Impact" },
            ["1261"] = new SkillDefinition { Name = "Instant Frost Storm", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Instant Frost Storm" },

            ["2401"] = new SkillDefinition { Name = "Sword of Justice", Type = SkillType.Damage, Element = ElementType.Light, Description = "Sword of Justice" },
            ["2402"] = new SkillDefinition { Name = "Sword of Justice", Type = SkillType.Damage, Element = ElementType.Light, Description = "Sword of Justice" },
            ["2403"] = new SkillDefinition { Name = "Sword of Justice", Type = SkillType.Damage, Element = ElementType.Light, Description = "Sword of Justice" },
            ["2404"] = new SkillDefinition { Name = "Sword of Justice", Type = SkillType.Damage, Element = ElementType.Light, Description = "Sword of Justice" },
            ["2416"] = new SkillDefinition { Name = "Judgment", Type = SkillType.Damage, Element = ElementType.Light, Description = "Judgment" },
            ["2417"] = new SkillDefinition { Name = "Judgment", Type = SkillType.Damage, Element = ElementType.Light, Description = "Judgment" },
            ["2407"] = new SkillDefinition { Name = "Awe · Holy Light Infusion", Type = SkillType.Damage, Element = ElementType.Light, Description = "Awe · Holy Light Infusion" },
            ["2031110"] = new SkillDefinition { Name = "Lucky Strike (Sword & Shield)", Type = SkillType.Damage, Element = ElementType.Light, Description = "Lucky Strike (Sword & Shield)" },
            ["2405"] = new SkillDefinition { Name = "Brave Shield Strike", Type = SkillType.Damage, Element = ElementType.Light, Description = "Brave Shield Strike" },
            ["2450"] = new SkillDefinition { Name = "Radiant Impact", Type = SkillType.Damage, Element = ElementType.Light, Description = "Radiant Impact" },
            ["2410"] = new SkillDefinition { Name = "Verdict", Type = SkillType.Damage, Element = ElementType.Light, Description = "Verdict" },
            ["2451"] = new SkillDefinition { Name = "Verdict (Holy Trigger)", Type = SkillType.Damage, Element = ElementType.Light, Description = "Verdict (Holy Trigger)" },
            ["2452"] = new SkillDefinition { Name = "Scorching Verdict", Type = SkillType.Damage, Element = ElementType.Fire, Description = "Scorching Verdict" },
            ["2412"] = new SkillDefinition { Name = "Liquidation", Type = SkillType.Damage, Element = ElementType.Light, Description = "Liquidation" },
            ["2413"] = new SkillDefinition { Name = "Blazing Liquidation", Type = SkillType.Damage, Element = ElementType.Fire, Description = "Blazing Liquidation" },
            ["240101"] = new SkillDefinition { Name = "Throw Shield", Type = SkillType.Damage, Element = ElementType.Light, Description = "Throw Shield" },
            ["2206401"] = new SkillDefinition { Name = "Holy Strike", Type = SkillType.Damage, Element = ElementType.Light, Description = "Holy Strike" },
            ["55421"] = new SkillDefinition { Name = "Verdict Heal", Type = SkillType.Heal, Element = ElementType.Light, Description = "Verdict Heal" },
            ["55404"] = new SkillDefinition { Name = "Holy Ring Damage/Heal (Same ID)", Type = SkillType.Heal, Element = ElementType.Light, Description = "Holy Ring Damage/Heal (Same ID)" },
            ["2406"] = new SkillDefinition { Name = "Vanguard Strike/Vanguard Pursuit", Type = SkillType.Damage, Element = ElementType.Light, Description = "Vanguard Strike/Vanguard Pursuit" },
            ["2421"] = new SkillDefinition { Name = "Holy Sword", Type = SkillType.Damage, Element = ElementType.Light, Description = "Holy Sword" },
            ["240102"] = new SkillDefinition { Name = "Radiant Resolve", Type = SkillType.Damage, Element = ElementType.Light, Description = "Radiant Resolve" },
            ["55412"] = new SkillDefinition { Name = "Cold Conquest", Type = SkillType.Damage, Element = ElementType.Light, Description = "Cold Conquest" },
            ["2206241"] = new SkillDefinition { Name = "Holy Mark", Type = SkillType.Damage, Element = ElementType.Light, Description = "Holy Mark" },
            ["2206552"] = new SkillDefinition { Name = "Radiant Core", Type = SkillType.Damage, Element = ElementType.Light, Description = "Radiant Core" },

            ["1005240"] = new SkillDefinition { Name = "Ultimate! Hunting Slash (Vanguard)", Type = SkillType.Damage, Element = ElementType.Dark, Description = "Ultimate! Hunting Slash (Vanguard)" },
            ["1006940"] = new SkillDefinition { Name = "Secret Art! Cocoon Technique (Spider)", Type = SkillType.Damage, Element = ElementType.Dark, Description = "Secret Art! Cocoon Technique (Spider)" },
            ["391006"] = new SkillDefinition { Name = "Ultimate! Chaotic Missiles (Phantom Devourer)", Type = SkillType.Damage, Element = ElementType.Dark, Description = "Ultimate! Chaotic Missiles (Phantom Devourer)" },
            ["1008440"] = new SkillDefinition { Name = "Secret Art! Turbulent Wind Howl (Flying Fish)", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Secret Art! Turbulent Wind Howl (Flying Fish)" },
            ["391301"] = new SkillDefinition { Name = "Ultimate! Electromagnetic Bomb (Gunner)", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Ultimate! Electromagnetic Bomb (Gunner)" },
            ["3913001"] = new SkillDefinition { Name = "Ultimate! Electromagnetic Bomb (Gunner)", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Ultimate! Electromagnetic Bomb (Gunner)" },
            ["1008641"] = new SkillDefinition { Name = "Hurricane Goblin Warrior", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Hurricane Goblin Warrior" },
            ["3210081"] = new SkillDefinition { Name = "Lizardman Hunter (Passive)", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Lizardman Hunter (Passive)" },
            ["391007"] = new SkillDefinition { Name = "Goblin Crossbowman (Passive)", Type = SkillType.Damage, Element = ElementType.Physics, Description = "Goblin Crossbowman (Passive)" },
            ["391008"] = new SkillDefinition { Name = "Mutant Peak (Passive)", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Mutant Peak Crossbowman (Passive)" },
            ["1700440"] = new SkillDefinition { Name = "Muke Boss", Type = SkillType.Damage, Element = ElementType.Dark, Description = "Muke Boss" },

            ["1222"] = new SkillDefinition { Name = "Phantom Charge", Type = SkillType.Damage, Element = ElementType.Light, Description = "Phantom Charge" },
            ["1241"] = new SkillDefinition { Name = "Beam", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Beam" },
            ["199902"] = new SkillDefinition { Name = "Rock Shield", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Rock Shield" },

            // Ice
            ["1240"] = new SkillDefinition { Name = "Freezing Cold Wind", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Freezing Cold Wind" },
            ["1242"] = new SkillDefinition { Name = "Frost Spear", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Frost Spear" },
            ["1243"] = new SkillDefinition { Name = "Ice Infusion", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Ice Infusion" },
            ["1245"] = new SkillDefinition { Name = "Ice Shelter", Type = SkillType.Heal, Element = ElementType.Ice, Description = "Ice Shelter" },
            ["1246"] = new SkillDefinition { Name = "Tide Convergence - Water Tornado", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Tide Convergence - Water Tornado" },
            ["1247"] = new SkillDefinition { Name = "Talent Trigger Comet", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Talent Trigger Comet" },
            ["1249"] = new SkillDefinition { Name = "Cooperative Ice Crystal", Type = SkillType.Damage, Element = ElementType.Ice, Description = "Cooperative Ice Crystal" },

            // Wind
            ["1405"] = new SkillDefinition { Name = "Gale Stab", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Gale Stab" },
            ["1406"] = new SkillDefinition { Name = "Wind Elegance Dance", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Wind Elegance Dance" },
            ["1407"] = new SkillDefinition { Name = "Wind God", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Wind God" },
            ["1410"] = new SkillDefinition { Name = "Wind God · Wind of Breakthrough", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Wind God · Wind of Breakthrough" },
            ["1426"] = new SkillDefinition { Name = "Wind God · Wind of Breakthrough", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Wind God · Wind of Breakthrough" },
            ["1430"] = new SkillDefinition { Name = "Soaring Return", Type = SkillType.Damage, Element = ElementType.Wind, Description = "Soaring Return (Extra Version)" },

            // Earth
            ["1517"] = new SkillDefinition { Name = "Control Vines - Red Light Counter", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Control Vines - Red Light Counter" },
            ["1527"] = new SkillDefinition { Name = "Floral Revival", Type = SkillType.Heal, Element = ElementType.Earth, Description = "Floral Revival" },
            ["1556"] = new SkillDefinition { Name = "Floral Revival", Type = SkillType.Heal, Element = ElementType.Earth, Description = "Floral Revival" },
            ["1562"] = new SkillDefinition { Name = "Regeneration Pulse - Diffuse Heal", Type = SkillType.Heal, Element = ElementType.Earth, Description = "Regeneration Pulse - Diffuse Heal" },

            // Thunder
            ["1711"] = new SkillDefinition { Name = "My Style Secret Blade", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "My Style Secret Blade" },
            ["1712"] = new SkillDefinition { Name = "My Style Secret Blade 2", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "My Style Secret Blade 2" },
            ["1716"] = new SkillDefinition { Name = "Ultra Output", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Ultra Output" },
            ["1720"] = new SkillDefinition { Name = "Mind's Eye", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "Mind's Eye" },
            ["1721"] = new SkillDefinition { Name = "My Style Secret Blade · First Form · Modified", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "My Style Secret Blade · First Form · Modified" },
            ["1722"] = new SkillDefinition { Name = "My Style Secret Blade · Second Form · Modified", Type = SkillType.Damage, Element = ElementType.Thunder, Description = "My Style Secret Blade · Second Form · Modified" },

            // Rock / Shield
            ["1905"] = new SkillDefinition { Name = "Dragon Slayer Technique", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Dragon Slayer Technique" },
            ["1906"] = new SkillDefinition { Name = "Retreat Slash", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Retreat Slash" },
            ["1907"] = new SkillDefinition { Name = "Rock Guard · Cracking Loop", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Rock Guard · Cracking Loop" },
            ["1917"] = new SkillDefinition { Name = "Giant Rock Impact", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Giant Rock Impact" },
            ["1922"] = new SkillDefinition { Name = "Shield Slam", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Shield Slam" },
            ["1925"] = new SkillDefinition { Name = "Rage Burst", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Rage Burst" },
            ["1926"] = new SkillDefinition { Name = "Grasp of Sandstone", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Grasp of Sandstone" },
            ["1928"] = new SkillDefinition { Name = "Rock's Protection", Type = SkillType.Heal, Element = ElementType.Earth, Description = "Rock's Protection" },
            ["1929"] = new SkillDefinition { Name = "Immovable as a Mountain", Type = SkillType.Heal, Element = ElementType.Earth, Description = "Immovable as a Mountain" },
            ["1936"] = new SkillDefinition { Name = "Giant Rock Body", Type = SkillType.Heal, Element = ElementType.Earth, Description = "Giant Rock Body" },
            ["1938"] = new SkillDefinition { Name = "Heroic Bulwark", Type = SkillType.Heal, Element = ElementType.Earth, Description = "Heroic Bulwark" },
            ["1941"] = new SkillDefinition { Name = "Fragmented Star Collapse", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Fragmented Star Collapse" },
            ["1943"] = new SkillDefinition { Name = "Giant Rock Strike", Type = SkillType.Damage, Element = ElementType.Earth, Description = "Giant Rock Strike" },

            // سایر (انتخاب شده)
            ["2220"] = new SkillDefinition { Name = "تیر طوفان", Type = SkillType.Damage, Element = ElementType.Wind, Description = "تیر طوفان" },
            ["2221"] = new SkillDefinition { Name = "تیر طوفان SP", Type = SkillType.Damage, Element = ElementType.Wind, Description = "تیر طوفان SP" },
            ["2230"] = new SkillDefinition { Name = "شلیک موج خشم", Type = SkillType.Damage, Element = ElementType.Earth, Description = "شلیک موج خشم" },
            ["2231"] = new SkillDefinition { Name = "تمرکز ذهنی", Type = SkillType.Damage, Element = ElementType.Light, Description = "تمرکز ذهنی" },
            ["2232"] = new SkillDefinition { Name = "باران تیر", Type = SkillType.Damage, Element = ElementType.Wind, Description = "باران تیر" },
            ["2234"] = new SkillDefinition { Name = "بمباران نورانی", Type = SkillType.Damage, Element = ElementType.Light, Description = "بمباران نورانی" },
            ["2237"] = new SkillDefinition { Name = "فراخوانی وحشی", Type = SkillType.Damage, Element = ElementType.Wind, Description = "فراخوانی وحشی" },
            ["2238"] = new SkillDefinition { Name = "شلیک انفجاری", Type = SkillType.Damage, Element = ElementType.Fire, Description = "شلیک انفجاری" },
            ["1256"] = new SkillDefinition { Name = "موج", Type = SkillType.Damage, Element = ElementType.Wind, Description = "موج" },
            // ===== 2025-08-19 تکمیل دسته‌ای: وارد کردن آیتم‌های جایگزین از skill_names.json =====
            ["1201"] = new SkillDefinition { Name = "باران موج‌ساز", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "باران موج‌ساز" },
            ["1202"] = new SkillDefinition { Name = "باران موج‌ساز - گلوله منحنی", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "باران موج‌ساز - گلوله منحنی" },
            ["1204"] = new SkillDefinition { Name = "باران موج‌ساز - حمله عادی مرحله 1", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "باران موج‌ساز - حمله عادی مرحله 1" },
            ["1210"] = new SkillDefinition { Name = "چرخش آب", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "چرخش آب" },
            ["1211"] = new SkillDefinition { Name = "گرداب پاک", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "گرداب پاک" },
            ["1219"] = new SkillDefinition { Name = "گرداب یخ", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "گرداب یخ" },
            ["1223"] = new SkillDefinition { Name = "جهش فانتوم", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "جهش فانتوم" },
            ["1238"] = new SkillDefinition { Name = "گرداب آب - نسخه غیرفعال", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "گرداب آب - نسخه غیرفعال" },
            ["1239"] = new SkillDefinition { Name = "طوفان شهاب", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "طوفان شهاب" },
            ["1244"] = new SkillDefinition { Name = "طوفان یخی", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "طوفان یخی" },
            ["1251"] = new SkillDefinition { Name = "چرخش آب", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "چرخش آب" },
            ["1258"] = new SkillDefinition { Name = "استعداد - سقوط بلور یخ", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "استعداد - سقوط بلور یخ" },
            ["1725"] = new SkillDefinition { Name = "برق متوالی 2", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "برق متوالی 2" },
            ["1726"] = new SkillDefinition { Name = "برق متوالی 3", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "برق متوالی 3" },
            ["1730"] = new SkillDefinition { Name = "نیروی بی‌پایان رعد و برق", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "نیروی بی‌پایان رعد و برق" },
            ["1731"] = new SkillDefinition { Name = "هدف سایه رعد هزارگانه", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "هدف سایه رعد هزارگانه" },
            ["1733"] = new SkillDefinition { Name = "داس رعد", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "داس رعد" },
            ["1734"] = new SkillDefinition { Name = "برش سریع رعد", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "برش سریع رعد" },
            ["1901"] = new SkillDefinition { Name = "نوک پایان جنگ 1 / گلوله سنگی", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "نوک پایان جنگ 1 / گلوله سنگی" },
            ["1902"] = new SkillDefinition { Name = "نوک پایان جنگ 2 / گلوله سنگی", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "نوک پایان جنگ 2 / گلوله سنگی" },
            ["1903"] = new SkillDefinition { Name = "نوک پایان جنگ 3", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "نوک پایان جنگ 3" },
            ["1904"] = new SkillDefinition { Name = "نوک پایان جنگ 4", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "نوک پایان جنگ 4" },
            ["1909"] = new SkillDefinition { Name = "نوک پایان جنگ (پرش)", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "نوک پایان جنگ (پرش)" },
            ["1912"] = new SkillDefinition { Name = "نوک پایان جنگ - مقابله با نور قرمز", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "نوک پایان جنگ - مقابله با نور قرمز" },
/*
            // 其他 (选摘)
            ["2220"] = new SkillDefinition { Name = "暴风箭矢", Type = SkillType.Damage, Element = ElementType.Wind, Description = "暴风箭矢" }, // ← 新增
            ["2221"] = new SkillDefinition { Name = "暴风箭矢SP", Type = SkillType.Damage, Element = ElementType.Wind, Description = "暴风箭矢SP" }, // ← 新增
            ["2230"] = new SkillDefinition { Name = "怒涛射击", Type = SkillType.Damage, Element = ElementType.Earth, Description = "怒涛射击" }, // ← 新增
            ["2231"] = new SkillDefinition { Name = "精神凝聚", Type = SkillType.Damage, Element = ElementType.Light, Description = "精神凝聚" }, // ← 新增
            ["2232"] = new SkillDefinition { Name = "箭雨", Type = SkillType.Damage, Element = ElementType.Wind, Description = "箭雨" }, // ← 新增
            ["2234"] = new SkillDefinition { Name = "光能轰炸", Type = SkillType.Damage, Element = ElementType.Light, Description = "光能轰炸" }, // ← 新增
            ["2237"] = new SkillDefinition { Name = "狂野呼唤", Type = SkillType.Damage, Element = ElementType.Wind, Description = "狂野呼唤" }, // ← 新增
            ["2238"] = new SkillDefinition { Name = "爆炸射击", Type = SkillType.Damage, Element = ElementType.Fire, Description = "爆炸射击" }, // ← 新增
            ["1256"] = new SkillDefinition { Name = "浪潮", Type = SkillType.Damage, Element = ElementType.Wind, Description = "浪潮" }, // ← 新增
                                                                                                                                     // ===== 2025-08-19 批量补齐：从 skill_names.json 导入的占位条目 =====
            ["1201"] = new SkillDefinition { Name = "雨打潮生", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "雨打潮生" }, // ← 2025-08-19 新增（占位）
            ["1202"] = new SkillDefinition { Name = "雨打潮生-转弯子弹", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "雨打潮生-转弯子弹" }, // ← 2025-08-19 新增（占位）
            ["1204"] = new SkillDefinition { Name = "雨打潮生-普攻1段", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "雨打潮生-普攻1段" }, // ← 2025-08-19 新增（占位）
            ["1210"] = new SkillDefinition { Name = "水之涡流", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "水之涡流" }, // ← 2025-08-19 新增（占位）
            ["1211"] = new SkillDefinition { Name = "清滝绕珠", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "清滝绕珠" }, // ← 2025-08-19 新增（占位）
            ["1219"] = new SkillDefinition { Name = "冰龙卷", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "冰龙卷" }, // ← 2025-08-19 新增（占位）
            ["1223"] = new SkillDefinition { Name = "幻影冲刺", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "幻影冲刺" }, // ← 2025-08-19 新增（占位）
            ["1238"] = new SkillDefinition { Name = "水龙卷-被动版", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "水龙卷-被动版" }, // ← 2025-08-19 新增（占位）
            ["1239"] = new SkillDefinition { Name = "陨星风暴", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "陨星风暴" }, // ← 2025-08-19 新增（占位）
            ["1244"] = new SkillDefinition { Name = "寒冰风暴", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "寒冰风暴" }, // ← 2025-08-19 新增（占位）
            ["1251"] = new SkillDefinition { Name = "水之涡流", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "水之涡流" }, // ← 2025-08-19 新增（占位）
            ["1258"] = new SkillDefinition { Name = "天赋-冰晶落", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "天赋-冰晶落" }, // ← 2025-08-19 新增（占位）
            ["1725"] = new SkillDefinition { Name = "霹雳连斩2", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "霹雳连斩2" }, // ← 2025-08-19 新增（占位）
            ["1726"] = new SkillDefinition { Name = "霹雳连斩3", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "霹雳连斩3" }, // ← 2025-08-19 新增（占位）
            ["1730"] = new SkillDefinition { Name = "无穷雷霆之力", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "无穷雷霆之力" }, // ← 2025-08-19 新增（占位）
            ["1731"] = new SkillDefinition { Name = "千雷闪影之意", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "千雷闪影之意" }, // ← 2025-08-19 新增（占位）
            ["1733"] = new SkillDefinition { Name = "雷霆之镰", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "雷霆之镰" }, // ← 2025-08-19 新增（占位）
            ["1734"] = new SkillDefinition { Name = "雷霆居合斩", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "雷霆居合斩" }, // ← 2025-08-19 新增（占位）
            ["1901"] = new SkillDefinition { Name = "止战之锋1/岩弹", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "止战之锋1/岩弹" }, // ← 2025-08-19 新增（占位）
            ["1902"] = new SkillDefinition { Name = "止战之锋2/岩弹", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "止战之锋2/岩弹" }, // ← 2025-08-19 新增（占位）
            ["1903"] = new SkillDefinition { Name = "止战之锋3", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "止战之锋3" }, // ← 2025-08-19 新增（占位）
            ["1904"] = new SkillDefinition { Name = "止战之锋4", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "止战之锋4" }, // ← 2025-08-19 新增（占位）
            ["1909"] = new SkillDefinition { Name = "止战之锋（跳跃）", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "止战之锋（跳跃）" }, // ← 2025-08-19 新增（占位）
            ["1912"] = new SkillDefinition { Name = "止战之锋-红光反制", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "止战之锋-红光反制" }, // ← 2025-08-19 新增（占位）
*/
            ["1924"] = new SkillDefinition { Name = "碎星冲", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "碎星冲" }, // ← 2025-08-19 新增（占位）
            ["1927"] = new SkillDefinition { Name = "砂石斗篷（初始）", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "砂石斗篷（初始）" }, // ← 2025-08-19 新增（占位）
            ["1930"] = new SkillDefinition { Name = "格挡冲击", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "格挡冲击" }, // ← 2025-08-19 新增（占位）
            ["1931"] = new SkillDefinition { Name = "格挡冲击", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "格挡冲击" }, // ← 2025-08-19 新增（占位）
            ["1932"] = new SkillDefinition { Name = "护盾猛击", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "护盾猛击" }, // ← 2025-08-19 新增（占位）
            ["1933"] = new SkillDefinition { Name = "止战之锋", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "止战之锋" }, // ← 2025-08-19 新增（占位）
            ["1934"] = new SkillDefinition { Name = "格挡冲击", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "格挡冲击" }, // ← 2025-08-19 新增（占位）
            ["1935"] = new SkillDefinition { Name = "格挡冲击-怒击", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "格挡冲击-怒击" }, // ← 2025-08-19 新增（占位）
            ["1937"] = new SkillDefinition { Name = "岩怒之击", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "岩怒之击" }, // ← 2025-08-19 新增（占位）
            ["1939"] = new SkillDefinition { Name = "岩怒之击", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "岩怒之击" }, // ← 2025-08-19 新增（占位）
            ["1940"] = new SkillDefinition { Name = "怒爆", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "怒爆" }, // ← 2025-08-19 新增（占位）
            ["1942"] = new SkillDefinition { Name = "崩裂", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "崩裂" }, // ← 2025-08-19 新增（占位）
            ["1944"] = new SkillDefinition { Name = "怒爆", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "怒爆" }, // ← 2025-08-19 新增（占位）
            ["1999"] = new SkillDefinition { Name = "岩之力", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "岩之力" }, // ← 2025-08-19 新增（占位）
            ["2201"] = new SkillDefinition { Name = "弹无虚发", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "弹无虚发" }, // ← 2025-08-19 新增（占位）
            ["2209"] = new SkillDefinition { Name = "锐眼·光能巨箭", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "锐眼·光能巨箭" }, // ← 2025-08-19 新增（占位）
            ["2222"] = new SkillDefinition { Name = "二连矢", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "二连矢" }, // ← 2025-08-19 新增（占位）
            ["2224"] = new SkillDefinition { Name = "夺命射击-四连矢", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "夺命射击-四连矢" }, // ← 2025-08-19 新增（占位）
            ["2235"] = new SkillDefinition { Name = "威慑射击", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "威慑射击" }, // ← 2025-08-19 新增（占位）
            ["2239"] = new SkillDefinition { Name = "爆炸箭二段", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "爆炸箭二段" }, // ← 2025-08-19 新增（占位）
            ["2240"] = new SkillDefinition { Name = "天翔贯星击-强化怒涛射击", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "天翔贯星击-强化怒涛射击" }, // ← 2025-08-19 新增（占位）
            ["2241"] = new SkillDefinition { Name = "天界雄鹰", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "天界雄鹰" }, // ← 2025-08-19 新增（占位）
            ["2242"] = new SkillDefinition { Name = "群兽践踏", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "群兽践踏" }, // ← 2025-08-19 新增（占位）
            ["2290"] = new SkillDefinition { Name = "锐眼·光能巨箭-聚怪(天赋)", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "锐眼·光能巨箭-聚怪(天赋)" }, // ← 2025-08-19 新增（占位）
            ["2293"] = new SkillDefinition { Name = "天赋-光能裂痕", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "天赋-光能裂痕" }, // ← 2025-08-19 新增（占位）
            ["2296"] = new SkillDefinition { Name = "幻影雄鹰", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "幻影雄鹰" }, // ← 2025-08-19 新增（占位）
            ["2307"] = new SkillDefinition { Name = "愈合节拍", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "愈合节拍" }, // ← 2025-08-19 新增（占位）
            ["2308"] = new SkillDefinition { Name = "聚合乐章", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "聚合乐章" }, // ← 2025-08-19 新增（占位）
            ["2309"] = new SkillDefinition { Name = "烈焰狂想", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "烈焰狂想" }, // ← 2025-08-19 新增（占位）
            ["2310"] = new SkillDefinition { Name = "鸣奏·英勇乐章", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "鸣奏·英勇乐章" }, // ← 2025-08-19 新增（占位）
            ["2311"] = new SkillDefinition { Name = "鸣奏·愈合乐章", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "鸣奏·愈合乐章" }, // ← 2025-08-19 新增（占位）
            ["2314"] = new SkillDefinition { Name = "升格·劲爆全场", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "升格·劲爆全场" }, // ← 2025-08-19 新增（占位）
            ["2315"] = new SkillDefinition { Name = "安可", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "安可" }, // ← 2025-08-19 新增（占位）
            ["2316"] = new SkillDefinition { Name = "万众瞩目", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "万众瞩目" }, // ← 2025-08-19 新增（占位）
            ["2318"] = new SkillDefinition { Name = "完结！愈合乐章", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "完结！愈合乐章" }, // ← 2025-08-19 新增（占位）
            ["2319"] = new SkillDefinition { Name = "音浪潮涌", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "音浪潮涌" }, // ← 2025-08-19 新增（占位）
            ["2320"] = new SkillDefinition { Name = "音塔爆炎冲击", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "音塔爆炎冲击" }, // ← 2025-08-19 新增（占位）
            ["2329"] = new SkillDefinition { Name = "炎舞奏者", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "炎舞奏者" }, // ← 2025-08-19 新增（占位）
            ["2330"] = new SkillDefinition { Name = "火柱冲击-炎舞奏者强化", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "火柱冲击-炎舞奏者强化" }, // ← 2025-08-19 新增（占位）
            ["2331"] = new SkillDefinition { Name = "音浪烈焰", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "音浪烈焰" }, // ← 2025-08-19 新增（占位）
            ["2332"] = new SkillDefinition { Name = "激昂·热情挥洒", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "激昂·热情挥洒" }, // ← 2025-08-19 新增（占位）
            ["2335"] = new SkillDefinition { Name = "升格·无限狂想", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "升格·无限狂想" }, // ← 2025-08-19 新增（占位）
            ["2352"] = new SkillDefinition { Name = "天界雄鹰", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "天界雄鹰" }, // ← 2025-08-19 新增（占位）
            ["2361"] = new SkillDefinition { Name = "愈合节拍copy", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "愈合节拍copy" }, // ← 2025-08-19 新增（占位）
            ["2362"] = new SkillDefinition { Name = "音波裁决", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "音波裁决" }, // ← 2025-08-19 新增（占位）
            ["2363"] = new SkillDefinition { Name = "激涌五重奏copy", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "激涌五重奏copy" }, // ← 2025-08-19 新增（占位）
            ["2364"] = new SkillDefinition { Name = "升格·劲爆全场copy", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "升格·劲爆全场copy" }, // ← 2025-08-19 新增（占位）
            ["2365"] = new SkillDefinition { Name = "升格·无限狂想copy", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "升格·无限狂想copy" }, // ← 2025-08-19 新增（占位）
            ["2399"] = new SkillDefinition { Name = "音响奶棍", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "音响奶棍" }, // ← 2025-08-19 新增（占位）
            ["2408"] = new SkillDefinition { Name = "投掷盾牌", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "投掷盾牌" }, // ← 2025-08-19 新增（占位）
            ["2409"] = new SkillDefinition { Name = "圣环", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "圣环" }, // ← 2025-08-19 新增（占位）
            ["2411"] = new SkillDefinition { Name = "灼热裁决", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "灼热裁决" }, // ← 2025-08-19 新增（占位）
            ["2414"] = new SkillDefinition { Name = "神圣壁垒", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "神圣壁垒" }, // ← 2025-08-19 新增（占位）
            ["2415"] = new SkillDefinition { Name = "圣光守卫", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "圣光守卫" }, // ← 2025-08-19 新增（占位）
            ["2417"] = new SkillDefinition { Name = "强化断罪", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "强化断罪" }, // ← 2025-08-19 新增（占位）
            ["2419"] = new SkillDefinition { Name = "冷酷征伐", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "冷酷征伐" }, // ← 2025-08-19 新增（占位）
            ["2420"] = new SkillDefinition { Name = "光明决心", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "光明决心" }, // ← 2025-08-19 新增（占位）
            ["2425"] = new SkillDefinition { Name = "投掷盾牌", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "投掷盾牌" }, // ← 2025-08-19 新增（占位）
            ["2452"] = new SkillDefinition { Name = "灼热裁决圣剑", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "灼热裁决圣剑" }, // ← 2025-08-19 新增（占位）
            ["3698"] = new SkillDefinition { Name = "风哥布林王(被动)", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "风哥布林王(被动)" }, // ← 2025-08-19 新增（占位）
            ["3901"] = new SkillDefinition { Name = "奥义！琉火咆哮(火魔)", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "奥义！琉火咆哮(火魔)" }, // ← 2025-08-19 新增（占位）
            ["3925"] = new SkillDefinition { Name = "绝技！无形冲击(巨魔)", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "绝技！无形冲击(巨魔)" }, // ← 2025-08-19 新增（占位）
            ["21418"] = new SkillDefinition { Name = "鹿之奔袭", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "鹿之奔袭" }, // ← 2025-08-19 新增（占位）
            ["21427"] = new SkillDefinition { Name = "惩击奶空A1段", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "惩击奶空A1段" }, // ← 2025-08-19 新增（占位）
            ["21428"] = new SkillDefinition { Name = "惩击奶空A2段", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "惩击奶空A2段" }, // ← 2025-08-19 新增（占位）
            ["21429"] = new SkillDefinition { Name = "惩击奶空A3段", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "惩击奶空A3段" }, // ← 2025-08-19 新增（占位）
            ["21430"] = new SkillDefinition { Name = "惩击奶空A4段", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "惩击奶空A4段" }, // ← 2025-08-19 新增（占位）
            ["27009"] = new SkillDefinition { Name = "冰箱BUFF", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "冰箱BUFF" }, // ← 2025-08-19 新增（占位）
            ["50036"] = new SkillDefinition { Name = "弱点打击", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "弱点打击" }, // ← 2025-08-19 新增（占位）
            ["50037"] = new SkillDefinition { Name = "格挡反击", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "格挡反击" }, // ← 2025-08-19 新增（占位）
            ["50049"] = new SkillDefinition { Name = "砂石斗篷（持续）", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "砂石斗篷（持续）" }, // ← 2025-08-19 新增（占位）
            ["50068"] = new SkillDefinition { Name = "格挡反击--强", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "格挡反击--强" }, // ← 2025-08-19 新增（占位）
            ["55231"] = new SkillDefinition { Name = "爆炸箭BUFF引爆", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "爆炸箭BUFF引爆" }, // ← 2025-08-19 新增（占位）
            ["55235"] = new SkillDefinition { Name = "光意·四连矢（溅射伤害）", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "光意·四连矢（溅射伤害）" }, // ← 2025-08-19 新增（占位）
            ["55236"] = new SkillDefinition { Name = "强化特攻最后一击虚拟体", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "强化特攻最后一击虚拟体" }, // ← 2025-08-19 新增（占位）
            ["55238"] = new SkillDefinition { Name = "弓-大招引力", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "弓-大招引力" }, // ← 2025-08-19 新增（占位）
            ["55239"] = new SkillDefinition { Name = "光能凝滞定身BUFF", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "光能凝滞定身BUFF" }, // ← 2025-08-19 新增（占位）
            ["55240"] = new SkillDefinition { Name = "光能轰炸伤害区域BUFF", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "光能轰炸伤害区域BUFF" }, // ← 2025-08-19 新增（占位）
            ["55328"] = new SkillDefinition { Name = "万众瞩目激涌五重奏弹奏翻倍", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "万众瞩目激涌五重奏弹奏翻倍" }, // ← 2025-08-19 新增（占位）
            ["55335"] = new SkillDefinition { Name = "万众瞩目热情挥洒3阶段", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "万众瞩目热情挥洒3阶段" }, // ← 2025-08-19 新增（占位）
            ["55344"] = new SkillDefinition { Name = "升格·劲爆全场", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "升格·劲爆全场" }, // ← 2025-08-19 新增（占位）
            ["55417"] = new SkillDefinition { Name = "冷酷征伐", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "冷酷征伐" }, // ← 2025-08-19 新增（占位）
            ["55431"] = new SkillDefinition { Name = "冷酷征伐伤害buff", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "冷酷征伐伤害buff" }, // ← 2025-08-19 新增（占位）
            ["55432"] = new SkillDefinition { Name = "冷冷酷征伐伤害buff", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "冷冷酷征伐伤害buff" }, // ← 2025-08-19 新增（占位）
            ["100730"] = new SkillDefinition { Name = "哥布林弩手主动", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "哥布林弩手主动" }, // ← 2025-08-19 新增（占位）
            ["102640"] = new SkillDefinition { Name = "绝技！猪突猛进(威猛野猪)", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "绝技！猪突猛进(威猛野猪)" }, // ← 2025-08-19 新增（占位）
            ["101112"] = new SkillDefinition { Name = "宠物雄鹰快速回旋", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "宠物雄鹰快速回旋" }, // ← 2025-08-19 新增（占位）
            ["141104"] = new SkillDefinition { Name = "变异蜂主动a1", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "变异蜂主动a1" }, // ← 2025-08-19 新增（占位）
            ["149904"] = new SkillDefinition { Name = "蒂娜龙卷", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "蒂娜龙卷" }, // ← 2025-08-19 新增（占位）
            ["179904"] = new SkillDefinition { Name = "神影斩-最后一击", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "神影斩-最后一击" }, // ← 2025-08-19 新增（占位）
            ["199903"] = new SkillDefinition { Name = "巨岩轰击", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "巨岩轰击" }, // ← 2025-08-19 新增（占位）
            ["220105"] = new SkillDefinition { Name = "光追箭", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "光追箭" }, // ← 2025-08-19 新增（占位）
            ["220106"] = new SkillDefinition { Name = "空中射击", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "空中射击" }, // ← 2025-08-19 新增（占位）
            ["220107"] = new SkillDefinition { Name = "魔法箭矢", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "魔法箭矢" }, // ← 2025-08-19 新增（占位）
            ["220110"] = new SkillDefinition { Name = "爆炸箭", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "爆炸箭" }, // ← 2025-08-19 新增（占位）
            ["221101"] = new SkillDefinition { Name = "弹无虚发-红光反制", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "弹无虚发-红光反制" }, // ← 2025-08-19 新增（占位）
            ["230106"] = new SkillDefinition { Name = "烈焰音符伤害", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "烈焰音符伤害" }, // ← 2025-08-19 新增（占位）
            ["391001"] = new SkillDefinition { Name = "绝技! 纷乱飞弹(虚蚀食人魔)1", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "绝技! 纷乱飞弹(虚蚀食人魔)1" }, // ← 2025-08-19 新增（占位）
            ["391002"] = new SkillDefinition { Name = "绝技! 纷乱飞弹(虚蚀食人魔)2", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "绝技! 纷乱飞弹(虚蚀食人魔)2" }, // ← 2025-08-19 新增（占位）
            ["391003"] = new SkillDefinition { Name = "绝技! 纷乱飞弹(虚蚀食人魔)3", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "绝技! 纷乱飞弹(虚蚀食人魔)3" }, // ← 2025-08-19 新增（占位）
            ["391004"] = new SkillDefinition { Name = "绝技! 纷乱飞弹(虚蚀食人魔)4", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "绝技! 纷乱飞弹(虚蚀食人魔)4" }, // ← 2025-08-19 新增（占位）
            ["391005"] = new SkillDefinition { Name = "绝技! 纷乱飞弹(虚蚀食人魔)5", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "绝技! 纷乱飞弹(虚蚀食人魔)5" }, // ← 2025-08-19 新增（占位）
            ["391008"] = new SkillDefinition { Name = "变异蜂被动", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "变异蜂被动" }, // ← 2025-08-19 新增（占位）
            ["391401"] = new SkillDefinition { Name = "虚蚀脉冲", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "虚蚀脉冲" }, // ← 2025-08-19 新增（占位）
            ["701001"] = new SkillDefinition { Name = "虚蚀之影爆炸", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "虚蚀之影爆炸" }, // ← 2025-08-19 新增（占位）
            ["701002"] = new SkillDefinition { Name = "虚蚀波动爆炸", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "虚蚀波动爆炸" }, // ← 2025-08-19 新增（占位）
            ["1002440"] = new SkillDefinition { Name = "绝技！超会心(姆克兵长)", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "绝技！超会心(姆克兵长)" }, // ← 2025-08-19 新增（占位）
            ["1002830"] = new SkillDefinition { Name = "奥义！冰霜震荡(冰魔)", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "奥义！冰霜震荡(冰魔)" }, // ← 2025-08-19 新增（占位）
            ["1005940"] = new SkillDefinition { Name = "姆克狂战士-旋风冲锋", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "姆克狂战士-旋风冲锋" }, // ← 2025-08-19 新增（占位）
            ["1007601"] = new SkillDefinition { Name = "变异蜂技能12", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "变异蜂技能12" }, // ← 2025-08-19 新增（占位）
            ["1007602"] = new SkillDefinition { Name = "变异蜂技能3", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "变异蜂技能3" }, // ← 2025-08-19 新增（占位）
            ["1007741"] = new SkillDefinition { Name = "剧毒蜂巢（初始）", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "剧毒蜂巢（初始）" }, // ← 2025-08-19 新增（占位）
            ["1008040"] = new SkillDefinition { Name = "绝技! 雷光球(雷光野猪)", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "绝技! 雷光球(雷光野猪)" }, // ← 2025-08-19 新增（占位）
            ["1008140"] = new SkillDefinition { Name = "奥义！地狱突刺(铁牙)", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "奥义！地狱突刺(铁牙)" }, // ← 2025-08-19 新增（占位）
            ["1008540"] = new SkillDefinition { Name = "奥义！静默潮汐(蜥蜴人王)", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "奥义！静默潮汐(蜥蜴人王)" }, // ← 2025-08-19 新增（占位）
            ["1010440"] = new SkillDefinition { Name = "绝技！强压之雷(蜥蜴人猎手)(主动)", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "绝技！强压之雷(蜥蜴人猎手)(主动)" }, // ← 2025-08-19 新增（占位）
            ["1700440"] = new SkillDefinition { Name = "奥义！重锤狂袭（姆头）", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "奥义！重锤狂袭（姆头）" }, // ← 2025-08-19 新增（占位）
            ["1700824"] = new SkillDefinition { Name = "甩尾", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "甩尾" }, // ← 2025-08-19 新增（占位）
            ["1700825"] = new SkillDefinition { Name = "狼突击", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "狼突击" }, // ← 2025-08-19 新增（占位）
            ["1700826"] = new SkillDefinition { Name = "狂野召唤", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "狂野召唤" }, // ← 2025-08-19 新增（占位）
            ["2001740"] = new SkillDefinition { Name = "绝技！瞬步奇袭（山贼斥候）", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "绝技！瞬步奇袭（山贼斥候）" }, // ← 2025-08-19 新增（占位）
            ["2002853"] = new SkillDefinition { Name = "绝技！碎星陨落（火哥）", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "绝技！碎星陨落（火哥）" }, // ← 2025-08-19 新增（占位）
            ["2031106"] = new SkillDefinition { Name = "幸运一击(手炮)", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "幸运一击(手炮)" }, // ← 2025-08-19 新增（占位）
            ["2031107"] = new SkillDefinition { Name = "幸运一击(巨刃)", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "幸运一击(巨刃)" }, // ← 2025-08-19 新增（占位）
            ["2031108"] = new SkillDefinition { Name = "幸运一击(仪刀)", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "幸运一击(仪刀)" }, // ← 2025-08-19 新增（占位）
            ["2110012"] = new SkillDefinition { Name = "奥义！脉冲祝祷（姆克王）", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "奥义！脉冲祝祷（姆克王）" }, // ← 2025-08-19 新增（占位）
            ["2110066"] = new SkillDefinition { Name = "绝技！大地之盾(山贼护卫队长)", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "绝技！大地之盾(山贼护卫队长)" }, // ← 2025-08-19 新增（占位）
            ["2110083"] = new SkillDefinition { Name = "火魔治疗", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "火魔治疗" }, // ← 2025-08-19 新增（占位）
            ["2110085"] = new SkillDefinition { Name = "雷电之种(奥尔维拉)", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "雷电之种(奥尔维拉)" }, // ← 2025-08-19 新增（占位）
            ["2110090"] = new SkillDefinition { Name = "虚蚀食人魔", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "虚蚀食人魔" }, // ← 2025-08-19 新增（占位）
            ["2110091"] = new SkillDefinition { Name = "虚蚀伤害", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "虚蚀伤害" }, // ← 2025-08-19 新增（占位）
            ["2110096"] = new SkillDefinition { Name = "奥义！雷霆咆哮(金牙)(雷击)", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "奥义！雷霆咆哮(金牙)(雷击)" }, // ← 2025-08-19 新增（占位）
            ["2110099"] = new SkillDefinition { Name = "剧毒蜂巢（持续）", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "剧毒蜂巢（持续）" }, // ← 2025-08-19 新增（占位）
            ["2201070"] = new SkillDefinition { Name = "格挡减伤", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "格挡减伤" }, // ← 2025-08-19 新增（占位）
            ["2201080"] = new SkillDefinition { Name = "格挡回复", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "格挡回复" }, // ← 2025-08-19 新增（占位）
            ["2201172"] = new SkillDefinition { Name = "坚毅之息", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "坚毅之息" }, // ← 2025-08-19 新增（占位）
            ["2201240"] = new SkillDefinition { Name = "护盾回声", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "护盾回声" }, // ← 2025-08-19 新增（占位）
            ["2201362"] = new SkillDefinition { Name = "沙晶石震荡", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "沙晶石震荡" }, // ← 2025-08-19 新增（占位）
            ["2201410"] = new SkillDefinition { Name = "砂石复苏", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "砂石复苏" }, // ← 2025-08-19 新增（占位）
            ["2201493"] = new SkillDefinition { Name = "回复（岩盾）", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "回复（岩盾）" }, // ← 2025-08-19 新增（占位）
            ["2201570"] = new SkillDefinition { Name = "岩护", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "岩护" }, // ← 2025-08-19 新增（占位）
            ["2202120"] = new SkillDefinition { Name = "艾露娜护盾", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "艾露娜护盾" }, // ← 2025-08-19 新增（占位）
            ["2202211"] = new SkillDefinition { Name = "绿意之爆发（治疗）", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "绿意之爆发（治疗）" }, // ← 2025-08-19 新增（占位）
            ["2202262"] = new SkillDefinition { Name = "复苏光环回血BUFF", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "复苏光环回血BUFF" }, // ← 2025-08-19 新增（占位）
            ["2202271"] = new SkillDefinition { Name = "天降圣光生效BUFF", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "天降圣光生效BUFF" }, // ← 2025-08-19 新增（占位）
            ["2202291"] = new SkillDefinition { Name = "生命馈赠-治疗子buff", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "生命馈赠-治疗子buff" }, // ← 2025-08-19 新增（占位）
            ["2002440"] = new SkillDefinition { Name = "奥义！雷霆天牢引（雷魔）", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "奥义！雷霆天牢引（雷魔）" }, // ← 2025-08-19 新增（占位）
            ["2202581"] = new SkillDefinition { Name = "坍缩！boom~", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "坍缩！boom~" }, // ← 2025-08-19 新增（占位）
            ["2202582"] = new SkillDefinition { Name = "坍缩！boom~", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "坍缩！boom~" }, // ← 2025-08-19 新增（占位）
            ["2203091"] = new SkillDefinition { Name = "生命流失（扑咬引爆）", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "生命流失（扑咬引爆）" }, // ← 2025-08-19 新增（占位）
            ["2203101"] = new SkillDefinition { Name = "生命流失", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "生命流失" }, // ← 2025-08-19 新增（占位）
            ["2203102"] = new SkillDefinition { Name = "生命流失（协同攻击引爆）", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "生命流失（协同攻击引爆）" }, // ← 2025-08-19 新增（占位）
            ["2203141"] = new SkillDefinition { Name = "生命流失（光追箭引爆）", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "生命流失（光追箭引爆）" }, // ← 2025-08-19 新增（占位）
            ["2203302"] = new SkillDefinition { Name = "生命流失（扫尾引爆）", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "生命流失（扫尾引爆）" }, // ← 2025-08-19 新增（占位）
            ["2203311"] = new SkillDefinition { Name = "爆炸箭矢（溅射）", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "爆炸箭矢（溅射）" }, // ← 2025-08-19 新增（占位）
            ["2204320"] = new SkillDefinition { Name = "冰冷脉冲", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "冰冷脉冲" }, // ← 2025-08-19 新增（占位）
            ["2406140"] = new SkillDefinition { Name = "获得护盾时造成aoe（套装）", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "获得护盾时造成aoe（套装）" }, // ← 2025-08-19 新增（占位）
            ["2206240"] = new SkillDefinition { Name = "神圣光辉", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "神圣光辉" }, // ← 2025-08-19 新增（占位）
            ["2207500"] = new SkillDefinition { Name = "极意万众瞩目", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "极意万众瞩目" }, // ← 2025-08-19 新增（占位）
            ["2207660"] = new SkillDefinition { Name = "极意万众瞩目", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "极意万众瞩目" }, // ← 2025-08-19 新增（占位）
            ["2207681"] = new SkillDefinition { Name = "螺旋演奏", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "螺旋演奏" }, // ← 2025-08-19 新增（占位）
            ["2900540"] = new SkillDefinition { Name = "奥义！瞬即斩(奥尔维拉)", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "奥义！瞬即斩(奥尔维拉)" }, // ← 2025-08-19 新增（占位）
            ["3001031"] = new SkillDefinition { Name = "虚蚀光环", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "虚蚀光环" }, // ← 2025-08-19 新增（占位）
            ["3001170"] = new SkillDefinition { Name = "虚蚀波动回血", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "虚蚀波动回血" }, // ← 2025-08-19 新增（占位）
            ["3081023"] = new SkillDefinition { Name = "绝技! 超重斩(黯影剑士队长)", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "绝技! 超重斩(黯影剑士队长)" }, // ← 2025-08-19 新增（占位）
            ["3210021"] = new SkillDefinition { Name = "奥义！流星陨落(风哥)(主动)", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "奥义！流星陨落(风哥)(主动)" }, // ← 2025-08-19 新增（占位）
            ["3210031"] = new SkillDefinition { Name = "雷魔被动", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "雷魔被动" }, // ← 2025-08-19 新增（占位）
            ["3210051"] = new SkillDefinition { Name = "山贼被动", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "山贼被动" }, // ← 2025-08-19 新增（占位）
            ["3210061"] = new SkillDefinition { Name = "姆克兵长被动", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "姆克兵长被动" }, // ← 2025-08-19 新增（占位）
            ["3210092"] = new SkillDefinition { Name = "蜥蜴人王被动", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "蜥蜴人王被动" }, // ← 2025-08-19 新增（占位）
            ["3210101"] = new SkillDefinition { Name = "姆克王-护盾", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "姆克王-护盾" }, // ← 2025-08-19 新增（占位）
            ["3936001"] = new SkillDefinition { Name = "绝技！静默之水(蜥蜴人法师)", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "绝技！静默之水(蜥蜴人法师)" }, // ← 2025-08-19 新增（占位）
            ["10040102"] = new SkillDefinition { Name = "剑盾哥布林-风刃斩共鸣", Type = SkillType.Unknown, Element = ElementType.Unknown, Description = "剑盾哥布林-风刃斩共鸣" }, // ← 2025-08-19 新增（占位）



        };

        public static readonly Dictionary<int, SkillDefinition> SkillsByInt = new();

        static EmbeddedSkillConfig()
        {
            foreach (var kv in SkillsByString)
            {
                if (int.TryParse(kv.Key, out var id))
                    SkillsByInt[id] = kv.Value;
            }
        }

        public static bool TryGet(string id, out SkillDefinition def)   => SkillsByString.TryGetValue(id, out def!);
        public static bool TryGet(int id, out SkillDefinition def)      => SkillsByInt.TryGetValue(id, out def!);

        public static string GetName(string id)     => TryGet(id, out var d) ? d.Name : id;
        public static string GetName(int id)        => TryGet(id, out var d) ? d.Name : id.ToString();

        public static SkillType GetTypeOf(string id)    => TryGet(id, out var d) ? d.Type : SkillType.Unknown;
        public static SkillType GetTypeOf(int id)       => TryGet(id, out var d) ? d.Type : SkillType.Unknown;

        public static ElementType GetElementOf(string id)   => TryGet(id, out var d) ? d.Element : ElementType.Unknown;
        public static ElementType GetElementOf(int id)      => TryGet(id, out var d) ? d.Element : ElementType.Unknown;

        public static IReadOnlyDictionary<string, SkillDefinition>  AllByString  => SkillsByString;
        public static IReadOnlyDictionary<int, SkillDefinition>     AllByInt     => SkillsByInt;
    }
}
