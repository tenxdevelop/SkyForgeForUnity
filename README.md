# SkyForgeForUnity it's Architecture template for Unity.

## Table of content:
- [Short description](#description)
- [Installation](#installation)
- [Get started](#get-started)

## Description

This architectural template is based on the MVVM pattern. A basic DI container is implemented here, as well as a command Handler 
pattern with a Proxy, to maintain the current state of the game through reactive properties. Flatbuffer is used to quickly download 
configs from Google tables, as it is a powerful enough tool even for large projects, but if you do not want to use it, then in the 
future I will add a convenient ScriptableObject download. It is also planned to improve skyForge in the future by adding new binder and new technologies.

## Installation

In order to install the SkyForge architecture, you must first install dependency Google.Apps, Google.Sheets 
and Google.FlatBuffers for working with configs from google sheets. 

To install these dependencies, you need to install nuget for Unity

just use unity Package Manager, at the left top corner click "+" and choose "Add package from git URL..."

![image](https://github.com/tenxdevelop/SkyForgeForUnity/blob/main/Assets/Images/packageManager.png)

Then paste the link below in the field and just press Enter.

```
https://github.com/GlitchEnzo/NuGetForUnity.git?path=/src/NuGetForUnity

```

After installing nuget, the nuget tab will appear on the top panel in Unity Editor. Install the necessary dependencies

![image](https://github.com/tenxdevelop/SkyForgeForUnity/blob/main/Assets/Images/dependency.png)

And the last step is just to install the SkyForge package, in the same way as nuget

just use unity Package Manager, at the left top corner click "+" and choose "Add package from git URL..."

![image](https://github.com/tenxdevelop/SkyForgeForUnity/blob/main/Assets/Images/packageManager.png)

Then paste the link below in the field and just press Enter.

```
https://github.com/tenxdevelop/SkyForgeForUnity.git
```

After that, SkyForge is ready to work

## Get started

