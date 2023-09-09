# ThruLine

ThruLine is a singleton prefab that observes events, directs the flow of the game, and manages player/story data.

## Support Scripts

There are three scripts that support this system.
1: Observer - The "eyes and ears" of the system/narrator.  Menu buttons interact with the Observer, specific paths in game trigger the Observer, all custom Yarn Commands move through the Observer, and so on.  Handles basically all system input and action monitoring in game.

2: Director - The "voice" of the system. All directable objects "listen" for the director, and may execute any number of functions based on the circumstance. This is our main driver for animations to fire, for special events to play, or for cutscenes to trigger.

3: Manager - The "brain" of the system.  Handles the save and load system, as well as our log.  Need to know how many times you've entered a room? The manager remembers that. Need to initialize data at the beginning of a game? The manager.

## Workflow

ThruLine is a game manager prefab.  It's loaded into every scene, and checks to see if there is a pre-existing ThruLine object before initializing.  If there is a pre-existing object, it will self-destruct to make room for the existing object.  