Rain of the Cubes
  Description
Cubes constantly fall onto the platform, spawning at random positions above. In addition to the main platform, there are several smaller tilted platforms to prevent cubes from stopping.

  Core Mechanics:
- When a cube touches a platform, it changes color (only once)
- A random lifespan (2–5 seconds) is assigned before the cube disappears
- When a cube disappears, a bomb spawns in its place, gradually turning transparent (2–5 seconds) before exploding and scattering nearby objects

  Technical Features:
- Object pooling is used for optimized spawning and removal

- Spawners are implemented using Generics

- Each spawner tracks:
The total number of spawned objects
The number of active objects in the scene
