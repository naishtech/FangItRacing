# Story 02: Install Required Packages

## Document Control
- Story ID: epic-01-story-02
- Story Name: Install required packages
- Parent Epic: [epic-01-project-setup](epic.md)
- Status: Planned
- Scope: Small
- Depends on: story-01
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Install all packages needed for the prototype: Input System, Splines, Cinemachine, and confirm Unity Test Framework is present.

## Acceptance Criteria

### AC-S02-01: Input System package installed
- **Given:** The project is open
- **When:** `Packages/manifest.json` is inspected
- **Then:** `"com.unity.inputsystem":` is present with a valid version, and no console errors appear after recompilation
- **Testability:** Manual — inspect manifest.json, check Console

### AC-S02-02: Splines package installed
- **Given:** The project is open
- **When:** `Packages/manifest.json` is inspected
- **Then:** `"com.unity.splines":` is present (≥2.8.0), Splines menu appears under GameObject
- **Testability:** Manual — inspect manifest.json, check GameObject menu

### AC-S02-03: Cinemachine package installed
- **Given:** The project is open
- **When:** `Packages/manifest.json` is inspected
- **Then:** `"com.unity.cinemachine":` is present, Cinemachine components available in Add Component menu
- **Testability:** Manual — inspect manifest.json, check Add Component menu

### AC-S02-04: Test Framework confirmed
- **Given:** The project is open
- **When:** `Packages/manifest.json` is inspected
- **Then:** `"com.unity.test-framework":` is present, Test Runner shows no errors
- **Testability:** Manual — inspect manifest.json, check Test Runner

## Test Strategy
- Manual verification against manifest.json and editor menus.
- No automated tests — this is package installation, not logic.
- Linked Requirement: (Infrastructure)
- Linked Design Section: technical-design.md §Package Dependencies

## Validation
- [ ] All four packages appear in `Packages/manifest.json`
- [ ] Editor compiles without errors after all packages resolve

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
