# Story 05: Performance Check, Final Validation & Merge

## Document Control
- Story ID: epic-06-story-05
- Story Name: Performance check, final validation & merge
- Parent Epic: [epic-06-polish-build](epic.md)
- Status: Planned
- Scope: Small
- Depends on: story-04
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Verify WebGL performance (≥30 FPS), run all tests green, update README, tag release, and merge.

## Acceptance Criteria

### AC-S05-01: FPS ≥ 30 in browser (AC-11)
- **Given:** Game running in browser with dev tools
- **When:** Full race played (multiple laps)
- **Then:** FPS stays ≥ 30 throughout
- **Testability:** Manual — browser Performance tab

### AC-S05-02: Memory stable across laps
- **Given:** Game running in browser
- **When:** Multiple laps completed
- **Then:** Memory usage stable (no leaks)
- **Testability:** Manual — browser Memory tab

### AC-S05-03: All 11 ACs verified
- **Given:** Full prototype
- **When:** Each AC from requirements verified
- **Then:** AC-01 through AC-11 all pass
- **Testability:** Manual — checklist verification

### AC-S05-04: README updated
- **Given:** Project
- **When:** README.md inspected
- **Then:** Contains build/run instructions for PC standalone + WebGL
- **Testability:** Manual — read README

### AC-S05-05: Release tagged & merged
- **Given:** All tests green, ACs verified, README updated
- **When:** Branch `epic/06-polish-build` squash-merged to `main`, tag `v0.1.0-prototype` created
- **Then:** Prototype complete and tagged
- **Testability:** Manual — `git tag`, verify on remote

## Test Strategy
- Manual performance profiling in browser.
- Full AC re-verification checklist.
- Final Test Runner: Run All — all tests from all epics must be green.
- Linked Requirement: AC-11 (and all prior ACs)
- Linked Design Section: technical-design.md §Performance, §Release

## Validation
- [ ] Test Runner: all green across all epics
- [ ] Browser: full game loop works, FPS ≥ 30
- [ ] README has clear build/run instructions
- [ ] Git tag `v0.1.0-prototype` on `main`

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
