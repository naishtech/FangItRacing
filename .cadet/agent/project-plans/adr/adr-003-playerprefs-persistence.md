# ADR-003: PlayerPrefs vs JSON File for Persistence

## Status
Accepted

## Context
Best lap time must survive app restart. For a prototype, the options are Unity's PlayerPrefs API or a custom JSON file written to `Application.persistentDataPath`.

## Decision
**PlayerPrefs.**

## Rationale
1. **Single value** — We're only storing one float (best lap time in seconds). PlayerPrefs' key-value model is a perfect fit. JSON is overkill for one number.
2. **WebGL compatibility** — PlayerPrefs in WebGL maps to `localStorage`, which persists across browser refreshes. A file-based approach requires IndexedDB or similar, which is more complex.
3. **Zero setup** — No file I/O code, no serialization concerns, no path resolution. One line to save, one to load.
4. **Interface abstraction** — We wrap it in `IBestTimeRepository` so swapping to JSON/cloud later requires changing only the implementation, not any consumers.

## Tradeoffs
| Pro | Con |
|---|---|
| Dead simple for single values | Not suitable for complex data (but we only have one float) |
| WebGL-native via localStorage | PlayerPrefs can be cleared by the user in browser settings |
| Zero boilerplate | No built-in encryption (not needed for lap times) |

## Alternatives Considered
- **JSON file:** Rejected — overengineered for one float value, more WebGL complexity.
- **Binary file:** Rejected — same overhead as JSON with worse debuggability.
