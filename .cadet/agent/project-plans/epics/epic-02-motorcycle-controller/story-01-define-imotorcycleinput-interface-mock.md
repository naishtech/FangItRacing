# Story 01: Define IMotorcycleInput Interface & Mock

## Document Control
- Story ID: epic-02-story-01
- Story Name: Define IMotorcycleInput interface & mock
- Parent Epic: [epic-02-motorcycle-controller](epic.md)
- Status: Planned
- Scope: Small
- Depends on: Epic 01 complete
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Define the input abstraction interface and a mock implementation so MotorcycleController can be developed and tested in isolation (EditMode) without the Input System.

## Acceptance Criteria

### AC-S01-01: Interface compiles
- **Given:** The `Scripts/Interfaces/` folder exists
- **When:** `IMotorcycleInput.cs` is created with `float Accelerate { get; }` and `float Steer { get; }`
- **Then:** The interface compiles without errors
- **Testability:** EditMode — reference interface in test

### AC-S01-02: Mock implementation exists
- **Given:** The interface is defined
- **When:** A `MockMotorcycleInput` class implements `IMotorcycleInput` with settable properties
- **Then:** An EditMode test can create the mock, set values, and read them back
- **Testability:** EditMode — `MockMotorcycleInput_SetValues_ReturnsCorrectValues`

## Test Strategy
- **Red:** No interface — test referencing IMotorcycleInput fails to compile.
- **Green:** Interface + mock created — test passes.
- Linked Requirement: AC-01, AC-02, AC-03
- Linked Design Section: technical-design.md §Motorcycle Controller

## Validation
- [ ] `IMotorcycleInput` compiles
- [ ] EditMode test: `MockMotorcycleInput_SetValues_ReturnsCorrectValues` — green

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
