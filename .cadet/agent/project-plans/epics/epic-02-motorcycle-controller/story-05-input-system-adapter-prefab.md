# Story 05: Create Input System Adapter & Prefab

## Document Control
- Story ID: epic-02-story-05
- Story Name: Create Input System adapter & prefab
- Parent Epic: [epic-02-motorcycle-controller](epic.md)
- Status: Planned
- Scope: Small
- Depends on: story-04
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Create the real `InputSystemMotorcycleInput` adapter and build the Motorcycle prefab with all components wired up.

## Acceptance Criteria

### AC-S05-01: Input System adapter compiles
- **Given:** Input Actions C# class exists from Epic 01
- **When:** `InputSystemMotorcycleInput.cs` implements `IMotorcycleInput`, reading Accelerate and Steer from generated InputActions
- **Then:** Adapter compiles, properties return values from Input System
- **Testability:** EditMode — instantiate adapter, verify property types

### AC-S05-02: Motorcycle prefab created
- **Given:** All components exist
- **When:** GameObject created with SpriteRenderer (red rectangle 1×0.5), kinematic Rigidbody2D, MotorcycleController, InputSystemMotorcycleInput
- **Then:** Prefab saved to `Assets/_Project/Prefabs/Motorcycle.prefab`
- **Testability:** Manual — verify prefab in Project window

### AC-S05-03: Prefab instantiates cleanly
- **Given:** Prefab exists
- **When:** Dragged into test scene, Play mode entered
- **Then:** Motorcycle appears with red rectangle sprite, no console errors
- **Testability:** PlayMode — instantiate and verify no errors

## Test Strategy
- Manual verification of prefab + adapter wiring.
- PlayMode smoke test: instantiate, verify no null refs or errors.
- Linked Requirement: AC-01, AC-02, AC-03
- Linked Design Section: technical-design.md §Input System, §Motorcycle Prefab

## Validation
- [ ] Adapter compiles
- [ ] Prefab exists at correct path
- [ ] Play mode: motorcycle visible, no console errors

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
