# Story 02: Create MotorcycleController with Acceleration

## Document Control
- Story ID: epic-02-story-02
- Story Name: Create MotorcycleController with acceleration
- Parent Epic: [epic-02-motorcycle-controller](epic.md)
- Status: Planned
- Scope: Medium
- Depends on: story-01
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Create the `MotorcycleController` MonoBehaviour with acceleration logic: reads input, applies forward velocity, clamps to maxSpeed. An `IsControllable` flag gates input.

## Acceptance Criteria

### AC-S02-01: Controller stub exists with serialized fields
- **Given:** `IMotorcycleInput` is defined
- **When:** `MotorcycleController.cs` is created with fields: `maxSpeed`, `acceleration`, `turnRate`, `driftFactor`, `IMotorcycleInput`, `IsControllable`
- **Then:** The component compiles and can be attached to a GameObject
- **Testability:** EditMode — instantiate component in test

### AC-S02-02: Speed starts at zero
- **Given:** MotorcycleController with mock input (Accelerate=0)
- **When:** One frame elapses
- **Then:** Current speed is 0
- **Testability:** EditMode — `MotorcycleController_StartsAtZeroSpeed`

### AC-S02-03: Acceleration increases speed (AC-01)
- **Given:** MotorcycleController with `acceleration=10`, `maxSpeed=50`, Accelerate=1
- **When:** `Update()` runs for 2 seconds
- **Then:** Speed > 0 and increases each frame, up to `maxSpeed=50`
- **Testability:** EditMode — `MotorcycleController_Accelerate_IncreasesSpeed`

### AC-S02-04: Speed clamps at maxSpeed (AC-01)
- **Given:** MotorcycleController with `maxSpeed=50`, Accelerate=1
- **When:** `Update()` runs long enough to exceed max
- **Then:** Speed never exceeds `maxSpeed`
- **Testability:** EditMode — `MotorcycleController_Accelerate_ClampsAtMaxSpeed`

### AC-S02-05: IsControllable gates input
- **Given:** `IsControllable=false`, Accelerate=1
- **When:** `Update()` runs
- **Then:** Current speed remains 0
- **Testability:** EditMode — `MotorcycleController_NotControllable_IgnoresInput`

## Test Strategy
- **Red:** Create MotorcycleController stub — acceleration test fails (speed stays 0).
- **Green:** Implement acceleration in Update() — all tests pass.
- Linked Requirement: AC-01
- Linked Design Section: technical-design.md §Motorcycle Controller

## Validation
- [ ] All EditMode tests green
- [ ] Motorcycle accelerates forward when controllable

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
