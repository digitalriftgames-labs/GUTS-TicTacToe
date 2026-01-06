# GUTS — Game Utility Template System
GUTS is a growing collection of small, self‑contained game modules designed to demonstrate clean architecture, modular design, and practical patterns that scale to real projects.

Each module includes:
- A pure C# engine (framework‑agnostic, deterministic, and easy to test)
- An optional Unity demo layer (UI, SFX, VFX, and presentation logic)

The goal is to provide clear, reusable building blocks that emphasize separation of concerns, readability, and maintainability.

## Core Principles
### 1. Engine‑first architecture

Every module begins with a pure C# engine that contains all gameplay logic.
No Unity dependencies. No scene assumptions. No presentation code.

### 2. Optional Unity presentation layer

Unity demos show how to connect the engine to UI, audio, and effects.
These demos are intentionally lightweight and easy to replace or extend.

### 3. Clear separation of concerns

Each layer has a single responsibility:
<pre>
Engine → Gameplay logic
Demo   → Presentation logic
</pre>

This keeps modules predictable, testable, and easy to reason about.

### 4. Beginner‑friendly structure

GUTS modules are intentionally small and readable.
They serve as approachable examples of clean game architecture.

### 5. Scalable patterns
Even though the modules are simple, the patterns support:
- Larger boards
- AI players
- Undo/redo
- Replay systems
- Analytics
- Networking
- Custom UI themes

The architecture grows with the project.

## Folder Structure
<pre>
GUTS/
└── <ModuleName>/
    ├── Engine/   # Pure C# gameplay logic
    └── Demo/     # Optional Unity presentation layer
</pre>

Each module includes its own README with deeper details.

## Current Modules

### TicTacToe
A complete implementation of TicTacToe featuring:
- A deterministic engine
- Multi‑line win detection
- Clean board state management
- A Unity demo with UI, SFX, and VFX
- Clear examples of event‑driven presentation logic

More modules will follow this same structure.

## Extending GUTS
GUTS is designed to support additional modules over time.

New modules can reuse the same structure:
- an engine‑first design
- a clear separation between logic and presentation
- an optional Unity demo for showcasing the system

This approach keeps the suite flexible and scalable without increasing complexity.

## Why GUTS Exists
GUTS provides a structured, modular foundation for experimenting with game mechanics, teaching clean architecture, and building reusable systems.
It encourages clarity, intentional design, and scalable patterns — regardless of project size.
