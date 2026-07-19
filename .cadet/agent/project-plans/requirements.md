# Requirements: Fang It Racing — Top-Down 2D Motorcycle Time Trial

## Document Control
- **Project:** Fang It Racing
- **Feature:** Core prototype — top-down 2D motorcycle time trial
- **Status:** Draft
- **Version:** 0.1.0
- **Last Updated:** 2026-07-19

## Learner Context
- **Relevant dimension:** Unity 2D game development, arcade physics, WebGL deployment
- **Assumed tier:** Tier 1 (Guided) — comfortable with Unity basics, benefits from scaffolded reasoning
- **Operating mode:** Instruction-first with full-plan-first review

## Context
- **Problem Statement:** Need a playable top-down 2D motorcycle time-trial prototype that demonstrates core racing feel and can be iterated on.
- **User Outcome:** Player controls a motorcycle around a circuit track, races against the clock, sees lap times, and tries to beat their best time.
- **Business/Gameplay Value:** Validates the core loop (race → see time → retry to improve) and confirms top-down 2D arcade controls feel fun.
- **Target Platforms:** PC Standalone (primary), WebGL (secondary)

## Scope

### In Scope
- Top-down 2D motorcycle movement with arcade-style physics (acceleration, steering, drift/slide feel)
- Single closed-loop circuit track with visible boundaries
- Lap detection with split/lap timing
- Best-lap-time persistence (local, survives app restart)
- HUD: current lap time, best lap time, lap count, speed indicator
- Simple main menu: Start Race, Best Times, Quit
- Keyboard input (primary); gamepad support (stretch)
- PC standalone + WebGL builds

### Out of Scope
- 3D rendering, realistic motorcycle simulation
- Multiple tracks or track selection
- AI opponents or ghost replays
- Online leaderboards or multiplayer
- Mobile/touch input
- Career mode, upgrades, garage, customization
- Audio/music (stretch only if time permits)
- Localization (English-only prototype)

## Constraints and Assumptions
- **Constraints:** Unity 6 (6000.4.5f1), 2D renderer, must build to WebGL, arcade physics only (no Rigidbody2D simulation required if custom controller suffices)
- **Assumptions:** Single player only, keyboard as primary input device, single screen (no camera scrolling needed for a compact track)
- **Dependencies:** Unity 6 installed, Unity 2D package set, WebGL build module
- **Risks:** WebGL performance with physics — mitigate by keeping controller simple; input latency in WebGL — mitigate with Input System package

## Acceptance Criteria (Given/When/Then)

### AC-01: Motorcycle Movement
- **Given:** The player is on the track in race mode
- **When:** The player presses accelerate (W/UpArrow)
- **Then:** The motorcycle accelerates forward in the direction it faces, up to a defined max speed
- **Testability:** EditMode unit test for acceleration math; PlayMode test for input→movement

### AC-02: Motorcycle Steering
- **Given:** The motorcycle is moving
- **When:** The player presses left (A/LeftArrow) or right (D/RightArrow)
- **Then:** The motorcycle rotates at a turn rate that increases with speed (faster = tighter turns)
- **Testability:** EditMode unit test for rotation math; PlayMode test for input→rotation

### AC-03: Arcade Drift Feel
- **Given:** The motorcycle is moving at speed
- **When:** The player turns while moving
- **Then:** The motorcycle exhibits a slight sideways drift/slide rather than rigid rail-like turning — lateral velocity persists partially during rotation
- **Testability:** EditMode unit test for drift vector math

### AC-04: Track Boundaries
- **Given:** The motorcycle is on the track
- **When:** The motorcycle leaves the track surface
- **Then:** Speed is reduced (off-track slow penalty), and the player must steer back onto the track to resume normal speed
- **Testability:** PlayMode test with trigger collider setup

### AC-05: Lap Detection
- **Given:** A start/finish line trigger exists on the track
- **When:** The motorcycle crosses the start/finish line in the correct direction after completing a full lap
- **Then:** A new lap is registered, the lap time is recorded, and the lap counter increments
- **Testability:** PlayMode test with controlled movement across trigger

### AC-06: Lap Timing
- **Given:** A race is in progress
- **When:** The race starts (first crossing of start line after countdown) and each subsequent lap is completed
- **Then:** Each lap time is displayed on the HUD, and the best lap time of the session is highlighted
- **Testability:** EditMode unit test for timing logic; PlayMode for full flow

### AC-07: Best Time Persistence
- **Given:** The player has completed at least one lap
- **When:** The race ends (player quits to menu or completes a set number of laps)
- **Then:** The best lap time is saved and survives app restart
- **Testability:** EditMode unit test for save/load logic with mock persistence layer

### AC-08: Main Menu
- **Given:** The game launches
- **When:** The main menu scene loads
- **Then:** The player sees "Fang It Racing" title and buttons: Start Race, Best Times, Quit
- **Testability:** PlayMode test for scene loading and button presence

### AC-09: Race Countdown
- **Given:** The player clicks "Start Race"
- **When:** The race scene loads
- **Then:** A 3-2-1-GO countdown displays before the motorcycle becomes controllable
- **Testability:** PlayMode test for countdown sequence and control enablement timing

### AC-10: HUD Display
- **Given:** A race is in progress
- **When:** The player is racing
- **Then:** The HUD shows: current lap time (live), best lap time, lap count (e.g., "Lap 2/3"), and a speed indicator
- **Testability:** PlayMode test for UI element visibility and value correctness

### AC-11: WebGL Build
- **Given:** The project is complete
- **When:** A WebGL build is created
- **Then:** The game loads in a browser, accepts keyboard input, and runs at ≥30 FPS on a mid-range machine
- **Testability:** Manual validation — build output tested in browser

## Technology Choices (Confirmed)

| Decision | Selection |
|---|---|
| Input handling | Unity Input System (new) — event-driven, WebGL-compatible |
| 2D track rendering | SpriteShape — spline-based smooth curves ideal for circuit tracks |
| Persistence | PlayerPrefs — built-in, survives WebGL refresh |
| Physics | Custom arcade controller — no Rigidbody2D, WebGL-friendly |

## Design Clarifications (Resolved)
| Decision | Selection |
|---|---|
| Race length | Unlimited hot lap — player races until they quit, always chasing best time |
| Track layout | Simple oval speedway — minimal SpriteShape complexity |
| Off-track penalty | Slow-down zone — speed capped at ~30% of max while off-track |
| Camera | Smooth follow via Cinemachine |
| Art style | Geometric placeholders — colored rectangles/circles, pure prototype look |
| Lap display | Shows "Lap N" counter (incrementing), not "Lap N/M" |

## Change History
| Version | Date | Author | Changes |
|---|---|---|---|
| 0.1.0 | 2026-07-19 | Cadet-Agent | Initial draft |
| 0.1.1 | 2026-07-19 | Cadet-Agent | Resolved 5 ambiguity clarifications; locked technology choices |
