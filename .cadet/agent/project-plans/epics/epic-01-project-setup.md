# Epic 01: Project Setup

**Status:** Not Started | **Depends on:** None | **Est. tasks:** 6

## Objective
Set up the Fang It Racing Unity project with correct packages, folder structure, and test infrastructure.

## Tasks

### T-01: Verify Unity project structure
- Confirm Unity 6 project opens correctly
- Verify 2D template settings are active
- **Validation:** Editor opens without errors

### T-02: Install required packages
- Install packages via Package Manager:
  - `com.unity.inputsystem` (Input System)
  - `com.unity.splines` (Splines — track path)
  - `com.unity.cinemachine` (Cinemachine)
  - `com.unity.test-framework` (UTF — should already be present)
- **Validation:** Packages appear in `Packages/manifest.json`, no console errors

### T-03: Create folder structure
```
Assets/
├── _Project/
│   ├── Scenes/
│   ├── Scripts/
│   │   ├── Core/
│   │   ├── UI/
│   │   └── Interfaces/
│   ├── Prefabs/
│   ├── Sprites/
│   ├── Splines/
│   └── Settings/
├── Tests/
│   ├── EditMode/
│   └── PlayMode/
```
- **Validation:** All folders exist in Project window

### T-04: Configure Input System
- Create Input Actions asset at `Assets/_Project/Settings/InputActions.inputactions`
- Define Action Map "Player": Accelerate (W/↑), Steer (A/←, D/→), Pause (Esc)
- Generate C# wrapper class
- **Validation:** InputActions asset opens in editor, C# class compiles

### T-05: Create test assemblies
- Create `Tests/EditMode/Tests.EditMode.asmdef` referencing game scripts
- Create `Tests/PlayMode/Tests.PlayMode.asmdef` referencing game scripts + Unity Input System test helpers
- Add a placeholder test in each that asserts `true`
- **Validation:** Both test assemblies compile and pass one green test each in Test Runner

### T-06: Bootstrap commit
- Commit all setup changes on branch `epic/01-project-setup`
- Push and create PR
- **Validation:** PR created, CI green (if configured), merge to `main`

## Acceptance Criteria Covered
- (Infrastructure — no gameplay ACs)

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.2.0 | 2026-07-23 | Cadet-Agent | Replaced SpriteShape with Splines package; added Splines/ folder, Settings/ folder |
| 0.1.0 | 2026-07-19 | Cadet-Agent | Initial |
