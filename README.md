# QualityLevelDetector (QLD)
<b>QLD</b> is a nice addition for your Unity3D project. It determines the optimal quality level to use on the current device by measuring framerates on a test scenario.

The code in this repository is licensed under the LGPL. I have plans to offer the package also on the Unity Asset Store for some dollars. Check this page for updates if you are interested in aquiring the package without a copyleft license.

###How does QLD work?###
There is a sample scene included, which will be used as a reference for your game. <b>QLD</b> runs the sample scene for each QualityLevel and records the frame rates. Starting with the lowest QualityLevel, the program will go through the different settings (ascending). As soon as the framerate gets low, the test is stopped. The last QualityLevel with a good framerate will be chosen as the optimal setting (framerate requirements can be configured).

##SetUp##

###Menu Scene###
You provide the names of the QualityLevels you want to be tested. In the "QLDController", you set the names in the correct order, starting with the highest QualityLevel.
![BenchmarkSceneImportantSettings](/HowToImages/ControllerSetup.PNG?raw=true) <br/>
You can then provide an FPS requirement for each QualityLevel (same order as above). These numbers define the "trade-off" between good quality and high framerate that you like.<br/><br/>
All the QualityLevels that are not available on the current platform will be ignored. If the fps requirements for the lowest setting is not acheived, the lowest setting will still be chosen.

###Benchmark Scene###
The Benchmark Scene represents an average scene of your game. If you want the test to be very precise, you should completely copy one of your levels and possibly use the same behaviours as you use in your scenes.<br/><br/>

If you just need approximate results, you can always use the included scene and tweak it to fit your needs. The current scene is aligned for a mobile 3D project, but you can easily raise the bar. There are lots of variables to adjust in the scene, most importantly the two PrefabGenerators, which clone different scene objects:<br/><br/>
The first PrefabGenerator clones a NavMeshAgent, which is a very CPU-intensive Object. The second PrefabGenerator clones a model, which only has to be rendered by the GPU (more or less). So if your game is very CPU-intensive you want to clone a high amount of NavMeshAgents. If your game has lots of models to render, you want to increase the amount on the second PrefabGenerator.
![BenchmarkSceneImportantSettings](/HowToImages/BenchmarkSetup.PNG?raw=true) <br/>
The scene can also be adjusted to use elements like: 
- baked and realtime lights
- shadows
- LOD groups
- normal maps
- camera distances
- disable objects on low quality settings
- lower terrain quality for better performance

In the BenchmarkController, you can adjust the measurement time for benachmark runs. If you lower the time, the results will be more random, if you raise it, the test takes longer.
