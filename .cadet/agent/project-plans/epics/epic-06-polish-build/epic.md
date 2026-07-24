# Epic 06: Polish & Build

## Backlinks
- Requirements document: [requirements.md](../../requirements.md)
- Technical design document: [technical-design.md](../../technical-design.md)
- Project plan document: [project-plan.md](../../project-plan.md)

## Document Control
- Epic ID: epic-06
- Epic Name: Polish & Build
- Owner: Cadet-Agent
- Status: Planned
- Version: 0.1.0
- Last Updated: 2026-07-24

## Learner Context
- Relevant learner dimension: Cinemachine, WebGL build pipeline, performance profiling
- Assumed learner tier: Guided (Tier 1)
- Operating mode during execution: Implementation-first
- Handoff notes: Requires Epic 05 complete — full game loop with HUD and persistence

## Epic Outcome
- User or Business Value: Game feels polished with smooth camera, satisfying controls, clear visuals, and runs in a browser. The prototype is complete and shippable.
- Testable Slice Definition: Camera follows motorcycle smoothly, controls feel fun, game builds to WebGL and runs at ≥30 FPS in browser.
- Acceptance Criteria Coverage: AC-11 (WebGL Build), plus re-verification of all prior ACs

## Scope
- In Scope: Cinemachine follow camera, controller feel tuning, placeholder sprite polish, WebGL build configuration + build + browser test, performance check, README, release tag.
- Out of Scope: Audio, advanced visual effects, mobile support, CI/CD pipeline.
- Dependencies: Epic 05 (full game loop), Cinemachine package (from Epic 01).
- Risks: WebGL performance with custom physics — mitigate by keeping controller simple (no Rigidbody2D), profiling early.

## Story Checklist
| # | Story | Status |
|---|---|---|
| 1 | [Set up Cinemachine follow camera](story-01-cinemachine-follow-camera.md) | Planned |
| 2 | [Tune arcade controller feel](story-02-tune-controller-feel.md) | Planned |
| 3 | [Add placeholder sprites & visual polish](story-03-placeholder-sprites.md) | Planned |
| 4 | [Configure & create WebGL build](story-04-webgl-build.md) | Planned |
| 5 | [Performance check, final validation & merge](story-05-perf-final-validation.md) | Planned |

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Restructured from flat epic file to directory with EpicTemplate |
