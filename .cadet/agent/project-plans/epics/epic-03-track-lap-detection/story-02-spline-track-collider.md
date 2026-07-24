# Story 02: Create Spline Track with Collider Generation

## Document Control
- Story ID: epic-03-story-02
- Story Name: Create spline track with collider generation
- Parent Epic: [epic-03-track-lap-detection](epic.md)
- Status: Planned
- Scope: Medium
- Depends on: story-01
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Add a Unity Splines `SplineContainer` to the scene, draw a closed-loop spline tracing the track path, and create a `SplineTrack` component that generates an `EdgeCollider2D` from spline knots.

## Acceptance Criteria

### AC-S02-01: Spline container exists with closed loop
- **Given:** Splines package installed
- **When:** SplineContainer added, closed-loop spline drawn tracing background image's track path
- **Then:** Spline visible in Scene view as closed curve
- **Testability:** Manual — inspect Scene view

### AC-S02-02: SplineTrack generates EdgeCollider2D
- **Given:** `SplineTrack.cs` in `Scripts/Core/`
- **When:** Component reads spline knot positions, calls `EdgeCollider2D.SetPoints()`
- **Then:** EdgeCollider2D appears in Scene view matching spline shape
- **Testability:** EditMode — `SplineTrack_GeneratesCollider_FromSpline`

### AC-S02-03: IsOnTrack method works
- **Given:** EdgeCollider2D generated
- **When:** `SplineTrack.IsOnTrack(Vector2)` called for point inside vs outside collider
- **Then:** Returns `true` on/near spline, `false` far away
- **Testability:** EditMode — `SplineTrack_IsOnTrack_ReturnsCorrectly`

## Test Strategy
- **Red:** Create SplineTrack stub — collider test fails.
- **Green:** Implement SetPoints from spline — tests pass.
- Linked Requirement: AC-04
- Linked Design Section: technical-design.md §Spline Track

## Validation
- [ ] Spline visible, collider matches shape in Scene view
- [ ] `IsOnTrack()` returns correct values in EditMode test

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
