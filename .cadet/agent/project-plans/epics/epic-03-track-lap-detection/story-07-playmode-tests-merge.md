# Story 07: PlayMode Tests & Merge

## Document Control
- Story ID: epic-03-story-07
- Story Name: PlayMode tests & merge
- Parent Epic: [epic-03-track-lap-detection](epic.md)
- Status: Planned
- Scope: Small
- Depends on: story-06
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Write PlayMode integration tests with full scene setup, verify end-to-end lap detection, then branch, PR, and merge.

## Acceptance Criteria

### AC-S07-01: PlayMode — lap registered on crossing
- **Given:** Full scene with Motorcycle, SplineTrack, StartFinish trigger
- **When:** Motorcycle moved across trigger via script in correct direction
- **Then:** LapManager registers the lap
- **Testability:** PlayMode — `LapDetection_PlayMode_CrossingRegistersLap`

### AC-S07-02: PlayMode — wrong-way rejected
- **Given:** Full scene
- **When:** Motorcycle crosses trigger in wrong direction
- **Then:** No lap registered
- **Testability:** PlayMode — `LapDetection_PlayMode_WrongWayRejected`

### AC-S07-03: All tests green & merged
- **Given:** All tests pass
- **When:** Branch `epic/03-track` squash-merged to `main`
- **Then:** AC-04, AC-05, AC-06 demonstrable
- **Testability:** Manual — verify merge, test in editor

## Test Strategy
- PlayMode tests with full scene assembly.
- Verify no regressions in Epic 02 tests.
- Linked Requirement: AC-04, AC-05, AC-06
- Linked Design Section: technical-design.md §Testing

## Validation
- [ ] Test Runner: all green
- [ ] Manual: drive laps, lap counter increments, times recorded

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
