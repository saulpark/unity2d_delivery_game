# Feature: Player Movement System

## Overview
Implement free movement for the delivery driver within configurable map boundaries using WASD/Arrow keys.

## Requirements
- Smooth 2D movement in top-down view
- Boundary enforcement within map limits
- Input handling via Unity's New Input System
- Responsive controls (<16ms input lag)

## Implementation Plan

### Phase 1: Basic Movement (Claude Generated)
**Scripts to Generate:**
- `PlayerController.cs` - Main player movement logic
- `PlayerInput.cs` - Input handling wrapper
- `MapBoundary.cs` - Boundary enforcement system

**Key Components:**
- Rigidbody2D for physics-based movement
- Input Actions for WASD/Arrow keys
- Boundary collision detection

### Phase 2: Unity Setup (Human Required)
**Manual Unity Tasks:**
1. Create Player GameObject in scene
2. Add Rigidbody2D component to player
3. Add Collider2D (CircleCollider2D or BoxCollider2D)
4. Create Input Action Asset for movement
5. Assign player sprite/visual representation
6. Set up camera to follow player
7. Create boundary colliders or trigger zones

## Tasks Breakdown

### Claude Tasks (Scripts)
- [ ] **PlayerController.cs**
  - Movement logic using Rigidbody2D
  - Speed configuration
  - Boundary checking integration
- [ ] **PlayerInput.cs**
  - New Input System integration
  - WASD/Arrow key mapping
  - Input vector calculation
- [ ] **MapBoundary.cs**
  - Boundary limit enforcement
  - Position clamping within map bounds

### Human Tasks (Unity Editor)
- [ ] **Scene Setup**
  - Create Player GameObject
  - Add and configure Rigidbody2D
  - Add appropriate Collider2D
  - Assign player sprite
- [ ] **Input Configuration**
  - Create Input Action Asset
  - Configure movement action bindings
  - Link Input Action to PlayerInput script
- [ ] **Camera Setup**
  - Configure camera to follow player
  - Set appropriate camera bounds
- [ ] **Visual Setup**
  - Import/create player sprite
  - Set up sprite animation (if needed)
  - Configure sorting layers

## Acceptance Criteria
- [ ] Player moves smoothly in all four directions
- [ ] Movement stops at map boundaries
- [ ] Input response time < 16ms
- [ ] No clipping through boundary colliders
- [ ] Camera follows player appropriately

## Dependencies
- Unity New Input System package
- Map system for boundary definitions

## Estimated Time: 1-2 days
- Scripts: 2-3 hours
- Unity setup: 3-4 hours
- Testing/refinement: 1-2 hours