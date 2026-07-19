# ADR-002: SpriteShape vs Tilemap for Track

## Status
Accepted

## Context
The track is a simple oval speedway. We need to render the track surface and generate collision edges for off-track detection. Options: Unity SpriteShape, Tilemap, or a single large sprite.

## Decision
**SpriteShape.**

## Rationale
1. **Smooth curves** — An oval speedway needs smooth, continuous curves. SpriteShape generates bezier-based meshes that look natural. Tilemap is grid-based and produces jagged edges on diagonals/curves.
2. **Auto-generated colliders** — SpriteShape can auto-generate EdgeCollider2D from the spline path, giving us the track boundary collision for free. No manual collider setup needed.
3. **Iteration speed** — Changing the track shape is a matter of adjusting spline control points. No re-authoring tiles or redrawing sprites.
4. **Growth path** — If we add a figure-8 or road circuit later, SpriteShape handles complex splines natively.

## Tradeoffs
| Pro | Con |
|---|---|
| Smooth curves, natural oval shape | Requires SpriteShape package dependency |
| Auto-generated EdgeCollider2D | Slightly more setup than a hand-drawn sprite |
| Easy to reshape via spline points | Limited built-in texturing variety (but we're using placeholders) |

## Alternatives Considered
- **Tilemap:** Rejected — grid-based, poor for smooth curved tracks.
- **Single large sprite:** Rejected — zero flexibility for iteration, manual collider setup.
