# 2D Platformer

A 2D platformer built in Unity 6 for an ALU Software Engineering assignment. The project started as a deliberately broken, half-finished game; the task was to inherit it, fix the bugs, complete the core scripts, and extend it with new features.

## Overview

You play as a character running through a side-scrolling level, collecting coins, avoiding enemies and water, and fighting a boss at the end. The game has a start menu, a HUD, water-respawn logic, and win/lose screens.

## How to play

- **A / D** or **Left / Right arrows** — move
- **Spacebar** — jump (only when grounded)
- **J** — shoot
- Reach the boss at the end and defeat it to win
- Falling in water or losing all lives ends the run

## Features

- Start menu with a Play button and a settings page (volume, music, difficulty controls)
- Player movement, grounded-check jumping, and one-way camera follow
- Coin collection with a HUD counter
- Life tracking shared across enemy contact and water hazards
- Water respawn near the point of entry rather than at the start, with an offset so the player lands on solid ground
- A shooting system that damages enemies and the boss
- A boss with 4 hit points that throws projectiles and plays a death animation
- Win screen on boss defeat; game-over screen when lives run out
- Replay, Main Menu, and Quit buttons on the end screens

## Scripts

- **PlayerMovement** — handles walking, jumping, grounded checks, and facing direction
- **CameraFollow** — follows the player with an offset, finding the target at runtime
- **GameManager** — central manager for lives, water respawn, win/lose screens, and scene navigation
- **WaterDeath** — detects when the player enters water and reports to the GameManager
- **PlayerDamage** — routes enemy contact damage into the GameManager
- **PlayerShoot / FireBullet** — spawn and move bullets that damage enemies
- **BossScript / BossHealth** — boss attack behaviour and hit tracking
- **MainMenuController / SettingsMenu** — start menu navigation and settings panel

## Bug fixes from the original project

- Assigned the player's Rigidbody2D in Awake (it was calling GetComponent on a null reference)
- Set the movement input to the Horizontal axis (it was an invalid axis)
- Called the grounded check and jump listener every frame in Update (Update was empty)
- Set jump to fire on the spacebar, once per press
- Assigned the camera's target to the player at runtime, keeping the target variable private and without using SerializeField
- Created a Ground layer and assigned the ground tiles so the grounded raycast works

## Game Demo & Code Walkthrough
https://youtu.be/nyby3sHrv8M

## Built with

- Unity 6
- C#
- TextMeshPro for UI text

## Author

Joshua Moses
