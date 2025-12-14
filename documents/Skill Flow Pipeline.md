# **📌 ASCII Architecture Map — Skill Flow Pipeline**

```
+-------------------------------------------------------------------------------------------+
|                                     SKILL CONFIG LAYER                                    |
+-------------------------------------------------------------------------------------------+
|                                                                                           |
|   skill_config.json (auto-generated source outside C#)                                    |
|            │                                                                              |
|            ▼                                                                              |
|   StarResonanceDpsAnalysis/Core/SkillConverter.cs                                          |
|   ─────────────────────────────────────────────────────────────────────────────────────── |
|   EmbeddedSkillConfig                                                                      |
|     • SkillDefinition (Name, Type, Element, Description...)                                |
|     • Elements:  ElementType → (Color, Icon)                                               |
|     • SkillsById:      "1401" → SkillDefinition                                            |
|     • SkillsByString:  string  → SkillDefinition (localized or raw)                        |
|     • SkillsByInt:     int     → SkillDefinition                                           |
|                                                                                           |
|   PURPOSE:                                                                                |
|     - Converts raw SkillID → Human-readable data                                           |
|     - Provides GetName() / GetTypeOf() / GetElementOf()                                    |
|     - Used everywhere skill names or metadata are required                                 |
+-------------------------------------------------------------------------------------------+


                                 SKILL LOOKUP FLOW
                                 ──────────────────
                                         │
                                         ▼

+-----------------------------+
| EmbeddedSkillConfig.GetName |
+-----------------------------+
              │
              ▼
 Returns Localized or Raw Skill Name
 e.g. “1401” → “风华翔舞”
              │
              ▼


+-------------------------------------------------------------------------------------------+
|                                   DAMAGE EVENT LAYER                                      |
+-------------------------------------------------------------------------------------------+

      Game Hit Events
(Combat system calling OnHit)
              │
              ▼

+-------------------------------------------------------------+
|  StarResonanceDpsAnalysis/Core/SkillDiaryGate.cs            |
|  ────────────────────────────────────────────────────────── |
|                                                             |
|  OnHit(uid, skillId, dmg, crit, lucky, treat)               |
|     │                                                       |
|     ├── filters: only records if uid == AppConfig.Uid       |
|     │                                                       |
|     └── calls Register(...)                                 |
|                                                             |
|  Register(...)                                              |
|     • Accumulates hits inside a (700ms) window              |
|     • Combines multihit skills                              |
|     • Tracks: Count, TotalDamage, CritCount, LuckyCount     |
|     • Returns “shouldWriteSegment?”                         |
|                                                             |
|  When segment ends → builds final line string:              |
|      "[01:23] 风华翔舞 | 伤害:250000 | 释放次数:3 | 暴击:2"   |
|                                                             |
|  And sends it to:                                           |
|      FormManager.skillDiary.AppendDiaryLine(line)           |
+-------------------------------------------------------------+


                                 DIARY LOG FLOW
                                 ───────────────
                                         │
                                         ▼

+-------------------------------------------------------------------------------------------+
|                                         UI LAYER                                          |
+-------------------------------------------------------------------------------------------+

+-------------------------------------------------------------+
| StarResonanceDpsAnalysis/Forms/SkillDiary.cs               |
|────────────────────────────────────────────────────────────|
| AppendDiaryLine(string line)                               |
|   • Parses "[time]"                                        |
|   • Splits " | " parts                                     |
|   • Colors:                                                |
|       - time (gray)                                        |
|       - skill name (bold)                                  |
|       - damage/heal                                        |
|       - hit count                                          |
|       - crit badge                                         |
|       - lucky badge                                        |
|   • Writes styled RichText                                 |
+-------------------------------------------------------------+

Final Output → RichTextBox Skill Diary Window
Example:
    [0:35] 风华翔舞 | 伤害:54000 | 释放次数:2 | 暴击 ×1


================================================================================================
                                PARALLEL SKILL REFERENCE VIEW
================================================================================================
(Not tied to SkillDiaryGate, but still depends on SkillConfig data)

+-------------------------------------------------------------------------------------------+
|                      StarResonanceDpsAnalysis/Forms/AuxiliaryForms/SkillReferenceForm.cs |
|-------------------------------------------------------------------------------------------|
| Loads reference data from server: /get_user_dps                                           |
|   For each skill: name, damage, hitCount, crit%, lucky%, avgHit, DPS, share               |
| Binds to AntdUI table for display                                                         |
| Uses: Common.FormatWithEnglishUnits, etc.                                                 |
+-------------------------------------------------------------------------------------------+
```

---

# **📌 Summary Flow (One-Screen)**

```
Game Hit Event
      │
      ▼
SkillDiaryGate.OnHit()
      │
      ▼
SkillDiaryGate.Register()
      │
      ├─ If still inside hit-window → accumulate
      └─ If window broke → produce final segment
               │
               ▼
EmbeddedSkillConfig.GetName()  ← SkillID → Skill Name
               │
               ▼
SkillDiary.AppendDiaryLine()  ← rich colored text
               │
               ▼
UI: Skill Diary Window


SkillReferenceForm (separate)
     │
     └── Loads REST data → Builds skill stats table
```

