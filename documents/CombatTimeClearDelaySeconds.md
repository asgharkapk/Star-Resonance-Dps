## 1) What is `CombatTimeClearDelaySeconds`

```
CombatTimeClearDelaySeconds : int
Meaning:
    "How many seconds of NO combat activity before a combat is considered ended"

Special value:
    0  => NEVER auto-end combat
```

It does **NOT immediately clear data**.
It only **marks combat as ended**, and delays clearing until the **next combat starts**.

---

## 2) High-level data flow map

```
[ Settings UI ]
      |
      | user changes value
      v
[ inputNumber2.Value ]
      |
      | button5_Click
      v
[ AppConfig.CombatTimeClearDelaySeconds ]
      |
      | lazy-loaded from config / saved to config
      v
[ PlayerStat.InactivityTimeout ]
      |
      | used by timer
      v
[ CheckTimerElapsed ]
```

---

## 3) UI → Config (SettingsForm)

```
SettingsForm_Load
│
├─ inputNumber2.Value
│     ← AppConfig.CombatTimeClearDelaySeconds
│
└─ slider1.Value
```

```
button5_Click
│
├─ AppConfig.Transparency               = slider1.Value
├─ AppConfig.CombatTimeClearDelaySeconds = (int)inputNumber2.Value
│
└─ Close SettingsForm
```

**Result:**
The value is persisted via `AppConfig.SetValue(...)`.

---

## 4) Config storage & lazy loading (AppConfig)

```
AppConfig.CombatTimeClearDelaySeconds
│
├─ if (_combatTimeClearDelaySeconds == null)
│      └─ read from config file (default "5")
│
└─ return cached value
```

Setter:

```
set:
    write to config
    cache in _combatTimeClearDelaySeconds
```

---

## 5) Conversion into runtime logic (PlayerStat)

```
private static readonly TimeSpan InactivityTimeout
    = TimeSpan.FromSeconds(AppConfig.CombatTimeClearDelaySeconds);
```

So:

```
CombatTimeClearDelaySeconds = 5
→ InactivityTimeout = 00:00:05
```

---

## 6) Runtime usage (core behavior)

### Timer loop

```
CheckTimerElapsed (runs periodically)
│
├─ if no players OR no combat yet → return
│
├─ UpdateAllRealtimeStats()
│
└─ if CombatTimeClearDelaySeconds != 0
      │
      └─ if (Now - _lastCombatActivity) > InactivityTimeout
            │
            ├─ mark combat end time
            │
            ├─ _pendingClearOnNextCombat = true
            │
            └─ reset _lastCombatActivity
```

---

## 7) Important behavior summary (VERY IMPORTANT)

```
Combat inactivity timeout reached
│
├─ ❌ DOES NOT clear data immediately
│
├─ ✅ Marks combat as "ended"
│     (_combatEnd is set)
│
└─ ✅ Sets flag:
      _pendingClearOnNextCombat = true
```

Actual clearing happens later:

```
NEXT combat starts
│
└─ pendingClear flag triggers
      → old combat data is cleared
```

---

## 8) Special case: value = 0

```
CombatTimeClearDelaySeconds = 0
│
└─ if (AppConfig.CombatTimeClearDelaySeconds != 0)
       ↑
       this block is skipped
```

Meaning:

```
✔ Combat NEVER auto-ends due to inactivity
✔ Combat only ends via other explicit logic
✔ Data is never auto-cleared by inactivity
```

---

## 9) One-line mental model

```
CombatTimeClearDelaySeconds
= "How long after the last hit before we *declare combat over* —
   but wait until the next fight to actually clear data"
```

---
---


1. normal value (e.g. `5`)
2. special value (`0`)

---

## CASE 1 — `CombatTimeClearDelaySeconds = 5`

```
Time (seconds)  → → → → → → → → → → → → → → →

t=0        t=3        t=7        t=10       t=12
|----------|----------|----------|----------|

EVENTS
=====
t=0   Player deals damage
      _lastCombatActivity = now
      _combatStart = t=0
      _combatEnd = null
      _pendingClearOnNextCombat = false

t=3   More damage
      _lastCombatActivity = t=3

t=7   No activity for 4s
      (7 - 3 = 4 < 5)
      → combat continues

t=8   No activity for 5s
      (8 - 3 = 5 == timeout)
      → still OK (not > timeout)

t=9   No activity for 6s
      (9 - 3 = 6 > timeout)
      → INACTIVITY TRIGGERED
```

```
INACTIVITY TRIGGER (t=9)
=======================
_combatEnd              = t=3   (last activity time)
_pendingClearOnNextCombat = true
_lastCombatActivity     = MinValue
```

```
t=10  NOTHING CLEARED YET
      UI still shows final combat data
      Combat is "ended" but preserved
```

```
t=12  NEW damage arrives
      NEW combat starts
```

```
NEW COMBAT START
================
_pendingClearOnNextCombat == true
│
├─ clear previous combat data
├─ reset stats
└─ _pendingClearOnNextCombat = false
```

---

## VISUAL SUMMARY (Case 1)

```
Damage        Damage          silence           silence
  ↓             ↓                ↓                 ↓
|===== COMBAT ACTIVE =====|===== ENDED =====|== CLEARED ==|
t0            t3              t9                t12
              ↑               ↑
     last activity      inactivity timeout
```

---

## CASE 2 — `CombatTimeClearDelaySeconds = 0`

```
Time → → → → → → → → → → → → → → →

t=0        t=10        t=30
|----------|-----------|

Damage     No damage   Still nothing
```

```
CheckTimerElapsed
│
└─ if (CombatTimeClearDelaySeconds != 0)
       ↑
       FALSE → skip inactivity logic
```

### Result

```
✔ _combatEnd is NEVER auto-set
✔ _pendingClearOnNextCombat is NEVER set
✔ Combat stays "open" forever
✔ Data accumulates until manually cleared or other logic
```

---

## VISUAL SUMMARY (Case 2)

```
Damage
  ↓
|================ COMBAT NEVER ENDS ================>
t0
```

---

## KEY TAKEAWAY (one glance)

```
CombatTimeClearDelaySeconds controls:
    WHEN combat is declared ended

It does NOT control:
    WHEN data is actually cleared

Clearing always happens:
    at the START of the NEXT combat
```

---
---

## CASE — `CombatTimeClearDelaySeconds = 5`

### FULL STATE TIMELINE (with flag)

```
Time (s) → → → → → → → → → → → → → → →

t=0        t=3        t=9        t=12
|----------|----------|----------|

Damage     Damage     silence    New damage
```

---

## STATE TABLE OVER TIME

```
┌──────┬──────────┬──────────────┬──────────────┬────────────────────────┐
│ Time │ Event    │ _combatEnd   │ _lastCombat  │ _pendingClearOnNextCombat │
│      │          │              │ Activity     │                          │
├──────┼──────────┼──────────────┼──────────────┼────────────────────────┤
│ t=0  │ damage   │ null         │ t=0          │ false                  │
│ t=3  │ damage   │ null         │ t=3          │ false                  │
│ t=8  │ silence  │ null         │ t=3          │ false                  │
│ t=9  │ timeout  │ t=3          │ MinValue     │ true   ◀── SET HERE     │
│ t=10 │ idle     │ t=3          │ MinValue     │ true                   │
│ t=12 │ damage   │ reset later  │ t=12         │ true   ◀── CONSUMED     │
└──────┴──────────┴──────────────┴──────────────┴────────────────────────┘
```

---

## FLAG-FOCUSED VIEW (important)

```
_pendingClearOnNextCombat

false ──────────────────────┐
                             │ inactivity timeout
true  ───────────────────────┘───────────────┐
                                              │ new combat starts
false ────────────────────────────────────────┘
```

---

## CODE ↔ TIMELINE ALIGNMENT

### 1️⃣ Flag is SET (timeout reached)

```csharp
if (DateTime.Now - _lastCombatActivity > InactivityTimeout)
{
    _combatEnd = _lastCombatActivity;
    _pendingClearOnNextCombat = true;   // ← HERE
    _lastCombatActivity = DateTime.MinValue;
}
```

```
Timeline position: t=9
Meaning:
    "This combat is finished — clear it NEXT time"
```

---

### 2️⃣ Flag is NOT acted upon immediately

```
t=9 → t=12

No clearing happens
No stats reset
UI remains stable
```

This is intentional:

> prevents UI flicker and partial clears

---

### 3️⃣ Flag is CONSUMED (next combat begins)

Somewhere in **“combat start” logic** (not shown here but implied):

```csharp
if (_pendingClearOnNextCombat)
{
    ClearAllStats();
    _pendingClearOnNextCombat = false;
}
```

```
Timeline position: t=12
Meaning:
    "Safe to destroy old combat now"
```

---

## WHY THIS FLAG EXISTS (design intent)

```
Without _pendingClearOnNextCombat:
    inactivity → immediate clear
    → UI flicker
    → broken DPS graphs
    → confusing resets

With it:
    inactivity → mark end
    next combat → clear safely
```

---

## ONE-LINE MENTAL MODEL

```
_pendingClearOnNextCombat
= "Trash this combat — but only when a new one begins"
```

---
---

## CASE — `CombatTimeClearDelaySeconds = 5`

### MASTER TIMELINE (all combat markers)

```
Time (s) → → → → → → → → → → → → → → →

t=0        t=3        t=9        t=12
|----------|----------|----------|

Damage     Damage     silence    New damage
```

---

## FULL STATE OVERLAY

```
┌──────┬──────────┬──────────────┬──────────────┬────────────────────────┐
│ Time │ Event    │ _combatStart │ _combatEnd   │ _pendingClearOnNextCombat │
├──────┼──────────┼──────────────┼──────────────┼────────────────────────┤
│ t=0  │ damage   │ t=0   ◀── SET│ null         │ false                  │
│ t=3  │ damage   │ t=0          │ null         │ false                  │
│ t=8  │ silence  │ t=0          │ null         │ false                  │
│ t=9  │ timeout  │ t=0          │ t=3   ◀── SET│ true   ◀── SET          │
│ t=10 │ idle     │ t=0          │ t=3          │ true                   │
│ t=12 │ damage   │ t=12 ◀── RESET│ null ◀── RESET│ true → false ◀── CLEAR │
└──────┴──────────┴──────────────┴──────────────┴────────────────────────┘
```

---

## VISUAL STACK (layered)

```
Damage events:        *      *
                       t0     t3

_combatStart:         |==============================|
                       t0

_combatEnd:                           |
                                      t3

_pendingClear:        false───────────true────────────false
                                       ↑ timeout      ↑ new combat

Data lifetime:        [========= COMBAT DATA =========][ CLEARED ]
```

---

## EXACT SEMANTICS (important details)

### `_combatStart`

```
• Set on FIRST combat activity
• Marks the beginning of a combat window
• Remains unchanged during silence
• Reset when a new combat starts
```

Timeline:

```
t=0  SET
t=12 RESET & SET to new combat
```

---

### `_combatEnd`

```
• NOT set immediately when damage stops
• Set ONLY after inactivity timeout
• Value = _lastCombatActivity (NOT "now")
• Represents the logical end of combat
```

Timeline:

```
t=9 timeout detected
_combatEnd = t=3
```

---

### `_pendingClearOnNextCombat`

```
• Acts as a deferred-destruction flag
• Prevents mid-idle data clearing
• Guarantees clean UI & stat transitions
```

Timeline:

```
t=9   set true
t=12  consumed and reset
```

---

## WHY `_combatEnd = _lastCombatActivity` (not DateTime.Now)

```
Damage at t=3
Silence until t=9

Actual fight ended at t=3
Timeout is only a detector
```

So:

```
_combatEnd = t=3  ✔ correct
_combatEnd = t=9  ✘ wrong
```

---

## ONE-SCREEN MENTAL MODEL

```
_combatStart  → "When fighting began"
_combatEnd    → "When fighting actually stopped"
timeout       → "When we NOTICE it stopped"
pendingClear  → "When we are allowed to erase it"
```

---
---

## ASSUMPTIONS

```
CombatTimeClearDelaySeconds = 5
```

---

## MASTER TIMELINE (two combats)

```
Time (s) → → → → → → → → → → → → → → → → → →

t=0     t=2     t=4     t=9     t=11    t=13    t=15
|-------|-------|-------|-------|-------|-------|

C1 dmg  C1 dmg  stop    timeout  C2 dmg  C2 dmg  stop
```

---

## FULL STATE TABLE (two combats)

```
┌──────┬─────────┬──────────────┬──────────────┬────────────────────────┐
│ Time │ Event   │ _combatStart │ _combatEnd   │ _pendingClearOnNextCombat │
├──────┼─────────┼──────────────┼──────────────┼────────────────────────┤
│ t=0  │ C1 dmg  │ t=0   ◀── SET│ null         │ false                  │
│ t=2  │ C1 dmg  │ t=0          │ null         │ false                  │
│ t=4  │ silence │ t=0          │ null         │ false                  │
│ t=9  │ timeout │ t=0          │ t=2   ◀── SET│ true   ◀── SET          │
│ t=11 │ C2 dmg  │ t=11 ◀── RESET│ null ◀── RESET│ true → false ◀── CLEAR │
│ t=13 │ C2 dmg  │ t=11         │ null         │ false                  │
│ t=15 │ silence │ t=11         │ null         │ false                  │
│ t=20 │ timeout │ t=11         │ t=13 ◀── SET │ true                   │
└──────┴─────────┴──────────────┴──────────────┴────────────────────────┘
```

---

## VISUAL LAYERS

```
Combat #1 activity:   *    *
                       t0   t2

Combat #2 activity:               *    *
                                   t11  t13
```

```
_combatStart:
C1 ─────|=================|
C2               ─────|====================|

_combatEnd:
C1               |
                  t2
C2                              |
                                 t13
```

```
_pendingClearOnNextCombat:
false ───────────true────────────false────────true──────
                  ↑ timeout       ↑ C2 start   ↑ C2 timeout
```

---

## CRITICAL TRANSITION (the hand-off)

```
t=9   Combat #1 timed out
      _combatEnd = t=2
      _pendingClearOnNextCombat = true
```

```
t=11  First hit of Combat #2
│
├─ clear Combat #1 data
├─ reset all stats
├─ _pendingClearOnNextCombat = false
└─ _combatStart = t=11
```

**There is NO moment where:**

* two combats share stats
* Combat #1 is cleared mid-idle
* UI flickers or partially resets

---

## WHY THIS WORKS (important)

```
Timeout ≠ Clear
Timeout = classification only

Clear is delayed until:
    a) new combat actually exists
    b) safe reset point is guaranteed
```

---

## FAILURE MODE (what this avoids)

Without deferred clear:

```
C1 timeout → clear immediately
    ↓
C2 first hit
    ↓
stats partially missing
DPS spikes
UI glitches
```

---

## ONE-LINE MODEL (two combats)

```
Combat #1 ends quietly
Combat #2 starts loudly
The boundary is clean
```

---
---

## 1) Conceptual difference (one glance)

```
CombatTimeClearDelaySeconds        _isClearing / HandleClearData
───────────────────────────        ─────────────────────────────
WHEN combat ENDS                  WHEN data is CLEARED
(time-based, passive)             (event-based, active)

Does NOT clear immediately         DOES clear immediately
Marks end + sets flag              Actively wipes/reset state

Timer-driven                       User / system driven
```

---

## 2) Responsibility split (VERY IMPORTANT)

```
CombatTimeClearDelaySeconds
└─ answers: "Is the combat over?"

HandleClearData / _isClearing
└─ answers: "Are we clearing data right now?"
```

They solve **different problems** and are intentionally decoupled.

---

## 3) Flow map — both systems together

```
        ┌───────────────┐
        │ Combat Active │
        └───────┬───────┘
                │
        (no damage for N seconds)
                │
                v
┌──────────────────────────────────────┐
│ CombatTimeClearDelaySeconds reached │
└──────────────────────────────────────┘
                │
                ├─ set _combatEnd
                ├─ _pendingClearOnNextCombat = true
                └─ DOES NOT clear anything
                │
                v
        ┌────────────────┐
        │ Idle / Waiting │
        └───────┬────────┘
                │
        (new combat starts OR manual clear)
                │
                v
┌──────────────────────────────────────┐
│ HandleClearData() is called          │
└──────────────────────────────────────┘
                │
                ├─ _isClearing = 1
                ├─ clear lists / stats
                ├─ reset timestamps
                └─ _isClearing = 0
```

---

## 4) `_isClearing` — what it REALLY is

```
_isClearing : int (Interlocked)
```

Purpose:

```
A re-entrancy + concurrency guard
```

ASCII meaning:

```
_isClearing = 1  → "STOP. Clearing in progress."
_isClearing = 0  → "Normal operations allowed."
```

Used like:

```
if (_isClearing == 1)
    return;   // do not update UI / stats / lists
```

It **does not decide WHEN to clear** — only **protects the clearing process**.

---

## 5) HandleClearData — what it REALLY does

```
HandleClearData()
│
├─ sets _isClearing = 1
│
├─ clears:
│     - DPS lists
│     - player stats
│     - combat timestamps
│
├─ resets flags
│
└─ sets _isClearing = 0
```

Think of it as:

```
"Hard reset the combat state NOW"
```

---

## 6) Timing comparison (timeline)

```
Time ───────────────────────────────────────────>

[ Damage ] [ Damage ] [ Damage ]  (idle)   (idle)
   │         │         │             │        │
   │         │         │             │        │
   │         │         │     CombatTimeClearDelaySeconds
   │         │         │──────────────┘
   │         │         │
   │         │     combat END is MARKED
   │         │     (no clearing yet)
   │         │
   │     UI still shows data
   │
(New combat starts)
   │
   └─── HandleClearData()
         ├─ _isClearing = 1
         ├─ wipe data
         └─ _isClearing = 0
```

---

## 7) Why they MUST be separate

If you merged them, you’d get bugs like:

```
❌ UI flickers
❌ Stats disappear mid-fight
❌ Timer clears data while packets still arrive
❌ Race conditions with UI refresh
```

So the design is:

```
CombatTimeClearDelaySeconds
→ logical combat lifecycle

HandleClearData / _isClearing
→ physical data lifecycle
```

---

## 8) One-line comparison (mental model)

```
CombatTimeClearDelaySeconds:
    "Has the fight ended?"

_isClearing / HandleClearData:
    "We are deleting data right now — nobody touch anything."
```

---

## 9) Quick cheat table

```
┌───────────────────────────────┬──────────────────────────────┐
│ CombatTimeClearDelaySeconds   │ _isClearing / HandleClearData │
├───────────────────────────────┼──────────────────────────────┤
│ Time-based                    │ Event-based                  │
│ Passive                       │ Active                       │
│ Marks combat end              │ Clears data                  │
│ Uses timer                    │ Uses explicit calls          │
│ Never touches lists           │ Directly mutates lists       │
│ Safe during combat            │ Blocks concurrent access     │
└───────────────────────────────┴──────────────────────────────┘
```

---
---

