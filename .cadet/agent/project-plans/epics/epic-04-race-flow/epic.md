# Epic 04: Race Flow

## Backlinks
- Requirements document: [requirements.md](../../requirements.md)
- Technical design document: [technical-design.md](../../technical-design.md)
- Project plan document: [project-plan.md](../../project-plan.md)

## Document Control
- Epic ID: epic-04
- Epic Name: Race Flow
- Owner: Cadet-Agent
- Status: Planned
- Version: 0.1.0
- Last Updated: 2026-07-24

## Learner Context
- Relevant learner dimension: Unity state machines, coroutines, scene management
- Assumed learner tier: Guided (Tier 1)
- Operating mode during execution: Implementation-first
- Handoff notes: Requires Epic 03 complete — track with lap detection functional

## Epic Outcome
- User or Business Value: Player experiences a complete race flow: menu → countdown → racing → can quit. The game has a beginning, middle, and end.
- Testable Slice Definition: Click Start Race → see countdown → motorcycle becomes controllable → timer runs. Main menu loads with all buttons.
- Acceptance Criteria Coverage: AC-08 (Main Menu), AC-09 (Race Countdown)

## Scope
- In Scope: RaceState enum, RaceManager (state machine, countdown coroutine, race timer, LapManager wiring), MainMenuScene with UI canvas, MenuController, scene transitions, Build Settings configuration.
- Out of Scope: HUD display, best time persistence, audio, settings menu.
- Dependencies: Epic 03 (LapManager, MotorcycleController).
- Risks: Scene loading timing in tests — mitigate by using LoadSceneMode.Single and waiting for scene loaded event.

## Story Checklist
| # | Story | Status |
|---|---|---|
| 1 | [Create RaceState & RaceManager stub](story-01-racestate-racemanger-stub.md) | Planned |
| 2 | [Implement countdown](story-02-implement-countdown.md) | Planned |
| 3 | [Implement race timer & LapManager wiring](story-03-race-timer-lapmanager-wiring.md) | Planned |
| 4 | [Create MainMenuScene](story-04-create-mainmenuscene.md) | Planned |
| 5 | [Implement scene transitions & merge](story-05-scene-transitions-merge.md) | Planned |

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Restructured from flat epic file to directory with EpicTemplate |
