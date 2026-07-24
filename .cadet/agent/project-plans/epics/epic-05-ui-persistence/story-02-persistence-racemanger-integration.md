# Story 02: Integrate Persistence with RaceManager

## Document Control
- Story ID: epic-05-story-02
- Story Name: Integrate persistence with RaceManager
- Parent Epic: [epic-05-ui-persistence](epic.md)
- Status: Planned
- Scope: Small
- Depends on: story-01
- Version: 0.1.0
- Last Updated: 2026-07-24

## Objective
Wire best-time repository into race flow: save on race end, load on menu Best Times display.

## Acceptance Criteria

### AC-S02-01: Best time saved on race end
- **Given:** RaceManager transitions to Ended with best lap recorded
- **When:** Race ends
- **Then:** `BestTimeRepository.SaveBestTime(bestLap)` called
- **Testability:** EditMode — `RaceManager_EndRace_SavesBestTime`

### AC-S02-02: Best time loaded on menu
- **Given:** Best time previously saved (42.5s)
- **When:** MainMenuScene loads, Best Times clicked
- **Then:** "42.50" displayed
- **Testability:** PlayMode — `Menu_BestTimes_ShowsSavedTime`

### AC-S02-03: No time handled gracefully
- **Given:** No best time saved
- **When:** Best Times clicked
- **Then:** "No time yet" or "---" displayed
- **Testability:** PlayMode — `Menu_BestTimes_ShowsNoTime`

## Test Strategy
- EditMode: verify RaceManager calls repository on EndRace.
- PlayMode: full flow — complete lap → end race → menu → verify display.
- Linked Requirement: AC-07
- Linked Design Section: technical-design.md §Persistence, §Race Manager

## Validation
- [ ] EditMode: RaceManager.EndRace() triggers save
- [ ] PlayMode: complete lap, quit, verify best time on menu

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-24 | Cadet-Agent | Initial story from epic breakdown |
