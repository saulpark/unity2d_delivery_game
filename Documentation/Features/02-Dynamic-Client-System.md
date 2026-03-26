# Feature: Dynamic Client System

## Overview
Random client spawning from predefined locations loaded from configuration file, with only one active client at a time.

## Requirements
- Load spawn locations from JSON configuration file
- Random client selection from valid locations
- Visual indicators for active client
- Client locations stay within map bounds
- Only one active delivery target exists simultaneously

## Implementation Plan

### Phase 1: Configuration & Logic (Claude Generated)
**Scripts to Generate:**
- `ClientSpawnData.cs` - Data structure for spawn locations
- `ClientManager.cs` - Client spawning and management logic
- `ClientLocation.cs` - Individual client behavior
- `ConfigLoader.cs` - JSON configuration loading

**Configuration Structure:**
```json
{
  "spawnLocations": [
    {"x": 10, "y": 15, "name": "House A"},
    {"x": 25, "y": 30, "name": "Office B"}
  ],
  "mapBounds": {"width": 50, "height": 50}
}
```

### Phase 2: Unity Setup (Human Required)
**Manual Unity Tasks:**
1. Create client prefab with visual indicator
2. Set up spawn point markers in scene
3. Create configuration JSON file
4. Place ClientManager in scene
5. Configure client visual states (active/inactive)

## Tasks Breakdown

### Claude Tasks (Scripts)
- [ ] **ClientSpawnData.cs**
  - Serializable data structure for locations
  - Validation methods for spawn points
  - JSON serialization support
- [ ] **ClientManager.cs**
  - Configuration file loading
  - Random client selection logic
  - Active client tracking
  - Client spawning/despawning
- [ ] **ClientLocation.cs**
  - Individual client behavior
  - Active/inactive state management
  - Visual indicator control
- [ ] **ConfigLoader.cs**
  - JSON file reading and parsing
  - Error handling for corrupt configs
  - Default location fallback

### Human Tasks (Unity Editor)
- [ ] **Prefab Creation**
  - Create Client prefab
  - Add visual components (SpriteRenderer)
  - Add Collider2D for interaction detection
  - Set up active/inactive visual states
- [ ] **Configuration Setup**
  - Create clients-config.json in StreamingAssets
  - Define initial spawn locations
  - Validate locations are within map bounds
- [ ] **Scene Integration**
  - Place ClientManager GameObject
  - Assign client prefab reference
  - Configure spawn point visualization (optional)
- [ ] **Visual Design**
  - Create client sprites/icons
  - Design active client indicators (glow, arrow, etc.)
  - Set up particle effects (optional)

## Configuration File Format
```json
{
  "spawnLocations": [
    {"x": 5.0, "y": 10.0, "name": "Residential Area A", "type": "house"},
    {"x": 15.0, "y": 20.0, "name": "Office Complex B", "type": "office"},
    {"x": 25.0, "y": 5.0, "name": "Shopping Center C", "type": "shop"}
  ],
  "mapBounds": {
    "minX": 0, "maxX": 50,
    "minY": 0, "maxY": 50
  }
}
```

## Acceptance Criteria
- [ ] Configuration loads successfully on game start
- [ ] Only one client is active at any time
- [ ] Client spawns randomly from valid locations
- [ ] Active client has clear visual indication
- [ ] All spawn points stay within map boundaries
- [ ] System handles configuration errors gracefully

## Dependencies
- Map system for boundary validation
- JSON parsing capability (Unity JsonUtility or Newtonsoft)

## Estimated Time: 2-3 days
- Scripts: 4-5 hours
- Configuration setup: 1-2 hours
- Unity prefab/scene work: 3-4 hours
- Testing/debugging: 2-3 hours