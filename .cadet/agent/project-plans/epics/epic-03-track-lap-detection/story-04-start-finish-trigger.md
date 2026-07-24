# Story 04: Create Start/Finish Line Trigger

## Document Control
- Story ID: epic-03-story-04
- Story Name: Create start/finish line trigger
- Parent Epic: [epic-03-track-lap-detection](epic.md)
- Status: Planned
- Scope: Small
- Depends on: story-03
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Add a start/finish line GameObject with visible line sprite and trigger collider spanning the track width.

## Acceptance Criteria

### AC-S04-01: Start/finish line visible and configured
- **Given:** Race scene exists
- **When:** GameObject with SpriteRenderer (white line) + BoxCollider2D (isTrigger) added across spline track
- **Then:** White line spans track, trigger collider covers track width
- **Testability:** Manual — inspect Scene view

### AC-S04-02: Tagged correctly
- **Given:** Start/finish GameObject exists
- **When:** Tag inspected
- **Then:** Tag = "StartFinish"
- **Testability:** Manual — inspect Inspector

### AC-S04-03: Trigger fires correctly
- **Given:** Test scene with trigger and moving object
- **When:** Object enters trigger
- **Then:** `OnTriggerEnter2D` fires with correct Collider2D
- **Testability:** PlayMode — `StartFinish_Trigger_FiresOnEnter`

## Test Strategy
- PlayMode test: move object into trigger, verify OnTriggerEnter2D callback.
- Linked Requirement: AC-05
- Linked Design Section: technical-design.md §Lap Detection

## Validation
- [ ] Trigger visible in Scene view
- [ ] PlayMode test: trigger detects object entering

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
