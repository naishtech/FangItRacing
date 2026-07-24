# Story 03: Implement Race Timer & LapManager Wiring

## Document Control
- Story ID: epic-04-story-03
- Story Name: Implement race timer & LapManager wiring
- Parent Epic: [epic-04-race-flow](epic.md)
- Status: Planned
- Scope: Small
- Depends on: story-02
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Add running race timer during Racing state, wire LapManager.OnLapCompleted to RaceManager for event forwarding.

## Acceptance Criteria

### AC-S03-01: Timer starts after GO
- **Given:** RaceManager transitions to Racing
- **When:** Update() runs
- **Then:** `RaceTime` increments by `Time.deltaTime` each frame
- **Testability:** EditMode — `RaceManager_Timer_StartsAfterGo`

### AC-S03-02: Timer stops on Ended
- **Given:** RaceManager transitions to Ended
- **When:** Update() runs
- **Then:** `RaceTime` no longer increments
- **Testability:** EditMode — `RaceManager_Timer_StopsOnEnded`

### AC-S03-03: LapManager events forwarded
- **Given:** RaceManager subscribes to LapManager.OnLapCompleted
- **When:** Lap completed
- **Then:** RaceManager fires its own OnLapCompleted with same LapData
- **Testability:** EditMode — `RaceManager_ForwardsLapEvents`

### AC-S03-04: Best lap exposed
- **Given:** LapManager reports new best lap
- **When:** RaceManager receives event
- **Then:** Best lap accessible via public property
- **Testability:** EditMode — `RaceManager_ExposesBestLap`

## Test Strategy
- **Red:** Write timer + event forwarding tests — fail.
- **Green:** Implement timer in Update(), subscribe to LapManager — tests pass.
- Linked Requirement: AC-09
- Linked Design Section: technical-design.md §Race Manager

## Validation
- [ ] EditMode tests: timer starts/stops, events forwarded
- [ ] Best lap property accessible

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
