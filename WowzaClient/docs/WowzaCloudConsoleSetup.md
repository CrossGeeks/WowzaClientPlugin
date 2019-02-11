# Wowza Account and API Key Setup
- Account

To access the Wowza services we will first need to create a trial or paid account and request them a valid license key to use their services in our mobile app's, to do so you can register in this [link.](https://www.wowza.com/products/gocoder/sdk/license)


- API Key

Once we have register succesfully, we will get a license key on the email account we used to register with, this is the key we are going to use in our app to initialize our plugin.



## Wowza Cloud Console Setup
**1.** Select the Add live stream session, to create our first live stream in the wowza cloud console

![Creating Live Stream 1](https://github.com/CrossGeeks/WowzaClientPlugin/blob/master/WowzaClient/images/SS1.png?raw=true)

**2.** Add a name for the session, and select a server close to the region you are broadcasting from, for best quality on your stream.

![Creating Live Stream 2](https://github.com/CrossGeeks/WowzaClientPlugin/blob/master/WowzaClient/images/SS2.png?raw=true)

**3.** Select the Transcoder you will be using to broadcast, in our case we will be using OBS Software which is another type of RTSP.

![Creating Live Stream 3](https://github.com/CrossGeeks/WowzaClientPlugin/blob/master/WowzaClient/images/SS3.png?raw=true)

**4.** Setup the options for your playback, enabling options like logo, positioning, width of player, etc.

![Creating Live Stream 4](https://github.com/CrossGeeks/WowzaClientPlugin/blob/master/WowzaClient/images/SS4.png?raw=true)

**5.** Complete final setup of optional hosted page provided by Wowza, add a name for the page, description, etc.

![Creating Live Stream 5](https://github.com/CrossGeeks/WowzaClientPlugin/blob/master/WowzaClient/images/SS5.png?raw=true)

**6.** Review your final setup and complete the creation process for the streaming session.

![Creating Live Stream 6](https://github.com/CrossGeeks/WowzaClientPlugin/blob/master/WowzaClient/images/SS6.png?raw=true)

**7.** Ce finito! now we have created succesfully our first streaming session, and we can use the information provided to us, to connect to our broadcast session once we started on the Wowza Cloud Console.

![Creating Live Stream 7](https://github.com/CrossGeeks/WowzaClientPlugin/blob/master/WowzaClient/images/SS7.png?raw=true)

![Creating Live Stream 8](https://github.com/CrossGeeks/WowzaClientPlugin/blob/master/WowzaClient/images/SS8.png?raw=true)


### - Continue => [OBS Setup Guide](OBSSetup.md)