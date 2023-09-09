# ThruLine

ThruLine is a singleton prefab that observes events, directs the flow of the game, and manages player/story data.

## Support Scripts

There are three scripts that support this system.
1: Observer - The "eyes and ears" of the system/narrator.  Menu buttons interact with the Observer, specific paths in game trigger the Observer, all custom Yarn Commands move through the Observer, and so on.  Handles basically all system input and action monitoring in game.

2: Director - The "voice" of the system. All directable objects "listen" for the director, and may execute any number of functions based on the circumstance. This is our main driver for animations to fire, for special events to play, or for cutscenes to trigger.

3: Manager - The "brain" of the system.  Handles the save and load system, as well as our log.  Need to know how many times you've entered a room? The manager remembers that. Need to initialize data at the beginning of a game? The manager.

## Workflow

ThruLine is a game manager prefab.  It's loaded into every scene, and checks to see if there is a pre-existing ThruLine object before initializing.  If there is a pre-existing object, it will self-destruct to make room for the existing object.  

If this is the first ThruLine in a scene, it will run the rest of its construction phase, which includes fetching save game information, and general information such as settings that the player may want to persist between launches of the game.

From here, the supporting scripts fulfill their roles. The manager keeps track of the game state, the Observer listens for important events, and the Director drives action when necessary. 

THERE IS CURRENTLY NO AUTOSAVE FEATURE. This means that players should try to save regularly. At the end of this prefab's lifecycle, it will self destruct with no backup. 

### The Observer
The Observer is the input layer for the system.  Any objects that need to communicate with the Observer need to have a reference to the observer, which is easily set up with a search, since it's the only one in the scene.  This system receives events from YS's systems, and any custom events that we need to keep track of as well.  The observer will usually communicate with the Manager or Director scripts directly.  

Commonly observed events might be changing areas in the game, talking to an NPC, finding an item, passing a milestone in game, triggering specific events in a Yarn Script, or solving a key puzzle.

### The Director
The Director is the output layer for the system.  Most output to players is handled through YS's systems, delivering lines of dialogue and choices to pick through.  The Director is a gatekeeper, making sure that players cannot stray outside the current scope of the game.  The Director swaps scripts when we leave one "act" of the play and go into another, or plays a musical note on every 3rd time we enter a specific room.

Where the Observer needs objects to report to it, the Director emits events and everything else listens.  This is handled through a tagging system, or through an Interface.

### The Manager
The Manager is the record keeper for the Director and Observer scripts.  It isn't listening for or emitting any events outside of this grouping. Instead, it communicates internally to provide information when required.  For instance, the manager is the mechanism that keeps track of how many times we've entered a room, while the Director is the mechanism that ensures a special tone plays on the third entrance to the room.

Typical tasks include reading and writing save files, tracking room and NPC interaction stats, tracking of game milestones, etc.