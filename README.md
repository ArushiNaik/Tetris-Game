# Tetris 🧩

**Unity 6000.3.10f1 · C#**

Falling pieces, tight spaces and one more cleared line. A Unity project focused on grid-based movement and a compact gameplay loop.

[Portfolio](https://github.com/ArushiNaik) · [Browse source](https://github.com/ArushiNaik/Tetris-Game)

## What to explore

- Tetromino movement and rotation.
- Grid occupancy and collision checks.
- Full-row detection and deletion.
- Piece spawning and locking.

## A guide to the code

- `Assets/Codes/Grid.cs` — board state and row deletion
- `Assets/Codes/Group.cs` — movement and rotation
- `Assets/Codes/Spawner.cs` — piece spawning

## Run locally

Clone the repository and add its root in Unity Hub. Install **Unity 6000.3.10f1**, matching `ProjectSettings/ProjectVersion.txt`, then let packages and assets import.

Open `Assets/Tetris_AI.unity` and press Play. Keep the checked-in package configuration when opening the project rather than upgrading the editor automatically.

### Controls

Review `Assets/Codes/Group.cs` for the active keyboard mappings and the input action asset for configured input.

## Project notes

This README describes the checked-in game project. Editor import and gameplay were not retested during the documentation update. Third-party assets, packages and sample content retain their original attribution and licensing; inclusion does not imply original authorship of every asset.

## Context

A project in [Arushi Naik’s portfolio](https://github.com/ArushiNaik).
