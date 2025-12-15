# 🌌 **ASCII SYSTEM MAP**

### **Star-Resonance-DPS → Plugin → DamageStatistics → StarResonanceDpsAnalysis.cs**

```
+---------------------------------------------------------------+
|                   StarResonanceDpsAnalysis.cs                 |
|                 (Entry point of the DPS plugin)               |
+---------------------------------------------------------------+
                     |
                     | 1) Subscribes to game events
                     v
     ====================================================================
     GAME EVENT STREAM (From Packet Sniffer / Memory Reader)
     ====================================================================
                     |
                     | OnDamagePacket(damageInfo)
                     | OnHealPacket(healInfo)
                     | OnNpcDamageTakenPacket(info)
                     | OnCombatStart()
                     | OnCombatEnd()
                     v
+---------------------------------------------------------------+
|                    StatisticData (global static)              |
|   +-------------------+-------------------------+-------------+
|   | DamageManager     | HealManager              | NpcManager |
|   | (players)         | (players)                | (NPCs)     |
+---+-------------------+--------------------------+-------------+
    | updates                                      
    v
```

---

# 📊 **1. MANAGERS LAYER**

Managers store and update per-player / per-NPC trackers.

```
+--------------------------------------------------------------+
| DamageManager                                                |
|   Dictionary<ulong, DamageTracker> PlayerTrackers ----------+--------+
|                                                              |        |
| HealManager                                                  |        |
|   Dictionary<ulong, HealTracker> PlayerTrackers ------------+--+     |
|                                                              |  |     |
| NpcManager                                                   |  |     |
|   Dictionary<ulong, NpcTracker> NpcTrackers -----------------+  |     |
+--------------------------------------------------------------+  |     |
                                                                |     |
                                                                v     v
```

---

# ⚙️ **2. TRACKERS LAYER (per player / per NPC)**

Each tracker holds *multiple skill stats*.

```
                      +----------------------------+
                      | DamageTracker              |
                      |----------------------------|
                      | TotalDamage                |
                      | Dictionary<int, SkillStat> |
                      | ActiveSeconds              |
                      | LastHitTime                |
                      +-------------+--------------+
                                    |
                                    v
                           +----------------+
                           | SkillStat      |
                           |----------------|
                           | Total          |
                           | Crits          |
                           | ActiveSeconds  |
                           | FirstAt        |
                           | LastAt         |
                           +----------------+

Same for:

  HealTracker
  NpcTracker  (but for damage taken)
```

All trackers use the same accumulator:

```
Accumulate(SkillStat skill, ...)
```

---

# 🧠 **3. ACCUMULATOR (Core Logic for Ticks, Damage, HPS, DPS)**

The **heart of the system** — all ActiveSeconds come from here.

```
+------------------------------------------------------------+
| Accumulate(SkillStat skill, value, isCrit, ...)            |
+------------------------------------------------------------+
| if first event -> skill.FirstAt = now                      |
| else delta = now - skill.LastAt                            |
|      skill.ActiveSeconds += min(delta, 3)                  |
| skill.LastAt = now                                         |
| skill.Total += value                                       |
| if isCrit -> skill.Crits++                                 |
+------------------------------------------------------------+
```

This is where:

✔ ActiveSecondsDamage
✔ ActiveSecondsHealing
✔ ActiveSecondsTaken

all originate.

---

# 🏗️ **4. MERGING LAYER (per-player totals)**

When UI requests data:

```
PlayerDamage = MergeStats(PlayerDamageTracker.SkillStats)
PlayerHealing = MergeStats(PlayerHealTracker.SkillStats)
PlayerTaken   = MergeStats(PlayerNpcTracker.SkillStats)
```

Merge logic:

```
Total = sum(skill.Total)
ActiveSeconds = max(skill.ActiveSeconds)
Crits = sum(skill.Crits)
```

---

# 📦 **5. FULL RECORDS (Data exposed to UI pages)**

This is where your row generating structures live:

```
+----------------------------------------------------+
| FullPlayerTotal                                    |
|  Uid                                               |
|  Nickname                                          |
|  CombatPower                                       |
|  Profession/SubProfession                          |
|  TotalDamage / TotalHealing / TakenDamage          |
|  Dps                                               |
|  Hps                                               |
|  Tps (your new field)                              |
+----------------------------------------------------+
```

These are created by:

```
StatisticData.BuildFullTotals()
StatisticData.BuildSkillBreakdown()
StatisticData.BuildNpcOverviewRows_Current()
```

---

# 🪟 **6. UI LAYER (Forms / Controls)**

```
+--------------------------------------------------------------+
| DpsStatisticsForm                                            |
|   +-- RefreshDpsTable()                                      |
|   +-- RefreshNpcs()                                          |
|   +-- DrawRowsToTable()                                      |
|   +-- SortButton / NPC Tanking Button / Filters              |
+--------------------------------------------------------------+
```

`RefreshDpsTable()` fetches latest:

```
rows = StatisticData.BuildFullTotals()
```

which internally:

```
→ Queries DamageManager / HealManager / NpcManager
→ Merges all SkillStats
→ Builds FullRow objects
→ Applies sorting (By DPS / By HPS / By TPS)
→ UI draws rows
```

---

# ⚔️ **7. COMBAT TIMELINE**

Putting everything together into a flow map:

```
GAME PACKETS
     │
     ▼
StarResonanceDpsAnalysis.cs
     │ dispatches
     ▼
MANAGERS (Damage / Heal / NPC)
     │
     ▼
TRACKERS (per player)
     │
     ▼
Accumulate()  <── ActiveSeconds come from here
     │
     ▼
MergeStats()
     │
     ▼
FullPlayerTotal rows
     │
     ▼
UI → DpsStatisticsForm
```

