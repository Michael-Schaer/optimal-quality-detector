# QualityLevelDetector (QLD)
<b>QLD</b> is an Asset for Unity3D, written in C#.

The program can be used for finding the optimal quality level on the current device.

###How does it work?###
There is a sample scene included, which will be used as a reference for your game. <b>QLD</b> runs the sample scene for each QualityLevel and records the frame rate.
Starting with the lowest QualityLevel, the program will go through the different settings. As soon as the framerate falls below a defined value, the test is stopped. The previous QualityLevel is the optimal level - it is the highest possible setting with an acceptable framerate.

