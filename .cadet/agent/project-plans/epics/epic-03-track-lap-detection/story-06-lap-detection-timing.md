# Story 06: Implement Lap Detection & Timing

## Document Control
- Story ID: epic-03-story-06
- Story Name: Implement lap detection & timing
- Parent Epic: [epic-03-track-lap-detection](epic.md)
- Status: Planned
- Scope: Medium
- Depends on: story-05
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Implement full lap detection: on valid crossing, increment lap count, calculate lap time, track best lap, fire `OnLapCompleted` event.

## Acceptance Criteria

### AC-S06-01: First crossing starts timing (AC-05)
- **Given:** Race started (post-countdown), no laps yet
- **When:** Motorcycle crosses start/finish in correct direction
- **Then:** LapCount=1, lap time recorded, `OnLapCompleted` fires
- **Testability:** EditMode — `LapManager_FirstCrossing_RecordsLap`

### AC-S06-02: Subsequent laps increment (AC-05)
- **Given:** LapCount=1, previous time recorded
- **When:** Motorcycle crosses again in correct direction
- **Then:** LapCount=2, new time = current race time − sum of previous times
- **Testability:** EditMode — `LapManager_SubsequentCrossing_Increments`

### AC-S06-03: Best lap tracked (AC-06)
- **Given:** Lap times [45.2s, 42.8s, 47.1s]
- **When:** All laps completed
- **Then:** BestLap = 42.8s
- **Testability:** EditMode — `LapManager_TracksBestLap`

### AC-S06-04: Event carries LapData (AC-06)
- **Given:** Subscriber to `OnLapCompleted`
- **When:** Lap completed
- **Then:** Subscriber receives LapData with correct LapNumber, LapTime, Timestamp
- **Testability:** EditMode — `LapManager_EventCarriesLapData`

## Test Strategy
- **Red:** Write lap detection/timing tests — fail (stub only).
- **Green:** Implement full lap logic — all tests pass.
- Linked Requirement: AC-05, AC-06
- Linked Design Section: technical-design.md §Lap Detection, §Timing

## Validation
- [ ] All EditMode tests green
- [ ] Lap times correct across multiple laps

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
