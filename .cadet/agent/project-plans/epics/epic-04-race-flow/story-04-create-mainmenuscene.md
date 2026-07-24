# Story 04: Create MainMenuScene

## Document Control
- Story ID: epic-04-story-04
- Story Name: Create MainMenuScene
- Parent Epic: [epic-04-race-flow](epic.md)
- Status: Planned
- Scope: Medium
- Depends on: story-03
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Create the main menu scene with UI canvas: title, Start Race, Best Times, Quit buttons. Create MenuController for button handling.

## Acceptance Criteria

### AC-S04-01: MainMenuScene exists (AC-08)
- **Given:** Project open
- **When:** `Assets/_Project/Scenes/MainMenuScene.unity` created
- **Then:** Scene contains Canvas with: Title "Fang It Racing", Start Race button, Best Times button, Quit button
- **Testability:** Manual — open scene, inspect hierarchy

### AC-S04-02: MenuController handles clicks
- **Given:** `MenuController.cs` in `Scripts/UI/`
- **When:** Start Race clicked
- **Then:** Handler invoked
- **Testability:** PlayMode — `MenuScene_StartButton_HasHandler`

### AC-S04-03: Best Times panel exists
- **Given:** Menu scene
- **When:** Best Times clicked
- **Then:** Panel displays best time or "No time yet"
- **Testability:** PlayMode — `MenuScene_BestTimes_ShowsPanel`

## Test Strategy
- PlayMode tests: verify button presence, click handlers wired.
- Best Times panel shows placeholder text until Epic 05 persistence.
- Linked Requirement: AC-08
- Linked Design Section: technical-design.md §Main Menu

## Validation
- [ ] Menu scene loads, all buttons visible
- [ ] MenuController compiles, handlers wired

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
