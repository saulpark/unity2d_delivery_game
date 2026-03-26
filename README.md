# Unity 2D Delivery Game

A 2D top-down delivery game built with Unity 6, where players control a delivery driver navigating through a configurable map to deliver packages to randomly spawning clients.

## 🎮 Game Overview

### Core Gameplay
- **Control a delivery driver** in a 2D top-down view
- **Navigate through a configurable map** with dynamic boundaries
- **Pick up and deliver packages** to randomly appearing clients
- **Race against time** with distance-based delivery deadlines
- **Score points** (+10 for success, -5 for failure) and track your performance

### Key Features
- **Dynamic Client System**: Clients spawn randomly from predefined locations loaded from configuration files
- **Distance-Based Timing**: Delivery time calculated based on distance between driver and client
- **Configurable Map**: Adjustable X × Y map dimensions
- **Scoring System**: Immediate feedback with visual and audio cues
- **Responsive Controls**: Smooth WASD/Arrow key movement with Unity's New Input System

## 🛠️ Technical Specifications

### Built With
- **Unity 6** (6000.3.x)
- **Universal Render Pipeline (URP)**
- **Unity New Input System**
- **C# 9.0** with .NET Standard 2.1

### Requirements
- Unity 6 or later
- Input System package
- TextMeshPro for UI
- Universal Render Pipeline

## 📁 Project Structure

```
├── Assets/                    # Unity assets, scripts, and scenes
├── Packages/                  # Unity package manifest
├── ProjectSettings/           # Unity project settings (version controlled)
├── Documentation/             # Complete project documentation
│   ├── REQUIREMENTS.md        # Project requirements and specifications
│   ├── DEVELOPMENT-PLAN.md    # 4-week implementation roadmap
│   └── Features/              # Individual feature implementation plans
└── CLAUDE.md                  # AI assistant instructions for development
```

## 📖 Documentation

Complete project documentation is available in the [`Documentation/`](Documentation/) folder:

1. **[REQUIREMENTS.md](Documentation/REQUIREMENTS.md)** - Complete project specifications
2. **[DEVELOPMENT-PLAN.md](Documentation/DEVELOPMENT-PLAN.md)** - 4-week implementation timeline
3. **[Features/](Documentation/Features/)** - Detailed feature implementation plans

### Feature Implementation Order
1. **Week 1**: Map Configuration + Player Movement (Foundation)
2. **Week 2**: Client Location Management + Dynamic Client System (Content)
3. **Week 3**: Timer System + Package Delivery System (Gameplay Loop)
4. **Week 4**: Scoring System + UI System (User Experience)

## 🚀 Getting Started

### Prerequisites
- Unity 6 (6000.3.x) or later
- Git

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/[username]/unity2d_delivery_game.git
   ```
2. Open the project in Unity Hub
3. Ensure you have the required packages installed:
   - Input System
   - Universal Render Pipeline
   - TextMeshPro

### Development Setup
1. Read the [Documentation/README.md](Documentation/README.md) for complete guidance
2. Follow the implementation order in [DEVELOPMENT-PLAN.md](Documentation/DEVELOPMENT-PLAN.md)
3. Each feature has detailed plans in the [`Documentation/Features/`](Documentation/Features/) folder

## 🎯 Development Status

**Current Phase**: Project Setup and Documentation Complete

**Estimated Total Development Time**: 63-82 hours
- Scripts and Logic: 30-38 hours
- Unity Editor Tasks: 33-44 hours

**Next Steps**:
1. Implement Map Configuration System
2. Create Player Movement System
3. Set up Client Location Management

## 🤝 Development Approach

This project uses a hybrid development approach:
- **AI-Generated Scripts**: Core game logic, algorithms, and data structures
- **Manual Unity Work**: Scene setup, prefabs, UI design, and visual polish

Each feature includes clear separation of automated and manual tasks for efficient development.

## 📝 Game Design

### Scoring System
- **+10 points** for successful deliveries
- **-5 points** for failed deliveries (timeout)
- **Minimum score**: 0 (no negative scores)

### Timer Mechanics
- **Time Calculation**: `Base Time = Distance × Multiplier + Buffer Time`
- **Visual Warnings**: Color changes at 60% and 30% remaining time
- **Audio Cues**: Warning sounds during critical countdown phases

### Map Features
- **Configurable Dimensions**: Adjustable X × Y map size
- **Boundary Enforcement**: Hard collision boundaries prevent out-of-bounds movement
- **Client Validation**: All spawn locations validated within map bounds

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🔮 Future Enhancements

- Multiple difficulty levels
- Power-ups and special package types
- Achievement system
- Leaderboards and statistics
- Weather effects and day/night cycles
- Additional client types and interaction mechanics