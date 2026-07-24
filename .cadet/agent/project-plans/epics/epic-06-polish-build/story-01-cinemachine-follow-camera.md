# Story 01: Set Up Cinemachine Follow Camera

## Document Control
- Story ID: epic-06-story-01
- Story Name: Set up Cinemachine follow camera
- Parent Epic: [epic-06-polish-build](epic.md)
- Status: Planned
- Scope: Small
- Depends on: Epic 05 complete
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Add Cinemachine Brain to Main Camera with a Virtual Camera that smoothly follows the motorcycle and shows the full track.

## Acceptance Criteria

### AC-S01-01: Cinemachine Brain on Main Camera
- **Given:** Cinemachine package installed
- **When:** Cinemachine Brain added to Main Camera
- **Then:** Brain component present and configured
- **Testability:** Manual — inspect Main Camera in Inspector

### AC-S01-02: Virtual Camera follows motorcycle
- **Given:** Virtual Camera created
- **When:** Follow target = Motorcycle, Framing Transposer body (soft damping X/Y, small dead zone)
- **Then:** Camera smoothly follows motorcycle in Play mode, no jitter
- **Testability:** Manual — enter Play mode, observe camera

### AC-S01-03: Full track visible
- **Given:** Virtual Camera configured
- **When:** Play mode entered
- **Then:** Full track + surrounding off-track area visible
- **Testability:** Manual — verify Game view shows entire track

## Test Strategy
- Manual visual verification only — camera feel is subjective.
- Linked Requirement: AC-11 (indirectly — polish)
- Linked Design Section: technical-design.md §Camera

## Validation
- [ ] Camera follows motorcycle smoothly
- [ ] Full track visible at all times during a lap

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
