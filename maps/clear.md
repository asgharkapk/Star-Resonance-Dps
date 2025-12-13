## 1️⃣ High-level flow (who calls what)

```
[ User Action ]
   │
   ├─ Click "Clear" button
   │
   ├─ Press ClearData hotkey
   │
   ▼
HandleClearData()
   │
   ├─ Stop chart auto-refresh
   ├─ OnCombatEnd()
   ├─ (optional) FullRecord.Reset()
   │
   ├──────────────▶ ListClear()
   │                 (sets _isClearing = 1)
   │
   ├─ ClearCurrentHistory()
   │
   └─ Restart chart auto-refresh (if capturing)
```

---

## 2️⃣ `_isClearing` as a global gate

```
_isClearing
───────────
0 = Normal operation
1 = Clearing in progress
```

Used by **three critical paths**:

```
HandleClearData()
ListClear()
RefreshDpsTable()
```

---

## 3️⃣ `ListClear()` — exclusive clearing section

```
ListClear()
   │
   ├─ Interlocked.Exchange(_isClearing, 1)
   │     ├─ already 1 ? ──▶ RETURN (skip)
   │     └─ was 0      ──▶ continue
   │
   ├─ Clear statistic managers
   ├─ Clear skill tables
   ├─ Reset labels
   │
   ├─ lock(_dataLock)
   │     ├─ DictList.Clear()
   │     ├─ list.Clear()
   │     ├─ userRenderContent.Clear()
   │     └─ UI thread:
   │          SortedProgressBarStatic.Data = empty list
   │
   └─ finally
         └─ Volatile.Write(_isClearing, 0)
```

**Key idea**
✔ Only ONE clear operation can ever run
✔ Guaranteed reset back to `0` even if something throws

---

## 4️⃣ `RefreshDpsTable()` — hard blocked during clearing

```
RefreshDpsTable(...)
   │
   ├─ if (_isClearing == 1) ──▶ RETURN   ← Gate #0
   │
   ├─ Validate visible source
   ├─ Build UI rows
   │
   ├─ lock(_dataLock)
   │     ├─ if (_isClearing == 1) ──▶ RETURN  ← Gate #1
   │     │
   │     ├─ Snapshot old list
   │     ├─ Build next list
   │     ├─ Replace list atomically
   │     └─ Bind to UI
   │
   └─ END
```

**Why double-check `_isClearing`?**

```
Outside lock  → fast rejection
Inside lock   → race-safe rejection
```

This prevents:

* enumerating a list while it’s being cleared
* UI binding to half-cleared data
* cross-thread mutation crashes

---

## 5️⃣ Timeline view (race-safe behavior)

```
Time ─────────────────────────────────────────▶

Thread A (UI refresh):
   RefreshDpsTable()
       sees _isClearing == 0
       enters lock(_dataLock)

Thread B (Clear button):
   HandleClearData()
       └─ ListClear()
            sets _isClearing = 1
            waits for _dataLock

Thread A:
   inside lock → checks _isClearing
       == 1 → abort safely
       releases lock

Thread B:
   acquires lock
   clears everything
   sets _isClearing = 0
```

✅ No crashes
✅ No partial UI
✅ No concurrent enumeration

---

## 6️⃣ Mental model (one sentence)

```
_isClearing is a global “RED LIGHT”:
when it’s on, ALL rendering and rebuilding must stop immediately.
```

