# ADR-004: Cinemachine for Camera Follow

## Status
Accepted

## Context
The camera should smoothly follow the motorcycle around the track. Options: custom camera script, Cinemachine (Unity's camera framework), or fixed overhead.

## Decision
**Cinemachine Virtual Camera with Framing Transposer.**

## Rationale
1. **Battle-tested** — Cinemachine is Unity's standard camera system, shipped with Unity 6. It handles edge cases (screen shake, damping, dead zones) that custom scripts often get wrong.
2. **Smooth follow out of the box** — A Virtual Camera with Framing Transposer gives us configurable damping, lookahead, and dead zone in a few clicks. No code needed for basic follow.
3. **Growth path** — If we later want camera shake on collisions, zoom on speed, or transition between cameras, Cinemachine supports all of that without rewriting the follow logic.
4. **Known technology** — Cinemachine is standard Unity curriculum; no learning curve concern at tier 1.

## Tradeoffs
| Pro | Con |
|---|---|
| Zero code for basic follow | Adds Cinemachine package dependency |
| Configurable damping/dead zones via inspector | Overhead of Virtual Camera component (negligible for 2D) |
| Easy to extend (shake, zoom, transitions) | Learning curve for advanced features (not needed here) |

## Alternatives Considered
- **Custom camera script:** Rejected — reinventing Cinemachine's damping/dead zone/lookahead for no benefit.
- **Fixed overhead camera:** Rejected — user chose smooth follow in requirements phase.
