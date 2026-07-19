# ADR-001: Custom Arcade Controller vs Rigidbody2D

## Status
Accepted

## Context
The motorcycle needs top-down 2D movement with arcade feel: snappy acceleration, speed-sensitive steering, and controlled drift. We have two options: Unity's built-in Rigidbody2D physics or a custom transform-based controller.

## Decision
**Custom transform-based controller.**

## Rationale
1. **Arcade feel** — Rigidbody2D enforces realistic mass/drag/friction. Getting the desired "slidey but responsive" drift feel requires fighting the physics engine with counter-forces. A custom controller gives direct control over velocity and rotation.
2. **WebGL performance** — Rigidbody2D simulation step runs every FixedUpdate, adding overhead. A simple transform controller runs in Update with minimal math, keeping WebGL frame budget healthy.
3. **Deterministic testing** — Custom math is fully deterministic in EditMode tests. Rigidbody2D simulation is non-deterministic without fixed timestep locking.
4. **Kinematic Rigidbody2D only for triggers** — We still attach a kinematic Rigidbody2D to the motorcycle so OnTriggerEnter2D works for lap detection and off-track zones. But Rigidbody2D is not used for movement.

## Tradeoffs
| Pro | Con |
|---|---|
| Complete control over movement feel | No "free" collision response — must handle boundaries manually |
| Deterministic tests | More code to write for drift math |
| WebGL-friendly | Less realistic — but arcade feel is the goal |

## Alternatives Considered
- **Rigidbody2D Dynamic:** Rejected — overkill for arcade prototype, WebGL overhead, non-deterministic tests.
- **Rigidbody2D with high drag and AddForce:** Rejected — still fights physics engine, harder to tune drift precisely.
