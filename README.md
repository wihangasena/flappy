# Flappy

A small 2D Flappy Bird-style game made with Unity. Guide the bird through
randomly positioned pipe gaps, avoid collisions, and try to achieve the
highest score possible.

## Features

- Space-bar flap control
- Randomly generated pipe positions
- Scrolling pipes that are removed after leaving the play area
- Score awarded for passing each pipe gap
- Automatic game-over screen with a restart button
- Bird death when it hits a pipe, leaves the camera bounds, or touches an
  invalid trigger

## Requirements

- Unity `6000.6.7f1` (Unity 6)
- A desktop platform supported by Unity

The project uses Unity's Input System package and 2D physics.

## Getting Started

1. Clone or download this repository.
2. Open **Unity Hub**.
3. Select **Add** and choose the project folder.
4. Open the project with Unity `6000.6.7f1`.
5. Open the game scene from `Assets/Scenes/`.
6. Press **Play** in the Unity Editor.

If the scene does not open automatically, use the scene included in
`Assets/Scenes/` and confirm that it contains the bird, pipes, camera, and
game logic objects.

## Controls

| Action | Key |
| --- | --- |
| Flap upward | `Space` |
| Restart after game over | Click the `Restart` button |

## Gameplay

Press `Space` to apply an upward impulse to the bird. The bird is affected by
2D physics between flaps. Passing through a pipe's middle trigger increases the
score by one.

The game ends when the bird collides with an obstacle, leaves the camera's
vertical bounds, or enters a non-scoring trigger. Once the bird is dead, the
game-over panel appears and the `Restart` button reloads the active scene.

## Project Structure

```text
Assets/
├── LogicScript.cs        # Score, game-over UI, and scene restart logic
├── birdscript.cs         # Bird input, movement, and death conditions
├── PipeMiddleScript.cs   # Awards points when the bird passes a gap
├── PipeMoveScript.cs     # Moves pipes left and destroys old pipes
├── PipeSpawnScript.cs    # Spawns pipes at random heights
├── pipe.prefab           # Reusable pipe obstacle
└── Scenes/               # Unity scenes
```

## Main Configuration

Several gameplay values are exposed in the Unity Inspector:

- `flapStrength` on the bird controls the upward flap impulse.
- `moveSpeed` and `deadZone` on pipes control their movement and cleanup.
- `spawnRate` and `heightOffset` control pipe frequency and vertical
  variation.

## Building

To create a standalone build, open **File > Build Profiles** in Unity, add
the game scene to the build, select a target platform, and choose **Build**.

## License

No license has been specified for this project.
