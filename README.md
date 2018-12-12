# Installation
0. [Download and install Unity LTS](https://unity3d.com/unity/qa/lts-releases). This was written using 2017.4.14f1.
1. Download and install Visual Studio Community.

# Start from Scratch Setup
0. Open unity and create a "new project".

# Start from this repo
0. Download this repo.
1. Open Unity, and open the folder containing the repo as an existing Unity project.
2. Download and import the SteamVR plugin. 
    1. This project uses [SteamVR Plugin v 1.2.3](https://github.com/ValveSoftware/steamvr_unity_plugin/releases?after=untagged-5f700d1bb4c709b0bcae), which has been deprecated, but I thought the controller interface was much eaier to use, and didn't crash all the time. Download the unitypackage, not the source code.
    2. Import the full package from Unity by going to Assets -> Import Package -> Custom Package and opening the SteamVR package you downloaded just a second ago. Import all.
    3. You may see a warning about an API change. In my experience, clicking "Go ahead I made a backup" works great.
3. Open the scene Scene -> ViveServer. If your headset is plugged in, controllers are on, and your playing area is set up, you can launch this right away. You should be able to see the controllers tracked in the VR space, and clicking buttons should print messages to the console.


