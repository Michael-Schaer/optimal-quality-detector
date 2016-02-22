# QualityLevelDetector (QLD)
<b>QLD</b> is an Asset for Unity3D, written in C#.

The program can be used for finding the optimal quality level on the current device.

###How does it work?###
There is a sample scene included, which will be used as a reference for your game. <b>QLD</b> runs the sample scene for each QualityLevel and records the frame rate.
Starting with the lowest QualityLevel, the program will go through the different settings. As soon as the framerate falls below a defined value, the test is stopped. The previous QualityLevel is the optimal level - it is the highest possible setting with an acceptable framerate.


##SetUp##

###Menu Scene###
You have to provide the Names of the QualityLevels you want to be tested. In the "QLDController", set the levels in the correct order, starting with the highest QualityLevel. <br/><br/>
You can then provide an FPS requirement for each QualityLevel (same order as above). Like that you define the "trade-off" between good quality and high framerate.
![BenchmarkSceneImportantSettings](/HowToImages/ControllerSetup.PNG?raw=true)
QualityLevels that are not available on the current platform, will be ignored. If the framerate falls below the lowest defined value (e.g. 24), the lowest QualityLevel will be choosen.

###Benchmark Scene###
The Benchmark Scene represents an average scene of your game.  If you want the scene to be really representative, you might want to completely copy one of your levels and make this scene really close to what you do in your game.<br/><br/>

You can however also use the scene that comes with this asset and tweak it to fit your needs. The first PrefabGenerator clones a NavMeshAgent, which is a very CPU-intensive Object. The second PrefabGenerator clones a Model, which only has to be rendered by the GPU (more or less). So if your game is very CPU-intensive you want to clone a high amount of NavMeshAgents. If your game has lots of Models to render, you want to increase the amount on the second Generator. Don't forget to tweak things like baked vs. realtime lights, shadows, LOD groups, normal maps, camera distances, trees, fog, and other stuff that impacts your game performance.
![BenchmarkSceneImportantSettings](/HowToImages/BenchmarkSetup.PNG?raw=true)

In the BenchmarkController, you can adjust the measurement time for benachmark runs. If you lower the time, the results will be more random, if you raise it, the test takes longer.
