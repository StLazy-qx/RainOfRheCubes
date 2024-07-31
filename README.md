Many cubes are constantly falling onto the platform.
Creation occurs in a random position above the platform.
When a cube touches a platform, the color of the cube changes (only once, even if there is repeated contact) and then a random lifetime is selected for each cube in the range from 2 to 5 seconds, after which it disappears (counting begins only after contact with the platform ).
Make several additional smaller platforms above the main one, which will be inclined (enough so that they do not stop on them). This is necessary so that the cubes can collide with them and continue their movement. When contacting these platforms, the effect is the same as with the main one.
All falling cubes must have the same color.
Use a pool of objects.
--------------
It is also worth implementing several platforms, as in the previous task (at an angle of slightly smaller sizes above the main one).
After removing the cube, a bomb is created in its place (a black ball with a collider and a rigidbody), which smoothly becomes transparent (for each cube, a time of 2 to 5 seconds is selected) and then explodes (scatters objects in the specified radius).
When changing alpha, it is advisable to replace the Material, Render Mode used.
A bomb, like a cube, is created by a spawner.
To create similar spawners, you should study Generalizations.

Each spawner has an indicator for displaying the following parameters on the screen
1) the number of objects created for the entire time (separately cubes and bombs)
2) the number of active objects on the scene (Data can be taken from ObjectPool)
