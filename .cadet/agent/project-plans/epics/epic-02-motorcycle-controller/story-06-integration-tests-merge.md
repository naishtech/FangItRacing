# Story 06: Integration Tests & Merge

## Document Control
- Story ID: epic-02-story-06
- Story Name: Integration tests & merge
- Parent Epic: [epic-02-motorcycle-controller](epic.md)
- Status: Planned
- Scope: Small
- Depends on: story-05
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Write PlayMode integration tests with InputTestFixture, verify real input → movement → rotation, then branch, PR, and merge.

## Acceptance Criteria

### AC-S06-01: PlayMode — accelerate input moves motorcycle
- **Given:** MotorcycleController in test scene with InputTestFixture
- **When:** Accelerate pressed (value=1) for 2 seconds
- **Then:** Motorcycle position changes (moves forward)
- **Testability:** PlayMode — `MotorcycleController_PlayMode_AccelerateMovesForward`

### AC-S06-02: PlayMode — steer input rotates motorcycle
- **Given:** MotorcycleController at speed (accelerate first)
- **When:** Steer set to +1
- **Then:** Motorcycle rotation changes
- **Testability:** PlayMode — `MotorcycleController_PlayMode_SteerRotates`

### AC-S06-03: All tests green
- **Given:** All stories complete
- **When:** Run All in Test Runner
- **Then:** Every test passes (EditMode + PlayMode)
- **Testability:** Run All in Test Runner

### AC-S06-04: Merged to main
- **Given:** All tests green, PR reviewed
- **When:** Branch `epic/02-controller` squash-merged to `main`
- **Then:** AC-01, AC-02, AC-03 demonstrable in editor
- **Testability:** Manual — verify merge on remote

## Test Strategy
- PlayMode tests using InputTestFixture for real input simulation.
- Ensure all prior EditMode tests still pass (no regressions).
- Linked Requirement: AC-01, AC-02, AC-03
- Linked Design Section: technical-design.md §Motorcycle Controller, §Testing

## Validation
- [ ] Test Runner: all green
- [ ] Manual: WASD moves and steers motorcycle in Play mode

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
