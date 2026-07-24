# Story 03: Implement Off-Track Slow Zone

## Document Control
- Story ID: epic-03-story-03
- Story Name: Implement off-track slow zone
- Parent Epic: [epic-03-track-lap-detection](epic.md)
- Status: Planned
- Scope: Small
- Depends on: story-02
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Add `offTrackMultiplier` to MotorcycleController and wire it so speed reduces to ~30% off track, then restores when back on.

## Acceptance Criteria

### AC-S03-01: Off-track reduces speed (AC-04)
- **Given:** MotorcycleController with `offTrackMultiplier=0.3`, SplineTrack reference
- **When:** `SplineTrack.IsOnTrack(position)` returns `false`
- **Then:** Speed multiplied by `offTrackMultiplier`
- **Testability:** EditMode — `MotorcycleController_OffTrack_ReducesSpeed`

### AC-S03-02: Speed restores on track (AC-04)
- **Given:** Motorcycle off-track with reduced speed
- **When:** Moves back onto track
- **Then:** Speed returns to normal (no multiplier)
- **Testability:** EditMode — `MotorcycleController_ReturnsToTrack_RestoresSpeed`

## Test Strategy
- **Red:** Test with mock SplineTrack returning off-track — speed unchanged (no logic).
- **Green:** Add off-track check in MotorcycleController.Update() — tests pass.
- Linked Requirement: AC-04
- Linked Design Section: technical-design.md §Track Boundaries

## Validation
- [ ] EditMode test green
- [ ] Manual: drive off track, speed drops; back on, speed restores

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
