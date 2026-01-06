# TicTacToe Engine
This folder contains the pure C# gameplay engine for the TicTacToe module of the GUTS (Game Utility Template System) suite.
It implements all game rules, state transitions, and win detection without any Unity dependencies.

The engine is designed to be:
- Framework‑agnostic (usable in Unity, console apps, tests, or other engines)
- Beginner‑friendly (clear, readable, minimal abstractions)
- Modular (UI, audio, and VFX live entirely outside this layer)
- Deterministic (no randomness except for choosing the starting player)
- Easy to extend (NxN boards, AI players, analytics, etc.)

This is the authoritative source of truth for TicTacToe gameplay.

## Responsibilities of the Engine
The engine handles:
- Board state management
- Move validation
- Turn order
- Win detection (including multiple simultaneous winning lines)
- Draw detection
- Exposing game state to external systems

It does not handle:
- UI
- Audio
- Visual effects
- Input
- Scene logic

Those belong in the Demo layer.

## Folder Structure
<pre>
Engine/
├── BoardState.cs
├── Enums.cs
├── GameRules.cs
├── Position.cs
├── TicTacToeEngine.cs
└── WinInfo.cs
</pre>
Each file has a clear, single responsibility.

## Script Overview
### BoardState.cs
Represents the 3×3 grid.

Handles:
- Storing cell values
- Clearing the board
- Index ↔ position conversion
- Safe access via indexers
- Returning a copy of the grid

This class contains no game logic — only board data.

### Enums.cs
Defines the core enums used throughout the engine:
- Player (None, O, X)
- GameResult (Ongoing, Draw, OWins, XWins)

Simple, explicit, and easy to extend.

### GameRules.cs
Contains all rule logic for determining:
- Winning lines
- Multiple simultaneous wins
- Overlapping win positions
- Draw conditions
- Ongoing state

This class is stateless and purely functional.

### Position.cs
A lightweight struct representing a grid coordinate.

Implements:
- Value equality
- Hashing
- Debug‑friendly ToString()

Used throughout the engine for clarity and safety.

### TicTacToeEngine.cs
The main gameplay controller.

Responsible for:
- Starting new games
- Tracking the current player
- Validating moves
- Applying moves
- Switching turns
- Evaluating game state via GameRules
- Exposing results and winning positions

This is the class external systems interact with.

### WinInfo.cs
A simple struct returned by GameRules.

Contains:
- The GameResult
- All winning positions (deduplicated)

This allows UI layers to highlight all winning cells, even when multiple lines are present.

## Architecture Summary
<pre>
TicTacToeEngine
↑
GameRules (pure logic)
↑
BoardState (data only)
↑
Position / Enums / WinInfo (support types)
</pre>

This layered approach keeps the engine:
- predictable
- testable
- easy to reason about
- easy to port to other platforms

## Extending the Engine
The engine is intentionally simple but designed for growth.

You can extend it with:
- NxN boards
- Variable win lengths
- AI players
- Undo/redo
- Replay systems
- Analytics
- Networked multiplayer

All without touching the Unity demo layer.
