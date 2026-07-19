# Epic 06: Polish & Build

**Status:** Not Started | **Depends on:** Epic 05 | **Est. tasks:** 8

## Objective
Add Cinemachine smooth-follow camera, tunable arcade feel, WebGL build configuration, and final validation. Covers AC-11.

## Tasks

### T-01: Set up Cinemachine camera
- Add Cinemachine Brain to Main Camera
- Create Virtual Camera, set Follow target to Motorcycle
- Configure Framing Transposer: soft damping on X/Y, small dead zone
- Set orthographic size for good track visibility
- **Validation:** Camera smoothly follows motorcycle in Play mode

### T-02: Tune arcade controller feel
- Adjust MotorcycleController serialized fields for satisfying feel:
  - `maxSpeed`: fast but controllable
  - `acceleration`: quick ramp-up
  - `turnRate`: responsive but not twitchy
  - `driftFactor`: visible but not out-of-control slide
- Test with keyboard input, iterate
- **Validation:** Movement feels fun and responsive (manual)

### T-03: Add placeholder sprites
- Create simple colored sprite placeholders:
  - Motorcycle: red rectangle (1×0.5)
  - Track surface: dark grey
  - Off-track: green/brown
  - Start/finish line: white stripe
- **Validation:** Visuals are clear and distinguishable

### T-04: Configure WebGL build settings (AC-11)
- File → Build Settings → WebGL
- Player Settings:
  - Resolution: 960×600 (good balance for browser)
  - Compression: Gzip
  - Code Optimization: Size (for faster download)
  - Memory: 256MB
- **Validation:** Build settings saved

### T-05: Create WebGL build
- Build to `Builds/WebGL/`
- Run local server: `python -m http.server 8000` in build folder (or use Unity's Build & Run)
- **Validation:** Game loads in browser

### T-06: WebGL input test
- Test keyboard input works in browser (WASD/arrows)
- Test all UI buttons clickable
- Test lap detection and HUD updates
- **Validation:** Full game loop works in browser

### T-07: Performance check
- Open browser dev tools → Performance tab
- Verify FPS ≥ 30 during gameplay
- Check memory usage is stable (no leaks across laps)
- **Validation:** Performance metrics acceptable

### T-08: Final merge & project close
- All tests green, PR reviewed, squash merge to `main`
- Update README.md with build/run instructions
- Tag release: `v0.1.0-prototype`
- **Validation:** All 11 ACs verified, prototype ready

## Acceptance Criteria Covered
| AC | Status |
|---|---|
| AC-11: WebGL Build | ✅ |
| (Polish — all ACs re-verified) | ✅ |

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-19 | Cadet-Agent | Initial |
