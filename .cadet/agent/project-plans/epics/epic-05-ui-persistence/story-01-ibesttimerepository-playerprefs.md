# Story 01: Create IBestTimeRepository & PlayerPrefs Implementation

## Document Control
- Story ID: epic-05-story-01
- Story Name: Create IBestTimeRepository & PlayerPrefs implementation
- Parent Epic: [epic-05-ui-persistence](epic.md)
- Status: Planned
- Scope: Small
- Depends on: Epic 04 complete
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Define the persistence abstraction and implement it with PlayerPrefs so best lap times survive app restart.

## Acceptance Criteria

### AC-S01-01: Interface compiles
- **Given:** `IBestTimeRepository.cs` in `Scripts/Interfaces/`
- **When:** Defines `void SaveBestTime(float)` and `float LoadBestTime()`
- **Then:** Interface compiles
- **Testability:** EditMode — reference interface

### AC-S01-02: Mock for testing
- **Given:** Interface exists
- **When:** `MockBestTimeRepository` implements with in-memory storage
- **Then:** EditMode tests can use mock
- **Testability:** EditMode — `MockBestTimeRepository_SaveAndLoad`

### AC-S01-03: PlayerPrefs saves and loads (AC-07)
- **Given:** `PlayerPrefsBestTimeRepository` uses `PlayerPrefs.SetFloat("BestLapTime", time)` + `PlayerPrefs.Save()`
- **When:** SaveBestTime(42.5f) then LoadBestTime()
- **Then:** Returns 42.5f
- **Testability:** EditMode — `BestTimeRepository_SaveAndLoad_RoundTrip`

### AC-S01-04: Default when nothing saved (AC-07)
- **Given:** No best time ever saved
- **When:** LoadBestTime()
- **Then:** Returns `float.MaxValue` (sentinel for "no time")
- **Testability:** EditMode — `BestTimeRepository_LoadDefault_ReturnsMaxValue`

## Test Strategy
- **Red:** Write save/load tests — fail (no implementation).
- **Green:** Create interface + PlayerPrefs implementation — tests pass.
- Linked Requirement: AC-07
- Linked Design Section: technical-design.md §Persistence

## Validation
- [ ] Save → load round-trip test green
- [ ] Default value test green

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
