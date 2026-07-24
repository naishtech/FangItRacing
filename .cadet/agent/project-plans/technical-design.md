# Technical Design: Fang It Racing — Core Prototype

## Document Control
- **Project:** Fang It Racing
- **Feature:** Core prototype — top-down 2D motorcycle time trial
- **Status:** Draft
- **Version:** 0.2.0
- **Last Updated:** 2026-07-23

## Learner Context
- **Assumed tier:** Tier 0 (New)
- **Operating mode:** Guided implementation
- **Explanation depth:** Layman's terms, explain why each step matters, ask before/after each substantive step

## Design Summary
- **Overview:** Two-scene Unity 2D project: main menu and race scene. Arcade motorcycle controller drives a geometric sprite around a spline-defined track overlaid on a user-provided background image. LapManager tracks crossings and times. RaceManager orchestrates state (countdown → racing → ended). Cinemachine follows the motorcycle. PlayerPrefs saves best lap time.
- **Objectives:** Prove the top-down 2D arcade racing loop is fun; establish clean component boundaries for future iteration.
- **Scope Boundaries:** Single track, single player, no audio, no online features. See [requirements.md](../requirements.md).
- **Design Decision 2026-07-23:** Replaced SpriteShape with Unity Splines package (`com.unity.splines`) + user-provided background image. Rationale: SpriteShape's profile/fill/tangent workflow was too complex at Tier 0. Splines are simpler (click to add knots, drag to move) and the background image handles all visual detail.

## Requirements Mapping
| Requirement ID | Design Section | Notes |
|---|---|---|
| AC-01, AC-02, AC-03 | MotorcycleController | Movement, steering, drift — all in one component |
| AC-04 | TrackManager + SplineTrack + Background | Slow-down zone via colliders generated from spline; track visuals from background image |
| AC-05, AC-06 | LapManager | Trigger-based lap detection + timing |
| AC-07 | BestTimeRepository | PlayerPrefs-backed persistence |
| AC-08 | MenuController + MainMenuScene | Simple button-driven menu |
| AC-09 | RaceManager (Countdown state) | 3-2-1-GO before releasing control |
| AC-10 | HUDController | UI bound to RaceManager events |
| AC-11 | Build configuration | WebGL build settings + manual validation |

## Architecture

### Scene Structure
```
MainMenuScene
├── Canvas
│   ├── Title Text ("Fang It Racing")
│   ├── Start Race Button
│   ├── Best Times Button
│   └── Quit Button
└── MenuController (MonoBehaviour)

RaceScene
├── Motorcycle (GameObject)
│   ├── SpriteRenderer (colored rectangle placeholder)
│   ├── MotorcycleController (MonoBehaviour)
│   └── Rigidbody2D (kinematic — for trigger detection only)
├── Track
│   ├── Background (SpriteRenderer — user-provided track image, sits behind everything)
│   ├── SplineContainer (closed loop spline defining the racing line)
│   ├── SplineTrack (MonoBehaviour — generates EdgeCollider2D from spline points)
│   └── OffTrackTriggers (slow-down zones outside track)
├── StartFinishLine (GameObject with BoxCollider2D trigger)
├── RaceManager (MonoBehaviour, singleton for this prototype)
├── LapManager (MonoBehaviour)
├── HUD
│   ├── Canvas (World Space or Screen Space overlay)
│   ├── LapTimeText, BestTimeText, LapCountText, SpeedText
│   └── HUDController (MonoBehaviour)
├── Cinemachine Virtual Camera (follows Motorcycle)
└── CountdownOverlay (3-2-1-GO text)
```

### Component Design

#### MotorcycleController
- **Responsibility:** Input → movement, rotation, drift
- **Serialized fields:** `maxSpeed`, `acceleration`, `turnRate`, `driftFactor`
- **Input actions:** Accelerate (W/↑), Steer (A/←, D/→)
- **Algorithm:**
  1. Read input → acceleration force & steer direction
  2. Apply acceleration along forward vector: `velocity += forward * accelInput * acceleration * dt`
  3. Clamp speed to `maxSpeed`
  4. Calculate turn: `turnAmount = steerInput * turnRate * (currentSpeed / maxSpeed) * dt`
  5. Apply rotation to transform
  6. Apply drift: preserve fraction of lateral velocity during rotation via `driftFactor`
  7. Apply off-track speed multiplier if on slow zone
- **Public API:** `bool IsControllable { get; set; }`, `float CurrentSpeed { get; }`

#### RaceManager
- **Responsibility:** Race lifecycle state machine
- **States:** `Countdown` → `Racing` → `Ended`
- **Events:** `OnRaceStateChanged(RaceState)`, `OnLapCompleted(LapData)`
- **Flow:**
  1. Scene loads → Countdown state, MotorcycleController.IsControllable = false
  2. Countdown 3→2→1→GO (coroutine), then → Racing state, IsControllable = true
  3. Racing: listen for LapManager.OnLapCompleted, update timer
  4. Ended: triggered by Quit to Menu, save best time via BestTimeRepository

#### LapManager
- **Responsibility:** Detect start/finish crossing, track lap times
- **Logic:** OnTriggerEnter2D on start/finish line → check crossing direction → if valid, emit OnLapCompleted
- **Direction check:** Track crossing direction (e.g., right-to-left) to prevent double-counting
- **Data:** `List<float> lapTimes`, `float bestLap`, `int lapCount`

#### HUDController
- **Responsibility:** Display race data on UI
- **Binds to:** RaceManager events for lap time updates
- **Updates each frame:** Current lap time, best lap time, lap count, speed
- **Format:** Times as `M:SS.mm`

#### BestTimeRepository
- **Interface:** `IBestTimeRepository` with `SaveBestTime(float)`, `LoadBestTime() → float`
- **Implementation:** `PlayerPrefsBestTimeRepository` — keys stored as `"BestLapTime"`
- **Fallback:** Returns `float.MaxValue` if no saved time (any new time beats it)

#### MenuController
- **Responsibility:** Main menu button handlers
- **Start Race:** `SceneManager.LoadScene("RaceScene")`
- **Best Times:** Display best saved time in a panel
- **Quit:** `Application.Quit()`

### Data Flow
```
┌──────────────┐     input      ┌──────────────────────┐
│ Input System │ ──────────────→ │ MotorcycleController  │
└──────────────┘                 └────────┬─────────────┘
                                          │ transform
                                          ▼
┌──────────────┐   trigger      ┌──────────────────────┐
│ StartFinish  │ ──────────────→ │     LapManager        │
│ Line Trigger │                 └────────┬─────────────┘
└──────────────┘                          │ OnLapCompleted event
                                          ▼
                                 ┌──────────────────────┐
                                 │     RaceManager       │
                                 └──────┬───────┬───────┘
                                        │       │
                              UI updates│       │ save best
                                        ▼       ▼
                                 ┌──────────┐ ┌──────────────────┐
                                 │HUDController│ │BestTimeRepository│
                                 └──────────┘ └──────────────────┘
```

## Technology Choices
See ADRs in [adr/](adr/):
- [ADR-001](adr/adr-001-custom-arcade-controller.md) — Custom arcade controller vs Rigidbody2D
- [ADR-002](adr/adr-002-spriteshape-track.md) — SpriteShape vs Tilemap for track
- [ADR-003](adr/adr-003-playerprefs-persistence.md) — PlayerPrefs vs JSON file
- [ADR-004](adr/adr-004-cinemachine-camera.md) — Cinemachine for camera follow

## TDD Strategy (Red/Green)

### Test Matrix
| AC ID | Failing Test (Red) | Implementation Step (Green) | Type |
|---|---|---|---|
| AC-01 | MotorcycleController_Accelerate_IncreasesSpeed | Implement acceleration in MotorcycleController | EditMode |
| AC-02 | MotorcycleController_Steer_RotatesTransform | Implement steering with speed-sensitive turn rate | EditMode |
| AC-03 | MotorcycleController_Drift_PreservesLateralVelocity | Implement drift factor in velocity calculation | EditMode |
| AC-04 | MotorcycleController_OffTrack_ReducesSpeed | Add off-track multiplier + trigger detection | PlayMode |
| AC-05 | LapManager_CrossFinishLine_RegistersLap | Implement OnTriggerEnter2D + direction check | PlayMode |
| AC-06 | LapManager_TracksBestLap_AcrossLaps | Implement lap time list + best calculation | EditMode |
| AC-07 | BestTimeRepository_SaveAndLoad_PersistsData | Implement PlayerPrefs save/load | EditMode |
| AC-08 | MenuScene_StartButton_LoadsRaceScene | Wire button → SceneManager.LoadScene | PlayMode |
| AC-09 | RaceManager_Countdown_ReleasesControlAfterGo | Implement countdown coroutine + state transitions | PlayMode |
| AC-10 | HUDController_DisplaysLapData_UpdatesEachFrame | Implement UI binding to RaceManager data | PlayMode |
| AC-11 | N/A — manual validation | Build WebGL, test in browser | Manual |

### Test Infrastructure
- **EditMode tests:** `Assets/Tests/EditMode/` — pure logic, no scene dependencies
- **PlayMode tests:** `Assets/Tests/PlayMode/` — require loaded scenes, input simulation via InputTestFixture
- **Mocking:** `IBestTimeRepository` mocked in LapManager/RaceManager tests
- **Assembly:** Separate test assembly referencing game code via `.asmdef`

## Rollout
- **No migration needed** — greenfield prototype
- **Rollback:** N/A for prototype
- **Future-proofing:** `IBestTimeRepository` interface allows swapping PlayerPrefs for JSON/cloud later

## Traceability to Planning
- See [project-plan.md](../project-plan.md) (to be created after design approval)
- Epic breakdown will follow: Setup → Controller → Track → Timing → UI → Polish → Build

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.2.0 | 2026-07-23 | Cadet-Agent | Replaced SpriteShape with Unity Splines + background image; updated learner tier to Tier 0 |
| 0.1.0 | 2026-07-19 | Cadet-Agent | Initial technical design |
