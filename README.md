# VR Handy Arcade
17th September 2022

[Video Gameplay footage](https://youtu.be/FwV8bzlUIWQ) 

### OVERVIEW
VR Handy Arcade is a game developed for the meta quest 2 devices using built-in hand-tracking feature to play through and interact with 3 different arcade games:
(Hammer cats / Ball hoops / Rolling ball).

### Scenes
- Main menu scene where the player gets game instructions and chooses an arcade game to play.
- Game scene containing 3 different games:
- Hammer cats: a simple game were the player grabs two hammers and starts smashing around to gain score.
- Ball hoops: a simple game like basket ball, grab physics balls and throw inside the hoops. 
- Rolling ball: press arrow buttons to collect stars to gain more time and score.

### Theme
The game setting takes place in a 90th looking arcade game hall to give a nostalgic and arcade looking feeling to the player.

### Audio
- The audio is supposed to help immerse you in the overall experience of the game by adding arcade ambiance sounds and retro-like background music.

### Graphics
- Main colors: Black, Red and Blue
- Art style: Simple looking art style

### Development
- GameManager.cs: to handle the game timer, score and losing conditions.
- LevelManager.cs: manages transition between different scenes and games.
- AudioManager.cs: organizes game audio and sound effects.
- DontDestroy.cs: script written for the AudioManager to not destroy it.
- HammerHead.cs: handles collision with the game hammer.
- MazeBall.cs: responsible for rolling ball movement and button integration
- Star.cs: detect collision with rolling ball.
- StarSpawner.cs: random star spawner with constraints.
- Ring.cs: detect collision with throwable ball for ball hoops game.

### Challenges
- Throwable and grabbable objects physics simulation

