# Epic 02: Motorcycle Controller

**Status:** Not Started | **Depends on:** Epic 01 | **Est. tasks:** 10

## Objective
Implement arcade motorcycle movement: acceleration, speed-sensitive steering, and drift feel. Covers AC-01, AC-02, AC-03.

## Tasks

### T-01: Create IMotorcycleInput interface
- Define `IMotorcycleInput` with `float Accelerate { get; }` and `float Steer { get; }`
- Create mock implementation for testing
- **Validation:** EditMode test passes with mock

### T-02: Create MotorcycleController stub
- Create `MotorcycleController.cs` in `Scripts/Core/`
- Serialized fields: `maxSpeed`, `acceleration`, `turnRate`, `driftFactor`
- Inject `IMotorcycleInput`
- **Test (Red):** `MotorcycleController_Accelerate_IncreasesSpeed` — starts at 0, fails

### T-03: Implement acceleration (AC-01)
- `Update()`: read `IMotorcycleInput.Accelerate`, apply forward velocity: `velocity += forward * input * acceleration * dt`
- Clamp to `maxSpeed`
- `IsControllable` flag gates input
- **Test (Green):** Speed increases with accelerate input, clamps at maxSpeed

### T-04: Create InputSystemMotorcycleInput adapter
- Implement `IMotorcycleInput` using Input System generated C# class
- Read Accelerate and Steer actions
- Attach to MotorcycleController prefab
- **Validation:** PlayMode test — pressing W moves the motorcycle

### T-05: Implement steering (AC-02)
- `Update()`: read `IMotorcycleInput.Steer`, rotate transform: `turnAmount = steer * turnRate * (speed/maxSpeed) * dt`
- Motorcycle rotates in steer direction, faster at higher speeds
- **Test (Green):** Rotation changes with steer input, turn rate scales with speed

### T-06: Implement drift (AC-03)
- After rotation, preserve fraction of lateral velocity using `driftFactor`
- Drift calculation: `velocity = forward * forwardSpeed + right * lateralSpeed * driftFactor`
- **Test (Green):** Lateral velocity persists after rotation, stronger at higher driftFactor

### T-07: Create MotorcycleController prefab
- Create GameObject with SpriteRenderer (colored rectangle, e.g., red 1×0.5), kinematic Rigidbody2D, MotorcycleController
- Save as prefab at `Assets/_Project/Prefabs/Motorcycle.prefab`
- **Validation:** Prefab exists, instantiates correctly in scene

### T-08: Write comprehensive EditMode tests
- Test acceleration at zero, mid, and max speed
- Test steering at zero speed (no rotation), mid, max
- Test drift factor at 0 (no drift), 0.5, 1.0 (full drift)
- **Validation:** All EditMode tests green

### T-09: Write PlayMode integration test
- Instantiate MotorcycleController in test scene with InputTestFixture
- Simulate accelerate input → verify position changes
- Simulate steer input → verify rotation changes
- **Validation:** PlayMode test green

### T-10: Merge Epic 02
- All tests green, PR reviewed, squash merge to `main`
- **Validation:** AC-01, AC-02, AC-03 demonstrable in editor

## Acceptance Criteria Covered
| AC | Status |
|---|---|
| AC-01: Acceleration | ✅ |
| AC-02: Steering | ✅ |
| AC-03: Drift | ✅ |

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-19 | Cadet-Agent | Initial |
