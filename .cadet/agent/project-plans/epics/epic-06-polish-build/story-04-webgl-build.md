# Story 04: Configure & Create WebGL Build

## Document Control
- Story ID: epic-06-story-04
- Story Name: Configure & create WebGL build
- Parent Epic: [epic-06-polish-build](epic.md)
- Status: Planned
- Scope: Medium
- Depends on: story-02, story-03
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Configure WebGL build settings, create a build, and verify it loads and accepts input in a browser.

## Acceptance Criteria

### AC-S04-01: WebGL settings configured (AC-11)
- **Given:** Build Settings → WebGL
- **When:** Player Settings: Resolution 960×600, Compression Gzip, Code Optimization Size, Memory 256MB
- **Then:** Settings persist after save
- **Testability:** Manual — inspect Player Settings

### AC-S04-02: WebGL build succeeds (AC-11)
- **Given:** Build settings configured
- **When:** Build to `Builds/WebGL/`
- **Then:** Build completes without errors
- **Testability:** Manual — check Console for build errors

### AC-S04-03: Game loads in browser (AC-11)
- **Given:** WebGL build output exists
- **When:** Local HTTP server serves build folder, browser navigates to it
- **Then:** Game loads, main menu appears
- **Testability:** Manual — load in browser

### AC-S04-04: Keyboard input works (AC-11)
- **Given:** Game loaded in browser
- **When:** WASD/arrows pressed during race
- **Then:** Motorcycle responds to input
- **Testability:** Manual — test in browser

## Test Strategy
- Manual build + browser verification.
- No automated tests for build pipeline.
- Linked Requirement: AC-11
- Linked Design Section: technical-design.md §WebGL Build

## Validation
- [ ] Build completes without errors
- [ ] Game loads in browser, all scenes accessible
- [ ] Keyboard input functional in browser

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
