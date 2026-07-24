# Story 02: Implement Countdown

## Document Control
- Story ID: epic-04-story-02
- Story Name: Implement countdown
- Parent Epic: [epic-04-race-flow](epic.md)
- Status: Planned
- Scope: Small
- Depends on: story-01
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Implement 3-2-1-GO countdown coroutine: display countdown, release control, transition to Racing state.

## Acceptance Criteria

### AC-S02-01: Countdown sequence runs (AC-09)
- **Given:** RaceScene loaded, Countdown state
- **When:** Scene starts
- **Then:** Coroutine displays 3 (1s) → 2 (1s) → 1 (1s) → "GO!" (0.5s)
- **Testability:** EditMode — `RaceManager_Countdown_RunsSequence` (mock time)

### AC-S02-02: Control released after GO (AC-09)
- **Given:** Countdown running
- **When:** "GO!" completes
- **Then:** `CurrentState=Racing`, `IsControllable=true`
- **Testability:** EditMode — `RaceManager_Countdown_ReleasesControlAfterGo`

### AC-S02-03: State change event fires (AC-09)
- **Given:** Countdown → Racing transition
- **When:** State changes
- **Then:** `OnRaceStateChanged(Racing)` fires
- **Testability:** EditMode — `RaceManager_Countdown_FiresStateChangedEvent`

### AC-S02-04: Countdown duration correct
- **Given:** Countdown starts at Time.time=0
- **When:** GO! completes
- **Then:** ~3.5s elapsed (3×1s + 0.5s)
- **Testability:** EditMode — `RaceManager_Countdown_DurationCorrect`

## Test Strategy
- **Red:** Write countdown tests — fail (stub only).
- **Green:** Implement coroutine — all tests pass (using mock time or yielding).
- Linked Requirement: AC-09
- Linked Design Section: technical-design.md §Race Manager

## Validation
- [ ] All EditMode tests green
- [ ] Countdown timing, state transitions, control flag verified

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
