# TECH-SPEC.MD — Technical Specification

## Project Stack

| Layer | Choice |
|-------|--------|
| Engine | Unity 6 (6000.3.x) |
| Render Pipeline | Universal Render Pipeline (URP) |
| Input | Unity New Input System |
| Language | C# 9.0 / netstandard2.1 |
| Assembly | Assembly-CSharp |

---

## Player Movement System

**Script**: `Assets/Car.cs`
**Component dependencies**: `Rigidbody2D` (required on same GameObject)

### Design Decisions

#### Direct device polling vs. PlayerInput component
Input is read via `InputSystem.GetDevice<Keyboard>()` and `InputSystem.GetDevice<Gamepad>()` in `Update`. This avoids the need to wire a `PlayerInput` component in the scene but does not use the project's `InputSystem_Actions.inputactions` asset. Kept simple for single-player, single-device use; revisit if control rebinding or local co-op is needed.

#### Steering axis inversion
The A/Left keys and gamepad left stick X produce a positive `input.x` value for left-steering. This reflects car-centric turning (rotating the transform around Z), not world-space translation. The sign is flipped consistently across all three input sources.

#### Speed representation
A scalar `currentSpeed` (not a Vector2) tracks forward/backward speed. The car always moves along `transform.up`. This gives authentic car feel — the car cannot strafe.

#### Reverse speed cap
Reverse is limited to `maxSpeed * 0.5f`. Forward is limited to `maxSpeed`.

#### Rotation gating
`HandleRotation` only applies steering when `|currentSpeed| > 0.1f`. This prevents the car from spinning in place when stationary.

#### Brake detection
If `motor` input is opposite in sign to `currentSpeed`, the `brakeForce` multiplier is used instead of `deceleration`. This gives perceptibly sharper stopping.

#### Physics integration
| Phase | Work done |
|-------|-----------|
| `Update` | Poll input, update `moveInput` |
| `FixedUpdate` | `HandleMovement` → `HandleRotation` → `ApplyDrag` |

`Rigidbody2D.freezeRotation = true` — all rotation is done through `transform.Rotate` to keep steering deterministic and not influenced by collision torque.

### Tunable Parameters (Inspector)

| Field | Default | Notes |
|-------|---------|-------|
| `maxSpeed` | 10 | Forward cap (units/s) |
| `acceleration` | 8 | Speed gain per second |
| `deceleration` | 8 | Coast decay per second |
| `brakeForce` | 15 | Hard-stop decay per second |
| `turnSpeed` | 200 | deg/s at full steering input |
| `dragCoefficient` | 3 | Velocity damping factor |

### Scene Setup Checklist

- [ ] Car GameObject has `Sprite Renderer` (sprite facing **up** / +Y)
- [ ] `Rigidbody2D` attached; `Car.cs` sets `gravityScale = 0` and `freezeRotation = true` in `Awake`
- [ ] Layer/collision matrix configured if boundary walls are needed
- [ ] No `PlayerInput` component required

---

## Planned Systems (not yet implemented)

| System | Notes |
|--------|-------|
| Map Configuration | Configurable X x Y bounds; loads client spawn points from config files |
| Client Location Management | Predefined spawn locations validated within map bounds |
| Dynamic Client System | Random selection from available locations |
| Timer System | `Distance x Multiplier + Buffer` formula; visual/audio warnings |
| Package Delivery System | Pickup and drop-off interaction |
| Scoring System | +10 success / -5 failure / floor 0 |
| UI System | TextMeshPro; score, timer, delivery status |
