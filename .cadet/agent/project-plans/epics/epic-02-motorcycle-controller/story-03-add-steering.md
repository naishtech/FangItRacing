# Story 03: Add Steering

## Document Control
- Story ID: epic-02-story-03
- Story Name: Add steering
- Parent Epic: [epic-02-motorcycle-controller](epic.md)
- Status: Planned
- Scope: Small
- Depends on: story-02
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Add steering: read `IMotorcycleInput.Steer` and rotate the transform. Turn rate scales with speed.

## Acceptance Criteria

### AC-S03-01: No rotation at zero speed (AC-02)
- **Given:** MotorcycleController with speed=0, Steer=1
- **When:** `Update()` runs
- **Then:** Rotation does not change
- **Testability:** EditMode — `MotorcycleController_Steer_NoRotationAtZeroSpeed`

### AC-S03-02: Rotation at speed (AC-02)
- **Given:** MotorcycleController at speed > 0, Steer=1 (right)
- **When:** `Update()` runs
- **Then:** Transform rotates clockwise (negative Z in 2D)
- **Testability:** EditMode — `MotorcycleController_Steer_RotatesAtSpeed`

### AC-S03-03: Turn rate scales with speed (AC-02)
- **Given:** Same steer input at low vs high speed
- **When:** `Update()` runs for same duration
- **Then:** Rotation is greater at higher speed (proportional to `speed/maxSpeed`)
- **Testability:** EditMode — `MotorcycleController_Steer_TurnRateScalesWithSpeed`

### AC-S03-04: Steer direction respected
- **Given:** MotorcycleController at speed > 0
- **When:** Steer = +1 vs Steer = -1
- **Then:** Rotation direction matches steer sign
- **Testability:** EditMode — `MotorcycleController_Steer_DirectionRespected`

## Test Strategy
- **Red:** Write steering tests against existing MotorcycleController — all fail (no steering code).
- **Green:** Add steering in Update() — all pass.
- Linked Requirement: AC-02
- Linked Design Section: technical-design.md §Motorcycle Controller

## Validation
- [ ] All EditMode tests green
- [ ] Motorcycle rotates left/right proportionally to steer input and speed

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
