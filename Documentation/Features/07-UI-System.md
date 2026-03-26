# Feature: UI System

## Overview
Complete user interface displaying score, timer, delivery status, and game information with clear visual hierarchy and responsive design.

## Requirements
- Real-time score display with change animations
- Countdown timer with visual urgency indicators
- Current delivery status and target information
- Game controls/instructions display
- Responsive UI scaling for different screen sizes

## Implementation Plan

### Phase 1: UI Controllers (Claude Generated)
**Scripts to Generate:**
- `UIManager.cs` - Main UI coordination and state management
- `HUDController.cs` - Heads-up display management
- `ScoreUI.cs` - Score display and animations
- `TimerUI.cs` - Timer display and visual effects
- `DeliveryStatusUI.cs` - Delivery information display

### Phase 2: Unity UI Setup (Human Required)
**Manual Unity Tasks:**
1. Create main Canvas with proper scaling
2. Design and position UI elements layout
3. Set up UI prefabs and components
4. Configure animations and transitions
5. Implement responsive design scaling

## Tasks Breakdown

### Claude Tasks (Scripts)
- [ ] **UIManager.cs**
  - Central UI state management
  - UI panel activation/deactivation
  - Event subscription for game state changes
  - UI animation coordination
- [ ] **HUDController.cs**
  - HUD element positioning and updates
  - Real-time game data display coordination
  - HUD visibility management
- [ ] **ScoreUI.cs**
  - Score text formatting and updates
  - Score change animation triggers
  - Color transitions for score changes
  - Score milestone visual effects
- [ ] **TimerUI.cs**
  - Timer display formatting (MM:SS)
  - Progress bar updates and visual states
  - Warning and critical state visual changes
  - Timer expiration effects
- [ ] **DeliveryStatusUI.cs**
  - Current delivery target information
  - Package status indicators
  - Distance to target display (optional)
  - Delivery progress visualization

### Human Tasks (Unity Editor)
- [ ] **Canvas Setup**
  - Create main Canvas with Screen Space - Overlay
  - Configure Canvas Scaler for multiple resolutions
  - Set up safe area handling for mobile (if needed)
  - Create UI hierarchy structure
- [ ] **HUD Layout Design**
  - Position score display (top-right corner)
  - Position timer display (top-center)
  - Position delivery status (top-left or bottom)
  - Ensure non-intrusive placement over gameplay
- [ ] **UI Components Creation**
  - Create TextMeshPro components for text displays
  - Add Image components for backgrounds/icons
  - Create Slider component for timer progress bar
  - Add Button components for controls (if needed)
- [ ] **Visual Styling**
  - Configure fonts, sizes, and colors
  - Create UI background panels with transparency
  - Add drop shadows or outlines for text readability
  - Set up consistent visual theme
- [ ] **Animation Setup**
  - Create score change popup animations
  - Set up timer warning pulse animations
  - Configure delivery status transition effects
  - Add UI feedback animations

## UI Layout Structure

### Main HUD Elements
```
┌─────────────────────────────┐
│ Status    Timer    Score    │
│                             │
│                             │
│         GAME AREA           │
│                             │
│                             │
│      [Instructions]         │
└─────────────────────────────┘
```

### Detailed Component Layout
- **Top-Left**: Delivery status, package indicator
- **Top-Center**: Timer with progress bar
- **Top-Right**: Current score with change animations
- **Bottom-Center**: Instructions/controls (optional)

## UI Data Binding

### Score Display
```csharp
// Subscribe to score changes
ScoreManager.OnScoreChanged += UpdateScoreDisplay;

// Display format: "Score: 150"
private void UpdateScoreDisplay(int newScore, int change)
{
    scoreText.text = $"Score: {newScore}";
    if (change != 0)
        ShowScoreChangeAnimation(change);
}
```

### Timer Display
```csharp
// Subscribe to timer updates
DeliveryTimer.OnTimerUpdate += UpdateTimerDisplay;

// Display format: "02:34"
private void UpdateTimerDisplay(float remainingTime)
{
    int minutes = (int)(remainingTime / 60);
    int seconds = (int)(remainingTime % 60);
    timerText.text = $"{minutes:00}:{seconds:00}";
}
```

### Delivery Status
```csharp
// Display current delivery information
"Deliver to: Office Complex B"
"Distance: 15.2 units"
"Package: In Transit"
```

## Visual States and Animations

### Score Animations
- **Positive Score**: Green popup with +X animation
- **Negative Score**: Red popup with -X animation
- **Milestone**: Special effect every 100 points

### Timer Visual States
- **Normal (>60%)**: White/green text, steady progress bar
- **Warning (30-60%)**: Yellow text, slow pulse animation
- **Critical (<30%)**: Red text, fast pulse, warning icon

### Delivery Status
- **No Package**: "Waiting for new delivery..."
- **Package Available**: "Pick up package!"
- **In Transit**: "Deliver to: [Client Name]"
- **Delivered**: "Delivery complete!" (brief message)

## Responsive Design Features
- Canvas Scaler with "Scale With Screen Size" mode
- UI elements anchor to appropriate screen edges
- Text scaling based on screen resolution
- Minimum/maximum UI element sizes

## Accessibility Features
- High contrast text with outlines/shadows
- Large, readable font sizes
- Color-blind friendly color schemes
- Clear visual hierarchy and spacing

## Acceptance Criteria
- [ ] Score displays accurately and updates immediately
- [ ] Timer shows MM:SS format with proper countdown
- [ ] Progress bar reflects timer state visually
- [ ] Delivery status information is clear and current
- [ ] Score change animations play correctly
- [ ] Timer warning states trigger at proper thresholds
- [ ] UI scales properly on different screen sizes
- [ ] All text is readable against game background
- [ ] UI doesn't obstruct important gameplay elements

## Dependencies
- Scoring System (score updates)
- Timer System (countdown display)
- Package Delivery System (delivery status)
- Dynamic Client System (target information)

## Future Enhancements
- Settings/options menu
- Pause menu
- High score display
- Statistics screen
- Achievement notifications

## Estimated Time: 2-3 days
- Scripts: 4-5 hours
- UI layout and design: 4-6 hours
- Animation setup: 2-3 hours
- Responsive design configuration: 2-3 hours
- Testing and polish: 2-3 hours