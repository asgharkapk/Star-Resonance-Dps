# StarResonanceDpsAnalysis To-Do List

## To-Do

### Issues

- [ ] Player’s own class/job is not obtained correctly

### Features

- [ ] Local information caching
- [ ] Try using GPU rendering for controls
- [ ] Allow users to reset user settings by launching the application with Shift / Control

### Refactoring

- [ ] Split analysis logic from data logic
- [ ] After switching network adapters in settings, automatically toggle detection once

## Completed

### 2025-08-18 Bug Fixes

- [x] Fixed font display issues when loading from resource files
- [x] Error popup when DPS statistics are active with many players

### 2025-08-18 Features Completed

- [x] Create an application entry that launches the program with administrator privileges

### 2025-08-19 Features Completed

- [x] Save window position before closing; launch at the last position on next startup
- [x] Prompt the user to restart the application after switching network adapters in settings

## Version 2.0.2 Update Notes

1. [x] Added monster damage-taken statistics, used to view total team damage required to kill a boss, or to view damage rankings against a specific monster  
   *(Currently only IDs are available, no names — please identify manually)*
2. [x] Added insignia level and player level display to the skill details page
3. [x] Added historical skill cast monitoring to check whether personal rotation is disordered
5. [x] Added damage-based sorting to history records
6. [x] Updated skill IDs

## Version 2.0.3 Update Notes

1. [x] Skill cast records now support monitoring other players’ skill usage
2. [ ] Display total team damage in DPS statistics
3. [ ] Add scrollbar to DPS statistics
4. [ ] Add target dummy selection in training mode  
   (Choose the far-right dummy or the one behind the NPC to avoid issues such as stacked defense-reduction debuffs or other players attacking the same dummy, which can cause abnormal damage values)
5. [x] Added skill detail view to damage reference
6. [ ] Add NPC data
7. [ ] Include level and insignia level in data collection

## To-Do (Not Completed)

### UI / UX

- [ ] Make AlwaysOnTop button use a toggle icon
- [ ] Change button icons
- [ ] Add colored SVG icon support
- [ ] Improve module calculator visuals
- [ ] Fix light theme fully transparent background
- [ ] Add subclass icons
- [ ] Add fully customizable theme  
  (colors, fonts, sizes, positions, progress bar values, and display formats)
- [ ] Fix showing light-mode icon when dark mode is enabled on startup
- [ ] Fix skill diary background to fully support themes  
  (adjust text colors and highlights)

### Module Calculator

- [ ] Improve module calculator calculation script
- [ ] Fix module calculator tooltip  
  (users don’t understand they must keep the calculator open and teleport to a *different* map—not the same map—for it to work)
- [ ] Add more flexible module attribute selection
- [ ] Add gear export list and gear calculator
- [ ] Translate module attribute names to official game translations

### Data / Parsing

- [ ] Add monster detector GPS
- [ ] Check if parser can detect player party/group
- [ ] Add group view based on in-game group view  
  (if group detection is possible)
- [ ] Detect special gear attributes  
  (e.g. Damage vs Bosses) and display them on progress bars  
  (icon + percentage)
- [ ] Fix updating class in progress bars when player changes class

### Progress Bars & Views

- [ ] Add multi-column progress bar view (same tab, e.g. DPS in 2 columns)
- [ ] Add multi-column progress bar view for multiple tabs  
  (e.g. DPS + Heal shown at the same time)
- [ ] Add progress bar to battle history

### NPC / Combat Display

- [ ] Show monster names and max HP as `(received / max HP)` in NPC tanking
- [ ] Fix overall tanking number flickering bug

### Localization

- [ ] Fix translations and tooltips
- [ ] Translate skills to official game skill names

### History & Utilities

- [ ] Save and load history locally
- [ ] Add screenshot button  
  (copy app screenshot to clipboard and save locally)
- [ ] Add copy button to quickly copy DPS meter data
- [ ] Add duplicate DPS meter button
- [ ] Add pause button
- [ ] Add refresh button for adapter list in settings

## To-Do (Not Completed)

---

### UI / UX

- [ ] Make AlwaysOnTop button use a toggle icon  
  - [ ] Use distinct ON / OFF SVG icons  
  - [ ] Sync icon state with actual `TopMost` state on startup  
  - [ ] Add tooltip indicating current state  

- [ ] Change button icons  
  - [ ] Replace placeholder icons with consistent style  
  - [ ] Unify icon size, padding, and alignment  
  - [ ] Ensure icons scale correctly on different DPI settings  

- [ ] Add colored SVG icon support  
  - [ ] Support multi-color SVG rendering  
  - [ ] Allow theme-based color override  
  - [ ] Fallback to monochrome if SVG color parsing fails  

- [ ] Improve module calculator visuals  
  - [ ] Improve layout spacing and alignment  
  - [ ] Highlight active / updated values  
  - [ ] Improve readability of numbers and labels  
  - [ ] Add visual grouping for related attributes  

- [ ] Fix light theme fully transparent background  
  - [ ] Identify controls ignoring theme background  
  - [ ] Ensure consistent background opacity across all panels  
  - [ ] Verify behavior on window resize and redraw  

- [ ] Add subclass icons  
  - [ ] Design or import subclass icons  
  - [ ] Display subclass icon near player name  
  - [ ] Update icon dynamically on subclass change  

- [ ] Add fully customizable theme  
  - [ ] Color customization (background, text, highlights)  
  - [ ] Font family and font size selection  
  - [ ] Progress bar height, spacing, and rounding  
  - [ ] Number format customization (percent, raw, shortened)  
  - [ ] Save and load custom theme presets  

- [ ] Fix showing light-mode icon when dark mode is enabled on startup  
  - [ ] Load theme before initializing icons  
  - [ ] Refresh icons after theme load  
  - [ ] Ensure correct icon state on first render  

- [ ] Fix skill diary background to fully support themes  
  - [ ] Update text colors based on theme  
  - [ ] Fix highlight and selection colors  
  - [ ] Ensure contrast remains readable in dark/light modes  

---

### Module Calculator

- [ ] Improve module calculator calculation script  
  - [ ] Refactor calculation logic for readability  
  - [ ] Validate formulas against in-game results  
  - [ ] Reduce redundant recalculations  
  - [ ] Add comments and documentation  

- [ ] Fix module calculator tooltip behavior  
  - [ ] Explain requirement to keep calculator open  
  - [ ] Clarify that teleporting must be to a *different map*  
  - [ ] Add warning when teleporting to same map  
  - [ ] Add example or short usage guide  

- [ ] Add more flexible module attribute selection  
  - [ ] Allow manual enable/disable of attributes  
  - [ ] Support partial or conditional attributes  
  - [ ] Add presets for common builds  

- [ ] Add gear export list and gear calculator  
  - [ ] Export equipped gear data  
  - [ ] Display gear stats in readable table  
  - [ ] Integrate gear stats into module calculator  
  - [ ] Allow comparison between gear sets  

- [ ] Translate module attribute names to official game translations  
  - [ ] Map internal attribute IDs to official names  
  - [ ] Support multiple languages  
  - [ ] Ensure consistency with skill translations  

---

### Data / Parsing

- [ ] Add monster detector GPS  
  - [ ] Track monster position relative to player  
  - [ ] Detect active combat target  
  - [ ] Use data for tanking and positioning features  

- [ ] Check if parser can detect player party/group  
  - [ ] Identify party members from combat data  
  - [ ] Track joins/leaves dynamically  
  - [ ] Handle solo vs party state  

- [ ] Add group view based on in-game group view  
  - [ ] Group players by party/subgroup  
  - [ ] Show group totals and averages  
  - [ ] Allow collapsing/expanding groups  

- [ ] Detect special gear attributes  
  - [ ] Detect attributes like “Damage vs Bosses”  
  - [ ] Store attribute values per player  
  - [ ] Display icon + percentage on progress bars  
  - [ ] Allow toggling visibility  

- [ ] Fix updating class in progress bars when player changes class  
  - [ ] Detect class change event reliably  
  - [ ] Update icon, color, and label instantly  
  - [ ] Prevent stale class data in history  

---

### Progress Bars & Views

- [ ] Add multi-column progress bar view (same tab)  
  - [ ] Support 2+ columns in same metric (e.g. DPS)  
  - [ ] Balance column width dynamically  
  - [ ] Maintain sorting across columns  

- [ ] Add multi-column view for multiple tabs  
  - [ ] Show DPS and Heal side-by-side  
  - [ ] Allow user to select metrics per column  
  - [ ] Sync scrolling between columns  

- [ ] Add progress bar to battle history  
  - [ ] Visualize damage/healing over time  
  - [ ] Allow scrubbing or hovering for details  
  - [ ] Match colors with live progress bars  

---

### NPC / Combat Display

- [ ] Show monster names and max HP in NPC tanking  
  - [ ] Display as `(received damage / max HP)`  
  - [ ] Support boss vs normal NPC formatting  
  - [ ] Handle unknown or partial HP data  

- [ ] Fix overall tanking number flickering bug  
  - [ ] Identify recalculation timing issues  
  - [ ] Add value smoothing or debounce  
  - [ ] Ensure stable display during combat  

---

### Localization

- [ ] Fix translations and tooltips  
  - [ ] Review unclear or incorrect text  
  - [ ] Improve grammar and clarity  
  - [ ] Ensure tooltips explain advanced mechanics  

- [ ] Translate skills to official game skill names  
  - [ ] Map skill IDs to official names  
  - [ ] Support localization per language  
  - [ ] Keep translations in sync with game updates  

---

### History & Utilities

- [ ] Save and load history locally  
  - [ ] Define history storage format  
  - [ ] Auto-save on session end  
  - [ ] Manual import/export support  

- [ ] Add screenshot button  
  - [ ] Capture app window only  
  - [ ] Copy image to clipboard  
  - [ ] Save locally with timestamp  

- [ ] Add copy button for DPS meter data  
  - [ ] Copy formatted text summary  
  - [ ] Support CSV / plain text  
  - [ ] Respect current sorting and filters  

- [ ] Add duplicate DPS meter button  
  - [ ] Clone current meter configuration  
  - [ ] Allow independent sorting and filters  
  - [ ] Useful for comparison views  

- [ ] Add pause button  
  - [ ] Pause data updates without clearing data  
  - [ ] Visual indicator for paused state  
  - [ ] Resume without losing session data  

- [ ] Add adapter list refresh in settings  
  - [ ] Manual refresh button  
  - [ ] Preserve selected adapter if still available  
  - [ ] Warn if active adapter disappears  

