# Epic 01: Project Setup

## Backlinks
- Requirements document: [requirements.md](../../requirements.md)
- Technical design document: [technical-design.md](../../technical-design.md)
- Project plan document: [project-plan.md](../../project-plan.md)

## Document Control
- Epic ID: epic-01
- Epic Name: Project Setup
- Owner: Cadet-Agent
- Status: Planned
- Version: 0.1.0
- Last Updated: 2026-07-24

## Learner Context
- Relevant learner dimension: Unity 2D project configuration, package management
- Assumed learner tier: Guided (Tier 1)
- Operating mode during execution: Implementation-first
- Handoff notes: None — first epic, no prior state

## Epic Outcome
- User or Business Value: Establish a clean, working Unity project skeleton with all required packages, folder structure, test infrastructure, and input configuration — the foundation every other epic builds on.
- Testable Slice Definition: Unity Editor opens without errors, Test Runner shows green placeholder tests, Input Actions asset is configured and compiles.
- Acceptance Criteria Coverage: (Infrastructure — no gameplay ACs)

## Scope
- In Scope: Package installation (Input System, Splines, Cinemachine), folder structure creation, EditMode + PlayMode test assemblies with placeholder tests, Input Actions asset with Player action map, Git bootstrap commit.
- Out of Scope: Any gameplay code, scene content beyond SampleScene, CI/CD pipeline configuration.
- Dependencies: Unity 6 (6000.4.5f1) installed with 2D + WebGL modules.
- Risks: Package version conflicts — mitigate by using verified versions from Unity Registry.

## Story Checklist
| # | Story | Status |
|---|---|---|
| 1 | [Verify Unity project structure](story-01-verify-project-structure.md) | Planned |
| 2 | [Install required packages](story-02-install-required-packages.md) | Planned |
| 3 | [Create folder structure & test assemblies](story-03-folder-structure-test-assemblies.md) | Planned |
| 4 | [Configure Input System](story-04-configure-input-system.md) | Planned |
| 5 | [Bootstrap commit & PR](story-05-bootstrap-commit-pr.md) | Planned |

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Restructured from flat epic file to directory with EpicTemplate |
