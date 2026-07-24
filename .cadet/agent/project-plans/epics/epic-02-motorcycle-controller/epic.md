# Epic 02: Motorcycle Controller

## Backlinks
- Requirements document: [requirements.md](../../requirements.md)
- Technical design document: [technical-design.md](../../technical-design.md)
- Project plan document: [project-plan.md](../../project-plan.md)

## Document Control
- Epic ID: epic-02
- Epic Name: Motorcycle Controller
- Owner: Cadet-Agent
- Status: Planned
- Version: 0.1.0
- Last Updated: 2026-07-24

## Learner Context
- Relevant learner dimension: Unity MonoBehaviour lifecycle, interfaces, arcade physics math
- Assumed learner tier: Guided (Tier 1)
- Operating mode during execution: Implementation-first
- Handoff notes: Requires Epic 01 complete — Input System configured, test assemblies green

## Epic Outcome
- User or Business Value: Player can control a motorcycle with WASD/arrows — accelerate, steer, and feel arcade drift. This is the core gameplay feel.
- Testable Slice Definition: EditMode tests verify acceleration, steering, drift math; PlayMode test verifies input→movement→rotation.
- Acceptance Criteria Coverage: AC-01 (Acceleration), AC-02 (Steering), AC-03 (Drift)

## Scope
- In Scope: IMotorcycleInput interface, mock implementation, MotorcycleController MonoBehaviour (acceleration, steering, drift), InputSystemMotorcycleInput adapter, Motorcycle prefab, EditMode + PlayMode tests.
- Out of Scope: Track interaction, lap detection, HUD, race state machine, visual polish beyond placeholder sprite.
- Dependencies: Epic 01 (Input System, test assemblies, folder structure).
- Risks: Drift math may feel wrong in practice — mitigate by making driftFactor tunable and testing early with keyboard.

## Story Checklist
| # | Story | Status |
|---|---|---|
| 1 | [Define IMotorcycleInput interface & mock](story-01-define-imotorcycleinput-interface-mock.md) | Planned |
| 2 | [Create MotorcycleController with acceleration](story-02-motorcyclecontroller-acceleration.md) | Planned |
| 3 | [Add steering](story-03-add-steering.md) | Planned |
| 4 | [Add drift feel](story-04-add-drift-feel.md) | Planned |
| 5 | [Create Input System adapter & prefab](story-05-input-system-adapter-prefab.md) | Planned |
| 6 | [Integration tests & merge](story-06-integration-tests-merge.md) | Planned |

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Restructured from flat epic file to directory with EpicTemplate |
