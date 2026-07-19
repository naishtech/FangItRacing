# Epic 04: Race Flow

**Status:** Not Started | **Depends on:** Epic 03 | **Est. tasks:** 8

## Objective
Implement RaceManager state machine (Countdown → Racing → Ended), main menu scene, and scene transitions. Covers AC-08, AC-09.

## Tasks

### T-01: Create RaceState enum
- `enum RaceState { Countdown, Racing, Ended }`
- **Validation:** Compiles

### T-02: Create RaceManager stub (AC-09)
- `RaceManager.cs` with `RaceState CurrentState`, `float raceTime`
- Events: `OnRaceStateChanged(RaceState)`, `OnLapCompleted(LapData)`
- References: MotorcycleController, LapManager
- **Test (Red):** `RaceManager_Countdown_ReleasesControlAfterGo` — fails

### T-03: Implement countdown (AC-09)
- On scene start: CurrentState = Countdown, MotorcycleController.IsControllable = false
- Coroutine: display 3 (1s) → 2 (1s) → 1 (1s) → "GO!" (0.5s)
- After "GO!": CurrentState = Racing, IsControllable = true
- **Test (Green):** Controls enabled only after countdown completes

### T-04: Implement race timer
- During Racing state: `raceTime += Time.deltaTime`
- Expose as public property for HUD
- **Test (Green):** Timer starts after GO, stops on Ended

### T-05: Wire LapManager to RaceManager
- Subscribe to LapManager.OnLapCompleted
- Re-raise event with lap data for HUD consumption
- Update best lap if new record
- **Test (Green):** RaceManager receives and forwards lap events

### T-06: Create MainMenuScene (AC-08)
- New scene: `Assets/_Project/Scenes/MainMenuScene.unity`
- Canvas with: Title text, Start Race button, Best Times button, Quit button
- Create `MenuController.cs` with button handlers
- **Test (Red):** `MenuScene_StartButton_LoadsRaceScene` — fails

### T-07: Implement scene transitions (AC-08)
- Start Race → `SceneManager.LoadScene("RaceScene")`
- Quit → `Application.Quit()`
- Best Times → display panel with best time from PlayerPrefs (or "No time yet")
- Add RaceScene to Build Settings (both scenes)
- **Test (Green):** PlayMode test — button click loads race scene

### T-08: Merge Epic 04
- All tests green, PR reviewed, squash merge to `main`
- **Validation:** Full flow — menu → countdown → racing → quit works

## Acceptance Criteria Covered
| AC | Status |
|---|---|
| AC-08: Main Menu | ✅ |
| AC-09: Race Countdown | ✅ |

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-19 | Cadet-Agent | Initial |
