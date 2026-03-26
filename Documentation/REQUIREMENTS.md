# Project Requirements Template

## 1. Project Overview
**Project Name:** delivery driver
**Version:** 1.0.0
**Date:** [Date]
**Author(s):** [Author Names]

### Purpose
This is a 2D top-down delivery game, where the player controls a driver who must pick up and deliver packages to clients across a map of size X × Y. Clients do not stay fixed during gameplay; instead, they appear randomly from a predefined list of valid spawn locations loaded from a configuration file.

The main challenge comes from navigation, time management, and route planning. The player must move efficiently through the map, find the active client, complete the delivery, and then continue serving new clients as they appear.

Each package delivered will grand 10 points to the score, while failing deliver a package will substract 5 points from the score.

The time to deliver will be calculated based on the distance from the driver and the new client.

### Scope
#### Functional requirements
-The game must use a 2D top-down view.
-The playable map must have a configurable size defined as X and Y.
-The player must control a driver that can move freely within the map bounds.
-The game must load client spawn locations from a configuration file.
-Each new delivery request must select one client location randomly from the valid configured locations.
-The player must have available a new package once one is delivered or the delivery time runs off.
-The player must deliver the package to the currently active client location.
-A successful delivery must add 10 points to the total score.
-A failed delivery must subtract 5 points from the total score.
-The allowed delivery time must be calculated from the distance between the driver and the newly assigned client.
-After a delivery is completed or failed, a new client request must be generated.

System rules
-Client spawn locations must always stay inside the map limits.
-Only one active delivery target should exist at a time.
-The score must be updated immediately after success or failure.
-The timer for a delivery must start when the new client is assigned.

## 2. Functional Requirements

### Core Features
- [ ] **Player Movement System**: Free movement within map boundaries using WASD or arrow keys
- [ ] **Dynamic Client System**: Random client spawning from predefined locations loaded from config file
- [ ] **Package Delivery System**: Pick up and deliver packages with success/failure tracking
- [ ] **Scoring System**: +10 points for successful deliveries, -5 points for failures
- [ ] **Timer System**: Dynamic delivery time calculation based on distance to client
- [ ] **Map Configuration**: Configurable X × Y map size with boundary enforcement
- [ ] **UI System**: Display score, timer, and current delivery status
- [ ] **Client Location Management**: Load and validate spawn locations from external config

### User Stories
- **As a** player, **I want** to control a delivery driver with smooth movement **so that** I can navigate efficiently
- **As a** player, **I want** to see a clear delivery timer **so that** I know how much time I have left
- **As a** player, **I want** to receive immediate score feedback **so that** I know my performance
- **As a** player, **I want** clients to appear in different locations **so that** the game remains challenging
- **As a** player, **I want** delivery time based on distance **so that** far deliveries are fairly timed

### Acceptance Criteria
- [ ] Driver must stay within configurable map boundaries at all times
- [ ] Only one active delivery target exists simultaneously
- [ ] Score updates immediately upon delivery completion or failure
- [ ] Timer starts when new client is assigned
- [ ] New delivery request generates after previous completion/failure
- [ ] Client locations load successfully from configuration file
- [ ] Distance-based time calculation works accurately

## 3. Non-Functional Requirements

### Performance
- [ ] Game must maintain 60 FPS on target platforms
- [ ] Input response time < 16ms for smooth controls
- [ ] Memory usage < 500MB on target devices
- [ ] Loading time for new client assignment < 100ms

### Security
- [ ] Configuration files must be validated on load
- [ ] No external network access required (offline game)
- [ ] Score data integrity protection

### Usability
- [ ] Clear visual indicators for delivery target
- [ ] Intuitive control scheme (WASD/Arrow keys)
- [ ] Readable UI elements for score and timer
- [ ] Visual feedback for successful/failed deliveries

### Compatibility
- [ ] Unity 6 (6000.3.x) with URP
- [ ] Windows, macOS, Linux support
- [ ] New Input System compatibility
- [ ] Configurable screen resolutions

## 4. Technical Requirements

### Technology Stack
- **Game Engine:** Unity 6 (6000.3.x)
- **Rendering:** Universal Render Pipeline (URP)
- **Input:** Unity New Input System
- **Language:** C# 9.0 with .NET Standard 2.1
- **Configuration:** JSON/ScriptableObject files

### System Architecture
- **MVC Pattern:** Separate Model (game data), View (UI), Controller (input/logic)
- **Component-Based:** Unity GameObject/Component architecture
- **Event System:** Observer pattern for delivery events and score updates
- **Configuration System:** External file loading for client spawn locations
- **State Management:** Game states (delivering, waiting, completed)

### Dependencies
- Unity Input System package
- Unity URP package
- JSON.NET for configuration parsing (if needed)
- Unity UI (TextMeshPro for text rendering)

## 5. Constraints and Assumptions

### Constraints
- Unity 6 LangVersion 9.0 limitation (no newer C# features)
- .NET Standard 2.1 target framework
- No AllowUnsafeBlocks (disabled in project)
- Single-player offline game only
- 2D graphics only (no 3D elements)

### Assumptions
- Players are familiar with basic WASD/Arrow key controls
- Configuration files will be properly formatted JSON
- Map size will be reasonable for gameplay (not excessively large)
- Players understand delivery game mechanics
- Target platform has Unity runtime support

## 6. Success Metrics

### Key Performance Indicators (KPIs)
- **Playability**: Game runs smoothly at 60 FPS
- **Functionality**: All core features work without crashes
- **Accuracy**: Scoring system calculates correctly 100% of the time
- **Responsiveness**: Input lag < 16ms for player movement

### Definition of Done
- [ ] Player can move freely within map boundaries
- [ ] Delivery system works with proper scoring (+10/-5)
- [ ] Timer calculates correctly based on distance
- [ ] Client locations load from configuration file
- [ ] Game handles delivery completion/failure cycles
- [ ] UI displays all required information clearly
- [ ] No critical bugs or crashes during gameplay
- [ ] Code follows Unity and C# best practices

## 7. Risk Assessment

| Risk | Impact | Probability | Mitigation Strategy |
|------|---------|-------------|-------------------|
| Configuration file corruption | Medium | Low | Validate config on load, provide default locations |
| Performance issues on low-end devices | High | Medium | Profile early, optimize movement and rendering |
| Complex distance calculation errors | Medium | Medium | Use Unity's built-in Vector2.Distance, unit test |
| Player confusion about delivery mechanics | Low | Medium | Clear UI indicators and visual feedback |
| Map boundary detection bugs | Medium | Low | Use Unity Collider2D for boundary enforcement |
| Timer synchronization issues | High | Low | Use Unity's Time system, avoid custom timers |

## 8. Timeline and Milestones

| Milestone | Target Date | Dependencies |
|-----------|-------------|--------------|
| Basic Player Movement | Week 1 | Unity project setup, Input System |
| Map System & Boundaries | Week 1 | Player movement complete |
| Client Spawning System | Week 2 | Map system, configuration loading |
| Delivery & Scoring Logic | Week 2 | Client system, player movement |
| Timer & Distance Calculation | Week 3 | Delivery system |
| UI Implementation | Week 3 | All core systems |
| Testing & Bug Fixes | Week 4 | Complete feature set |
| Final Polish & Documentation | Week 4 | Testing complete |

## 9. Approval

| Role | Name | Signature | Date |
|------|------|-----------|------|
| Project Owner | | | |
| Technical Lead | | | |
| Stakeholder | | | |

---

**Document Status:** [Draft/Under Review/Approved]
**Last Updated:** [Date]
**Next Review Date:** [Date]