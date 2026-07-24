# Story 04: Configure Input System

## Document Control
- Story ID: epic-01-story-04
- Story Name: Configure Input System
- Parent Epic: [epic-01-project-setup](epic.md)
- Status: Planned
- Scope: Small
- Depends on: story-03
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Create the Input Actions asset with the Player action map (Accelerate, Steer, Pause) and generate the C# wrapper class.

## Acceptance Criteria

### AC-S04-01: Input Actions asset created
- **Given:** The Input System package is installed
- **When:** An Input Actions asset is created at `Assets/_Project/Settings/InputActions.inputactions`
- **Then:** The asset opens in the Input Actions editor, showing an Action Map named "Player"
- **Testability:** Manual — open asset in editor

### AC-S04-02: Player actions defined
- **Given:** The Input Actions asset is open
- **When:** The "Player" action map is inspected
- **Then:** It contains three actions:
  - `Accelerate` (Value, binding: W and ↑)
  - `Steer` (Value, binding: A/← for negative, D/→ for positive)
  - `Pause` (Button, binding: Esc)
- **Testability:** Manual — inspect bindings in Input Actions editor

### AC-S04-03: C# wrapper compiles
- **Given:** The Input Actions asset has "Generate C# Class" enabled
- **When:** The asset is saved and Unity recompiles
- **Then:** The generated C# class compiles without errors
- **Testability:** EditMode — attempt to reference generated class in a test

## Test Strategy
- **Red:** Create Input Actions asset without saving/generating — no C# class exists.
- **Green:** Enable C# generation, save — class compiles, test referencing it passes.
- Linked Requirement: (Infrastructure)
- Linked Design Section: technical-design.md §Input System

## Validation
- [ ] InputActions asset opens in editor with correct bindings
- [ ] Generated C# class is usable in scripts (no compile errors)

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
