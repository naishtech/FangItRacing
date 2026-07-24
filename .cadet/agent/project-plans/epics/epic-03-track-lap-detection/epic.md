# Epic 03: Track & Lap Detection

## Backlinks
- Requirements document: [requirements.md](../../requirements.md)
- Technical design document: [technical-design.md](../../technical-design.md)
- Project plan document: [project-plan.md](../../project-plan.md)

## Document Control
- Epic ID: epic-03
- Epic Name: Track & Lap Detection
- Owner: Cadet-Agent
- Status: Planned
- Version: 0.1.0
- Last Updated: 2026-07-24

## Learner Context
- Relevant learner dimension: Unity Splines package, collider generation, trigger-based detection
- Assumed learner tier: Guided (Tier 1)
- Operating mode during execution: Implementation-first
- Handoff notes: Requires Epic 02 complete — MotorcycleController with acceleration, steering, drift

## Epic Outcome
- User or Business Value: Player races on a spline-defined track over a background image, with off-track slow zones and lap timing. The core racing loop becomes functional.
- Testable Slice Definition: Drive a lap — cross start/finish, see lap count increment, see lap time recorded, drive off track and feel speed reduce.
- Acceptance Criteria Coverage: AC-04 (Track Boundaries), AC-05 (Lap Detection), AC-06 (Lap Timing)

## Scope
- In Scope: Background image import, SplineContainer + SplineTrack collider generation, off-track speed penalty, start/finish trigger, LapData struct, LapManager (direction check, lap counting, timing, best lap), PlayMode tests.
- Out of Scope: Multiple tracks, track editor, visual track rendering beyond background image.
- Dependencies: Epic 02 (MotorcycleController), Unity Splines package (from Epic 01).
- Risks: EdgeCollider2D generation from spline may have edge cases with self-intersecting paths — mitigate by using simple oval layout.

## Story Checklist
| # | Story | Status |
|---|---|---|
| 1 | [Import background image & add to scene](story-01-import-background-image.md) | Planned |
| 2 | [Create spline track with collider generation](story-02-spline-track-collider.md) | Planned |
| 3 | [Implement off-track slow zone](story-03-offtrack-slow-zone.md) | Planned |
| 4 | [Create start/finish line trigger](story-04-start-finish-trigger.md) | Planned |
| 5 | [Create LapData & LapManager stub](story-05-lapdata-lapmanager-stub.md) | Planned |
| 6 | [Implement lap detection & timing](story-06-lap-detection-timing.md) | Planned |
| 7 | [PlayMode tests & merge](story-07-playmode-tests-merge.md) | Planned |

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Restructured from flat epic file to directory with EpicTemplate |
