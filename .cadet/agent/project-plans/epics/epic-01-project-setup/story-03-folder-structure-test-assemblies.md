# Story 03: Create Folder Structure & Test Assemblies

## Document Control
- Story ID: epic-01-story-03
- Story Name: Create folder structure & test assemblies
- Parent Epic: [epic-01-project-setup](epic.md)
- Status: Planned
- Scope: Small
- Depends on: story-02
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Create the standard `_Project/` and `Tests/` folder layout, and set up EditMode and PlayMode test assemblies with a green placeholder test in each.

## Acceptance Criteria

### AC-S03-01: Project folder structure exists
- **Given:** The project is open
- **When:** The Project window is inspected
- **Then:** All required folders exist under `Assets/`:
  `_Project/Scenes/`, `_Project/Scripts/Core/`, `_Project/Scripts/UI/`, `_Project/Scripts/Interfaces/`, `_Project/Prefabs/`, `_Project/Sprites/`, `_Project/Splines/`, `_Project/Settings/`, `Tests/EditMode/`, `Tests/PlayMode/`
- **Testability:** Manual — verify in Project window

### AC-S03-02: EditMode test assembly compiles and passes
- **Given:** An `.asmdef` references the game scripts assembly
- **When:** A placeholder test `[Test] public void Placeholder_Passes() => Assert.IsTrue(true);` is created and run
- **Then:** The test is discovered, compiles, and passes green in Test Runner
- **Testability:** EditMode — run via Test Runner

### AC-S03-03: PlayMode test assembly compiles and passes
- **Given:** An `.asmdef` references game scripts + Unity Input System test helpers
- **When:** A placeholder `[UnityTest] public IEnumerator Placeholder_Passes() { yield return null; Assert.IsTrue(true); }` is created and run
- **Then:** The test is discovered, compiles, and passes green in Test Runner
- **Testability:** PlayMode — run via Test Runner

## Test Strategy
- **Red:** Create .asmdef files without tests — Test Runner shows empty assemblies.
- **Green:** Add placeholder tests — both pass.
- Linked Requirement: (Infrastructure)
- Linked Design Section: technical-design.md §Project Structure, §Test Infrastructure

## Validation
- [ ] All folders visible in Project window
- [ ] Both test assemblies have one green test each in Test Runner

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
