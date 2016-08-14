# GladLive.Lobby

GladLive is network service comparable to Xboxlive or Steam. 

GladLive.Lobby provides libraries, contracts, and implementations for lobby systems for the GladLive distributed network. providing:
  - Generic Lobby System
  - Lobby ASP Controllers
  - Lobby DB Scheme/Models
  - PeerToPeer Lobby Implementation

## Setup

To use this project you'll first need a couple of things:
  - Visual Studio 2015 RC 3
  - ASP Core VS Tools
  - Dotnet SDK
  - Add Nuget Feed https://www.myget.org/F/hellokitty/api/v2 in VS (Options -> NuGet -> Package Sources)

## Builds

Available on HelloKitty Nuget feed:  https://www.myget.org/F/hellokitty/api/v2

##Tests

#### Linux/Mono - Unit Tests
||Debug x86|Debug x64|Release x86|Release x64|
|:--:|:--:|:--:|:--:|:--:|:--:|
|**master**| N/A | N/A | N/A | [![Build Status](https://travis-ci.org/GladLive/GladLive.Lobby.svg?branch=master)](https://travis-ci.org/GladLive/GladLive.Lobby) |
|**dev**| N/A | N/A | N/A | [![Build Status](https://travis-ci.org/GladLive/GladLive.Lobby.svg?branch=dev)](https://travis-ci.org/GladLive/GladLive.Lobby)|

#### Windows - Unit Tests

(Done locally)

##Licensing

This project is licensed under the MIT license with the additional requirement of adding the GladLive splashscreen to your product.
