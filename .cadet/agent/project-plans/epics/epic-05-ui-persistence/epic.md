# Epic 05: UI & Persistence

## Backlinks
- Requirements document: [requirements.md](../../requirements.md)
- Technical design document: [technical-design.md](../../technical-design.md)
- Project plan document: [project-plan.md](../../project-plan.md)

## Document Control
- Epic ID: epic-05
- Epic Name: UI & Persistence
- Owner: Cadet-Agent
- Status: Planned
- Version: 0.1.0
- Last Updated: 2026-07-24

## Learner Context
- Relevant learner dimension: Unity UI (Canvas, TextMeshPro), PlayerPrefs, repository pattern
- Assumed learner tier: Guided (Tier 1)
- Operating mode during execution: Implementation-first
- Handoff notes: Requires Epic 04 complete — RaceManager with state machine and menu scenes

## Epic Outcome
- User or Business Value: Player sees live HUD during races (lap count, time, best, speed) and best times survive app restart. The game feels complete.
- Testable Slice Definition: Race shows all HUD elements updating in real time. Complete a lap, quit to menu, Best Times shows saved time. Restart app — time still there.
- Acceptance Criteria Coverage: AC-07 (Best Time Persistence), AC-10 (HUD Display)

## Scope
- In Scope: IBestTimeRepository interface, PlayerPrefsBestTimeRepository, RaceManager persistence integration, HUD Canvas with TextMeshPro elements, HUDController live updates, TimeFormatter utility, PlayMode integration tests.
- Out of Scope: Multiple save slots, cloud save, settings menu, audio.
- Dependencies: Epic 04 (RaceManager, MenuController, scene flow).
- Risks: PlayerPrefs reliability in WebGL — mitigate by testing early in browser build (Epic 06).

## Story Checklist
| # | Story | Status |
|---|---|---|
| 1 | [Create IBestTimeRepository & PlayerPrefs implementation](story-01-ibesttimerepository-playerprefs.md) | Planned |
| 2 | [Integrate persistence with RaceManager](story-02-persistence-racemanger-integration.md) | Planned |
| 3 | [Create HUD Canvas layout](story-03-hud-canvas-layout.md) | Planned |
| 4 | [Create HUDController with live updates](story-04-hudcontroller-live-updates.md) | Planned |
| 5 | [TimeFormatter, PlayMode tests & merge](story-05-timeformatter-tests-merge.md) | Planned |

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Restructured from flat epic file to directory with EpicTemplate |
