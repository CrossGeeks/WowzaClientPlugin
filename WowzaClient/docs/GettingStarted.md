# Getting Started
## Android Setup

* Install Plugin.WowzaClient package into your Android project.

### Prerequisites
- Project configured to compile against Android 4.0(Ice Cream Sandwich) or newer.

- Complete the [Wowza Cloud Console Setup](WowzaCloudConsoleSetup.md) and [OBS Setup](OBSSetup.md) to be able to broadcast succesfully to our Wowza Cloud Server and play it back in our Mobile Device.

### AndroidManifest.xml

Add this permission.
```xml
    <uses-permission android:name="android.permission.INTERNET"/>
```

### MainActivity.cs
- On the **OnCreate** method just before calling base.OnCreate:
```cs
     WowzaClientManager.Initialize(this, "<Wowza GoCoder SDK Key>");
```

## iOS Setup
* Install Plugin.WowzaClient package into your iOS project.

### Prerequisites
1. Complete the [Wowza Cloud Console Setup](WowzaCloudConsoleSetup.md) and [OBS Setup](OBSSetup.md) to be able to broadcast succesfully to our Wowza Cloud Server and play it back in our Mobile Device.

### AppDelegate.cs
- On the FinishedLaunching method just before calling global::Xamarin.Forms.Forms.Init():
```cs
     WowzaClientManager.Initialize("<Wowza GoCoder SDK Key>");
```

### Wowza Config

Here is an example on how to create the WowzaConfig class needed for the Plugin Setup method:

```cs
    public class WowzaCloudConfig : IWowzaConfig
    {
        public string HostAddress => "<Host address>";

        public int PortNumber => 1935;

        public string ApplicationName => "<Application Name>";

        public string StreamName => "<Stream Name>";

        public string Username => "<Username>";

        public string Password => "<Password>";
    }
```

### Setup

Here is an example on how to setup the Wowza Client:

```cs
    CrossWowzaClient.Current.Setup(new WowzaCloudConfig());
```

### Play & Stop
Here is an example on how to play or stop the Wowza Client:
```cs
    if (!CrossWowzaClient.Current.IsPlaying)
    {
        CrossWowzaClient.Current.Play();
    }
    else
        CrossWowzaClient.Current.Stop();
```

### Available Properties
* **IsPlaying**
* **Volume**

### Events
* **OnPlayerStatusChanged**
* **OnError**


### Exceptions
Types of exceptions the user can handle from the Wowza Client plugin.
```cs
    // Indicates Wowza Client Plugin was not initialized correctly on the platform.
    WowzaClientNotInitializedException	

    // Indicates Wowza Client Plugin is not setup.
    WowzaClientNotSetupException

    // Indicates our Wowza Player View is not currently attached.
    WowzaClientPlayerViewNotAttachedException

    // Indicates a problem with the Wowza Client License Key.
    WowzaClientLicensingKeyException

    // Indicates the HslURL is Null or Empty
    WowzaClientHslUrlParameterNullOrEmptyException

```

<= Back to [Table of Contents](../../README.md)
