# Decommission: SpriteShape → Unity Splines

## Document Control
- **Project:** Fang It Racing
- **Status:** Complete
- **Version:** 1.0.0
- **Last Updated:** 2026-07-23

## Reason
SpriteShape (`com.unity.2d.spriteshape`) was originally chosen as the track-building tool in the technical design (v0.1.0). At learner Tier 0 (New), the SpriteShape workflow — profiles, fill textures, tangent handles — proved too complex. The decision was made to replace it with the Unity Splines package (`com.unity.splines`) + a user-provided background image:

- **Splines** define the racing path and generate the collider (simpler: click to add knots, drag to move).
- **Background image** handles all track visuals (no need to learn SpriteShape's visual tooling).

See [technical-design.md](technical-design.md) v0.2.0 and [epic-03](epics/epic-03-track-lap-detection.md) v0.2.0 for the updated design.

## Decommission Steps

### Step 1: Remove SpriteShape package
- Open `Packages/manifest.json`
- Remove the line: `"com.unity.2d.spriteshape": "14.0.1",`
- Unity will recompile on next focus

### Step 2: Remove SpriteShape folder
- Delete `Assets/_Project/SpriteShapes/` folder if it exists
- (No assets were found — folder may not exist yet; skip if absent)

### Step 3: Install Splines package
- Add to `Packages/manifest.json`: `"com.unity.splines": "2.8.0",`
- Or install via Package Manager UI: Window → Package Manager → Unity Registry → "Splines" → Install

### Step 4: Create Splines folder
- Create `Assets/_Project/Splines/` folder (for spline data assets)

## Affected Documents (already updated)
| Document | Version | Change |
|---|---|---|
| [technical-design.md](technical-design.md) | 0.2.0 | Replaced SpriteShape with Splines + background image |
| [project-plan.md](project-plan.md) | 0.2.0 | Updated Epic 03 description |
| [epic-01](epics/epic-01-project-setup.md) | 0.2.0 | `spriteshape` → `splines` package; `SpriteShapes/` → `Splines/` |
| [epic-03](epics/epic-03-track-lap-detection.md) | 0.2.0 | Full track task rewrite: spline + background image |

## Verification
- [ ] `com.unity.2d.spriteshape` not in `Packages/manifest.json`
- [ ] `com.unity.splines` present in `Packages/manifest.json`
- [ ] `Assets/_Project/SpriteShapes/` deleted (if existed)
- [ ] `Assets/_Project/Splines/` folder exists
- [ ] Unity Editor opens without compilation errors
