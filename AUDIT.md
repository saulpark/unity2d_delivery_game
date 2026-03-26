# AUDIT.md — Security & Correctness Issues

## Open Issues

### A-001 — Steering X-axis inversion is undocumented in code
**File**: `Assets/Car.cs` lines 42-43, 48-49, 62-63
**Severity**: Low
**Description**: The A/Left key and left stick map to `input.x += 1f` (positive X = steer left), which is the opposite of standard Unity 2D convention. This is intentional for car-relative turning but the inversion is only noted with a comment. A future contributor could "fix" it and break steering.
**Recommendation**: Add a clear comment block explaining the coordinate convention, or encapsulate it in a named helper.

### A-002 — `InputSystem.GetDevice<>` polling pattern
**File**: `Assets/Car.cs` lines 34, 55
**Severity**: Low
**Description**: Input is polled each `Update` frame via `InputSystem.GetDevice<>` rather than using Unity's recommended `PlayerInput` component or generated `InputSystem_Actions` wrapper. This works correctly but bypasses the project's existing `InputSystem_Actions.inputactions` asset and makes it harder to rebind controls or support multiple local players.
**Recommendation**: Consider migrating to the generated `InputSystem_Actions` C# class for consistency with the project's input asset.

### A-003 — `AddForce` accumulates on top of velocity without velocity cap
**File**: `Assets/Car.cs` line 111
**Severity**: Low
**Description**: `currentSpeed` is clamped, but `rb.AddForce` adds to the existing `Rigidbody2D` velocity. If drag (`ApplyDrag`) does not fully cancel accumulated velocity each frame, the car can slightly exceed `maxSpeed` at high frame rates.
**Recommendation**: Clamp `rb.linearVelocity.magnitude` after applying forces, or switch to `rb.MovePosition` / direct velocity assignment.

## Resolved Issues

_(none yet)_
