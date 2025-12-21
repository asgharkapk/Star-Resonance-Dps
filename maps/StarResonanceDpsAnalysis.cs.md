StarResonanceDpsAnalysis.Plugin.DamageStatistics
└── Static Class: FullRecord
    │
    ├── [Category 1: Utilities]
    │   └── R2(double v)
    │
    ├── [Category 2: Shim (readonly views)]
    │   ├── Class: StatsLike
    │   │   ├── GetAveragePerHit()
    │   │   ├── GetCritRate()
    │   │   └── GetLuckyRate()
    │   ├── Class: PlayerLike
    │   │   ├── GetTotalDps()
    │   │   └── GetTotalHps()
    │   ├── Class: TakenOverviewLike
    │   ├── Private Helpers
    │   │   ├── From(StatAcc s)
    │   │   └── MergeStats(IEnumerable<StatAcc>)
    │   ├── Public Methods
    │   │   ├── GetOrCreate(uid)
    │   │   └── GetPlayerTakenOverview(uid)
    │
    ├── [Category 3: UI Views]
    │   ├── Record Struct: StatView
    │   ├── ToView(StatAcc s)
    │   └── MergeStats(IEnumerable<StatAcc>)
    │
    ├── [Category 4: External Queries]
    │   ├── GetPlayerDamageStats(uid)
    │   ├── GetPlayerHealingStats(uid)
    │   └── GetPlayerTakenStats(uid)
    │
    ├── [Category 4.5: Death Statistics]
    │   ├── GetTeamDeathCount()
    │   ├── GetPlayerDeathCount(uid)
    │   ├── GetAllPlayerDeathCounts(includeZero=false)
    │   └── GetPlayerDeathBreakdownBySkill(uid)
    │
    ├── [Category 5: Binding Structures]
    │   └── Record: FullPlayerTotal
    │
    ├── [Category 6: Session State & Control]
    │   ├── Properties
    │   │   ├── IsRecording
    │   │   ├── StartedAt
    │   │   ├── EndedAt
    │   │   ├── TeamRealtimeDps
    │   │   └── SessionHistory
    │   ├── Methods
    │   │   ├── Start()
    │   │   ├── Stop()
    │   │   ├── ClearSessionHistory()
    │   │   ├── Reset(preserveHistory=true)
    │   │   ├── GetSessionTotalTimeSpan()
    │   │   └── GetPlayerSkills(uid)
    │
    ├── [Category 7: List Data / Totals]
    │   ├── GetPlayersWithTotals(includeZero=false)
    │   ├── GetEffectiveDurationString()
    │   └── GetPlayersWithTotalsArray(includeZero=false)
    │
    ├── [Category 8: Internal Stop & Snapshots]
    │   └── StopInternal(auto)
    │
    └── [Category 9+: (not fully shown in snippet)]
        ├── TakeSnapshot()
        ├── UpdateRealtimeDps()
        ├── GetTeamDps()
        ├── GetPlayerDps()
        └── Other snapshot/time retrieval helpers
