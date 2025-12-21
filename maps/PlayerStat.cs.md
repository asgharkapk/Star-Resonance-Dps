StarResonanceDpsAnalysis.Plugin.DamageStatistics
│
├── Class: StatisticData
│   ├── Properties (counters & totals)
│   │   ├── CountMiss, CountDead
│   │   ├── Normal, Critical, Lucky, CritLucky, LuckyAndCritical
│   │   ├── CauseLucky, CountCauseLucky
│   │   ├── HpLessen, Total, MaxSingleHit, MinSingleHit
│   │   ├── CountNormal, CountCritical, CountLucky, CountTotal
│   │   ├── RealtimeValue, RealtimeMax
│   │   └── LastRecordTime
│   ├── Methods
│   │   ├── RegisterMiss()
│   │   ├── RegisterKill()
│   │   ├── AddRecord(value, isCrit, isLucky, hpLessenValue, isCauseLucky)
│   │   ├── UpdateRealtimeStats()
│   │   ├── GetTotalPerSecond()
│   │   ├── GetAveragePerHit()
│   │   ├── GetCritRate()
│   │   ├── GetLuckyRate()
│   │   └── Reset()
│   └── Static Managers
│       ├── PlayerDataManager _manager
│       └── NpcManager _npcManager
│
├── Class: SkillMeta
│   ├── Id, Name, School, IconPath
│   ├── Type (Core.SkillType), Element (Core.ElementType)
│   ├── IsDoT, IsUltimate
│
├── Static Class: SkillBook
│   ├── Dictionary<ulong, SkillMeta> _metas
│   ├── SetOrUpdate(meta)
│   ├── SetName(id, name)
│   ├── Get(id)
│   └── TryGet(id, out meta)
│
├── Class: SkillSummary
│   ├── SkillId, SkillName
│   ├── Total, HitCount, AvgPerHit
│   ├── CritRate, LuckyRate
│   ├── MaxSingleHit, MinSingleHit
│   ├── RealtimeValue, RealtimeMax
│   ├── TotalDps, LastTime, ShareOfTotal
│   ├── LuckyDamage, CritLuckyDamage, CauseLuckyDamage
│   └── CountLucky
│
├── Class: TeamSkillSummary
│   ├── SkillId, SkillName
│   ├── Total, HitCount
│
└── Class: PlayerData
    ├── Properties
    │   ├── Uid, Nickname, CombatPower, Profession, SubProfession
    │   ├── Attributes (Dictionary<string, object>)
    │   ├── DamageStats (StatisticData)
    │   ├── HealingStats (StatisticData)
    │   ├── TakenStats (StatisticData)
    │   ├── TakenDamage (ulong)
    │   ├── SkillUsage (Dictionary<ulong, StatisticData>)
    │   ├── SkillUsageByElement (Dictionary<ulong, Dictionary<string, StatisticData>>)
    │   ├── HealingBySkillTarget (Dictionary<ulong, Dictionary<ulong, StatisticData>>)
    │   ├── TakenDamageBySkill (Dictionary<ulong, StatisticData>)
    │   └── HealingBySkill (Dictionary<ulong, StatisticData>)
    ├── Constructor
    │   └── PlayerData(ulong uid)
    ├── Methods
    │   ├── AddDamage(skillId, damage, isCrit, isLucky, hpLessen, damageElement, isCauseLucky)
    │   ├── AddHealing(skillId, healing, isCrit, isLucky, damageElement, isCauseLucky, targetUuid)
    │   ├── AddTakenDamage(skillId, damage, isCrit, isLucky, hpLessen, damageSource, isMiss, isDead)
    │   ├── SetProfession(profession)
    │   ├── SetAttrKV(key, value)
    │   ├── GetAttrKV(key)
    │   ├── HasCombatData()
    │   └── UpdateRealtimeStats()
