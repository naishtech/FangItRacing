# Story 03: Add Placeholder Sprites & Visual Polish

## Document Control
- Story ID: epic-06-story-03
- Story Name: Add placeholder sprites & visual polish
- Parent Epic: [epic-06-polish-build](epic.md)
- Status: Planned
- Scope: Small
- Depends on: Epic 05 complete
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Ensure all visual elements use clear, distinguishable placeholder sprites so the prototype looks intentional.

## Acceptance Criteria

### AC-S03-01: Motorcycle sprite distinct
- **Given:** Motorcycle prefab
- **When:** Uses colored rectangle sprite (red, 1×0.5)
- **Then:** Clearly visible and distinguishable from track
- **Testability:** Manual — inspect in Game view

### AC-S03-02: Track vs off-track visually distinct
- **Given:** Background image or placeholder surface
- **When:** Motorcycle on vs off track
- **Then:** Player can visually distinguish track from off-track
- **Testability:** Manual

### AC-S03-03: Start/finish line clearly visible
- **Given:** Start/finish GameObject
- **When:** Playing game
- **Then:** White line clearly visible across track
- **Testability:** Manual

### AC-S03-04: Countdown text visible
- **Given:** Race countdown active
- **When:** 3-2-1-GO displays
- **Then:** Numbers large and centered on screen
- **Testability:** Manual

## Test Strategy
- Manual visual verification only.
- Linked Requirement: (Polish — all ACs)
- Linked Design Section: technical-design.md §Visuals

## Validation
- [ ] All visual elements clearly distinguishable
- [ ] Placeholder art consistent (simple geometric shapes)

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
