# OBS Setup
Setting up streaming software with Wowza Livestream source connection information.

**1.** Once we have succesfully created our streaming session, we will use the following information to setup our streaming software, in our case we will be using [OBS Studio](https://obsproject.com/).

![Live Stream Connection Information 1](https://github.com/CrossGeeks/WowzaClientPlugin/blob/master/WowzaClient/images/SS8.png?raw=true)

**3.** Once you have Downloaded OBS Studio, Press the Studio Mode and add a source to your scene (Microphone Input, Music Track, Camera Input, etc), once you have your scene ready transition it, and it should show on the live broadcast on the right side of the studio, when you are online.

![Configuring OBS 1](https://github.com/CrossGeeks/WowzaClientPlugin/blob/master/WowzaClient/images/SSOBS2.png?raw=true)

**4.** Now Lets add the settings to go online, we can do so by following **Settings > Streaming**, fill out the information and apply the changes. 

![Configuring OBS 2](https://github.com/CrossGeeks/WowzaClientPlugin/blob/master/WowzaClient/images/SSOBS1.png?raw=true)

**2.** Now that we have OBS Studio ready to stream, we need to start our Wowza Cloud Server so it starts listening for a connection, to do so we simple press the green **Start Live Stream** button on our Wowza Cloud Session Dashboard, once it's online we go back to OBS and press **Start Streaming**. We should now be able to see our live stream working correctly on our Test Page provided by Wowza!

![Live Stream Connection Information 2](https://github.com/CrossGeeks/WowzaClientPlugin/blob/master/WowzaClient/images/SS7.png?raw=true)

