# Story 04: Add Drift Feel

## Document Control
- Story ID: epic-02-story-04
- Story Name: Add drift feel
- Parent Epic: [epic-02-motorcycle-controller](epic.md)
- Status: Planned
- Scope: Small
- Depends on: story-03
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Add arcade drift: preserve a fraction of lateral velocity after rotation so the motorcycle slides. Controlled by `driftFactor` (0 = no drift, 1 = full slide).

## Acceptance Criteria

### AC-S04-01: Lateral velocity persists after rotation (AC-03)
- **Given:** MotorcycleController moving forward, then steering
- **When:** Rotation is applied in Update()
- **Then:** Velocity vector has non-zero lateral component (motorcycle slides)
- **Testability:** EditMode — `MotorcycleController_Drift_LateralVelocityPersists`

### AC-S04-02: driftFactor=0 eliminates drift (AC-03)
- **Given:** `driftFactor=0`
- **When:** Steering while moving
- **Then:** Lateral velocity is zero after each frame
- **Testability:** EditMode — `MotorcycleController_Drift_ZeroFactorNoSlide`

### AC-S04-03: Higher driftFactor increases slide (AC-03)
- **Given:** driftFactor=0.3 vs 0.8
- **When:** Same steer at same speed
- **Then:** Lateral velocity is higher with 0.8
- **Testability:** EditMode — `MotorcycleController_Drift_HigherFactorMoreSlide`

### AC-S04-04: Forward speed preserved during drift (AC-03)
- **Given:** MotorcycleController drifting (driftFactor > 0)
- **When:** Steering is applied
- **Then:** Total speed magnitude does not decrease due to drift alone
- **Testability:** EditMode — `MotorcycleController_Drift_ForwardSpeedPreserved`

## Test Strategy
- **Red:** Write drift tests — all fail (no drift code).
- **Green:** Add drift calculation in Update() after rotation — all pass.
- Linked Requirement: AC-03
- Linked Design Section: technical-design.md §Motorcycle Controller

## Validation
- [ ] All EditMode tests green
- [ ] Drift feel is tunable via serialized field

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
