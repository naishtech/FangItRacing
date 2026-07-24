# Story 05: Implement Scene Transitions & Merge

## Document Control
- Story ID: epic-04-story-05
- Story Name: Implement scene transitions & merge
- Parent Epic: [epic-04-race-flow](epic.md)
- Status: Planned
- Scope: Small
- Depends on: story-04
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Wire button handlers to scene loading and quit. Add both scenes to Build Settings. Write PlayMode tests, branch, PR, merge.

## Acceptance Criteria

### AC-S05-01: Start Race loads RaceScene (AC-08)
- **Given:** MainMenuScene active
- **When:** Start Race clicked
- **Then:** `SceneManager.LoadScene("RaceScene")` called, RaceScene loads
- **Testability:** PlayMode — `MenuScene_StartButton_LoadsRaceScene`

### AC-S05-02: Quit exits application (AC-08)
- **Given:** MainMenuScene active
- **When:** Quit clicked
- **Then:** `Application.Quit()` called
- **Testability:** EditMode — verify method call (mock Application)

### AC-S05-03: Both scenes in Build Settings
- **Given:** File → Build Settings
- **When:** Scene list inspected
- **Then:** MainMenuScene (index 0) and RaceScene (index 1) present
- **Testability:** Manual — inspect Build Settings

### AC-S05-04: All tests green & merged
- **Given:** All tests pass
- **When:** Branch `epic/04-race-flow` squash-merged to `main`
- **Then:** Full menu → countdown → racing flow works
- **Testability:** Manual — end-to-end test

## Test Strategy
- PlayMode test: load menu, click Start Race, verify scene loaded.
- All prior epic tests must remain green.
- Linked Requirement: AC-08, AC-09
- Linked Design Section: technical-design.md §Scene Management

## Validation
- [ ] Test Runner: all green
- [ ] Manual: menu → countdown → racing loop works end to end

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
