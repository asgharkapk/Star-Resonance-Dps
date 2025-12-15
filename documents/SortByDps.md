# ⭐ **ASCII MAP — `SortByDps` Sorting Pipeline**

```
+-----------------------------------------------------------+
|  Global Static Flag                                       |
|                                                           |
|   DpsStatisticsForm.Function.cs                           |
|   -----------------------------------------------------   |
|   private static bool SortByDps = false;                  |
|                     |                                     |
|                     | (toggled by SortToggleButton)       |
+---------------------+-------------------------------------+

             |
             v
+-----------------------------------------------------------+
| RefreshDpsTable()                                         |
|                                                           |
| STEP 1 — Build UI rows (raw data): BuildUiRows()          |
| STEP 2 — Filter rows                                      |
|                                                           |
| STEP 3 — APPLY SORT  <--------------- SortByDps           |
|                                                           |
|   if (SortByDps)                                          |
|         ordered = uiList.OrderByDescending(p.PerSecond)   |
|   else                                                    |
|         ordered = uiList.OrderByDescending(p.Total)       |
|                                                           |
+-----------------------------------------------------------+
             |
             |
             |   create/update ProgressBarData
             v
+-----------------------------------------------------------+
| For each row p in ordered list:                           |
|                                                           |
|   orderKey = SortByDps ? p.PerSecond : p.Total            |
|                                                           |
|   pb.OrderValue = orderKey                                |
|                                                           |
|   (ProgressBarValue = ratio is *not* used for ordering)   |
+-----------------------------------------------------------+
             |
             v
+-----------------------------------------------------------+
| next: List<ProgressBarData> prepared                      |
| assigned to SortedProgressBarList.Data                    |
+-----------------------------------------------------------+
             |
             v
+===========================================================+
|         SortedProgressBarList.Function.cs (UI List)       |
+===========================================================+

+-----------------------------------------------------------+
| Resort()                                                  |
|                                                           |
| This method controls animated list reordering.            |
|                                                           |
|   _dataDict = all ProgressBarData items                   |
|   _animatingInfoBuffer = animation states                 |
|                                                           |
| Sorting happens HERE:                                     |
|                                                           |
|   _animatingInfoBuffer =                                  |
|       buffer.OrderByDescending(                           |
|            e.Data.OrderValue ?? e.Data.ProgressBarValue   |
|       )                                                   |
|                                                           |
| → when SortByDps = TRUE:                                  |
|         OrderValue = PerSecond                            |
| → when SortByDps = FALSE:                                 |
|         OrderValue = Total                                |
|                                                           |
| Resort() assigns new animated indexes: ToIndex = 0,1,2…   |
+-----------------------------------------------------------+

             |
             v
+-----------------------------------------------------------+
| UI ProgressBarList animates rows to their new positions   |
+-----------------------------------------------------------+
```

---

# ⭐ **Ultra-Condensed Flow**

```
SortToggleButton → SortByDps
         ↓
RefreshDpsTable()
         ↓
Create ProgressBarData.OrderValue using:
    DPS (PerSecond)   OR   Total Damage
         ↓
SortedProgressBarList.Resort()
         ↓
Rows animated + reordered in UI
```

---

# ⭐ EXACT PLACES WHERE `SortByDps` MATTERS

### ✔ 1. **Choosing sort algorithm**

```csharp
var ordered = SortByDps
    ? uiList.OrderByDescending(x => x.PerSecond)
    : uiList.OrderByDescending(x => x.Total);
```

### ✔ 2. **Storing ordering weight into ProgressBarData**

```csharp
double orderKey = SortByDps ? p.PerSecond : p.Total;
pb.OrderValue = orderKey;
```

### ✔ 3. **SortedProgressBarList applies the sort**

```csharp
.OrderByDescending(e => e.Data.OrderValue ?? e.Data.ProgressBarValue)
```

---

# ⭐ When you see ranking change in label1 (“🥇1”) this is why

Ranking in:

```csharp
label1.Text = $" [🥇{i + 1}]";
```

`i` is index in `ordered`, **which is sorted by SortByDps**.

So the gold-medal rank follows the same sort.


