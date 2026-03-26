# Feature: Client Location Management

## Overview
Advanced management of client spawn locations including configuration loading, validation, dynamic location updates, and integration with all game systems.

## Requirements
- Load client locations from external configuration file
- Validate spawn points are within map boundaries
- Support different client types (house, office, shop)
- Enable runtime location updates and management
- Provide fallback locations for error handling

## Implementation Plan

### Phase 1: Location Management Logic (Claude Generated)
**Scripts to Generate:**
- `ClientLocationManager.cs` - Main location management system
- `LocationValidator.cs` - Spawn point validation and verification
- `ClientLocationData.cs` - Data structures for location information
- `LocationConfigLoader.cs` - Configuration file parsing and loading

### Phase 2: Unity Setup (Human Required)
**Manual Unity Tasks:**
1. Create and configure JSON configuration files
2. Set up location visualization tools (editor-only)
3. Create different client prefabs for location types
4. Configure StreamingAssets folder structure
5. Set up location debugging visual aids

## Tasks Breakdown

### Claude Tasks (Scripts)
- [ ] **ClientLocationManager.cs**
  - Central location management hub
  - Available location pool maintenance
  - Location selection algorithms (random, weighted)
  - Integration with client spawning system
  - Location usage tracking
- [ ] **LocationValidator.cs**
  - Spawn point boundary validation
  - Overlap detection with existing objects
  - Distance validation between locations
  - Configuration integrity checking
- [ ] **ClientLocationData.cs**
  - Serializable location data structures
  - Location metadata (name, type, coordinates)
  - Location grouping and categorization
  - Custom location properties
- [ ] **LocationConfigLoader.cs**
  - JSON configuration file parsing
  - Error handling and recovery
  - Default location generation
  - Configuration hot-reloading support

### Human Tasks (Unity Editor)
- [ ] **Configuration File Creation**
  - Create client-locations.json in StreamingAssets
  - Define comprehensive location dataset
  - Organize locations by type and area
  - Include location metadata and descriptions
- [ ] **Location Visualization Tools**
  - Create editor script for location preview
  - Add Gizmos for visualizing spawn points in Scene view
  - Create location validation tools in editor
  - Set up location testing and verification system
- [ ] **Client Type Prefabs**
  - Create distinct prefabs for different client types
  - Configure visual differences (house, office, shop icons)
  - Set up client-specific interaction zones
  - Add type-specific visual effects
- [ ] **StreamingAssets Setup**
  - Create StreamingAssets folder structure
  - Organize configuration files properly
  - Set up version control inclusion for configs
  - Create backup/default configuration files

## Configuration File Structure

### Main Configuration Format
```json
{
  "version": "1.0",
  "mapBounds": {
    "minX": 0, "maxX": 50,
    "minY": 0, "maxY": 50
  },
  "locationTypes": ["house", "office", "shop"],
  "locations": [
    {
      "id": "loc_001",
      "name": "Suburban House A",
      "type": "house",
      "position": {"x": 5.5, "y": 12.3},
      "metadata": {
        "description": "Cozy suburban home",
        "difficulty": "easy",
        "weight": 1.0
      }
    },
    {
      "id": "loc_002",
      "name": "Downtown Office",
      "type": "office",
      "position": {"x": 25.7, "y": 18.9},
      "metadata": {
        "description": "Busy office complex",
        "difficulty": "medium",
        "weight": 1.5
      }
    }
  ]
}
```

### Location Categories
- **Houses**: Residential areas, easier access
- **Offices**: Business districts, medium difficulty
- **Shops**: Commercial areas, varied accessibility

## Advanced Features

### Location Selection Algorithms
```csharp
public enum LocationSelectionMode
{
    Random,           // Pure random selection
    Weighted,         // Based on location weight/difficulty
    DistanceBased,    // Consider distance from current position
    TypeRotation      // Ensure variety in location types
}
```

### Location Metadata
- **Difficulty Rating**: Easy, Medium, Hard
- **Selection Weight**: Probability modifier
- **Accessibility**: Special requirements or obstacles
- **Visual Theme**: Styling information for client appearance

### Validation Rules
- All locations must be within map boundaries
- Minimum distance between locations (avoid clustering)
- Maximum locations per area/quadrant
- Type distribution requirements

## Integration Points

### Client Manager Integration
```csharp
// Get next client location
ClientLocationData nextLocation = ClientLocationManager.GetNextLocation();

// Validate location before spawning
bool isValid = LocationValidator.ValidateLocation(nextLocation);

// Mark location as used
ClientLocationManager.MarkLocationUsed(nextLocation.id);
```

### Map System Integration
```csharp
// Validate all locations against current map bounds
bool allValid = LocationValidator.ValidateAllLocations(MapManager.GetMapBounds());

// Update locations when map size changes
ClientLocationManager.RefreshLocationValidation();
```

## Error Handling and Fallbacks

### Configuration Loading Errors
1. **File Not Found**: Use built-in default locations
2. **Parse Error**: Load backup configuration
3. **Invalid Data**: Filter out invalid locations, continue with valid ones
4. **Empty Configuration**: Generate procedural locations

### Runtime Error Handling
- Location validation failures
- Out-of-bounds location correction
- Duplicate location prevention
- Emergency location generation

## Development Tools

### Editor Extensions (Future Enhancement)
- Visual location editor in Scene view
- Location testing and validation tools
- Configuration file hot-reload
- Location distribution analysis

### Debug Features
- Location usage statistics
- Visual spawn point indicators
- Configuration validation reports
- Location accessibility testing

## Acceptance Criteria
- [ ] Configuration loads successfully from JSON file
- [ ] All locations validate within map boundaries
- [ ] Location selection provides good variety
- [ ] Error handling works for all failure scenarios
- [ ] Location types are properly differentiated
- [ ] Integration with client spawning works seamlessly
- [ ] Configuration can be updated without code changes
- [ ] Location validation prevents invalid spawn attempts

## Dependencies
- Map Configuration System (boundary validation)
- Dynamic Client System (location usage)
- File I/O system (configuration loading)

## Performance Considerations
- Cache loaded locations for fast access
- Minimize file I/O during gameplay
- Efficient location selection algorithms
- Pre-validate locations on game start

## Security Considerations
- Validate all configuration data on load
- Prevent buffer overflow with location arrays
- Sanitize location names and descriptions
- Handle malformed JSON gracefully

## Estimated Time: 2-3 days
- Scripts: 5-6 hours
- Configuration creation: 2-3 hours
- Validation and testing tools: 3-4 hours
- Integration testing: 2-3 hours
- Error handling and edge cases: 2-3 hours