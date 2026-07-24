# Project Plan: Fang It Racing — Core Prototype

## Document Control
- **Project:** Fang It Racing
- **Status:** Draft
- **Version:** 0.2.0
- **Last Updated:** 2026-07-23

## References
- [Requirements](requirements.md)
- [Technical Design](technical-design.md)
- [ADRs](adr/)

## Epic Sequence

| Order | Epic | Covers | Est. Effort |
|---|---|---|---|
| 1 | [Project Setup](epics/epic-01-project-setup.md) | Package config, folder structure, test assembly, Input System | Small |
| 2 | [Motorcycle Controller](epics/epic-02-motorcycle-controller.md) | AC-01, AC-02, AC-03 — movement, steering, drift | Medium |
| 3 | [Track & Lap Detection](epics/epic-03-track-lap-detection.md) | AC-04, AC-05, AC-06 — Spline track over background image, start/finish, timing | Medium |
| 4 | [Race Flow](epics/epic-04-race-flow.md) | AC-08, AC-09 — RaceManager state machine, countdown, scene loading | Small |
| 5 | [UI & Persistence](epics/epic-05-ui-persistence.md) | AC-07, AC-10 — HUD, menu, best time save/load | Medium |
| 6 | [Polish & Build](epics/epic-06-polish-build.md) | AC-11 — Cinemachine, WebGL build, final validation | Small |

## Branch Strategy
- Feature branch per epic: `epic/01-project-setup`, `epic/02-controller`, etc.
- Merge to `main` via squash-merge PR after each epic passes tests.
- Rebase feature branches onto `main` before PR.

## Definition of Done (per Epic)
1. All ACs in scope pass with green tests
2. PlayMode tests verified in Unity Editor
3. No regressions in prior epics
4. Code review gate passed (automated + manual)
5. Branch squashed and merged to `main`

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.2.0 | 2026-07-23 | Cadet-Agent | Updated Epic 03 description for Splines redesign |
| 0.1.0 | 2026-07-19 | Cadet-Agent | Initial project plan |
