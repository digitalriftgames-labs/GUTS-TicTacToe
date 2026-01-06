# TicTacToe Demo
This folder contains the Unity demo layer for the TicTacToe module of the GUTS (Game Utility Template System) suite.
It demonstrates how to connect the pure C# engine to Unity UI, audio, and visual effects in a clean, modular, and beginner‑friendly way.

The demo is intentionally lightweight and fully optional — all gameplay logic lives in the Engine folder.
This layer simply shows how to present that logic inside a Unity scene.

## Purpose of This Demo
- Provide a simple, readable example of how to integrate the engine into Unity
- Demonstrate clean, event‑driven UI and effects
- Keep all presentation logic separate from gameplay logic
- Offer a template beginners can safely extend
- Maintain a clear architectural boundary between engine and UI

## Folder Structure
<pre>
Demo/
└── Scripts/
    ├── GridButton.cs
    ├── TicTacToeEvents.cs
    ├── TicTacToeGame.cs
    ├── TicTacToeUI.cs
    ├── TicTacToeSFX.cs
    ├── TicTacToeUIFX.cs
    └── TicTacToeVFX.cs
</pre>

Each script has a single, well‑defined responsibility.

## Script Overview
### GridButton.cs
Represents a single cell on the board.

Handles:
- Displaying X/O/empty
- Interactable state
- Highlighting winning cells

### TicTacToeEvents.cs
A simple event hub used by the demo layer.

Allows decoupled communication between:
- UI
- SFX
- UIFX
- VFX
- Game wrapper

The engine does not depend on these events.

### TicTacToeGame.cs
A thin wrapper around the pure engine.

Responsible for:
- Starting new games
- Making moves
- Exposing engine state
- Converting between Unity and engine types

Keeps Unity‑specific code out of the engine.

### TicTacToeUI.cs
The main UI controller.

Handles:
- Button clicks
- Updating the board
- Updating status text
- Triggering demo events
- Managing interactability

Acts as the glue between the engine and the presentation layer.

### TicTacToeSFX.cs
Optional audio layer.

Listens to demo events and plays:
- Move sounds
- Reject sounds
- Win/Draw sounds
- New game sound

If no clips are assigned, logs what would have played.

### TicTacToeUIFX.cs
Optional UI animation layer.

Adds small, delightful polish such as:
- Button pop animation when a move is made

Purely visual — no gameplay logic.

### TicTacToeVFX.cs
Optional scene‑level visual effects.

Currently handles:
- Smooth camera background color transitions based on game state
(ongoing, X wins, O wins, draw)

This is the only non‑UI visual effect in the demo.

## Architecture Summary
<pre>
Engine (pure C#)
↑
TicTacToeGame (Unity wrapper)
↑
UI / SFX / UIFX / VFX (presentation layer)
↑
Unity Scene
</pre>

This ensures:
- The engine is reusable anywhere
- The demo is easy to understand and modify
- Presentation logic never pollutes gameplay logic

## Extending the Demo
You can safely add:
- Custom animations
- New UI layouts
- Additional SFX/VFX
- Themes or skins
- AI players
- Analytics or replay systems

All without touching the engine.
