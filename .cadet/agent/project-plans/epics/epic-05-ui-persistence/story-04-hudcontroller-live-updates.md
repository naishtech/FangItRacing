# Story 04: Create HUDController with Live Updates

## Document Control
- Story ID: epic-05-story-04
- Story Name: Create HUDController with live updates
- Parent Epic: [epic-05-ui-persistence](epic.md)
- Status: Planned
- Scope: Medium
- Depends on: story-03
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Create `HUDController` that reads RaceManager and MotorcycleController data each frame, formats values, and updates UI text elements.

## Acceptance Criteria

### AC-S04-01: HUDController stub exists (AC-10)
- **Given:** `HUDController.cs` in `Scripts/UI/`
- **When:** Has references to four TMP text elements, RaceManager, LapManager, MotorcycleController
- **Then:** Component compiles
- **Testability:** EditMode — instantiate with mocks

### AC-S04-02: Lap count updates (AC-10)
- **Given:** HUDController active, lap completed
- **When:** Update() runs
- **Then:** LapCountText displays updated lap number
- **Testability:** PlayMode — `HUD_LapCount_Updates`

### AC-S04-03: Lap time updates live (AC-10)
- **Given:** HUDController active, Racing state
- **When:** Update() runs each frame
- **Then:** LapTimeText shows current lap time updating in real time
- **Testability:** PlayMode — `HUD_LapTime_UpdatesLive`

### AC-S04-04: Best time displayed (AC-10)
- **Given:** Best lap exists
- **When:** HUDController updates
- **Then:** BestTimeText shows formatted best lap time
- **Testability:** PlayMode — `HUD_BestTime_Displayed`

### AC-S04-05: Speed displayed (AC-10)
- **Given:** MotorcycleController has current speed
- **When:** HUDController updates
- **Then:** SpeedText shows current speed (integer)
- **Testability:** PlayMode — `HUD_Speed_Displayed`

## Test Strategy
- **Red:** Write HUD update tests — fail (no HUDController).
- **Green:** Create HUDController with Update() logic — tests pass.
- Linked Requirement: AC-10
- Linked Design Section: technical-design.md §HUD

## Validation
- [ ] All PlayMode tests green
- [ ] All four HUD elements update in real time

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
