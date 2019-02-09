# Wowza Client Plugin for Xamarin iOS and Android

Cross platform plugin for handling streaming, broadcasting, and playback with Wowza Media Services.

### Setup
* Available on Nuget: https://www.nuget.org/packages/Plugin.WowzaClient
[![NuGet Pre Release](https://img.shields.io/nuget/vpre/Plugin.WowzaClient.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.WowzaClient)
* Install into your PCL project and Client projects.
* Create your [Wowza Cloud Console](WowzaClient/docs/WowzaCloudConsoleSetup.md) broadcast session.
* Follow the [Getting Started](WowzaClient/docs/GettingStarted.md) guide

**Platform Support**

|Platform|Version|
| ------------------- | :------------------: |
|Xamarin.iOS|iOS 8+|
|Xamarin.Android|API 15+|

### API Usage

Call **CrossWowzaClient.Current** from any project or PCL to gain access to API.

## Features

- Playback
- Broadcast [On Progress]

## Documentation

Here you will find detailed documentation on setting up and using the Wowza Client Plugin for Xamarin

* [Wowza Cloud Console Setup](WowzaClient/docs/WowzaCloudConsoleSetup.md)
* [Getting Started](WowzaClient/docs/GettingStarted.md)

### Wowza Client Sample Application
* [Wowza Client Sample App](WowzaClient/WowzaClientSample)

### References
* [Documentation References](GoogleClient/docs/References.md)
* Wowza SDK Bindings by [CrossGeeks](https://github.com/CrossGeeks):

    - [Xamarin.Android.LinkedIn](https://www.nuget.org/packages/Xamarin.Android.Wowza/)
    
    - [Xamarin.iOS.Wowza](https://www.nuget.org/packages/Xamarin.iOS.Wowza/)

### Contributors

* [Luis Pujols](https://github.com/pujolsluis)
* [Rendy Del Rosario](https://github.com/rdelrosario)