# Story 01: Create RaceState & RaceManager Stub

## Document Control
- Story ID: epic-04-story-01
- Story Name: Create RaceState & RaceManager stub
- Parent Epic: [epic-04-race-flow](epic.md)
- Status: Planned
- Scope: Small
- Depends on: Epic 03 complete
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Define `RaceState` enum and create `RaceManager` stub with state tracking, events, and references to MotorcycleController and LapManager.

## Acceptance Criteria

### AC-S01-01: RaceState enum compiles
- **Given:** `RaceState.cs` created
- **When:** Defines `enum RaceState { Countdown, Racing, Ended }`
- **Then:** Enum compiles
- **Testability:** EditMode — reference enum in test

### AC-S01-02: RaceManager stub exists
- **Given:** `RaceManager.cs` in `Scripts/Core/`
- **When:** Has `RaceState CurrentState`, `float RaceTime`, events `OnRaceStateChanged`, `OnLapCompleted`, references to MotorcycleController + LapManager
- **Then:** Component compiles
- **Testability:** EditMode — instantiate RaceManager

### AC-S01-03: IsControllable wired
- **Given:** RaceManager references MotorcycleController
- **When:** RaceManager.Start() sets `IsControllable=false`
- **Then:** MotorcycleController ignores input
- **Testability:** EditMode — `RaceManager_Start_DisablesControl`

## Test Strategy
- **Red:** Write RaceManager initialization test — fails.
- **Green:** Create enum + RaceManager stub — test passes.
- Linked Requirement: AC-09
- Linked Design Section: technical-design.md §Race Manager

## Validation
- [ ] Enum and RaceManager compile
- [ ] EditMode test: RaceManager initializes in Countdown, IsControllable=false

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
