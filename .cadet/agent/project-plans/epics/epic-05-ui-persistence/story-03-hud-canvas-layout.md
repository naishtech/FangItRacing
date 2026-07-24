# Story 03: Create HUD Canvas Layout

## Document Control
- Story ID: epic-05-story-03
- Story Name: Create HUD Canvas layout
- Parent Epic: [epic-05-ui-persistence](epic.md)
- Status: Planned
- Scope: Small
- Depends on: Epic 04 complete
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Add a Screen Space - Overlay Canvas to RaceScene with anchored TextMeshPro elements for lap count, lap time, best time, and speed.

## Acceptance Criteria

### AC-S03-01: HUD Canvas exists
- **Given:** RaceScene open
- **When:** Canvas (Screen Space - Overlay) added
- **Then:** Canvas visible, covers screen
- **Testability:** Manual — inspect Game view

### AC-S03-02: Text elements positioned correctly
- **Given:** Canvas exists
- **When:** TMP Text elements added:
  - Top-left: "Lap: N"
  - Top-center: "Time: 0:00.00"
  - Top-right: "Best: 0:00.00"
  - Bottom-center: "Speed: 0"
- **Then:** All four visible, anchored to correct corners
- **Testability:** Manual — inspect Game view at different resolutions

## Test Strategy
- Manual verification of canvas layout and anchoring.
- No automated tests — this is UI setup, not logic.
- Linked Requirement: AC-10
- Linked Design Section: technical-design.md §HUD

## Validation
- [ ] All four HUD elements visible in correct positions
- [ ] Elements scale with resolution changes

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
