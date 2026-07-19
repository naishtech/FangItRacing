# Epic 05: UI & Persistence

**Status:** Not Started | **Depends on:** Epic 04 | **Est. tasks:** 10

## Objective
Implement HUD display (lap time, best time, lap count, speed) and best-time persistence via PlayerPrefs. Covers AC-07, AC-10.

## Tasks

### T-01: Create IBestTimeRepository interface
- `IBestTimeRepository` with `SaveBestTime(float time)` and `LoadBestTime() → float`
- Create mock for testing
- **Validation:** Interface compiles

### T-02: Create PlayerPrefsBestTimeRepository (AC-07)
- Implement `IBestTimeRepository` using PlayerPrefs
- Key: `"BestLapTime"`, default: `float.MaxValue`
- **Test (Red):** `BestTimeRepository_SaveAndLoad_PersistsData` — fails

### T-03: Implement save/load (AC-07)
- Save: `PlayerPrefs.SetFloat("BestLapTime", time); PlayerPrefs.Save();`
- Load: `PlayerPrefs.GetFloat("BestLapTime", float.MaxValue);`
- **Test (Green):** Save a time, load it back, verify equality

### T-04: Integrate with RaceManager
- On race end: `BestTimeRepository.SaveBestTime(RaceManager.BestLap)`
- On menu "Best Times": `BestTimeRepository.LoadBestTime()` and display
- **Test (Green):** PlayMode — complete a lap, quit, check best times shows saved time

### T-05: Create HUD Canvas
- Add Canvas (Screen Space - Overlay) to RaceScene
- Create UI elements anchored to corners:
  - Top-left: "Lap: N" (LapCountText)
  - Top-center: "Time: 0:00.00" (LapTimeText)
  - Top-right: "Best: 0:00.00" (BestTimeText)
  - Bottom-center: "Speed: 0" (SpeedText)
- **Validation:** Canvas visible in Game view, all text elements present

### T-06: Create HUDController stub (AC-10)
- `HUDController.cs` with references to UI Text elements
- References: RaceManager (for race time, lap count, best lap), MotorcycleController (for speed)
- **Test (Red):** `HUDController_DisplaysLapData_UpdatesEachFrame` — fails

### T-07: Implement HUD updates (AC-10)
- `Update()`: read RaceManager.RaceTime, LapManager.LapCount, LapManager.BestLap, MotorcycleController.CurrentSpeed
- Format time as `M:SS.mm`
- Update Text elements
- **Test (Green):** PlayMode — verify HUD shows correct values during race

### T-08: Format lap times
- Create `TimeFormatter` utility: `FormatTime(float seconds) → "M:SS.mm"`
- Unit test: test 0s, 59.99s, 60s, 3599.99s
- **Test (Green):** All formatting edge cases pass

### T-09: Write PlayMode integration tests
- Full flow: start race, complete a lap, verify HUD updates, quit, verify best time saved
- Edge case: no best time yet → display "---"
- **Validation:** All PlayMode tests green

### T-10: Merge Epic 05
- All tests green, PR reviewed, squash merge to `main`
- **Validation:** AC-07, AC-10 demonstrable

## Acceptance Criteria Covered
| AC | Status |
|---|---|
| AC-07: Best Time Persistence | ✅ |
| AC-10: HUD Display | ✅ |

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-19 | Cadet-Agent | Initial |
