# Feature: Map Configuration System

## Overview
Configurable X × Y map size with boundary enforcement, visual representation, and integration with all game systems.

## Requirements
- Configurable map dimensions (X × Y units)
- Visual map boundaries and background
- Boundary enforcement for player movement
- Integration with client spawn validation
- Scalable map representation

## Implementation Plan

### Phase 1: Map Logic (Claude Generated)
**Scripts to Generate:**
- `MapManager.cs` - Main map configuration and management
- `MapBoundary.cs` - Boundary enforcement system
- `MapRenderer.cs` - Visual map representation
- `MapConfig.cs` - Serializable map configuration data

**Map Configuration:**
```json
{
  "mapDimensions": {"width": 50, "height": 50},
  "boundaryType": "hard", // "hard" or "soft"
  "backgroundTileSize": 1.0,
  "visualGrid": true
}
```

### Phase 2: Unity Setup (Human Required)
**Manual Unity Tasks:**
1. Create map background sprites/tiles
2. Set up boundary colliders or invisible walls
3. Configure camera bounds to match map
4. Create visual grid or map markers
5. Set up map background rendering

## Tasks Breakdown

### Claude Tasks (Scripts)
- [ ] **MapManager.cs**
  - Map configuration loading and validation
  - Boundary coordinate calculation
  - Integration with other systems
  - Runtime map size adjustments
- [ ] **MapBoundary.cs**
  - Boundary enforcement for GameObjects
  - Position clamping within map limits
  - Boundary collision detection
  - Integration with player movement
- [ ] **MapRenderer.cs**
  - Dynamic map background generation
  - Grid visualization (optional)
  - Boundary visualization
  - Scalable rendering system
- [ ] **MapConfig.cs**
  - Serializable configuration structure
  - Default map settings
  - Validation methods for map dimensions

### Human Tasks (Unity Editor)
- [ ] **Background Setup**
  - Create or import map background sprites
  - Set up tilemap system for large maps
  - Configure sprite tiling for seamless backgrounds
  - Set up multiple background layers (optional)
- [ ] **Boundary Creation**
  - Create invisible boundary colliders around map edges
  - Set up BoxCollider2D components as walls
  - Configure boundary GameObject placement
  - Set up boundary trigger zones (optional warnings)
- [ ] **Camera Configuration**
  - Set camera bounds to match map dimensions
  - Configure camera constraints (don't show outside map)
  - Set up camera following with map limits
  - Adjust orthographic camera size for map scale
- [ ] **Visual Elements**
  - Create grid overlay sprites (if desired)
  - Add map corner markers or landmarks
  - Set up lighting and visual effects
  - Configure sorting layers for map elements

## Map Coordinate System
- **Origin (0,0)**: Bottom-left corner of map
- **Max Coordinates**: (mapWidth, mapHeight)
- **Units**: Unity world units
- **Client Spawning**: Within map bounds validation

## Configuration Structure
```csharp
[System.Serializable]
public class MapConfiguration
{
    [Header("Map Dimensions")]
    public float mapWidth = 50f;
    public float mapHeight = 50f;

    [Header("Boundary Settings")]
    public BoundaryType boundaryType = BoundaryType.Hard;
    public float boundaryThickness = 0.5f;

    [Header("Visual Settings")]
    public bool showGrid = false;
    public float gridSpacing = 5f;
    public Color gridColor = Color.white;

    [Header("Background")]
    public bool useRepeatingBackground = true;
    public float backgroundTileSize = 1f;
}
```

## Integration Points

### Player Movement Integration
```csharp
// Clamp player position within map bounds
Vector2 clampedPosition = MapManager.ClampToMapBounds(playerPosition);
```

### Client Spawn Validation
```csharp
// Validate client spawn location is within map
bool isValidSpawn = MapManager.IsPositionWithinBounds(spawnPosition);
```

### Camera Bounds
```csharp
// Set camera movement limits based on map size
CameraController.SetBounds(MapManager.GetMapBounds());
```

## Boundary Types

### Hard Boundaries
- Physical colliders prevent movement outside map
- Immediate stopping at boundary edges
- No position correction needed

### Soft Boundaries
- Position clamping without physics collision
- Smooth movement restriction
- Better for fluid gameplay

## Visual Map Features
- Optional grid overlay for navigation aid
- Corner markers for map limits visualization
- Background tiling for large maps
- Minimap integration support (future feature)

## Acceptance Criteria
- [ ] Map dimensions are configurable via settings
- [ ] Player cannot move outside map boundaries
- [ ] Client spawn locations validate against map bounds
- [ ] Camera respects map limits during following
- [ ] Map background scales with configured dimensions
- [ ] Boundary enforcement works consistently
- [ ] Grid overlay displays correctly (if enabled)
- [ ] Map configuration loads from external file

## Dependencies
- Player Movement System (boundary enforcement)
- Dynamic Client System (spawn validation)
- Camera system (bounds constraint)

## Performance Considerations
- Efficient boundary checking (avoid per-frame calculations)
- Optimized background rendering for large maps
- Minimal garbage collection from boundary operations

## Estimated Time: 1-2 days
- Scripts: 3-4 hours
- Background and visual setup: 2-3 hours
- Boundary collision setup: 1-2 hours
- Camera integration: 1-2 hours
- Testing and optimization: 1-2 hours