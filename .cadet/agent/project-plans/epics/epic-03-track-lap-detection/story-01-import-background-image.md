# Story 01: Import Background Image & Add to Scene

## Document Control
- Story ID: epic-03-story-01
- Story Name: Import background image & add to scene
- Parent Epic: [epic-03-track-lap-detection](epic.md)
- Status: Planned
- Scope: Small
- Depends on: Epic 02 complete
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Import the user-provided track background image and place it in the race scene as the visual layer behind all other objects.

## Acceptance Criteria

### AC-S01-01: Background image imported correctly
- **Given:** User provides a track background image
- **When:** Image is imported into `Assets/_Project/Sprites/` with Texture Type: Sprite (2D and UI)
- **Then:** Sprite appears in Project window with correct import settings
- **Testability:** Manual — inspect import settings

### AC-S01-02: Background visible in scene
- **Given:** Sprite is imported
- **When:** SpriteRenderer GameObject added to race scene with background sprite, lowest sorting order
- **Then:** Background fills camera view in Scene and Game views
- **Testability:** Manual — enter Play mode, verify background visible

## Test Strategy
- Manual verification only — asset import and scene setup.
- Linked Requirement: AC-04
- Linked Design Section: technical-design.md §Track & Background

## Validation
- [ ] Background image visible in Game view
- [ ] No other objects obscured (correct sorting layer/order)

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
