# Story 02: Tune Arcade Controller Feel

## Document Control
- Story ID: epic-06-story-02
- Story Name: Tune arcade controller feel
- Parent Epic: [epic-06-polish-build](epic.md)
- Status: Planned
- Scope: Small
- Depends on: story-01
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Adjust MotorcycleController serialized fields to achieve satisfying arcade racing feel with keyboard input.

## Acceptance Criteria

### AC-S02-01: Speed feels fast but controllable
- **Given:** Default field values
- **When:** Values iterated in Play mode
- **Then:** Motorcycle reaches satisfying top speed without feeling uncontrollable
- **Testability:** Manual — subjective feel check

### AC-S02-02: Acceleration ramp-up is responsive
- **Given:** Motorcycle at standstill
- **When:** Accelerate pressed
- **Then:** Reaches full speed in satisfying timeframe (not instant, not sluggish)
- **Testability:** Manual

### AC-S02-03: Steering responsive but not twitchy
- **Given:** Motorcycle at speed
- **When:** Steer applied
- **Then:** Turns feel responsive without snapping
- **Testability:** Manual

### AC-S02-04: Drift visible but controllable
- **Given:** Motorcycle turning at speed
- **When:** Steer held
- **Then:** Visible lateral slide, motorcycle remains controllable
- **Testability:** Manual

## Test Strategy
- Manual iteration in Play mode — tune, test, repeat.
- Document final tuned values in story completion notes.
- Linked Requirement: AC-01, AC-02, AC-03 (indirectly — polish pass)
- Linked Design Section: technical-design.md §Motorcycle Controller

## Validation
- [ ] Movement feels fun and responsive with keyboard
- [ ] Tuned values documented

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
