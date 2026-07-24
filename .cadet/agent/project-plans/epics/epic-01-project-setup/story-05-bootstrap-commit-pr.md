# Story 05: Bootstrap Commit & PR

## Document Control
- Story ID: epic-01-story-05
- Story Name: Bootstrap commit & PR
- Parent Epic: [epic-01-project-setup](epic.md)
- Status: Planned
- Scope: Small
- Depends on: story-04
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Commit all Epic 01 setup changes on a feature branch, push, create a PR, and merge to `main`.

## Acceptance Criteria

### AC-S05-01: Feature branch created
- **Given:** Git is initialized in the project
- **When:** A branch named `epic/01-project-setup` is created from `main`
- **Then:** All story-01 through story-04 changes are committed on that branch
- **Testability:** Manual — `git log` shows commits

### AC-S05-02: PR created and merged
- **Given:** The branch is pushed to the remote
- **When:** A pull request is created for `epic/01-project-setup` → `main`
- **Then:** CI passes (if configured), PR is reviewed, squash-merged to `main`
- **Testability:** Manual — verify PR merged on remote

## Test Strategy
- Manual verification of git history and PR status.
- No automated tests — this is a process gate.
- Linked Requirement: (Infrastructure)
- Linked Design Section: N/A

## Validation
- [ ] All changes from Epic 01 are on `main`
- [ ] Project opens cleanly from `main` with all packages, folders, and Input Actions in place

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
