# Story 05: TimeFormatter, PlayMode Tests & Merge

## Document Control
- Story ID: epic-05-story-05
- Story Name: TimeFormatter, PlayMode tests & merge
- Parent Epic: [epic-05-ui-persistence](epic.md)
- Status: Planned
- Scope: Small
- Depends on: story-04
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Create `TimeFormatter` utility, write comprehensive PlayMode integration tests, branch, PR, and merge.

## Acceptance Criteria

### AC-S05-01: TimeFormatter formats correctly
- **Given:** `TimeFormatter.FormatTime(float)` utility
- **When:** Called with 0s, 59.99s, 60s, 3599.99s
- **Then:** Returns "0:00.00", "0:59.99", "1:00.00", "59:59.99"
- **Testability:** EditMode — `TimeFormatter_AllEdgeCases`

### AC-S05-02: PlayMode — full HUD flow
- **Given:** RaceScene with HUD, MotorcycleController, LapManager, RaceManager
- **When:** Full race runs (countdown → racing → lap)
- **Then:** HUD displays correct values throughout
- **Testability:** PlayMode — `HUD_FullFlow_Integration`

### AC-S05-03: PlayMode — persistence end-to-end (AC-07)
- **Given:** Race completes with best lap
- **When:** Return to menu, check Best Times
- **Then:** Best time displayed correctly
- **Testability:** PlayMode — `Persistence_FullFlow`

### AC-S05-04: All tests green & merged
- **Given:** All tests pass
- **When:** Branch `epic/05-ui-persistence` squash-merged to `main`
- **Then:** AC-07, AC-10 demonstrable
- **Testability:** Manual — end-to-end verification

## Test Strategy
- EditMode: TimeFormatter unit tests for edge cases.
- PlayMode: full integration tests for HUD + persistence.
- Linked Requirement: AC-07, AC-10
- Linked Design Section: technical-design.md §HUD, §Persistence

## Validation
- [ ] Test Runner: all green
- [ ] Manual: HUD updates, best time survives quit → relaunch

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
