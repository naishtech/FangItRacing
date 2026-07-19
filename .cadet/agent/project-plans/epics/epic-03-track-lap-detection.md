# Epic 03: Track & Lap Detection

**Status:** Not Started | **Depends on:** Epic 02 | **Est. tasks:** 10

## Objective
Create the SpriteShape oval track with off-track slow zones and implement start/finish line lap detection with timing. Covers AC-04, AC-05, AC-06.

## Tasks

### T-01: Create oval track with SpriteShape
- Create SpriteShape profile for track (solid color fill, dark grey)
- Draw closed spline in oval shape in RaceScene
- Generate EdgeCollider2D from spline
- **Validation:** Track visible in Scene view, collider matches shape

### T-02: Create off-track trigger zone (AC-04)
- Add child GameObject with large BoxCollider2D (isTrigger) covering area outside track
- Or: invert track collider logic — tag "OffTrack" areas
- Create `TrackSurface` component with `IsOnTrack(Vector2 position)` method
- **Test (Red):** `MotorcycleController_OffTrack_ReducesSpeed` — fails, no off-track logic yet

### T-03: Implement off-track slow-down (AC-04)
- In MotorcycleController: multiply speed by `offTrackMultiplier` (0.3) when off track
- Detect via triggers or position check against TrackSurface
- **Test (Green):** Speed is 30% when off track, restores when back on

### T-04: Create start/finish line
- Add GameObject with SpriteRenderer (white line across track) and BoxCollider2D (isTrigger)
- Tag as "StartFinish"
- **Validation:** Trigger visible, collider spans track width

### T-05: Create LapData struct
- `LapData` with `int lapNumber`, `float lapTime`, `DateTime timestamp`
- Immutable struct for passing lap completion data
- **Validation:** Compiles

### T-06: Create LapManager stub (AC-05, AC-06)
- `LapManager.cs` with `List<float> lapTimes`, `float bestLap`, `int lapCount`
- `OnTriggerEnter2D` on StartFinish tag
- Direction check (e.g., must cross right-to-left)
- Events: `OnLapCompleted(LapData)`
- **Test (Red):** `LapManager_CrossFinishLine_RegistersLap` — fails

### T-07: Implement lap detection (AC-05)
- On valid crossing: increment lapCount, calculate lapTime = Time.time - raceStartTime - previousLapsTime
- Start timing from first crossing after countdown
- **Test (Green):** Crossing trigger increments lap count and records time

### T-08: Implement best lap tracking (AC-06)
- After each lap: compare lapTime to bestLap, update if faster
- Store all lap times in list for potential post-race review
- **Test (Green):** `LapManager_TracksBestLap_AcrossLaps` — best lap updates correctly

### T-09: Write PlayMode tests
- Scene with Motorcycle, Track, StartFinish trigger
- Move motorcycle across trigger via script, verify lap registered
- Verify direction check rejects wrong-way crossing
- **Validation:** All PlayMode tests green

### T-10: Merge Epic 03
- All tests green, PR reviewed, squash merge to `main`
- **Validation:** AC-04, AC-05, AC-06 demonstrable

## Acceptance Criteria Covered
| AC | Status |
|---|---|
| AC-04: Track Boundaries | ✅ |
| AC-05: Lap Detection | ✅ |
| AC-06: Lap Timing | ✅ |

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-19 | Cadet-Agent | Initial |
