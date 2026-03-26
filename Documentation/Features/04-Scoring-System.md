# Feature: Scoring System

## Overview
Track and manage player score with +10 points for successful deliveries and -5 points for failed deliveries, with immediate UI updates.

## Requirements
- Award 10 points for successful delivery
- Deduct 5 points for failed delivery (timeout)
- Immediate score updates upon delivery completion
- Persistent score tracking during gameplay session
- Integration with UI display system

## Implementation Plan

### Phase 1: Core Scoring Logic (Claude Generated)
**Scripts to Generate:**
- `ScoreManager.cs` - Main scoring logic and persistence
- `ScoreEvents.cs` - Event system for score changes
- `ScoreDisplay.cs` - UI integration and formatting

**Scoring Rules:**
- Successful delivery: +10 points
- Failed delivery: -5 points
- Minimum score: 0 (no negative scores)
- Score persistence: Session-based

### Phase 2: Unity Setup (Human Required)
**Manual Unity Tasks:**
1. Create ScoreManager GameObject in scene
2. Set up UI Text components for score display
3. Configure score change animations/effects
4. Link scoring events with delivery system
5. Create score feedback visual effects

## Tasks Breakdown

### Claude Tasks (Scripts)
- [ ] **ScoreManager.cs**
  - Score tracking and calculation
  - Event subscription for delivery events
  - Score validation (minimum 0)
  - Session persistence logic
  - High score tracking (optional)
- [ ] **ScoreEvents.cs**
  - UnityEvent definitions for scoring
  - Event triggering methods
  - Score change event data structures
- [ ] **ScoreDisplay.cs**
  - UI text formatting and updates
  - Score change animations triggers
  - Real-time score display management

### Human Tasks (Unity Editor)
- [ ] **UI Setup**
  - Create Canvas for score display
  - Add TextMeshPro components for current score
  - Position score display in appropriate UI location
  - Configure text styling (font, size, color)
- [ ] **ScoreManager Integration**
  - Create ScoreManager GameObject in scene
  - Assign UI references to ScoreDisplay script
  - Configure scoring event listeners
- [ ] **Visual Feedback**
  - Create score change popup animations
  - Add particle effects for score gains/losses
  - Configure color changes (+green, -red)
  - Set up score milestone effects (optional)
- [ ] **Audio Integration**
  - Add sound effects for score changes
  - Configure audio clips for positive/negative scoring
  - Set up audio source components

## Event Integration Points

### Delivery System Integration
```csharp
// In DeliverySystem.cs
public static event System.Action<bool> OnDeliveryComplete;

// On successful delivery
OnDeliveryComplete?.Invoke(true);  // +10 points

// On failed delivery
OnDeliveryComplete?.Invoke(false); // -5 points
```

### UI Update Flow
1. Delivery completion triggers event
2. ScoreManager receives event and updates score
3. ScoreDisplay receives score change and updates UI
4. Visual/audio feedback plays

## Score Display Features
- Current score prominently displayed
- Score change animations (+10, -5)
- Optional high score tracking
- Score milestone celebrations (every 100 points)

## Acceptance Criteria
- [ ] Score increases by 10 on successful delivery
- [ ] Score decreases by 5 on failed delivery
- [ ] Score cannot go below 0
- [ ] UI updates immediately upon score changes
- [ ] Score persists throughout gameplay session
- [ ] Visual feedback clearly indicates score changes
- [ ] Audio feedback accompanies score changes

## Dependencies
- Package Delivery System (delivery completion events)
- Timer System (delivery failure detection)
- UI System (score display components)

## Data Persistence (Future Enhancement)
- Save high scores to PlayerPrefs
- Track delivery statistics
- Performance metrics (accuracy percentage)

## Estimated Time: 1-2 days
- Scripts: 3-4 hours
- UI setup and styling: 2-3 hours
- Animation and effects: 2-3 hours
- Integration and testing: 1-2 hours