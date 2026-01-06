# TicTacToe (GUTS Module)
This folder contains the complete TicTacToe module for the GUTS (Game Utility Template System) suite.
It includes a fully decoupled, framework‑agnostic gameplay engine and an optional Unity demo that showcases how to integrate the engine into a real scene.

The goal of this module is to demonstrate clean architecture, modular design, and beginner‑friendly patterns that scale to larger games.

## Module Overview
The TicTacToe module is split into two clear layers:
<pre>
Engine  →  Pure C# gameplay logic
Demo    →  Unity presentation layer (UI, SFX, VFX)
</pre>

This separation ensures:
- The engine is reusable in any environment
- The Unity demo is optional and replaceable
- Presentation logic never pollutes gameplay logic
- Beginners can learn clean architecture from a small, approachable example

## Folder Structure
<pre>
TicTacToe/
├── Engine/        # Pure C# gameplay logic (no Unity dependencies)
└── Demo/          # Optional Unity presentation layer
</pre>

Each folder contains its own README with deeper details.

## Architecture Summary

### Engine Layer
A deterministic, framework‑agnostic implementation of TicTacToe.

Handles:
- Board state
- Move validation
- Turn order
- Win detection (including multiple simultaneous lines)
- Draw detection
- Exposing results and winning positions

The engine is intentionally simple, readable, and easy to extend.

### Demo Layer
A Unity‑based example showing how to present the engine visually.

Includes:
- UI logic
- Button interactions
- Audio feedback
- UI animations
- Camera color transitions
- Event‑driven communication

The demo is designed to be lightweight and educational.

## Extending the Module
The TicTacToe module is intentionally small, but the architecture supports:
- NxN boards
- Variable win lengths
- AI opponents
- Undo/redo
- Replay systems
- Analytics
- Networked multiplayer
- Custom themes or skins
- Alternative UI layouts

All without modifying the core engine.

## Why This Module Exists
This TicTacToe implementation serves as a template for future GUTS modules.

It demonstrates:
- Clean separation of engine vs. presentation
- Event‑driven Unity architecture
- Beginner‑friendly code organization
- Reusable patterns for UI, SFX, and VFX
- A professional project structure

It’s a small game with big architectural lessons.
