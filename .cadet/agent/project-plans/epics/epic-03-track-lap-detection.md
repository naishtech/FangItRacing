# Epic 03: Track & Lap Detection

**Status:** Not Started | **Depends on:** Epic 02 | **Est. tasks:** 11

## Objective
Create a spline-defined track over a user-provided background image with off-track slow zones, and implement start/finish line lap detection with timing. The spline (Unity Splines package) provides the racing path and collider generation; the background image provides all track visuals. Covers AC-04, AC-05, AC-06.

## Why Splines instead of SpriteShape
- **Simpler:** Click to add knots, drag to move — no need for profiles, fill textures, or tangent handles
- **Visual separation:** The background image handles all track art; the spline only defines the path and colliders
- **Easier at Tier 0:** Less Unity-specific tooling to learn upfront

## Tasks

### T-01: Import background image and add to scene
- Import the user-provided track background image into `Assets/_Project/Sprites/`
- Add to RaceScene as a SpriteRenderer GameObject (sorting order: lowest, behind everything)
- Scale to fill the camera view
- **Validation:** Background image visible in Scene and Game view

### T-02: Create spline track (replaces old SpriteShape T-01)
- Add SplineContainer GameObject to RaceScene (via `com.unity.splines` package)
- Draw a closed-loop spline tracing the track path on top of the background image
- Create `SplineTrack.cs` component that reads spline knot positions and generates an EdgeCollider2D
- **Validation:** Collider matches the spline shape, visible in Scene view

### T-03: Create off-track trigger zone (AC-04)
- Add child GameObject with large BoxCollider2D (isTrigger) covering area outside spline track
- Alternatively: use `SplineTrack.IsOnTrack(Vector2 position)` method to check position against EdgeCollider2D
- **Test (Red):** `MotorcycleController_OffTrack_ReducesSpeed` — fails, no off-track logic yet

### T-04: Implement off-track slow-down (AC-04)
- In MotorcycleController: multiply speed by `offTrackMultiplier` (0.3) when off track
- Detect via triggers or `SplineTrack.IsOnTrack()` check
- **Test (Green):** Speed is 30% when off track, restores when back on

### T-05: Create start/finish line
- Add GameObject with SpriteRenderer (white line across spline track) and BoxCollider2D (isTrigger)
- Tag as "StartFinish"
- **Validation:** Trigger visible, collider spans track width

### T-06: Create LapData struct
- `LapData` with `int lapNumber`, `float lapTime`, `DateTime timestamp`
- Immutable struct for passing lap completion data
- **Validation:** Compiles

### T-07: Create LapManager stub (AC-05, AC-06)
- `LapManager.cs` with `List<float> lapTimes`, `float bestLap`, `int lapCount`
- `OnTriggerEnter2D` on StartFinish tag
- Direction check (e.g., must cross right-to-left)
- Events: `OnLapCompleted(LapData)`
- **Test (Red):** `LapManager_CrossFinishLine_RegistersLap` — fails

### T-08: Implement lap detection (AC-05)
- On valid crossing: increment lapCount, calculate lapTime = Time.time - raceStartTime - previousLapsTime
- Start timing from first crossing after countdown
- **Test (Green):** Crossing trigger increments lap count and records time

### T-09: Implement best lap tracking (AC-06)
- After each lap: compare lapTime to bestLap, update if faster
- Store all lap times in list for potential post-race review
- **Test (Green):** `LapManager_TracksBestLap_AcrossLaps` — best lap updates correctly

### T-10: Write PlayMode tests
- Scene with Motorcycle, SplineTrack, Background, StartFinish trigger
- Move motorcycle across trigger via script, verify lap registered
- Verify direction check rejects wrong-way crossing
- **Validation:** All PlayMode tests green

### T-11: Merge Epic 03
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
| 0.2.0 | 2026-07-23 | Cadet-Agent | Replaced SpriteShape with Unity Splines + background image; 10 → 11 tasks |
| 0.1.0 | 2026-07-19 | Cadet-Agent | Initial |
