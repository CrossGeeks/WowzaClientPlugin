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

<= Back to [Table of Contents](../../README.md)
