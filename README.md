# QualityLevelDetector (QLD)
<b>QLD</b> is a nice addition for your Unity3D project. It determines the optimal quality level to use on the current device by measuring framerates on a test scenario.

The code in this repository is licensed under the LGPL. I have plans to offer the package also on the Unity Asset Store for some dollars. Check this page for updates if you are interested in aquiring the package without a copyleft license.

###How does QLD work?###
There is a sample scene included, which will be used as a reference for your game. <b>QLD</b> runs the sample scene for each QualityLevel and records the frame rates. Starting with the lowest QualityLevel, the program will go through the different settings. As soon as the framerate falls below a defined value, the test is stopped. The previous QualityLevel is the optimal level - it is the highest possible setting with an acceptable framerate.


##SetUp##

###Menu Scene###
You have to provide the names of the QualityLevels you want to be tested. In the "QLDController", set the levels in the correct order, starting with the highest QualityLevel.
![BenchmarkSceneImportantSettings](/HowToImages/ControllerSetup.PNG?raw=true) <br/>
You can then provide an FPS requirement for each QualityLevel (same order as above). Like that you define the "trade-off" between good quality and high framerate.<br/><br/>
QualityLevels that are not available on the current platform, will be ignored. If the fps requirements for the lowest setting is not acheived, the lowest setting will still be chosen.

###Benchmark Scene###
The Benchmark Scene represents an average scene of your game. If you want the test to be very precise, you should completely copy one of your levels and possibly use the same behaviours as you use in your scenes.<br/><br/>

If you just need approximate results, you can always use the included scene and tweak it to fit your needs. There are lots of variables to adjust in the scene, like those in the PrefabGenerators:<br/><br/>
The first PrefabGenerator clones a NavMeshAgent, which is a very CPU-intensive Object. The second PrefabGenerator clones a model, which only has to be rendered by the GPU (more or less). So if your game is very CPU-intensive you want to clone a high amount of NavMeshAgents. If your game has lots of models to render, you want to increase the amount on the second PrefabGenerator.
![BenchmarkSceneImportantSettings](/HowToImages/BenchmarkSetup.PNG?raw=true) <br/>
Other things you should tweak include: 
- Baked vs. realtime lights
- shadows
- LOD groups
- normal maps
- camera distances
- trees

In the BenchmarkController, you can adjust the measurement time for benachmark runs. If you lower the time, the results will be more random, if you raise it, the test takes longer.
