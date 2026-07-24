# Story 05: Create LapData & LapManager Stub

## Document Control
- Story ID: epic-03-story-05
- Story Name: Create LapData & LapManager stub
- Parent Epic: [epic-03-track-lap-detection](epic.md)
- Status: Planned
- Scope: Small
- Depends on: story-04
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Define the `LapData` struct and create `LapManager` stub that detects start/finish crossings with direction validation.

## Acceptance Criteria

### AC-S05-01: LapData struct compiles
- **Given:** `LapData.cs` created
- **When:** Defines `int LapNumber`, `float LapTime`, `DateTime Timestamp`
- **Then:** Struct compiles, is immutable (readonly properties)
- **Testability:** EditMode — instantiate and verify properties

### AC-S05-02: LapManager stub exists
- **Given:** `LapManager.cs` in `Scripts/Core/`
- **When:** Has `List<float> LapTimes`, `float BestLap`, `int LapCount`, `OnTriggerEnter2D` checking "StartFinish" tag, direction check
- **Then:** Component compiles
- **Testability:** EditMode — instantiate LapManager

### AC-S05-03: Direction check accepts correct direction
- **Given:** Start/finish oriented vertically (forward = left→right)
- **When:** Motorcycle crosses left to right
- **Then:** Crossing accepted as valid
- **Testability:** EditMode — `LapManager_DirectionCheck_AcceptCorrect`

### AC-S05-04: Direction check rejects wrong direction
- **Given:** Same setup
- **When:** Motorcycle crosses right to left (backwards)
- **Then:** Crossing rejected
- **Testability:** EditMode — `LapManager_DirectionCheck_RejectWrong`

## Test Strategy
- **Red:** Write direction check tests — fail (no LapManager).
- **Green:** Create LapData + LapManager stub with direction logic — tests pass.
- Linked Requirement: AC-05
- Linked Design Section: technical-design.md §Lap Detection

## Validation
- [ ] `LapData` compiles
- [ ] EditMode tests: direction check logic validated

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
