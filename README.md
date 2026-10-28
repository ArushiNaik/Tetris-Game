# Tetris Game

A classic Tetris clone built in Unity with Tilemaps and the Input System. This project recreates the core gameplay loop of falling tetrominoes, line clearing, and fast arcade-style decisions in a clean, readable C# codebase.

<p align="center">
  <img src="https://img.shields.io/badge/Engine-Unity-000000?style=for-the-badge&logo=unity" alt="Unity" />
  <img src="https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=csharp" alt="C#" />
  <img src="https://img.shields.io/badge/Status-Playable-4CAF50?style=for-the-badge" alt="Playable" />
</p>

## Overview

This repository contains a playable Tetris project using Unity 2D, with a grid-based board, falling pieces, collision detection, and line-clearing logic. The project is intentionally lightweight and structured to be easy to follow, making it a good starting point for learning Unity gameplay systems or expanding with new features.

## Features

- 7 classic tetromino shapes: I, O, T, L, J, S, and Z
- Tilemap-based board and falling piece logic
- Row detection and automatic line clearing
- Keyboard controls for movement and rotation
- Clean C# architecture with small, readable gameplay scripts
- Simple Unity scene setup for quick experimentation

## Tech Stack

- Language: C#
- Engine: Unity
- Core systems: Tilemap, Input System, Unity scene workflow

## Getting Started

### Prerequisites

- Unity Editor (preferably a recent LTS version)
- A Unity project setup that supports Tilemaps and the Input System

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/ArushiNaik/Tetris-Game.git
   ```

2. Open the cloned folder in Unity Hub or directly in the Unity Editor.

3. Open the scene:

   ```text
   Assets/Tetris_AI.unity
   ```

4. Press Play to start the game.

### Notes

- If Unity prompts you to install or upgrade packages such as the Input System or Tilemap support, accept the prompt.
- Some Unity versions may ask to upgrade the project; this is normal for older Unity projects.

## Controls

- Left Arrow: move left
- Right Arrow: move right
- Up Arrow: rotate piece
- Down Arrow: soft drop / speed up descent

Controls are defined in the project scripts and input configuration files, including:

- `Assets/Codes/Group.cs`
- `Assets/InputSystem_Actions.inputactions`

## Key Scripts

- `Assets/Codes/Grid.cs` — manages the locked board, grid state, and full-row deletion
- `Assets/Codes/Group.cs` — handles tetromino movement, rotation, and locking behavior
- `Assets/Codes/Spawner.cs` — spawns tetromino pieces and assigns visuals

These scripts form the core gameplay loop: the spawner creates a falling piece, the piece controls movement and rotation, and the grid handles locking and row clearing.

## Project Structure

```text
Assets/
  Codes/            Core gameplay scripts
  Scenes/           Unity scenes
  *.prefab          Tetromino prefabs and tile assets
  tetrisbrick*      Tile and image assets
Packages/            Unity package configuration
ProjectSettings/     Unity project settings
Tetris.slnx         Generated Unity solution file
```

## How It Works

1. The spawner creates a new falling tetromino object.
2. The piece chooses a random shape and color, then draws itself on a falling Tilemap.
3. Player input updates the movement and rotation of the active piece.
4. When the piece can no longer move downward, it locks into place.
5. The grid checks for full rows and clears them to keep the game progressing.

## Roadmap

Ideas for future improvements:

- Add score, level progression, and line counter
- Implement hard drop and hold-piece mechanics
- Add a next-piece preview
- Improve UI and visual polish
- Add sound effects and background music
- Expand with testing and gameplay balancing

## Contributing

Contributions are welcome. If you want to improve the project, consider adding gameplay features, smoothing the controls, or refining the Unity project structure.

## License

There is no license file included in this repository yet. If you plan to share or distribute this project publicly, consider adding an open-source license such as the MIT License.

## Contact

Created by [@ArushiNaik](https://github.com/ArushiNaik). Feel free to open issues or pull requests with suggestions and improvements.
