# Feature: Timer System

## Overview
Dynamic delivery time calculation based on distance between driver and client, with countdown timer and timeout handling.

## Requirements
- Calculate delivery time based on distance to client
- Start timer when new client is assigned
- Visual countdown display for player
- Handle timeout events (failed deliveries)
- Integration with delivery and scoring systems

## Implementation Plan

### Phase 1: Timer Logic (Claude Generated)
**Scripts to Generate:**
- `DeliveryTimer.cs` - Main timer logic and countdown
- `DistanceCalculator.cs` - Distance-based time calculation
- `TimerDisplay.cs` - UI timer formatting and updates
- `TimerEvents.cs` - Timer-related event system

**Time Calculation Formula:**
```
Base Time = Distance * Time Multiplier + Buffer Time
- Distance: Unity units between player and client
- Time Multiplier: Configurable (e.g., 2 seconds per unit)
- Buffer Time: Grace period (e.g., 10 seconds)
```

### Phase 2: Unity Setup (Human Required)
**Manual Unity Tasks:**
1. Create timer UI elements (progress bar, text)
2. Set up visual timer warnings (color changes)
3. Configure timer audio warnings
4. Link timer with delivery system events
5. Create timer expiration effects

## Tasks Breakdown

### Claude Tasks (Scripts)
- [ ] **DeliveryTimer.cs**
  - Countdown timer implementation
  - Timer start/stop/reset functionality
  - Timeout detection and event triggering
  - Configurable timer settings
- [ ] **DistanceCalculator.cs**
  - Distance calculation between player and client
  - Time formula implementation
  - Minimum/maximum time constraints
  - Real-time distance updates
- [ ] **TimerDisplay.cs**
  - Timer UI formatting (MM:SS format)
  - Progress bar updates
  - Color transitions based on remaining time
  - Warning state visual changes
- [ ] **TimerEvents.cs**
  - Timer expiration events
  - Warning threshold events
  - Timer state change events

### Human Tasks (Unity Editor)
- [ ] **Timer UI Creation**
  - Create Canvas for timer display
  - Add TextMeshPro for time display
  - Add Slider component for progress bar
  - Position timer UI in appropriate location
- [ ] **Visual Design**
  - Style timer text (font, size, colors)
  - Configure progress bar appearance
  - Set up color transitions (green → yellow → red)
  - Create urgency visual effects
- [ ] **Audio Integration**
  - Add timer warning sound effects
  - Configure audio for final countdown
  - Set up audio source components
  - Create audio fade effects for urgency
- [ ] **Effects Setup**
  - Create screen flash effects for warnings
  - Add particle effects for timer expiration
  - Configure UI animations for urgency states

## Timer States and Visual Feedback

### Timer Phases
1. **Safe (>60% time left)**: Green, normal display
2. **Warning (30-60% time left)**: Yellow, slight pulsing
3. **Critical (<30% time left)**: Red, fast pulsing, audio warnings
4. **Expired (0% time left)**: Red flash, timeout effects

### Time Calculation Examples
```
Distance: 10 units, Multiplier: 1.5s, Buffer: 15s
→ Total Time: (10 × 1.5) + 15 = 30 seconds

Distance: 25 units, Multiplier: 1.5s, Buffer: 15s
→ Total Time: (25 × 1.5) + 15 = 52.5 seconds
```

## Configuration Settings
```csharp
[System.Serializable]
public class TimerSettings
{
    public float timeMultiplier = 1.5f;    // Seconds per distance unit
    public float bufferTime = 15f;         // Grace period in seconds
    public float minDeliveryTime = 20f;    // Minimum time regardless of distance
    public float maxDeliveryTime = 120f;   // Maximum time cap
    public float warningThreshold = 0.3f;  // When to show warnings (30%)
    public float criticalThreshold = 0.6f; // When to show critical state (60%)
}
```

## Integration Events

### Timer → Delivery System
```csharp
public static event System.Action OnTimerExpired;
public static event System.Action<float> OnTimerWarning;
```

### Delivery System → Timer
```csharp
public void StartDeliveryTimer(Vector2 playerPos, Vector2 clientPos)
public void StopTimer()
public void ResetTimer()
```

## Acceptance Criteria
- [ ] Timer calculates time based on distance accurately
- [ ] Timer starts when new client is assigned
- [ ] Countdown displays in MM:SS format
- [ ] Visual warnings appear at 60% and 30% thresholds
- [ ] Audio warnings play during critical phase
- [ ] Timer expiration triggers delivery failure
- [ ] Progress bar accurately reflects remaining time
- [ ] Timer resets properly for new deliveries

## Dependencies
- Dynamic Client System (client position)
- Player Movement System (player position)
- Package Delivery System (delivery completion/failure)
- Scoring System (timeout penalty)

## Edge Cases to Handle
- Timer expiration during delivery zone entry
- Multiple rapid client assignments
- Player position updates during countdown
- Pausing/resuming timer (if pause feature exists)

## Estimated Time: 2 days
- Scripts: 4-5 hours
- UI creation and styling: 3-4 hours
- Audio and effects setup: 2-3 hours
- Integration and testing: 2-3 hours