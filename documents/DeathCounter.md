## 1) Where death is COUNTED (the only increment points)

```
[ Network / Packet / Combat Event ]
                |
                v
   isDead == true ?
                |
        +-------+-------+
        |               |
        v               v
RecordTakenDamage   RecordNpcTakenDamage
(player takes dmg)  (NPC takes dmg)
```

### A) Player death (MOST IMPORTANT)

```
RecordTakenDamage(...)
{
    if (isDead)
        s.CountDead++;
}
```

ASCII data path:

```
Player UID
   |
   v
PlayerAcc p
   |
   v
p.TakenSkills[skillId] : StatAcc
   |
   v
StatAcc.CountDead += 1   <---- PLAYER DEATH STORED HERE
```

⚠️ **Death is stored per (player, skill that killed them)**
There is **NO global death counter**

---

### B) NPC death (SEPARATE, NOT PLAYER DEATHS)

```
RecordNpcTakenDamage(...)
{
    if (isDead)
        n.Taken.CountDead++;
}
```

ASCII:

```
NPC ID
  |
  v
NpcAcc n
  |
  v
n.Taken : StatAcc
  |
  v
StatAcc.CountDead += 1   <---- NPC KILL COUNT
```

🚫 This **does NOT affect player death statistics**

---

## 2) How deaths are AGGREGATED (read-only phase)

All queries **SUM `StatAcc.CountDead`** across skills.

### A) Per-player total deaths

```
GetPlayerDeathCount(uid)
{
    sum = 0
    foreach skill in p.TakenSkills
        sum += skill.CountDead
}
```

ASCII:

```
PlayerAcc
   |
   +-- Skill A → CountDead = 2
   +-- Skill B → CountDead = 1
   +-- Skill C → CountDead = 0
   |
   v
Total Player Deaths = 3
```

---

### B) Team total deaths

```
GetTeamDeathCount()
{
    foreach player
        foreach skill
            sum += CountDead
}
```

ASCII:

```
Team
 |
 +-- Player 1 → 3 deaths
 +-- Player 2 → 1 death
 +-- Player 3 → 0 deaths
 |
 v
Team Deaths = 4
```

---

### C) Per-player death breakdown by skill

```
GetPlayerDeathBreakdownBySkill(uid)
```

ASCII:

```
PlayerAcc
 |
 +-- Fireball → 2 deaths
 +-- Slash    → 1 death
 |
 v
Sorted DESC
```

---

## 3) How death data reaches the UI

### DeathStatisticsForm (table)

```
Timer / Button
     |
     v
LoadInformation()
     |
     v
FullRecord.GetAllPlayerDeathCounts()
     |
     v
Sum CountDead per player
     |
     v
DeathStatisticsTable (BindingList)
```

ASCII:

```
StatAcc.CountDead
        |
        v
GetAllPlayerDeathCounts()
        |
        v
DeathStatisticsTable
        |
        v
AntdUI Table
```

---

### DPS Progress Bar (💀 icon)

```
RefreshDpsTable()
     |
     v
FullRecord.GetPlayerDeathCount(uid)
     |
     v
"💀{deathCount}"
```

ASCII:

```
StatAcc.CountDead
        |
        v
GetPlayerDeathCount
        |
        v
UI Row Text = 💀X
```

---

## 4) When deaths are CLEARED (critical)

### ❗ There is NO automatic per-combat reset

Deaths persist for the **entire recording session**.

Clearing happens ONLY when:

```
IsRecording == false
AND
FullRecord.Clear / Reset logic is triggered
```

(You didn’t paste the clear method, but based on `_isClearing` and pattern:)

### Effective clear path

```
Session Reset / Stop Capture / Manual Clear
        |
        v
_isClearing = 1
        |
        v
_players.Clear()
        |
        v
All PlayerAcc destroyed
        |
        v
All TakenSkills destroyed
        |
        v
ALL CountDead = 0 (by object destruction)
```

ASCII:

```
PlayerAcc (destroyed)
   X TakenSkills
   X StatAcc
       X CountDead
```

🧠 **Important consequence**

* Deaths are **session-wide**
* NOT per fight
* NOT per NPC
* NOT auto-cleared on combat end

---

## 5) Summary (one-screen mental model)

```
isDead flag
    |
    v
StatAcc.CountDead
    |
    v
TakenSkills (per skill)
    |
    v
PlayerAcc
    |
    +--> UI Table (DeathStatisticsForm)
    |
    +--> UI DPS Row (💀)
    |
    +--> Team Sum
```

### Clearing rule

```
NO reset on combat end
ONLY reset when session data is cleared
```

---
---

## 1) **Death counting sources**

```
Player combat event
   |
   v
RecordTakenDamage(...)
   |
   |-- if isDead → StatAcc.CountDead++
   |
   |-- Accumulate hpLessen/damage (for stats)
```

```
NPC combat event
   |
   v
RecordNpcTakenDamage(...)
   |
   |-- if isDead → NPC.Taken.CountDead++
```

**Key points:**

* Player deaths are stored **per skill** in `p.TakenSkills[skillId].CountDead`.
* NPC deaths are stored **per NPC** in `n.Taken.CountDead`.
* `isMiss` events are counted separately via `CountMiss`.
* Death counts are **session-wide**, not per fight.

---

## 2) **Aggregation (read-only queries)**

```
GetPlayerDeathCount(uid)
   |
   v
Sum over p.TakenSkills[*].CountDead
```

```
GetTeamDeathCount()
   |
   v
foreach player:
    foreach skill:
        sum += CountDead
```

```
GetPlayerDeathBreakdownBySkill(uid)
   |
   v
foreach skill in p.TakenSkills:
    if CountDead > 0 → add to list
   |
   v
return sorted descending
```

**Usage in UI:**

```
DeathStatisticsForm.LoadInformation()
   |
   v
FullRecord.GetAllPlayerDeathCounts()
   |
   v
DeathStatisticsTable (BindingList)
   |
   v
AntdUI Table
```

```
DPS Form (sorted progress bars)
   |
   v
FullRecord.GetPlayerDeathCount(uid)
   |
   v
💀{CountDead} label in progress bar row
```

---

## 3) **Session lifecycle**

```
FullRecord.Start()
   |
   v
IsRecording = true
StartedAt = now (if first time)
EndedAt = null
```

```
FullRecord.Stop()
   |
   v
if IsRecording → StopInternal(auto=false)
   |
   v
TakeSnapshot() → add to _sessionHistory
   |
   v
Clear _players, _npcs, TeamRealtimeDps = 0
StartedAt = null
EndedAt = null
```

```
FullRecord.Reset()
   |
   v
StopInternal(auto=false) (if has data)
Clear _players, _npcs, TeamRealtimeDps = 0
StartedAt = now
EndedAt = null
IsRecording = true
(preserveHistory optional)
```

```
ClearSessionHistory()
   |
   v
_sessionHistory.Clear()
```

**Notes:**

* Death counts are cleared **only on Stop() or Reset()**.
* Fast snapshots are stored in `_sessionHistory` before clearing.
* Between Start() and Stop()/Reset(), death counts accumulate across all fights.

---

## 4) **Effective session time**

```
SessionSeconds()
   |
   v
if not started → 0
if recording → now - StartedAt
if stopped → EndedAt - StartedAt
```

* Used for **TeamRealtimeDps**, but **does not affect CountDead**.

---

## 5) **End-to-end ASCII diagram**

```
[Combat Event]
      |
      v
+-------------------+
| RecordTakenDamage |
+-------------------+
      |
      |-- isDead? --> StatAcc.CountDead++
      |
      |-- Accumulate hpLessen/damage
      v
+-------------------+
| PlayerAcc / TakenSkills |
+-------------------+
      |
      v
[FullRecord aggregation]
      |
      +-- GetPlayerDeathCount(uid)
      +-- GetTeamDeathCount()
      +-- GetAllPlayerDeathCounts()
      |
      v
UI Layer
  - DeathStatisticsForm
  - DPS ProgressBars (💀 icon)
```

```
Session control
  Start()  -----------------+
                             |
                             v
                     IsRecording = true
                             |
Stop() / Reset() -------------+
                             |
                             v
                   TakeSnapshot() → _sessionHistory
                   Clear _players/_npcs
                   Reset IsRecording/StartedAt/EndedAt
```

---

✅ **Key takeaways**

1. Death counting is **per skill** per player (StatAcc.CountDead).
2. Aggregation sums these counts to give player/team totals.
3. Data persists **for the whole recording session**, cleared only by `Stop()` or `Reset()`.
4. Snapshots preserve historical totals.
5. NPC death counting is separate (`n.Taken.CountDead`) and does **not affect player stats**.

---
---

# 1) Definitions (important to be explicit)

```
WIPE DEATH
- Player dies
- Encounter does NOT end in NPC death
- Usually followed by combat reset / disengage / party wipe

KILL DEATH
- Player dies
- Encounter eventually ends with NPC death (boss killed)
```

Both are still **player deaths**, but **classified differently**.

---

# 2) Data model (minimal & safe change)

### Extend `StatAcc` (player-side only)

```
StatAcc
{
    int CountDead;          // existing (total deaths)
    int CountWipeDead;      // NEW
    int CountKillDead;      // NEW
}
```

ASCII memory layout:

```
PlayerAcc
  |
  +-- TakenSkills[skillId]
          |
          +-- StatAcc
                |
                +-- CountDead
                +-- CountWipeDead
                +-- CountKillDead
```

⚠️ `CountDead = CountWipeDead + CountKillDead`
(You still keep backward compatibility.)

---

# 3) Where deaths are FIRST recorded (unchanged)

```
RecordTakenDamage(... isDead = true)
```

ASCII:

```
Combat Event
     |
     v
isDead == true
     |
     v
StatAcc.CountDead++
     |
     v
[ TEMP: unresolved death ]
```

At this point:

* We **DO NOT know** if it’s wipe or kill yet
* So classification is deferred

---

# 4) Encounter state tracking (lightweight)

You need **one encounter-level state**:

```
EncounterContext
{
    bool BossAlive;
    HashSet<ulong> PlayersDiedThisEncounter;
}
```

ASCII:

```
Encounter
   |
   +-- BossAlive = true
   +-- PlayersDied = { uid1, uid2 }
```

### When encounter starts

```
BossAlive = true
PlayersDied.Clear()
```

---

# 5) Mark deaths during encounter

Modify `RecordTakenDamage`:

```
if (isDead)
{
    s.CountDead++;
    Encounter.PlayersDiedThisEncounter.Add(uid);
}
```

ASCII:

```
Player Death
    |
    v
CountDead++
    |
    v
PlayersDiedThisEncounter += uid
```

---

# 6) Classify deaths when encounter ENDS

## A) NPC (boss) dies → KILL deaths

Hook point:

```
RecordNpcTakenDamage(... isDead = true)
```

ASCII flow:

```
Boss HP → 0
     |
     v
isDead == true
     |
     v
Encounter END (KILL)
```

### Classification

```
foreach uid in PlayersDiedThisEncounter
    foreach skill in player.TakenSkills
        skill.CountKillDead++
```

ASCII:

```
PlayersDiedThisEncounter
     |
     +-- uid1
     +-- uid2
     |
     v
CountKillDead++
```

---

## B) Encounter resets → WIPE deaths

Hook points (any of these):

* Combat disengage
* Target reset
* Player revive reset
* Capture stop without NPC death

ASCII flow:

```
Combat Reset
     |
     v
BossAlive == true
     |
     v
Encounter END (WIPE)
```

### Classification

```
foreach uid in PlayersDiedThisEncounter
    foreach skill in player.TakenSkills
        skill.CountWipeDead++
```

ASCII:

```
PlayersDiedThisEncounter
     |
     +-- uid1
     +-- uid2
     |
     v
CountWipeDead++
```

---

# 7) Reset encounter state (important)

```
PlayersDiedThisEncounter.Clear()
BossAlive = false
```

ASCII:

```
Encounter END
     |
     v
State Reset
```

---

# 8) Query layer (no breakage)

### Total deaths (existing)

```
CountDead
```

### New APIs

```
GetPlayerWipeDeaths(uid)
GetPlayerKillDeaths(uid)
```

ASCII:

```
StatAcc
  |
  +-- CountDead
  +-- CountWipeDead
  +-- CountKillDead
```

---

# 9) UI examples

### DPS row

```
💀 12
☠️ 9W / 3K
```

### Death table

```
Player | Total | Wipe | Kill
----------------------------
A      | 12    | 9    | 3
```

---

# 10) Clear behavior (session vs encounter)

```
Encounter reset
    → DOES NOT clear counts

Session reset
    → Clears ALL counters
```

ASCII:

```
Encounter End  ──> classify only
Session Clear  ──> destroy StatAcc
```

---

# 11) One-screen mental model

```
Death Event
     |
     v
CountDead++
     |
     v
[ wait for encounter result ]
     |
     +--> Boss Dead → CountKillDead++
     |
     +--> Reset     → CountWipeDead++
```

---
---

# 1️⃣ Death Event Hook (player death occurs)

**File:** `StarResonanceDpsAnalysis/Plugin/DamageStatistics/StarResonanceDpsAnalysis.cs`
**Method:** `RecordTakenDamage`

```csharp
if (isDead)
{
    s.CountDead++;   // existing
    Encounter.PlayersDiedThisEncounter.Add(uid); // NEW
}
```

**Hook location:**

```
RecordTakenDamage()
    |
    +-- if(isDead)
          |
          +-- increment CountDead (already)
          +-- add uid to Encounter.PlayersDiedThisEncounter (new)
```

✅ This captures all **player deaths during the encounter**.

---

# 2️⃣ NPC death hook (classify KILL deaths)

**File:** `StarResonanceDpsAnalysis/Plugin/DamageStatistics/StarResonanceDpsAnalysis.cs`
**Method:** `RecordNpcTakenDamage`

```csharp
if (isDead) // NPC died
{
    // NPC Taken.CountDead++ (existing)
    Encounter.BossAlive = false;  // mark encounter as ending

    foreach (var uid in Encounter.PlayersDiedThisEncounter)
    {
        foreach (var skill in GetOrCreate(uid).TakenSkills.Values)
            skill.CountKillDead++; // NEW
    }

    Encounter.PlayersDiedThisEncounter.Clear();
}
```

**Hook location:**

```
RecordNpcTakenDamage()
    |
    +-- if(isDead)  <-- NPC death
          |
          +-- mark encounter as finished
          +-- classify CountKillDead for all players who died
          +-- clear PlayersDiedThisEncounter
```

✅ Only increments **Kill deaths**, preserves **total CountDead**.

---

# 3️⃣ Encounter reset / wipe hook (classify WIPE deaths)

**File:** likely in `DpsStatisticsForm.Function.cs` or wherever combat reset occurs (you have `_isClearing` flag)

**Candidate hook:** before `_players.Clear()` or combat reset

```csharp
if (_isClearing == 1) // combat reset
{
    foreach (var uid in Encounter.PlayersDiedThisEncounter)
    {
        var p = GetOrCreate(uid);
        foreach (var s in p.TakenSkills.Values)
            s.CountWipeDead++; // NEW
    }

    Encounter.PlayersDiedThisEncounter.Clear();
}
```

**Hook location:**

```
DpsStatisticsForm.Function.cs
RefreshDpsTable() / or session reset
    |
    +-- if(_isClearing==1)
          |
          +-- classify CountWipeDead for all players who died
          +-- clear PlayersDiedThisEncounter
```

✅ This captures **wipe deaths** (player died but boss not killed).

---

# 4️⃣ Query hooks for UI

**Files:**

* `DeathStatisticsForm.cs` → table
* `DpsStatisticsForm.Function.cs` → progress bar

**New methods:**

```csharp
public static int GetPlayerWipeDeaths(ulong uid)
{
    lock (_sync)
    {
        if (!_players.TryGetValue(uid, out var p)) return 0;
        return p.TakenSkills.Values.Sum(s => s.CountWipeDead);
    }
}

public static int GetPlayerKillDeaths(ulong uid)
{
    lock (_sync)
    {
        if (!_players.TryGetValue(uid, out var p)) return 0;
        return p.TakenSkills.Values.Sum(s => s.CountKillDead);
    }
}
```

**Hook locations in UI:**

```
DeathStatisticsForm.LoadInformation()
    |
    +-- rows = FullRecord.GetAllPlayerDeathCounts()
    +-- UI table columns: add Wipe / Kill column using new API

RefreshDpsTable()
    |
    +-- string share = $"💀{thedeathCount} (W:{GetPlayerWipeDeaths(uid)} K:{GetPlayerKillDeaths(uid)})"
```

---

# 5️⃣ Encounter state structure

**File:** new class in `StarResonanceDpsAnalysis/Plugin/DamageStatistics/StarResonanceDpsAnalysis.cs`

```csharp
public class EncounterContext
{
    public bool BossAlive;
    public HashSet<ulong> PlayersDiedThisEncounter = new();
}
```

**Hook locations:**

```
Start combat → EncounterContext.BossAlive = true
Player death → PlayersDiedThisEncounter.Add(uid)
NPC death → classify Kill
Combat reset → classify Wipe
```

---

# ✅ Summary Table of Hook Locations

| Event               | File                            | Method                      | Hook                                           |
| ------------------- | ------------------------------- | --------------------------- | ---------------------------------------------- |
| Player dies         | `StarResonanceDpsAnalysis.cs`   | `RecordTakenDamage`         | Add UID to `PlayersDiedThisEncounter`          |
| Boss/NPC dies       | `StarResonanceDpsAnalysis.cs`   | `RecordNpcTakenDamage`      | Increment `CountKillDead` for all dead players |
| Combat reset / wipe | `DpsStatisticsForm.Function.cs` | `_isClearing` / Reset logic | Increment `CountWipeDead` for all dead players |
| UI display          | `DeathStatisticsForm.cs`        | `LoadInformation`           | Add Wipe / Kill columns                        |
| UI display          | `DpsStatisticsForm.Function.cs` | `RefreshDpsTable`           | Show 💀 with W/K counts                        |

---
---

```
+-------------------+
| Combat / Damage   |
| Event (packet)    |
+-------------------+
         |
         v
+-------------------+
| RecordTakenDamage |
+-------------------+
         |
         | isDead?
         +--------------------+
         |                    |
        Yes                   No
         |                    |
         v                    v
+-------------------+     (do nothing for UI)
| StatAcc.CountDead |  
| Increment         |
+-------------------+
         |
         v
+-------------------+
| EncounterContext  |
| PlayersDiedThisEncounter.Add(uid)
+-------------------+

         |
         |---------------------------+
         |                           |
         |                         Other stats (CountMiss, RealtimeDps, etc.)
         v
+-------------------+
| Damage accumulation|
| / HP lessen        |
+-------------------+


-------------------------------------------------
  Encounter Ends / NPC Death?
-------------------------------------------------
         |
         v
+----------------------------+
| RecordNpcTakenDamage       |
| (isDead == true for boss)  |
+----------------------------+
         |
         v
+----------------------------+
| EncounterContext.BossAlive = false
| For each uid in PlayersDiedThisEncounter:
|   For each skill in TakenSkills:
|       skill.CountKillDead++
+----------------------------+
         |
         v
+----------------------------+
| PlayersDiedThisEncounter.Clear()
+----------------------------+


-------------------------------------------------
  Encounter Reset / Wipe (no boss kill)
-------------------------------------------------
         |
         v
+----------------------------+
| _isClearing == 1           |
| For each uid in PlayersDiedThisEncounter:
|   For each skill in TakenSkills:
|       skill.CountWipeDead++
+----------------------------+
         |
         v
+----------------------------+
| PlayersDiedThisEncounter.Clear()
+----------------------------+


-------------------------------------------------
  UI Layer: DeathStatisticsForm / DPS Table
-------------------------------------------------
         |
         v
+----------------------------+
| LoadInformation()          |
| FullRecord.GetAllPlayerDeathCounts() -> CountDead
| FullRecord.GetPlayerWipeDeaths(uid) -> CountWipeDead
| FullRecord.GetPlayerKillDeaths(uid) -> CountKillDead
+----------------------------+
         |
         v
+----------------------------+
| BindingList<DeathStatisticsTable> |
| Columns: Total | Wipe | Kill         |
+----------------------------+

         |
         v
+----------------------------+
| DPS Progress Bar (RefreshDpsTable)     |
| Row UI: 💀 Total (W: Wipe K: Kill)    |
+----------------------------+
```

---

### ✅ Key points

1. **Player deaths** are always incremented first in `StatAcc.CountDead`.
2. **Classification** (Wipe vs Kill) happens **after encounter ends**:

   * `Kill` → NPC/boss died
   * `Wipe` → encounter reset without boss death
3. **UI** reads all three counts separately.
4. **PlayersDiedThisEncounter** is the **temporary hook** to track deaths per encounter.
5. **CountDead = CountWipeDead + CountKillDead** ensures backward compatibility.


