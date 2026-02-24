# <a href="https://denchisoft.com"><img src="https://raw.githubusercontent.com/DenchiSoft/VTubeStudio/master/Images/vtube_studio_logo_nyan_2.png" width="542" /></a><br> [![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/DenchiSoft/VTubeStudio/blob/master/LICENSE) [![VTube Studio Discord](https://discordapp.com/api/guilds/652602255748497449/widget.png?style=shield)](https://discord.gg/VTubeStudio) [![Stars](https://img.shields.io/github/stars/DenchiSoft/VTubeStudio?style=social)](https://github.com/DenchiSoft/VTubeStudio) [![Twitter Follow](https://img.shields.io/twitter/follow/VTubeStudio.svg?style=social)](https://twitter.com/VTubeStudio)


[![VTube Studio Discord](https://discordapp.com/api/guilds/652602255748497449/widget.png?style=banner2)](https://discord.gg/VTubeStudio)

## Are you looking for the [VTube Studio Manual](https://github.com/DenchiSoft/VTubeStudio/wiki)?

That can be found here: https://github.com/DenchiSoft/VTubeStudio/wiki

## Are you looking for a [list of VTube Studio Plugins](https://github.com/DenchiSoft/VTubeStudio/wiki/Plugins)?

Check out this page: https://github.com/DenchiSoft/VTubeStudio/wiki/Plugins

## Are you a developer looking for a way to receive tracking data from the VTube Studio iPhone app?

The process for requesting tracking data from the VTube Studio iOS app is described here: https://github.com/DenchiSoft/VTubeStudioBlendshapeUDPReceiverTest

## Are you a developer who wants to learn about creating VTube Studio Plugins?

Everything you're looking for is on this page. If you have any questions, please ask in the [Discord](https://discord.gg/VTubeStudio).

## Contents

- [General Info](#general-info)
- [Legal Info](#legal-info)
- [Available Plugins and Examples](#available-examples)
- [Event API](#event-api)
- [API Details](#api-details)
  - [API Permissions](#api-permissions)
  - [API Server Discovery (UDP)](#api-server-discovery-udp)
  - [Authentication](#authentication)
  - [Subscribing to and unsubscribing from events](#subscribing-to-and-unsubscribing-from-events)
  - [Getting current VTS statistics](#getting-current-vts-statistics)
  - [Getting list of VTS folders](#getting-list-of-vts-folders)
  - [Getting the currently loaded model](#getting-the-currently-loaded-model)
  - [Getting a list of available VTS models](#getting-a-list-of-available-vts-models)
  - [Loading a VTS model by its ID](#loading-a-vts-model-by-its-id)
  - [Moving the currently loaded VTS model](#moving-the-currently-loaded-vts-model)
  - [Requesting list of hotkeys available in current or other VTS model](#requesting-list-of-hotkeys-available-in-current-or-other-vts-model)
  - [Requesting execution of hotkeys](#requesting-execution-of-hotkeys)
  - [Requesting list of expressions and their states](#requesting-current-expression-state-list)
  - [Requesting activation/deactivation of expressions](#requesting-activation-or-deactivation-of-expressions)
  - [Requesting list of ArtMeshes in current model](#requesting-list-of-artmeshes-in-current-model)
  - [Tint ArtMeshes with color](#tint-artmeshes-with-color)
  - [Getting scene lighting overlay color](#getting-scene-lighting-overlay-color)
  - [Checking if face is currently found by tracker](#checking-if-face-is-currently-found-by-tracker)
  - [Requesting list of available tracking parameters](#requesting-list-of-available-tracking-parameters)
  - [Get the value for one specific parameter, default or custom](#get-the-value-for-one-specific-parameter-default-or-custom)
  - [Get the value for all Live2D parameters in the current model](#get-the-value-for-all-live2d-parameters-in-the-current-model)
  - [Adding new tracking parameters ("custom parameters")](#adding-new-tracking-parameters-custom-parameters)
  - [Delete custom parameters](#delete-custom-parameters)
  - [Feeding in data for default or custom parameters](#feeding-in-data-for-default-or-custom-parameters)
  - [Getting physics settings of currently loaded VTS model](#getting-physics-settings-of-currently-loaded-vts-model)
  - [Overriding physics settings of currently loaded VTS model](#overriding-physics-settings-of-currently-loaded-vts-model)
  - [Get and/or set NDI settings](#get-and-set-ndi-settings)
  - [Requesting list of available items or items in scene](#requesting-list-of-available-items-or-items-in-scene)
  - [Loading item into the scene](#loading-item-into-the-scene)
  - [Removing item from the scene](#removing-item-from-the-scene)
  - [Controling items and item animations](#controling-items-and-item-animations)
  - [Moving items in the scene](#moving-items-in-the-scene)
  - [Set within-model-sorting for items](#set-item-within-model-sorting-order)
  - [Asking user to select ArtMeshes](#asking-user-to-select-artmeshes)
  - [Pin items to the model](#pin-items-to-the-model)
  - [Get list of post-processing effects and state](#get-list-of-post-processing-effects-and-state)
  - [Set post-processing effects](#set-post-processing-effects)
  
## General Info

VTube Studio has a **public API**. This means you are able to write plugins/scripts that can trigger hotkeys, feed in face tracking data, load items, load models, get event notifications for various events, tint model ArtMeshes and much more.

If you develop a plugin or any app that can be used with VTube Studio, please open a PR and I will add it to the list on this page.

## Legal Info

You are free to write, publish and sell any plugin you want for VTube Studio. No permission is required and there are no licensing fees or royalties.

## Available Examples

If you're a user of VTube Studio looking for plugins you can use, check out the [plugin list wiki page](https://github.com/DenchiSoft/VTubeStudio/wiki/Plugins).

If you're a developer looking for examples/libraries for you to look at that make it easier to integrate the VTube Studio API into your app, please take a look at the following table. 

:warning: **If you made something you want to have included here, open a pull request with the modified table!!** :warning:

| Plugin | Developer | Type | Explanation |
| --- | --- | --- | --- |
| [Cheers Bot](https://cheers.hawk.bar/) | [Hawkbar](https://twitter.com/HawkbarGaming) | App | A web-based Twitch integration platform which can trigger actions in VTube Studio when chatters redeem channel points, among many other features. |
| [VTubeStudioJS](https://github.com/Hawkbat/VTubeStudioJS) | [Hawkbar](https://twitter.com/HawkbarGaming) | Library | A JavaScript library for use by other plugin authors which implements the VTube Studio WebSocket API. Compatible with both NodeJS and the browser. 
| [VTS Linker - SMB1](https://github.com/Renpona/VTStudio-Linker-SMB1) | [Renpona](https://twitter.com/renpona) | Example | A prototype for reading data from an emulated copy of Super Mario Bros, and using that data to automatically move and recolor a Live2D model in VTS based on what's happening in the game.
| [VTchaos](https://github.com/Raelice/VTchaos) | [Raelice](https://twitter.com/theraelice) | App | A program that reads YouTube and Twitch chat to perform functions like model swapping, rotation, hotkeys, and movement in vtube studio through simple chat commands.
| [Mix It Up](https://mixitupapp.com/) | [Mix It Up](https://twitter.com/mixitupapp) | App | Streaming Software Bot for Chat, Events, and other awesome features!
| [VsPyYt](https://github.com/mlo40/VsPyYt) | [emlo40](https://emlo40.com) | App/Framework | VsPyYt is a command prompt app that can read YouTube chat and execute commands saved in token.json. You can also use it as a base for python programs that interact with VTube Studio. |
| [VTS-Sharp](https://github.com/FomTarro/VTS-Sharp) | [Skeletom](https://www.twitter.com/FomTarro) | Library | A Unity/C# library for use by other plugin authors which implements the VTube Studio WebSocket API. |
| [node-red-contrib-vts](https://github.com/eslym/node-red-contrib-vts) | [0nepeop1e](https://github.com/eslym) | Library | A library package which provides node for Node-RED to integrate with VTube Studio |
| [VTS Mod](https://github.com/MechaWolfVtuberShin/VTS-Mod/releases/tag/vts-mod) | [MechaWolfVtuber_Shin](https://github.com/MechaWolfVtuberShin) | App | A program that allows users to change the surface color of the model including RGB. It can also change the rotation of the model. |
| [Tie Tools: VTS Color Editor](https://tie-tools.tiberiusx.me) | [Prof. Tiberius](https://www.twitter.com/prof_tiberius) | App | Web App that gives in depth control of the colors and opacity of specific parts of your model. |
| [vtubestudio-rs](https://github.com/walfie/vtubestudio-rs) | [Walfie](https://www.twitter.com/walfieee) | Library | A Rust library for use by other plugin authors which implements the VTube Studio WebSocket API. |
| [vts-heartrate](https://skeletom-ch.itch.io/vts-heartrate) | [Skeletom](https://www.twitter.com/FomTarro) | App | A plugin that connects real-time heartrate data to VTube Studio, allowing for dynamic model tinting and providing custom tracking parameters based on pulse. |
| [vts-chameleon](https://satetsu888.github.io/vts-chameleon/) | [satetsu888](https://www.twitter.com/satetsu888) | App | A plugin for applying color tints. You can play around by changing color tones of hair, skin, uniform, etc. of your models. |
| [ViewLink](https://kawaentertainment.itch.io/viewlink) | [KawaEntertainment](https://twitter.com/kawa_entertain) | App | Are you a VTuber that wants to stream VR games, but only have a Live2D model? With ViewLink, you can have your Live2D avatar react to VR gameplay without any fancy setup or additional hardware! |
| [VTS Desktop Audio](https://lualucky.itch.io/vts-desktop-audio-plugin) | [Lua Lucky](https://twitter.com/LuaVLucky) | App | A plugin for using desktop audio as input parameters in VTS. |
| [pyvts](https://github.com/Genteki/pyvts) | [Genteki](https://github.com/Genteki) | Library | A python library for interacting with the VTube Studio API. |
| [DSYS: Dummy System](https://github.com/chuigda/Project-WG/tree/master/extra/dsys) | [Chuigda](https://github.com/chuigda) | App | A simple plugin for recording/replaying/semi-autopiloting with VTS model parameters. |
| [SAMMIVtubeStudioExtension](https://github.com/HueVirtualCreature/SAMMIVtubeStudioExtension) | [hue](https://twitter.com/Hue_SwordDevil) | Plugin | A plugin for the stream automation tool called [SAMMI](https://sammi.solutions/) |
| [Streamer.bot](https://streamer.bot) | [Streamer.bot](https://streamer.bot) | App | Advanced multi-platform streaming software with an official [VTubeStudio integration](https://docs.streamer.bot/guide/integrations/vtube-studio) |
| [coovts](https://github.com/lgc2333/coovts) | [LgCookie](https://github.com/lgc2333) | Library | Another library for making VTube Studio plugins with Python (in early dev). Full type hints \| Async design \| Pydantic based data validation |
| [VTS Terminal](https://www.nekomaido.com/plugin/vts-terminal) | [Neko Maido](https://www.nekomaido.com) | App | A plugin that provides many utilities, can trigger hotkeys, adjust the model's position and visual effects, and generate a PDF manual for your Live2D model. |
| [VTS4J](https://github.com/aDL1n/VTS4J) | [aDL1n](https://github.com/aDL1n) | Library | A Java library for interacting with the VTube Studio WebSocket API |
| [BlerpVTS](https://blerp.com/vtuber-pet?referralId=vtube-studio-github) | [Blerp](https://blerp.com) | Streaming Extension | A plugin for streamers that lets your pet lip-sync when viewers trigger Blerp sounds or TTS. Pet can also answer questions sent through the Blerp extension autonomously. Works across Twitch, Kick, YouTube, TikTok, and more! |

# Event API

There is another wiki page that describes the **Event API**, which you can use to subscribe events happening in VTube Studio, such as models being loaded or hotkeys being executed. Please check out the page about events [right here](Events/).


# API Details

The VTube Studio websocket server runs on `ws://localhost:8001`. This is the default, but users can also change the port in the app. Websockets in general support `binary` and `text` messages. VTube Studio will always respond with `text` messages and it is recommended to also send `text` messages to the API. You may also send `binary` messages but if you do, make sure they are encoded in UTF-8.

If your plugin cannot connect to the websocket server, tell the users to check if the port is correct or if there are any firewall/antivirus settings that may prevent the connection. Most importantly, you should ask the users to `"Allow Plugin API access"` in VTube Studio. It's an option on the main config page in VTS.
You should also make sure your plugin supports configuring the port used for the connection.

If you can connect, the first thing you can try is check the status of your session.

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "MyIDWithLessThan64Characters",
	"messageType": "APIStateRequest"
}
```

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"messageType": "APIStateResponse",
	"requestID": "MyIDWithLessThan64Characters",
	"data": {
		"active": true,
		"vTubeStudioVersion": "1.9.0",
		"currentSessionAuthenticated": false
	}
}
```

Every request has to contain `"apiName" : "VTubeStudioPublicAPI"` and the used API version, which will be `"1.0"` at the time of the first release.
This API version will stay the same until incompatible changes are made to the behavior/payloads. This means that new functionality may be added to the API (including new fields in existing payloads) without increasing the version. Make sure your app can handle this and doesn't break if it encounters unknown fields during deserialization.

An example for an incompatible change would be renaming an existing field or removing it from the payload altogether. If there are any incompatible changes, the API version will be increased for them so the old APIs can still be used as they are.

You can add the `"requestID"` field to every request. This is optional but recommended, because it allows you to identify responses to your requests.
This ID will also be used to log the request in the VTube Studio logs along with any errors. If anything goes wrong, you can use this as reference to check for any errors related to this request in the logs.

You can use the same ID or different IDs for each request. If provided, IDs should only contain ASCII characters and be at least 1 and at most 64 characters in length.
If you don't add the `"requestID"` field, VTube Studio will add a randomly generated UUID for the request and return it with the response.

The `"currentSessionAuthenticated"` will tell you if the current session has already been authenticated.

All possible error IDs are listed on the page [ErrorsID.cs](https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/ErrorID.cs).

Once connected, the client can poll information about the current app state at any time.

## API Permissions

Certain functionality offered by the VTube Studio API is locked behind additional **permissions** that have to be requested by the plugin after authenticating. Like the permissions in iOS and Android, this is to make sure users understand when plugins use functionality that could be considered risky or potentially dangerous, such as loading arbitrary images as items.

When requesting a permission, a popup is shown to the user explaining what the permission does. The user can then choose to grant or deny it. For more information on how to request permissions and what you need them for, check the [permissions page](Permissions/).

[![VTube Studio Permission Request Screen](/Images/vts_api_permissions_1_transparent.png)](Permissions/)


## API Server Discovery (UDP)

VTube Studio also broadcasts the API state on the local network via UDP on port 47779. This is done once every two seconds even if the user has turned off the API.
The `instanceID` is a random ID that gets generated for a VTube Studio instance when it is started. It doesn't change while this instance is running so two VTube Studio instances would have different IDs.

The `windowTitle` is the title text of the window. On Windows, this will be different for different VTS instances. When more than one instance is started, the first instance will have the title `VTube Studio`, the second instance will have the title `VTube Studio Window 2` and so on. On macOS, all instances will have the title `VTube Studio`

```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1630159656406,
	"messageType": "VTubeStudioAPIStateBroadcast",
	"requestID": "VTubeStudioAPIStateBroadcast",
	"data": {
		"active": false,
		"port": 8001,
		"instanceID": "93aa0d0494304fddb057ae8a295c4e59",
		"windowTitle": "VTube Studio"
	}
}
```

## Authentication

Before using the API, you have to authenticate once. For this, you'll have to provide your plugin name and the name of the developer. They should both be between 3 and 32 characters.

This is done by requesting a token for your plugin. Send the following request:

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "AuthenticationTokenRequest",
	"data": {
		"pluginName": "My Cool Plugin",
		"pluginDeveloper": "My Name",
		"pluginIcon": "iVBORw0.........KGgoA="
	}
}
```

If the user has activated API access, this will trigger a popup inside of VTS asking the user if they want to allow the plugin `"My Cool Plugin"` by `"My Name"` to control VTube Studio. `"pluginIcon"` can be added optionally. This has to be a base64 encoded PNG or JPG image with the exact dimensions 128x128 pixels. If you add this, the icon will be used in the plugin access request popup shown to the user. If they click "Allow", you will get the following response:

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "AuthenticationTokenResponse",
	"data": {
		"authenticationToken": "adcd-123-ef09-some-token-string-abcd"
	}
}
```

The field `"authenticationToken"` contains an ASCII string which will serve as the token for authenticating with the API. It is at most 64 characters in length.
If they deny access, you will get the following error:

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "APIError",
	"data": {
		"errorID": 50,
		"message": "User has denied API access for your plugin."
	}
}
```
Users can revoke API access from your plugin at any point from within VTube Studio. If they do, you will also get this error when trying to send any requests. You may try to re-authenticate in this case.

You only need to obtain the token once. With this token, you can now authenticate for this session. In the next session (for example when VTS is restarted or your plugin has to re-connect to VTS for some reason), you can use the same token to authenticate again so you don't have to send the requests to get a token again so the user will only be asked about allowing your plugin once.

To authenticate for one session, send the following request with your token:

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "AuthenticationRequest",
	"data": {
		"pluginName": "My Cool Plugin",
		"pluginDeveloper": "My Name",
		"authenticationToken": "adcd-123-ef09-some-token-string-abcd"
	}
}
```

`"pluginName"` and `"pluginDeveloper"` have to match the values you used when requesting the token, otherwise the authentication request will fail.

If the token is valid and API access has not been revoked by the user, you will get the following response:

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "AuthenticationResponse",
	"data": {
		"authenticated": true,
		"reason": "Token valid. The plugin is authenticated for the duration of this session."
	}
}
```

Congratulations, you are authenticated and can use the VTube Studio API.

If required fields are missing, you'll get an error response. If all fields are there and properly formatted but the token is invalid or has been revoked by the user, `"authenticated"` will be returned as `false`.

**Note about `data` field:** Some requests include a `data` JSON object field and some don't. To make things easier for you, you can also include this field in requests that don't need it. It will just be ignored by VTube Studio, even if you leave it empty or set it to `null`/`undefined`. VTube Studio will return this field with every request to make deserialization easier for your plugin. If the response doesn't have data, the field will contain an empty JSON object.

**Note about `timestamp` field:** All responses also have a `"timestamp"` field that contains the UNIX millisecond timestamp at which your request was processed. You may include a `"timestamp"` field in your requests, but it will be ignored.

## Subscribing to and unsubscribing from [events](Events/)

In previous API versions, information like the loaded model or items had to be polled repeatedly by plugins. Now, VTube Studio supports subscribing to **"events"**, which will make VTube Studio send you messages whenever something relevant to your plugin is happening. Events include getting notified when items are loaded, when tracking is lost/regained, when the model is clicked and many more.

Please check out the page about events [right here](Events/).

## Getting current VTS statistics

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "StatisticsRequest"
}
```

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "StatisticsResponse",
	"data": {
		"uptime": 1439384,
		"framerate": 73,
		"vTubeStudioVersion": "1.9.0",
		"allowedPlugins": 7,
		"connectedPlugins": 2,
		"startedWithSteam": true,
		"windowWidth": 1031,
		"windowHeight": 812,
		"windowIsFullscreen": false
	}
}
```

`"uptime"` contains the number of milliseconds since VTube Studio has been started. `"framerate"` is the current render FPS value. `"allowedPlugins"` is the number of plugins that the user has currently allowed to use VTube Studio, `"connectedPlugins"` is the number of plugins that are currently connected to the VTube Studio API. `"startedWithSteam"` is true if the app has been started using Steam, false otherwise (if the `.bat` file has been used to start VTS without Steam).

Window width and height is in pixels.

## Getting list of VTS folders

Returns the name of various VTube Studio folders. They are in the `StreamingAssets` folder in the game files.

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "VTSFolderInfoRequest"
}
```

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "VTSFolderInfoResponse",
	"data": {
		"models": "Live2DModels",
		"backgrounds": "Backgrounds",
		"items": "Items",
		"config": "Config",
		"logs": "Logs",
		"backup": "Backup"
	}
}
```

## Getting the currently loaded model

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "CurrentModelRequest"
}
```

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "CurrentModelResponse",
	"data": {
		"modelLoaded": true,
		"modelName": "My Currently Loaded Model",
		"modelID": "UniqueIDToIdentifyThisModelBy",
		"vtsModelName": "Model.vtube.json",
		"vtsModelIconName": "ModelIconPNGorJPG.png",
		"live2DModelName": "Model.model3.json",
		"modelLoadTime": 3021,
		"timeSinceModelLoaded": 419903,
		"numberOfLive2DParameters": 29,
		"numberOfLive2DArtmeshes": 136,
		"hasPhysicsFile": true,
		"numberOfTextures": 2,
		"textureResolution": 4096,
		"modelPosition": {
			"positionX": -0.1,
			"positionY": 0.4,
			"rotation": 9.33,
			"size": -61.9
		}
	}
}
```

`"modelLoaded"` will be `true` if a model is currently loaded. If no model is loaded or a model is currently in the process of being loaded, this will be false. In this case, all other values will be empty (or zero in case of integers).

`"modelLoadTime"` is the time in milliseconds it took to load the current model. `"timeSinceModelLoaded"` contains the time in milliseconds since the model has been loaded.

`"vtsModelIconName"` contains the name of the icon used for this model in the model selection bar in VTube Studio. If the model has no icon set, this will be an empty string. All file names returned in this request are relative to the respective model folder.

The `"modelPosition"` array contains the current model position, rotation and size. For more info on how to interpret these values, see `MoveModelRequest`.

## Getting a list of available VTS models

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "AvailableModelsRequest"
}
```

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "AvailableModelsResponse",
	"data": {
		"numberOfModels": 2,
		"availableModels": [
			{
				"modelLoaded": false,
				"modelName": "My First Model",
				"modelID": "UniqueIDToIdentifyThisModelBy1",
				"vtsModelName": "Model_1.vtube.json",
				"vtsModelIconName": "ModelIconPNGorJPG_1.png"
			},
			{
				"modelLoaded": true,
				"modelName": "My Second Model",
				"modelID": "UniqueIDToIdentifyThisModelBy2",
				"vtsModelName": "Model_2.vtube.json",
				"vtsModelIconName": "ModelIconPNGorJPG_1.png"
			}
		]
	}
}
```

`"modelLoaded"` is `true` if the respective model is currently loaded in VTube Studio, `false` otherwise. 

## Loading a VTS model by its ID

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "ModelLoadRequest",
	"data": {
		"modelID": "UniqueIDOfModelToLoad"
	}
}
```

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "ModelLoadResponse",
	"data": {
		"modelID": "UniqueIDOfModelThatWasJustLoaded"
	}
}
```

This may fail and return an error if the app is currently in a state where no model can be loaded/unloaded. This includes having config windows open or a model load operation currently already being in progress. There is also a global 2 second cooldown for this request.

If pass in an empty model ID, the currently loaded model will be unloaded (will do nothing if no model is loaded).

## Moving the currently loaded VTS model

If a model is loaded, this allows you to change its position, rotation and size. If no model is loaded, this will return an error, see [ErrorsID.cs](https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/ErrorID.cs)

The required fields in this request are `"timeInSeconds"` and `"valuesAreRelativeToModel"`. `"timeInSeconds"` is the time in seconds the movement should take and has to be a float value between 0 and 2. If this is set to 0, the model will instantly appear in the given position. A value higher than that will make the model move, rotate and grow/shrink smoothly to the given position (faded in/out). While the movement is going on, the user cannot move the model manually by dragging it. That will be possible again about half a second after the model has finished moving to the destination.

Subsequent `MoveModelRequest` can be sent without waiting for the ongoing one to finish. If one is ongoing, it will be interrupted and replaced by the new one. You can even take complete control over the movement by sending one request each frame with 0 as `"timeInSeconds"`.

The `"size"` is given as a float between -100 (smallest) and +100 (biggest). For `"positionX"`, `"positionY"` and `"rotation"`, please refer to the following image:

#### The VTS Coordinate System
![The VTS Coordinate System](/Images/coordinate_explanation.png)

The numbers in the cats represent the **[X/Y]** coordinates you can pass in using `"positionX"` and `"positionY"`. For example, sending [0/0] will position the middle of the model in the middle of the screen. What the "middle of the model" is can be set freely in Live2D Cubism and may vary between models. You can of course also send much bigger/smaller values to move the model off-screen. `"positionX"` and `"positionY"` have to be between -1000 and 1000.

The numbers around the circle represent the angles you can set using `"rotation"`. Values for this parameter have to be between -360 and 360. Please note how there are two representations for each angle: positive when rotating clockwise, negative when rotating counterclockwise. Which one you use is up to you, there is no difference. When you send a `CurrentModelRequest`, the response will also contain the position/rotation/size of the model. In this response, the angle will always be represented in the positive notation.

You don't have to provide all values in the request. For example, you could just provide positions or just a rotation or any other combination. All values that are not included in the request will be ignored when setting the position/rotation/size. Like this, you could for example only change the X-coordinate of the model while leaving everything else as it is.

If `"valuesAreRelativeToModel"` is set to `false`, the values from your request will be taken as absolute values and the model will be moved to that position. If `"valuesAreRelativeToModel"` is set to `true`, the values are considered to be relative to the current model position. Let's assume you set it to `true` and only include a rotation of `10` in your request. That would rotate the model clockwise by 10 degrees, from whatever rotation it is at right now while not touching the position and size at all. This can be very useful for implementing effects that should move the model in place, like shaking it independently of where it is on the screen.

If you want to move the model to a fixed pixel position or by a certain amount of pixels, you'll have to calculate the respective coordinates yourself. You can do so by getting the window width and height in pixels using the `StatisticsRequest`.

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "MoveModelRequest",
	"data": {
		"timeInSeconds": 0.2,
		"valuesAreRelativeToModel": false,
		"positionX": 0.1,
		"positionY": -0.7,
		"rotation": 16.3,
		"size": -22.5
	}
}
```

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "MoveModelResponse",
	"data": { }
}
```



## Requesting list of hotkeys available in current or other VTS model

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "HotkeysInCurrentModelRequest",
	"data": {
		"modelID": "Optional_UniqueIDOfModel",
		"live2DItemFileName": "Optional_Live2DItemFileName"
	}
}
```

The `"modelID"` (and `"data"` object in general here) is optional. If it's not provided, the hotkeys for the current model are returned. If the model ID is provided, the hotkeys of the model with the give model ID are returned. If no model with that ID is found, an error is returned (see [ErrorID.cs](https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/ErrorID.cs), `ModelIDNotFound`).

This can also return the hotkeys of any available Live2D item. To do that, just pass in the filename of the item in the `"live2DItemFileName"` field. You can get the (unique) filenames of all available Live2D items using the `ItemListRequest`.

If both `"modelID"` and `"live2DItemFileName"` are provided, only `"modelID"` is used and the other field will be ignored.

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "HotkeysInCurrentModelResponse",
	"data": {
		"modelLoaded": true,
		"modelName": "My Currently Loaded Model",
		"modelID": "UniqueIDOfModel",
		"availableHotkeys": [
			{
				"name": "My first hotkey",
				"type": "ToggleExpression",
				"description": "Toggles an expression",
				"file": "myExpression_1.exp3.json",
				"hotkeyID": "SomeUniqueIdToIdentifyHotkeyWith1",
				"keyCombination": [],
                		"onScreenButtonID": 8
			},
			{
				"name": "My second hotkey",
				"type": "TriggerAnimation",
				"description": "Triggers an animation",
				"file": "myAnimation.motion3.json",
				"hotkeyID": "SomeUniqueIdToIdentifyHotkeyWith2",
				"keyCombination": [],
                		"onScreenButtonID": -1
			},
			{
				"name": "My third hotkey",
				"type": "ChangeVTSModel",
				"description": "Changes the VTS model",
				"file": "someOtherModel.vtube.json",
				"hotkeyID": "SomeUniqueIdToIdentifyHotkeyWith3",
				"keyCombination": [],
                		"onScreenButtonID": -1
			},
			{
				"name": "My fourth hotkey",
				"type": "MoveModel",
				"description": "Moves the Live2D model",
				"file": "",
				"hotkeyID": "SomeUniqueIdToIdentifyHotkeyWith4",
				"keyCombination": [],
                		"onScreenButtonID": -1
			},
			{
				"name": "My fifth hotkey",
				"type": "Unset",
				"description": "No action set for hotkey",
				"file": "",
				"hotkeyID": "SomeUniqueIdToIdentifyHotkeyWith5",
				"keyCombination": [],
                		"onScreenButtonID": 5
			}
		]
	}
}
```

If no model ID was specified in the request and no model is loaded, `"modelLoaded"` will be false and the `"availableHotkeys"` array will be empty. If an ID was specified, the `"modelLoaded"` field will be `true` or `false` depending on whether or not the model with the given ID is currently loaded.

The `"file"` field contains the expression/animation/model filename for hotkeys of type `TriggerAnimation`, `ChangeIdleAnimation`, `ToggleExpression` and `ChangeVTSModel`. For `ChangeBackground` hotkeys, this contains the background name without the file extension. For all other types, it contains an empty string.

The `"description"` field contains a description of what the hotkey does. You can show this string on your plugin UI when you encounter a hotkey type that your plugin doesn't know, for example because the hotkey type was newly added to VTube Studio. 

The `"keyCombination"` array contains the keyboard (or mouse key) combination that will trigger they hotkey. See [RestrictedRawKey.cs](https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/RestrictedRawKey.cs) for all possible values. If the array is empty, no key combination has been set. **IMPORTANT:** For security reasons, the `"keyCombination"` array will currently **always be empty**, so this data won't be available to plugins for now. May be re-added in a future update.

The `"onScreenButtonID"` field contains all on-screen button IDs that will trigger the hotkey (1 (top) to 8 (bottom) or -1). If the value is `-1`, no on-screen button has been set for this hotkey.

All hotkey type strings can be found on the page [HotkeyActions.cs](https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/HotkeyAction.cs).

## Requesting execution of hotkeys

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "HotkeyTriggerRequest",
	"data": {
		"hotkeyID": "HotkeyNameOrUniqueIdOfHotkeyToExecute",
		"itemInstanceID": "Optional_ItemInstanceIdOfLive2DItemToTriggerThisHotkeyFor"
	}
}
```

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "HotkeyTriggerResponse",
	"data": {
		"hotkeyID": "UniqueIdOfHotkeyThatWasExecuted"
	}
}
```

This triggers a hotkey for the currently loaded VTube Studio model, if you leave `"itemInstanceID"` empty or don't provide it at all. If you do provide an ID in that field, it will trigger the hotkey in the given Live2D Item model instead (see below for more info).

You can trigger hotkeys either by their unique ID or the hotkey name (case-insensitive). If multiple hotkeys have the same name, only the first one will be executed (order is the order they show up in the UI). Hotkeys with empty name can only be triggered by ID.

This may return an error if the hotkey ID or name wasn't found or the hotkey couldn't be executed for some reason. Reasons include no model being currently loaded or the hotkey cooldown not being over (one specific hotkey can only be triggered once every 5 frames). You may send different hotkeys in quick succession, which will result in them getting queued. Once every 5 frames, one hotkey is take from the queue and executed. The queue holds 32 hotkeys. When the queue is full but you try to send in more hotkeys, an error will be returned.

### Triggering hotkeys in Live2D Items

You can also use this request to trigger hotkeys in Live2D items. See [this page](https://github.com/DenchiSoft/VTubeStudio/wiki/Live2D-Items) for more info on Live2D items in general.

To do this, just set `"itemInstanceID"` to the instance ID of the Live2D item. If no Live2D item with that instance ID is currently loaded, an error is returned. To get the instance IDs of all currently loaded items, you can use the `ItemListRequest`.

## Requesting current expression state list

You can get the current state (active or inactive) of one specific expression or all expressions. If you include `"expressionFile"`, only the state of that expression will be returned. If you don't include it or leave it as an empty string, the state of all expressions in the current model will be returned.

If you include a filename but it's invalid (doesn't end in `.exp3.json`) or not found in the current model, an error is returned (see "[ErrorID.cs](https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/ErrorID.cs)").

Setting `"details"` to true will return a few more details in the response (specifically, the `"usedInHotkeys"` and `"parameters"` arrays will be empty if `"details"` is set to false).

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "ExpressionStateRequest",
	"data": {
		"details": true,
		"expressionFile": "myExpression_optional_1.exp3.json",
	}
}
```

The `expressions` array will be empty if no model is loaded. Otherwise, this will contain information about the available expressions for the currently loaded model.

The `"file"` field is the filename of the expression as it is stored in the model folder. `"name"` is the same just without the `.exp3.json` extension. `"active"` tells you whether or not the expression is currently active.

If the expression was activated using a hotkey, `"deactivateWhenKeyIsLetGo"` and `"autoDeactivateAfterSeconds"` will tell you whether or not those options were activated for the expression hotkey. If `"autoDeactivateAfterSeconds"` is `true`, the remaining time until the expression is automatically deactivated will be returned in `"secondsRemaining"` (otherwise it will be 0).

If `"details"` was set to `true` in the request the `"usedInHotkeys"` array will contain a list of all hotkeys that this expression is used in. Also, the `"parameters"` array will contain the contents of the expression, meaning the Live2D parameter IDs and target values of all parameters used in the expression.

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "ExpressionStateResponse",
	"data": {
		"modelLoaded": true,
		"modelName": "My Currently Loaded Model",
		"modelID": "UniqueIDOfModel",
		"expressions": [
			{
				"name": "myExpression_optional_1",
				"file": "myExpression_optional_1 .exp3.json",
				"active": false,
				"deactivateWhenKeyIsLetGo": false,
				"autoDeactivateAfterSeconds": false,
				"secondsRemaining": 0,
				"usedInHotkeys": [
					{
						"name": "Some Hotkey",
						"id": "SomeUniqueIdToIdentifyHotkeyWith1"
					},
					{
						"name": "Some other Hotkey",
						"id": "SomeUniqueIdToIdentifyHotkeyWith2"
					}
				],
				"parameters": [
					{
						"name": "SomeLive2DParamID",
						"value": 0
					}
				]
			}
		]
	}
}
```

## Requesting activation or deactivation of expressions

It's recommended to activate expressions via hotkeys since otherwise users could end up with activated expressions they can't deactivate because they don't have hotkeys set up for them. However, you can also activate and deactivate expressions directly if that's required for your plugin. You do this by passing in an expression file name and whether the expression should be activated or deactivated.

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "ExpressionActivationRequest",
	"data": {
		"expressionFile": "myExpression_1.exp3.json",
		"fadeTime": 0.5,
		"active": true
	}
}
```

You will get this empty response if the request was successful. If the filename is invalid (doesn't end in `.exp3.json`) or not found in the current model or no model is loaded, an error is returned (see "[ErrorID.cs](https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/ErrorID.cs)").
The `fadeTime` parameter is clamped between 0 and 2 seconds. Its default is 0.25. Note that the fade time can only be set while fading in due to restrictions from the VTS animation system. When fading out an expression, the same time from the fade in will always be used.

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "ExpressionActivationResponse",
	"data": { }
}
```

## Requesting list of ArtMeshes in current model

The API uses the term `ArtMesh Name`, but this actually refers to the ArtMesh ID which will be unique per model as enforced by the Live2D Cubism Editor. `ArtMesh Tags` can be added by selecting an ArtMesh and writing into the UserData field. If you want to use tags, make sure that you check `Export UserData file (userdata3.json)`. You should then include the `.userdata3.json` file when copying the model to the VTube Studio Live2DModels-folder.

ArtMesh tags returned in the `"artMeshTags"` array will not contain duplicate tags.

If no model is loaded, `"modelLoaded"` will be `false` and the arrays will be empty.

**Note about "tags":** Tags can be added to ArtMeshes in the "UserData" field in the Live2D Cubism Editor. You can add any text into that field in the editor. VTube Studio will split that text at spaces and newline characters. This means if your tag text is "my tag", it will become two tags in VTS: "my" and "tag". You can add as many tags to each ArtMesh as you want.

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "ArtMeshListRequest"
}
```

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "ArtMeshListResponse",
	"data": {
		"modelLoaded": true,
		"numberOfArtMeshNames": 5,
		"numberOfArtMeshTags": 2,
		"artMeshNames": ["ArtMesh1", "ArtMesh2", "HairFront1", "HairFront2", "SomeArtMesh"],
		"artMeshTags": ["my_tag", "SomeOtherTag"]
	}
}
```

## Tint ArtMeshes with color

You can tint ArtMeshes by providing a color and matching criteria. Any ArtMesh matching any of the given criteria will be tinted with the given color. To reset the ArtMesh color, tint it white (R=G=B=A=255). You cannot turn an ArtMesh white with this request, only darker.

Not providing one of the color values or any being outside the 0-255 range will return an error. Trying to send this request when no model is loaded will also return an error.

Optionally, you can provide `mixWithSceneLightingColor` between 0 and 1. If provided, this will determine how the tint color is mixed with the scene lighting system color (see [here](https://github.com/DenchiSoft/VTubeStudio/wiki/Display-Light-Overlay) for more info on that). If it's set to 1, your provided color value will overwrite the value set by the scene lighting completely. Setting it to 0 will make the scene lighting color overwrite your provided color. Anything in between will mix the two colors. If scene lighting is off, this has no effect. If you don't provide `mixWithSceneLightingColor`, it's set to 1 per default, meaning your provided color will overwrite the scene lighting completely.

All arrays included in the `"artMeshMatcher"` object are optional. If you include them, it will select ArtMeshes based on whether or not the ArtMesh names or tags match any of the given strings exactly or contain them (when using the `"nameContains"`/`"tagContains"` arrays). The `"artMeshNumber"` array lets you select ArtMeshes based on their order within the model. If you just want to tint the whole model, don't include any of the matcher arrays and instead set `"tintAll"` to true.

When the session is disconnected, all ArtMeshes that have been tinted in this session will be reset to their default (fully opaque white). When multiple plugins/sessions overwrite the color of an ArtMesh, it will have the color set by the most recent request.

Matching is always executed **case-insensitive**.

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "ColorTintRequest",
	"data": {
		"colorTint": {
			"colorR": 255,
			"colorG": 150,
			"colorB": 0,
			"colorA": 255,
			"mixWithSceneLightingColor": 1
		},
		"artMeshMatcher": {
			"tintAll": false,
			"artMeshNumber": [1, 3, 5],
			"nameExact": ["eye_white_left", "eye_white_right"],
			"nameContains": ["mouth"],
			"tagExact": [],
			"tagContains": ["MyTag"]
		}
	}
}
```

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "ColorTintResponse",
	"data": {
		"matchedArtMeshes": 3
	}
}
```

## Getting scene lighting overlay color

VTube Studio has functionality to overlay the model with the average color captured from a screen (macOS/Windows) or specific window (Windows only). For more info, see [this page in the documentation](https://github.com/DenchiSoft/VTubeStudio/wiki/Display-Light-Overlay).

You can get the current user configuration and color for the scene lighting overlay system via the API.

In the top level of the response, you have the `active` field, which tells you whether or not the lighting overlay is on. If `itemsIncluded` is true, all items are also affected by the lighting overlay. If `isWindowCapture` is `true`, VTube Studio is set to capture the average color of a window. If this is `false`, the capture is set to a screen. 

`baseBrightness` (between 0 and 100), `colorBoost` (between 0 and 100) and `smoothing` (between 0 and 60) are the three values users can select using sliders on the UI. For an explanation, please check [documentation page about this feature](https://github.com/DenchiSoft/VTubeStudio/wiki/Display-Light-Overlay).

`leftCapturePart`, `middleCapturePart` and `rightCapturePart` describe the average colors of the respective parts of the captured window or screen. Their `active` field tells you whether or not the screen part has been activated by the user.

The average color calculated from all activated screen parts can be found in the `colorAvg` fields (R, G and B between 0 and 255).

The final color that will be used to overlay the ArtMeshes is in the `colorOverlay` fields (R, G and B between 0 and 459). Note that this allows values higher than 255. The final color is calculated as follows:

`colorAvg` *  (`colorBoost` / 50) + `WHITE_COLOR` * (`baseBrightness` / 100)

This may produce values as high as 2 * 255 for R, G and B. The values are capped at 1.8 * 255 = 459.

When the lighting overlay system is turned off, `active` on the top payload level will be `false` and all colors will be returned as white.

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "SceneColorOverlayInfoRequest"
}
```

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "SceneColorOverlayInfoResponse",
	"data": {
		"active": true,
		"itemsIncluded": true,
		"isWindowCapture": false,
		"baseBrightness": 16,
		"colorBoost": 35,
		"smoothing": 6,
		"colorOverlayR": 206,
		"colorOverlayG": 150,
		"colorOverlayB": 153,
		"colorAvgR": 237,
		"colorAvgG": 157,
		"colorAvgB": 162,
		"leftCapturePart": {
			"active": true,
			"colorR": 243,
			"colorG": 231,
			"colorB": 234
		},
		"middleCapturePart": {
			"active": true,
			"colorR": 230,
			"colorG": 83,
			"colorB": 89
		},
		"rightCapturePart": {
			"active": false,
			"colorR": 235,
			"colorG": 95,
			"colorB": 101
		}
	}
}
```


## Checking if face is currently found by tracker

Returns whether or not the face is currently found by the active tracker (smartphone via network/USB or webcam tracker).

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "FaceFoundRequest"
}
```

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "FaceFoundResponse",
	"data": {
		"found": true
	}
}
```

## Requesting list of available tracking parameters

You can request a list of parameters currently available in VTube Studio.
This includes all regular parameters and all custom parameters created by plugins. Parameters created by plugins will be marked as such when you select them from the parameter list in VTube Studio. It will also show the name of the plugin that created them.

**Important:** This may return a lot of data. It is not recommended to send this request at high frequencies (60+ FPS), as it may cause performance issues on slower PCs.

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "InputParameterListRequest"
}
```

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "InputParameterListResponse",
	"data": {
		"modelLoaded": true,
		"modelName": "My Currently Loaded Model",
		"modelID": "UniqueIDOfModel",
		"customParameters": [
			{
				"name": "MyCustomParamName1",
				"addedBy": "My Plugin Name",
				"value": 12.4,
				"min": -30,
				"max": 30,
				"defaultValue": 0
			},
			{
				"name": "MyCustomParamName2",
				"addedBy": "My Plugin Name",
				"value": 0.833,
				"min": -10,
				"max": 10,
				"defaultValue": 0
			},
			{
				"name": "MyCustomParamName3",
				"addedBy": "My Other Plugin Name",
				"value": 0,
				"min": 0,
				"max": 1,
				"defaultValue": 0
			}
		],
		"defaultParameters": [
			{
				"name": "FaceAngleX",
				"addedBy": "VTube Studio",
				"value": 45.78,
				"min": -30,
				"max": 30,
				"defaultValue": 0
			},
			{
				"name": "FacePositionX",
				"addedBy": "VTube Studio",
				"value": 8.33,
				"min": -10,
				"max": 10,
				"defaultValue": 0
			}
		]
	}
}
```
**Note:** The `"defaultParameters"` array is incomplete in this example payload. This will contain all default face/mouse/etc. tracking parameters offered by VTube Studio 

## Get the value for one specific parameter, default or custom

If the requested input parameter does not exist, an error will be returned.

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "ParameterValueRequest",
	"data": {
		"name": "MyCustomParamName1"
	}
}
```

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "ParameterValueResponse",
	"data": {
		"name": "MyCustomParamName1",
		"addedBy": "My Plugin Name",
		"value": 12.4,
		"min": -30,
		"max": 30,
		"defaultValue": 0
	}
}
```

## Get the value for all Live2D parameters in the current model

This will return an error if no model is loaded.

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "Live2DParameterListRequest"
}
```

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "Live2DParameterListResponse",
	"data": {
		"modelLoaded": true,
		"modelName": "My Currently Loaded Model",
		"modelID": "UniqueIDOfModel",
		"parameters": [
			{
				"name": "MyLive2DParameterID1",
				"value": 12.4,
				"min": -30,
				"max": 30,
				"defaultValue": 0
			},
			{
				"name": "MyLive2DParameterID2",
				"value": 0,
				"min": 0,
				"max": 1,
				"defaultValue": 0
			}
		]
	}
}
```

If no model is loaded, `"modelLoaded"` will be false and the parameter array will be empty. All other fields will be empty strings.

## Adding new tracking parameters ("custom parameters")

You can also add your own new tracking parameters and use them in your VTube Studio models. They are called "custom" parameters. After being added by your plugin, the user can select your parameters as inputs for Live2D parameter mappings.

Parameter names have to be unique, alphanumeric (no spaces allowed) and have to be between 4 and 32 characters in length. New tracking parameters are created like this:

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "ParameterCreationRequest",
	"data": {
		"parameterName": "MyNewParamName",
		"explanation": "This is my new parameter.",
		"min": -50,
		"max": 50,
		"defaultValue": 10
	}
}
```

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "ParameterCreationResponse",
	"data": {
		"parameterName": "MyNewParamName"
	}
}
```

The request may fail and return an error if the parameter name is invalid.

It will also fail if a parameter with the same name created by a different plugin already exists. If you create a parameter multiple times with the same plugin name, the request will succeed. You can also overwrite the `min`, `max` and `defaultValue` values that way

Min/Max/Default values have to be floating-point numbers between `-1000000` and `1000000`. The min/max values aren't actually the minimum and maximum values allowed for the parameter. They're the values that will be used as default lower and upper value when a new parameter mapping is created using this parameter.

The explanation is an optional, short (less than 256 characters) explanation stating what the parameter does and how users should use it in their models. If you provide this in the request, it will be shown when the user views the details of this custom parameter.

There is a global limit in VTS of 300 custom parameters and a limit of 100 custom parameters per plugin. If you try to create more, an error will be returned.

These custom parameters you create are stored as part of the VTube Studio configuration in a file called `custom_parameters.json` in the `Config` folder, which is located in the VTube Studio `StreamingAssets` folder. If you revoke the authentication token from a plugin, all custom parameters that this plugin create will also be deleted. They will still be set in the VTube Studio models that have used them, but will be shown in red text to indicate that the input parameter no longer exists. Plugins can get another token and recreate these parameters at any time and they will continue to work.

## Delete custom parameters

You can delete custom parameters. Default parameters cannot be deleted. You also cannot delete parameters created by plugins other than the one you have used to authenticate this session.

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "ParameterDeletionRequest",
	"data": {
		"parameterName": "MyNewParamName"
	}
}
```

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "ParameterDeletionResponse",
	"data": {
		"parameterName": "MyNewParamName"
	}
}
```

## Feeding in data for default or custom parameters

You can feed in data for any default or custom parameter. These tracking parameters will then be used as inputs for the loaded VTube Studio model and any loaded [Live2D Items](https://github.com/DenchiSoft/VTubeStudio/wiki/Live2D-Items).

The payload looks like this:

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "InjectParameterDataRequest",
	"data": {
		"faceFound": false,
		"mode": "set",
		"parameterValues": [
			{
				"id": "FaceAngleX",
				"value": 12.31
			},
			{
				"id": "MyNewParamName",
				"weight": 0.8,
				"value": 0.7
			}
		]
	}
}
```

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "InjectParameterDataResponse",
	"data": { }
}
```

If one or more of the parameters don't exist, an error payload will be returned.

Values have to be floating-point numbers between `-1000000` and `1000000`. Values outside of that range will also return an error.

If values exist for those parameters from webcam/iOS/Android tracking, the values from the API will overwrite those for as long as you keep sending data over the API.
You have to re-send data for a parameter you want to control with your plugin **at least once every second**. Failure to do so will result in the parameter being considered "lost" and it will go back to the value of whatever was controlling it before. If nothing else is controlling it, it will return to its default value.

You can also add an optional `"weight"` parameter between 0 and 1. This can be used used to mix the `"value"` you send in for the parameter with the value that has been set for the parameter from face tracking. You could for example control a parameter 50% with face tracking and 50% using the API. Only one API plugin can write to one parameter at a time though. One use-case for this would be to fade in/out control of a face tracking parameter so it doesn't "jump" the moment you take control of it via the API. If you don't include the `"weight"` parameter in your request for a parameter, it will be considered to have the value 1, meaning the target parameter will instantly be set to the value provided by your plugin.

It should also be noted that these parameters are treated similar to normal tracking parameters. As such, you can select them as normal inputs for VTube Studio parameter mappings and apply smoothing via the sliders on the UI. Deleting custom parameters while they are being used by a model also does not cause any issues and they can be recreated at any time.

Optionally, you can pass in `"faceFound": true`, which will tell VTube Studio to consider the user face as found. That way, you can control when the "tracking lost" animation is played.

### Controlling one parameter with multiple plugins

Generally, if another plugin is already controlling one (default or custom) parameter, an error will be returned. This happens because only one plugin can "set" (override) a given parameter at a time, which is the default mode for this request. This is the mode that is used when you don't provide a value in the `"mode"` field or set the value to `"set"`.

Alternatively, you can set the `"mode"` field to `"add"`. This will instead add the values you send to whatever the current parameter values are. The `"weight"` values aren't used in that case. Any number of plugins can use the `"add"` mode for a given parameter at the same time. This can be useful for **bonk/throwing** type plugins and other use-cases.

## Getting physics settings of currently loaded VTS model

Users can customize physics settings in VTube Studio. They can change the following settings:

- **Base physics strength (per model):** Integer between 0 (off) and 100 (max). Default is 50, which means physics will behave like in the Live2D Cubism Editor. 
- **Base wind strength (per model):** Integer between 0 (off) and 100 (max). Default is 0. 
- **Physics Multiplier (per physics group):** For each physics group (can be set up in Live2D Cubism), users can set a multiplier. The base physics value will be multiplied by this value when processing the respective physics group. Float between 0 and 2, default is 1 meaning the base value stays unchanged.
- **Wind Multiplier (per physics group):** For each physics group (can be set up in Live2D Cubism), users can set a multiplier. The base wind value will be multiplied by this value when processing the respective physics group. Float between 0 and 2, default is 1 meaning the base value stays unchanged.

These values set by the user can be read via the API and also overridden temporarily (see `SetCurrentModelPhysicsRequest`).

To read the values of the currently loaded model, use this request:


**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "GetCurrentModelPhysicsRequest"
}
```

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "GetCurrentModelPhysicsResponse",
	"data": {
		"modelLoaded": true,
		"modelName": "My Currently Loaded Model",
		"modelID": "UniqueIDOfModel",
		"modelHasPhysics": true,
		"physicsSwitchedOn": true,
		"usingLegacyPhysics": false,
		"physicsFPSSetting": -1,
		"baseStrength": 50,
		"baseWind": 17,
		"apiPhysicsOverrideActive": false,
		"apiPhysicsOverridePluginName": "",
		"physicsGroups": [
			{
				"groupID": "PhysicsSetting1",
				"groupName": "Hair Front Physics",
				"strengthMultiplier": 1.5,
				"windMultiplier": 0.3
			},
			{
				"groupID": "PhysicsSetting2",
				"groupName": "Clothes Physics",
				"strengthMultiplier": 1,
				"windMultiplier": 2
			}
		]
	}
}
```

If no model is loaded, `modelLoaded` will be `false`. All other values do not have any significance in that case and the `physicsGroups` array will be empty.

If a model is loaded, the `modelHasPhysics` field will tell you whether or not the model has a valid physics setup. Some models don't have physics set up or have a broken physics file which will cause the physics system to not start correctly. `physicsSwitchedOn` will be true if the `Use Physics` toggle has been activated for this model by the user in VTube Studio. `usingLegacyPhysics` is the state of the `Legacy Physics` toggle.

`physicsFPSSetting` contains the physics FPS setting for this model and can be 30, 60, 120 or -1, which indicates that the user has selected `Use same FPS as app`.

The `apiPhysicsOverrideActive` and `apiPhysicsOverridePluginName` fields indicate whether or not a plugin is currently overriding some of the physics settings. If it's active field is true, the name field will contain the name of the plugin. Only one plugin can take control of the physics system at a time. This will also be explained as part of the `SetCurrentModelPhysicsRequest` request. 

If you use the `SetCurrentModelPhysicsRequest` to override physics or wind base values or multipliers, these changes will **NOT** be reflected in this Get-Request. You have to remember your own physics overrides.

Note for the `physicsGroup` array: Every group has an ID but not every group has to have a name. In that case, the respective `groupName` field will be an empty string.

## Overriding physics settings of currently loaded VTS model

You can override the physics settings of the currently loaded model using this request. Once one plugin has taken control of the physics system via this API, no other plugin can use this API until the first plugin has given up control. Trying to do so will return the respective error, see "[ErrorID.cs](https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/ErrorID.cs)" (`SetCurrentModelPhysicsRequestPhysicsControlledByOtherPlugin`). This will also return an error if no model is loaded, if any of your provided physics group IDs don't exist in the current model or if you forgot to add a value to your overrides.

If the user has turned off physics for the currently loaded model, you cannot turn physics on using this API. You can only use this API to override physics/wind base values and multipliers.

As explained in the `GetCurrentModelPhysicsRequest` section above, values for physics/wind multipliers should be between 0 and 2 while values for physics/wind base values should be integers between 0 and 100 (because that's also how they're shown to the user in the app). Values outside that range will automatically be clamped.

If you want to set multipliers for strength or wind for a specific physics group, use the `strengthOverrides` and `windOverrides` arrays with the respective group ID and `setBaseValue` set to false. If you set `setBaseValue` to true, the provided value will be set as base value for physics strength or wind instead of a specific group. You can leave the group ID (`id`) empty in that case. 

Generally, the values set using this API are used to override the values set by the user in the app. They're not actually shown to the user on the UI and are not saved. Override values set using this API are automatically unset when their timer runs out (the value you set using `overrideSeconds`). If you want to keep overriding values, you have to repeatedly send this request.

When all timers run out, the API will no longer consider your plugin as controlling the physics system so another plugin could start controlling the physics system.

Override timer values have to be between 0.5 and 5 seconds.  Values outside that range will automatically be clamped.

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "SetCurrentModelPhysicsRequest",
	"data": {
		"strengthOverrides": [
			{
				"id": "PhysicsSetting1",
				"value": 1.5,
				"setBaseValue": false,
				"overrideSeconds": 2
			}
		],
		"windOverrides": [
			{
				"id": "",
				"value": 85,
				"setBaseValue": true,
				"overrideSeconds": 5
			}
		]
	}
}
```

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "SetCurrentModelPhysicsResponse",
	"data": { }
}
```

## Get and set NDI settings

You can request the current NDI settings and change them via the API. This allows you to turn NDI on/off, set a custom fixed resolution and more.

Information about NDI and how to use it in VTube Studio can be found on this page: https://github.com/DenchiSoft/VTubeStudio/wiki/Streaming-to-Mac-PC

If you set `"setNewConfig"` to `false`, this only returns the current config. All other fields are ignored in that case. If it's set to `true`, the given config will be set if it's valid.

`"ndiActive"` turns NDI on/off. If NDI is on, `"useNDI5"` uses NDI 5 instead of NDI 4 (I recommend using NDI 5).

Setting `"useCustomResolution"` to `true` means the NDI stream will no longer have the same resolution as the VTube Studio window but instead use the custom resolution set via the UI. This resolution can also be changed via the API using the `"customWidthNDI"` and `"customHeightNDI"` fields. Both have to be between 256 and 8192. The width has to be a multiple of 16 and the height has to be a multiple of 8. Setting them both to `-1` in the request will skip setting them and instead only set the boolean fields. That way you can for example turn NDI on/off without changing the resolution.

If the NDI resolution does not match the window resolution, VTube Studio will automatically cut and scale the video stream. VTube Studio will always make sure the aspect ratio is correct, even if that means cutting off parts at the top/bottom or left/right.

**Important:** This request has a cooldown period of 3 seconds. Triggering it too fast will return an error of type `NDIConfigCooldownNotOver` (see "[ErrorID.cs](https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/ErrorID.cs)").

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "NDIConfigRequest",
	"data": {
		"setNewConfig": true,
		"ndiActive": true,
		"useNDI5": true,
		"useCustomResolution": true,
		"customWidthNDI": 1024,
		"customHeightNDI": 512
	}
}
```

The response will just contain the current settings (the new ones if you requested a new config to be set). The `"setNewConfig"` field does not have any significance in the response.

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "NDIConfigResponse",
	"data": {
		"setNewConfig": true,
		"ndiActive": true,
		"useNDI5": true,
		"useCustomResolution": true,
		"customWidthNDI": 1024,
		"customHeightNDI": 512
	}
}
```

## Requesting list of available items or items in scene

This request lets you request a list of items that are currently in the scene. It also lets you request a list of item files that are available to be loaded on the user's PC, including Live2D items, animation folders, ...

If you want to know which order-spots are available to load items into right now, set `"includeAvailableSpots"` to `true`. Otherwise, the `"availableSpots"` array in the response will be empty.

If you want to know which items are loaded in the scene into right now, set `"includeItemInstancesInScene"` to `true`. Otherwise, the `"itemInstancesInScene"` array in the response will be empty.

If you want to know which item files are available to be loaded, set `"includeAvailableItemFiles"` to `true`. Otherwise, the `"availableItemFiles"` array in the response will be empty. **IMPORTANT:** This reads the full list of item files from the user's PC. This may lag the app for a small moment, so do not use this request with `"includeAvailableItemFiles"` set to `true` often. Only use it if you really need to refresh the list of available item files. Set it to `false` in any other case.

#### Filtering for specific items

If you only want the item lists to contain items with a certain item instance ID or a certain filename, you can provide them in the `"onlyItemsWithInstanceID"` and `"onlyItemsWithFileName"` fields respectively.

There will only ever be at most one item with a certain instance ID in the scene, but there could be many items with the same filename because you can load many item instances based on the same item file.

Please also note that **item filenames are unique**, meaning there cannot be two item files with the same filename. They are also **case-sensitive**, so if you want to refer to one specific file, make sure to not change the capitalization.

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "ItemListRequest",
	"data": {
		"includeAvailableSpots": true,
		"includeItemInstancesInScene": true,
		"includeAvailableItemFiles": false,
		"onlyItemsWithFileName": "OPTIONAL_my_item_filename.png",
		"onlyItemsWithInstanceID": "OPTIONAL_InstanceIdOfItemInScene"
	}
}
```

The fields in the response should me mostly self-explanatory.

The filename is the name of the item file. This is the name you can use to load an instance of the item into the scene. For JPG/PNG/GIF items, this is the full filename (without path) including the file extension (for example "my_item.jpg"). For animation folders, it's the folder name. For Live2D items, it is also the folder name.

The item type can be found in the `"type"` field. Possible values are `PNG`, `JPG`, `GIF`, `AnimationFolder` or `Live2D`. Another possible value is `Unknown`. This would only happen if there is another item type is added to VTube Studio before the API is updated, so it should never happen. 

`"canLoadItemsRightNow"` may be `false` if the user has certain menus or dialogs open in VTube Studio. This generally prevents actions such as loading items, using hotkeys and more.

`"framerate"` and `"frameCount"` are only available for animated items (GIFs and animation frame folders).

If `"pinnedToModel"` is true, `"pinnedModelID"` will contain the model ID of the model the item is pinned to (which will be the currently loaded model) and `"pinnedArtMeshID"` will contain the ID of the ArtMesh the item is pinned to.

If you set `"includeAvailableItemFiles"` to `true`, the `"availableItemFiles"` will contain a list of all item files in the user's `Items` folder. You can use the filenames returned here to load items into the scene using the `ItemLoadRequest`.

**`RESPONSE`**
```json
{
    "apiName": "VTubeStudioPublicAPI",
    "apiVersion": "1.0",
    "timestamp": 1625405710728,
    "messageType": "ItemListResponse",
    "requestID": "SomeID",
    "data": {
        "itemsInSceneCount": 2,
        "totalItemsAllowedCount": 60,
        "canLoadItemsRightNow": true,
        "availableSpots":
	[
            -30,-29,-28,-27,-26,-25,-24,-23,-22,-21,-20,-19,-18,-17,-16,-15,-14,
            -13,-12,-11,-10,-9,-8,-7,-6,-5,-4,-3,-2,-1,3,4,5,6,7,8,9,10,11,12,13,
            14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30
        ],
        "itemInstancesInScene": [
            {
                "fileName": "Ribbon (@denchisoft)",
                "instanceID": "18de53dc47154b00afdd382a6ebd2194",
                "order": 1,
                "type": "Live2D",
                "censored": false,
                "flipped": false,
                "locked": false,
                "smoothing": 0.0,
                "framerate": 0.0,
                "frameCount": -1,
                "currentFrame": -1,
                "pinnedToModel": true,
                "pinnedModelID": "47c71722c5304a039b0570b60a189875",
                "pinnedArtMeshID": "D_FACE_00",
                "groupName": "",
                "sceneName": "",
                "fromWorkshop": false
            },
            {
                "fileName": "akari_fly (@walfieee)",
                "instanceID": "716cddf2e12a438ab5da05bbbf8b341c",
                "order": 2,
                "type": "AnimationFolder",
                "censored": false,
                "flipped": false,
                "locked": false,
                "smoothing": 0.0,
                "framerate": 15.0,
                "frameCount": 7,
                "currentFrame": 0,
                "pinnedToModel": false,
                "pinnedModelID": "",
                "pinnedArtMeshID": "",
                "groupName": "",
                "sceneName": "",
                "fromWorkshop": false
            }
        ],
        "availableItemFiles": [
            {
                "fileName": "Ribbon (@denchisoft)",
                "type": "Live2D",
                "loadedCount": 1
            },
            {
                "fileName": "ANIM_headpat",
                "type": "AnimationFolder",
                "loadedCount": 0
            },
            {
                "fileName": "workshop_2801215328_ANIM_loading gif",
                "type": "AnimationFolder",
                "loadedCount": 0
            },
            {
                "fileName": "akari_fly (@walfieee)",
                "type": "AnimationFolder",
                "loadedCount": 1
            },
            {
                "fileName": "b_woozy (@denchisoft).png",
                "type": "PNG",
                "loadedCount": 0
            }
        ]
    }
}
```

## Loading item into the scene

With this request, you can load items into the scene. Items are loaded from the "Items" folder on the user's PC.

To get the list of available item files, use the `ItemListRequest`. You can use those names in the `"fileName"` field.

Items can be positioned/scaled/rotated using the `"positionX/Y"`, `"size"` and `"rotation"` fields. Please refer to the image showing the [VTube Studio coordinate system](#the-vts-coordinate-system) for more info on how to use these values. As for the size, it has to be between `0` and `1`, with `0.32` being roughly the "default" size that items will have when the user loads them manually.

You should make sure that your plugin cleans up its items. You should absolutely never leave any items outside of the visible scene where the user can't access them anymore without using the **"Delete all items in the scene"** button. To make this easier for you, you can set `"unloadWhenPluginDisconnects"` to true.

You can use the `"fadeTime"` field to specify a fade in/out time between 0 and 2 seconds for the item. If you set it to 0, the item will just appear instantly.

You can specify the sorting order that the item should get loaded at in the scene using the `"order"` field. If that order is taken, the item will automatically be loaded at the next higher available order and if all higher orders are full, it will check lower orders. If you want the item loading to fail if the requested order is taken, use `failIfOrderTaken` to `true`. In that case an error of type `ItemOrderAlreadyTaken` is returned (see [ErrorsID.cs](https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/ErrorID.cs)).

There are also limits to some of the values. Specifically, the size has to be between `0` and `1`, the positions have to be between `-1000` and `1000` (although `-1`/`1` are the screen edges), the fade time has to be between `0` and `2` seconds and smoothing has to be between `0` and `1`. If you go beyond those limits, an error of type `ItemLoadValuesInvalid` is returned.

### Custom Data Items

Plugins can also use this request to load arbitrary PNG/JPG/GIF data as items by passing it in via the `customDataBase64` field (has to be base64-encoded JPG, PNG or GIF file). Leave it empty/NULL if you aren't using it.

If you want to do this, you need the `LoadCustomImagesAsItems` permission. For more info on how to request permissions, check the [permissions page](Permissions/). If you do not have that permission, an error will be returned if you try to load a custom data image (`RequestRequiresPermission`, see [ErrorsID.cs](https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/ErrorID.cs)).

To request arbitrary data to be loaded as an item, the `customDataBase64` must contain valid data of a PNG, JPG or GIF file. Custom data Live2D items are not currently supported. The dimensions must be between (inclusive) 64 and 2048 pixels and the data has to be smaller than 5 MB (the binary data before you encode it to base64). For GIF data, the GIF must contain 1024 frames or less but at least 1 frame and all frames must have the same size.

When providing custom data, you still have to also provide a filename in the `fileName` field. The `fileName` has to be alphanumeric (but can contain hyphens) and must end with `.jpg`, `.png` or `.gif`. It has to be between (inclusive) 8 and 32 characters long.

When loading custom data, you have two options:
* Just load the custom data item instantly.
* Show small popup to the user (including item thumbnail) and ask them if they want to load the item.

Choose the appropriate option based on your use-case. It is your responsibility to make sure your plugin doesn't load any images that could cause problems for the user.

If you want to just load the item right away, set `customDataAskUserFirst` to `false`.

If you want to show a popup to the user first, set `customDataAskUserFirst` to `true`. If you do that, the following popup will be shown to the user:

![Custom Image Load Popup](/Images/vts_load_custom_image_1.png)

6 popups like this can be displayed at the same time (popups are stacked vertically). When 6 popups are already currently shown to the user, subsequent requests will return an error.

When showing the popup, the response for this request will only be returned once the user makes a decision. If the user decides to deny loading the custom data item, an error will be returned (`ItemCustomDataLoadRequestRejectedByUser`). When the user decides to load the item, it will be loaded and a normal response will be returned. That will also add it to the whitelist for your plugin so subsequent loads of the same item (as determined by its SHA256 hash) will not trigger the popup. If you want to force the popup to be triggered every time, you can set `customDataSkipAskingUserIfWhitelisted` to false.

You can set a timeout for the popup using the `customDataAskTimer` field. If you set it to 0 (or smaller), the popup will be shown forever (until the user clicks OK or cancel). If you set it to any other positive number, the popup will be shown for that number in seconds, with a visible countdown shown to the user. If the user doesn't make a decision before the countdown is done, the item load request is considered rejected by the user.

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "ItemLoadRequest",
	"data": {
		"fileName": "some_item_name.jpg",
		"positionX": 0,
		"positionY": 0.5,
		"size": 0.33,
		"rotation": 90,
		"fadeTime": 0.5,
		"order": 4,
		"failIfOrderTaken": false,
		"smoothing": 0,
		"censored": false,
		"flipped": false,
		"locked": false,
		"unloadWhenPluginDisconnects": true,
		"customDataBase64": "",
		"customDataAskUserFirst": true,
		"customDataSkipAskingUserIfWhitelisted": true,
		"customDataAskTimer": -1,
	}
}
```

The response contains the instance ID of the newly loaded item in the `instanceID` field. It also contains the filename.

If you loaded a custom data item, the filename will be generated by VTube Studio, so it will be different from the filename that you passed in. You can use that filename to request that item to be loaded again without passing in custom data. However, when VTube Studio is restarted, all temporary files are cleared, which includes custom data items.

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "ItemLoadResponse",
	"data": {
		"instanceID": "SomeUniqueItemInstanceId",
		"fileName": "some_item_name.jpg"
	}
}
```

## Removing item from the scene

You can use this request to unload any item that is currently loaded in the scene.

Setting `"unloadAllInScene"` to `true` unloads all items. All other fields are ignored in that case.

Setting `"unloadAllLoadedByThisPlugin"` to `true` unloads all items that have been loaded by this plugin.

If you want to prevent this request from unloading items that have been loaded by the user or other plugins, set `"allowUnloadingItemsLoadedByUserOrOtherPlugins"` to `false`.

You can also request specific item instances or item instances that have been loaded from certain filenames by using the optional `"instanceIDs"` and `"fileNames"` arrays. Even if those items aren't found in the scene, the request will not return an error. It will just return a response with an empty array.

This may return an error of type `CannotCurrentlyUnloadItem` if the user currently has menus open that prevent VTS from loading/unloading items.

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "ItemUnloadRequest",
    	"data": {
		"unloadAllInScene": false,
		"unloadAllLoadedByThisPlugin": false,
		"allowUnloadingItemsLoadedByUserOrOtherPlugins": true,
		"instanceIDs":
		[
			"SomeInstanceIdOfItemToUnload", "SomeOtherInstanceIdOfItemToUnload"
		],
		"fileNames":
		[
			"UnloadAllItemInstancesWithThisFileName", "SomeOtherFileName"
		]
    	}
}
```

The response contains the instance IDs and filenames of the unloaded items.

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "ItemUnloadResponse",
    	"data": {
		"unloadedItems":
		[
		    {
			"instanceID": "SomeInstanceId",
			"fileName": "SomeFileName"
		    },
		    {
			"instanceID": "SomeOtherInstanceId",
			"fileName": "SomeFileName"
		    }
		]
    	}
}
```

## Controling items and item animations

You can control certain aspects of items in the scene. This request allows you to make items darker (black overlay), change the opacity, and control the animation of animated items. This request does not work with Live2D items and will return an error of type `ItemAnimationControlUnsupportedItemType` if you try (see [ErrorsID.cs](https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/ErrorID.cs)). This can be useful for "reactive PNG"-type plugins and more.

For animated items, you can set the framerate (in frames-per-second, will automatically be clamped between `0.1` and `120`). You can also manually make the animation jump to a certain frame using the `"frame"` field. An error will get returned if that frame index is invalid. For an animated item with (for example) 20 frames, valid frame indices go from 0 (first frame) to 19 (last frame). Frame counts for animated items can be requested using the `ItemListRequest`. Trying to do this for normal JPG/PNG items will return an error of type `ItemAnimationControlSimpleImageDoesNotSupportAnim`.

If you want to not change the framerate, current frame, brightness or opacity, you can pass in `-1` for those fields (which is also their default if you omit the fields from the payload).

You can start/stop the animation using the `"animationPlayState"` field (`true` = play animation, `false` = stop animation). This field is only used if you set `"setAnimationPlayState"` to `true`, otherwise the animation play state will not be changed.

#### Using auto-stop frames

You can set a list of frame indices that the animation will automatically stop playing on using the `"autoStopFrames"` array. This array is only used if you set `"setAutoStopFrames"` to true, otherwise the auto-stop frames will not be changed. If you want to remove the auto-stop frames, set `"setAutoStopFrames"` to true and set an empty array in `"autoStopFrames"`. You can have a maximum of 1024 auto-stop frames.

Once the animation reaches one of those frames, it will stop playing and can only be started again via the API using this request to set the animation play state to `true` (see above). 

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "ItemAnimationControlRequest",
	"data": {
		"itemInstanceID": "ItemInstanceId",
		"framerate": 12,
		"frame": 3,
		"brightness": 1,
		"opacity": 1,
		"setAutoStopFrames": true,
		"autoStopFrames": [0, 7, 26],
		"setAnimationPlayState": true,
		"animationPlayState": true
	}
}
```

The response contains the current frame index and whether or not the animation is currently playing (only for animated items, for other item types these fields should be ignored).

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "ItemAnimationControlResponse",
	"data": {
		"frame": 3,
		"animationPlaying": true
	}
}
```

## Moving items in the scene

You can move items around in the scene. To do that, fill the `"itemsToMove"` array with all items you want to move. The response array (`"movedItems"`) will contain one entry for each requested item, showing whether or not the move request was successful for it (see respective `"success"` field). If it was not successful, the `"errorID"` field will contain the error code, which will tell you what went wrong (see [ErrorsID.cs](https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/ErrorID.cs)). If it was successful, `"success"` will be `true` and `"errorID"` will be `-1`.

The `"itemsToMove"` array can have up to 64 entries. All entries beyond that will be ignored. If the array has entries with duplicate item instance IDs, the last entry in the array for that ID will be used.

If you want to set the position instantly (for example when you want to set a new position every frame), set `"timeInSeconds"` to `0`. Otherwise, you can use this field to set the time used for the movement fade (clamped between 0 and 30 seconds).

If you want to set the flip state of the item, set `"setFlip"` to true. The flip state can then be set using the `"flip"` field.

If you want to change the order of an item, you can use the `"order"` field. You can only change the order to order spots that are not taken (see `ItemListResponse`). If you don't want to change the order, set this field to -1000 or lower or alternatively you can set it to the current order value of the item. Also, you cannot change the order when the user has any config windows open. The order will not actually be faded like the other parameters (if requested) but changed instantly to the requested value once the request is received.

For the fields that set the target of the movement (`"positionX"`, `"positionY"`, `"size"` and `"rotation"`), please refer to the documentation of the `ItemLoadRequest`. The only difference is that this `ItemMoveRequest` will not return an error if the given values are too high/low. Instead, you can set values of `-1000` or lower if you want a respective field to be ignored. If you do that, this field will not be included in the movement and instead the respective current value will be used.


#### Item movement transition fade types

You can set the movement type for the position/rotation/size fade using the `"fadeMode"` field. Accepted values are `"linear"`, `"easeIn"`, `"easeOut"`, `"easeBoth"`, `"overshoot"` and `"zip"`. They will only be used if the `"timeInSeconds"` field was set higher than `0`.

If you want the user to be able to stop the movement by clicking/dragging the item while it's moving, set `"userCanStop"` to `true`. If you set it to `false`, users will not be able to interact with the item while the movement is ongoing.

Here's a visual representation of the movement modes:

![VTube Studio Movement Modes](/Images/vts_movement_modes_smooth.png)

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "ItemMoveRequest",
	"data": {
		"itemsToMove":
		[
			{
				"itemInstanceID": "ItemInstanceId",
				"timeInSeconds": 1,
				"fadeMode": "easeOut",
				"positionX": 0.2,
				"positionY": -0.8,
				"size": 0.6,
				"rotation": 180,
				"order": -1000,
				"setFlip": true,
				"flip": false,
				"userCanStop": true
			},
			{
				"itemInstanceID": "SomeOther_ItemInstanceId",
				"timeInSeconds": 0.5,
				"fadeMode": "zip",
				"positionX": 1,
				"positionY": 1,
				"size": 0.3,
				"rotation": 0,
				"order": 25,
				"setFlip": false,
				"flip": false,
				"userCanStop": false
			}
		]
	}
}
```

If the request was successful, you will receive a response containing the status of all requested items.

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "ItemMoveResponse",
	"data": {
		"movedItems":
		[
			{
				"itemInstanceID": "ItemInstanceId",
				"success": true,
				"errorID": -1
			},
			{
				"itemInstanceID": "SomeOther_ItemInstanceId",
				"success": false,
				"errorID": 900
			}
		]
	}
}
```

## Set item within-model-sorting order

VTube Studio lets you sort and pin items **between the layers** of your main model. For some general information about how this works, check out the page about "[Between-Layer Item Pinning](https://github.com/DenchiSoft/VTubeStudio/wiki/Between-Layer-Item-Pinning)".

For [Live2D items](https://github.com/DenchiSoft/VTubeStudio/wiki/Live2D-Items) specifically, you can also split the **Live2D item model** into a front- and back-part and insert them into the main model separately. 

To identify the item you want to change the within-model-sorting settings for, pass in its item instance ID using the `"itemInstanceID"` field. An `ItemSortRequestInstanceIDNotFound` error is returned if no item with that ID was found. To get the item instance IDs of all loaded items, you can use the `ItemListRequest`. The ID is also directly returned when you use the `ItemLoadRequest` to load an item via the API.

For all errors this request can return, see "[ErrorsID.cs](https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/ErrorID.cs)".

*Note:* Normal items (non-Live2D items) do not have a "back part" or "split point", so the back/split fields are entirely ignored when using this request for normal items. You can leave them empty/`null`. The text below assumes you are using this request for a Live2D items. Also, VTube Studio will make sure that even if you set the back-part in front of the front-part, it will not move past it.

To insert the item into the model, set `"frontOn"` to `true`. If you have a Live2D item and want to insert its back part further back into the model, you can also set `"backOn"` to `true` (ignored for non-Live2D items).

Split point and front/back insertion points are set using `"splitAt"`, `"withinModelOrderFront"` and `"withinModelOrderBack"`. How these fields are interpreted depends on what you pass in via `"setSplitPoint"`, `"setFrontOrder"` and `"setBackOrder"`. 

The following fields are used to set the item split point and insertion point(s):

* `"splitAt"`: Set split point that is used to split the Live2D item model into front- and back-part.
  * Ignored for non-Live2D items.
  * If `"setSplitPoint"` is set to `"Unchanged"`: The value in `"splitAt"` will be ignored and the split point will be left unchanged.
  * If `"setSplitPoint"` is set to `"UseArtMeshID"`: `"splitAt"` expects an ArtMesh ID that exists in the Live2D item model and will return the error `ItemSortRequestInvalidSplitPoint` if that ArtMesh ID doesn't exist.
* `"withinModelOrderFront"`: Sets where to insert the item into the main model (or the front part of the item in case of Live2D items).
  * If `"setFrontOrder"` is set to `"Unchanged"`: The value in `"withinModelOrderFront"` will be ignored and the front part insertion position will be left unchanged.
  * If `"setFrontOrder"` is set to `"UseArtMeshID"`: `"withinModelOrderFront"` expects an ArtMesh ID that exists in the main Live2D model, but if it doesn't exist the request will still return successfully because it could be an ID for a Live2D model that is not currently loaded.
  * If `"setFrontOrder"` is set to `"UseSpecialID"`: `"withinModelOrderFront"` expects either `"FullyInFront"` or `"FullyInBack"` to always set the item (front part) fully in front of or fully behind the loaded main model. Any other value will return a `ItemSortRequestInvalidFrontOrder` error in this case.
* `"withinModelOrderBack"`: Sets where to insert the back part of Live2D items into the main model.
  * Ignored for non-Live2D items.
  * If `"setBackOrder"` is set to `"Unchanged"`: The value in `"withinModelOrderBack"` will be ignored and the back part insertion position will be left unchanged.
  * If `"setBackOrder"` is set to `"UseArtMeshID"`: `"withinModelOrderBack"` expects an ArtMesh ID that exists in the main Live2D model, but if it doesn't exist the request will still return successfully because it could be an ID for a Live2D model that is not currently loaded.
  * If `"setBackOrder"` is set to `"UseSpecialID"`: `"withinModelOrderBack"` expects `"FullyInBack"` to always set the item (back part) fully behind the loaded main model. Any other value will return a `ItemSortRequestInvalidBackOrder` error in this case.

Invalid values in `"setSplitPoint"`, `"setFrontOrder"` and `"setBackOrder"` will return a `ItemSortRequestInvalidValueSetType` error.

This will also return the error `ItemSortRequestItemConfigWindowOpen` if the within-model sorting window is currently open (meaning the user is currently manually setting insertion orders).

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "ItemSortRequest",
	"data": {
		"itemInstanceID": "b616cf51fe3444729ccbf6ee54a14d1a",
		"frontOn": true,
		"backOn": true,
		"setSplitPoint": "UseArtMeshID",
		"setFrontOrder": "UseArtMeshID",
		"setBackOrder": "UseSpecialID",
		"splitAt": "MyArtMeshIDInItemModel91",		
		"withinModelOrderFront": "MyArtMeshIDInMainModel73",
		"withinModelOrderBack": "FullyInBack"
	}
}
```

If the request was successful, you will receive this response.

`"itemInstanceID"` will pass back the instance ID of the item the request was for.

If a main model is currently loaded, `"modelLoaded"` will be `true` and `"modelID"` and `"modelName"` will contain the model ID and name of the model. If no model is loaded, these fields will be empty.

If a main model is loaded, `"loadedModelHadRequestedFrontLayer"` and `"loadedModelHadRequestedBackLayer"` will tell you whether or not the front/back insertion points you provided were found in the currently loaded model. If the insertion points were left unchanged, these fields are set to `false`.

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "ItemSortResponse",
	"data": {
		"itemInstanceID": "b616cf51fe3444729ccbf6ee54a14d1a",
		"modelLoaded": true,
		"modelID": "d87b771d2902473bbaa0226d03ef4754",
		"modelName": "Akari",
		"loadedModelHadRequestedFrontLayer": true,
		"loadedModelHadRequestedBackLayer": true
	}
}
```


## Asking user to select ArtMeshes

You can use this request to show a list in VTube Studio containing all ArtMeshes of the currently loaded main Live2D model and have the user select one or more of them. Once the user is done selecting ArtMeshes, the ArtMesh IDs will be returned. You can use those ArtMesh IDs in various other API requests, for example to apply a color tint to them or make them invisible.

If no model is currently loaded or there are currently other windows open, the request will return an error.

The user can hover over ArtMeshes to show their ID and click them to filter the shown list for all ArtMeshes under on the click position. The UI shown by this request looks like this:

![API ArtMesh selection request screen](/Images/vts_request_select_artmeshes.png)

Use the `requestedArtMeshCount` field to specify how many ArtMeshes the user has to activate. The "OK button will be unavailable until exactly that many ArtMeshes are activated. If you set `requestedArtMeshCount` to 0 or lower, the user will be asked to choose any arbitrary number of ArtMeshes (but at least one).

If you want to pre-activate ArtMeshes in the list, you can use the `activeArtMeshes` list and pass in some ArtMesh IDs. If any of those IDs are not contained in the current model, an error will be returned. If you want a list of all ArtMeshes in the currently loaded model, use the `ArtMeshListRequest`.

As you can see in the screenshot above, the list has some default text that is shown, asking the user to select ArtMeshes for the plugin. The same text is shown in a popup when you press the `?` button (help) in the top right. You can overwrite both of these strings using the `textOverride` and `helpOverride` fields respectively. If you leave them empty (empty string), null or leave them out of the payload, the default message shown above will be used. If you want to overwrite those messages, your provided string has to be between 4 and 1024 characters long, otherwise the default will be used. You can use `\n` for newlines in the strings you provide. 

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "ArtMeshSelectionRequest",
	"data": {
		"textOverride": "This text is shown over the ArtMesh selection list.",
		"helpOverride": "This text is shown when the user presses the ? button."
		"requestedArtMeshCount": 5
		"activeArtMeshes": [
			"D_BODY_00",
			"D_ARM_R_05"
		]
	}
}
```

If the request is successful, the selection list will be shown to the user. There will be no immediate response. The response will come once the user clicks the "OK or "Cancel" button. The "Cancel" button is always available but the "OK" button will only be clickable once the requested amount of ArtMeshes have been selected.

The activated/deactivated Artmeshes will be returned in the `activeArtMeshes` and `inactiveArtMeshes` arrays respectively. There will be **no overlap** between those arrays, so if you combine the ArtMeshes in those arrays, you would have a list of all ArtMeshes in the model.

If the user clicked "OK" the `success` field will be `true`. If the user clicked "Cancel", the `success` field will be `false` (in that case you should probably ignore the `activeArtMeshes` and `inactiveArtMeshes` arrays, although they will still be returned).

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "ArtMeshSelectionResponse",
	"data": {
		"success": true
		"activeArtMeshes": [
			"D_BROW_00",
			"D_EYE_BALL_03",
			"D_EYE_BALL_02",
			"D_EYE_BALL_01",
			"D_EYE_BALL_00",
			"D_EYE_11"
		],
		"inactiveArtMeshes": [
			"D_EAR_06",
			"D_BODY_00",
			"D_ARM_R_05"
		]
	}
}
```


## Pin items to the model

You can use this request to pin items in the scene to the currently loaded model.

The item instance ID to identify the item has to be specified in the `itemInstanceID` field. If you want to unpin the item, just set `pin` to `false`. No other info has to be provided in that case. If no item with that ID is currently loaded, an error is returned (see [ErrorsID.cs](https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/ErrorID.cs)).

If you want to pin an item, the pin position has to be provided in the `pinInfo` object. There are various ways to pin an item. For example, you can provide an exact position to pin to or you could just provide an ArtMesh and let VTS pin the item to the center of it or a random position on the ArtMesh. How exactly this works will be described below.

When you send an `ItemPinRequest` for an item with an active `ItemMoveRequest`, the `ItemMoveRequest` will be automatically canceled.

Also, if your plugin (or multiple different plugins) send multiple pin requests for the same item and they are received within the same frame in VTS, only the last received pin request is executed while the others are discarded.

### Options for pinning

There are three fields that determine how the data given in `pinInfo` is interpreted:

* `angleRelativeTo`: How should the provided angle be interpreted?
  * `RelativeToWorld`: Absolute angle. That means if you pass in 0 as angle, the item will be pinned upright at an angle of 0 compared to the VTS window. You'd use this if you want the item to face a certain direction relative to the VTS window.
  * `RelativeToCurrentItemRotation`: Relative to the angle the item currently is at. If you pass in 0 as angle, that means the item will be pinned at the angle it is already at meaning its current rotation will not be changed. You'd use this if you don't want to change the item rotation and just pin it as is.
  * `RelativeToModel`: Relative angle to model rotation. That means if you pass in 0 as angle and the user has rotated the model, the item will be pinned upright in relation to the model. This "model rotation" doesn't include rotation caused by Live2D ArtMesh deformation, only the actual rotation applied to the whole model by VTube Studio. You'd use this if you want the item to face a certain direction relative to the current rotation of the model.
  * `RelativeToPinPosition`: Relative angle to the pin position. This is what you should use if you want to pin an item at a certain position within a certain ArtMesh at a certain angle and you want that angle to be exactly the same no matter how the model is rotated right now or how the ArtMesh is deformed. However, what angle you have to pass in to get the desired effect will be completely different for each pin-position.
* `sizeRelativeTo`:
  * `RelativeToWorld`: Absolute size. Between 0 (smallest) and 1 (largest). See also `ItemLoadRequest`.
  * `RelativeToCurrentItemSize`: Relative to current item size. You can pass in numbers between `-1` and `1`, which will be added to the current item size, meaning you can pass in 0 if you want to pin the item at its current size without changing it.
* `vertexPinType`: 
  * `Provided`: The item will be pinned to the given ArtMesh using the pin position provided in the fields `vertexID1`, `vertexID2`, `vertexID3`, `vertexWeight1`, `vertexWeight2` and `vertexWeight3`. Details will be explained below.
  * `Center`: The item will be pinned to the "center" of the given ArtMesh. It's not really the center (spacially) but actually the triangle in the middle of the triangle list of the mesh. This will give you the same position every time for a given ArtMesh.
  * `Random`: The item will be pinned to a random triangle within the given ArtMesh.

If the provided model ID doesn't match the loaded model, an error is returned. You can also leave the model ID empty, which will try to pin to the currently loaded model (if one is loaded).

If the model doesn't have the ArtMesh with the ArtMesh ID you provided, an error is returned. If you leave the ArtMesh ID empty, a random ArtMesh will be chosen in the model.

For example, you could leave both the model ID and ArtMesh ID empty and set `vertexPinType` to `Random`. That will just pin the item to a random position on a random ArtMesh on the currently loaded model.

### Pinning to a specific position

If you set `vertexPinType` to `Provided`, you have to use the fields `vertexID1`, `vertexID2`, `vertexID3`, `vertexWeight1`, `vertexWeight2` and `vertexWeight3` to provide a valid position on the ArtMesh you selected using the `modelID` and `artMeshID` fields.

The three vertex ID fields have to be the vertex IDs of a triangle in the given ArtMesh. To define a position within that specific triangle, use the vertex weight fields. Those fields will be multiplied with the vertex positions to define a position in the triangle. Keep in mind that the weights must add up to exactly 1, otherwise the resulting position would be outside of the triangle (and an error will be returned). Those are [barycentric coordinates](https://en.wikipedia.org/wiki/Barycentric_coordinate_system).

To get one of those positions, you can use the [ModelClickedEvent](https://github.com/DenchiSoft/VTubeStudio/tree/master/Events#model-clicked-event). This event will return pin positions you can use with the `ItemPinRequest` when the model is clicked.

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "ItemPinRequest",
	"data": {
		"pin": true,
		"itemInstanceID": "4a241269394f463ca16b8b21aa636568",
		"angleRelativeTo": "RelativeToModel",
		"sizeRelativeTo": "RelativeToWorld",
		"vertexPinType": "Provided",
		"pinInfo": {
			"modelID": "d87b771d2902473bbaa0226d03ef4754",
			"artMeshID": "hair_right_4",
			"angle": 23.938,
			"size": 0.33,
			"vertexID1": 17,
			"vertexID2": 9,
			"vertexID3": 55,
			"vertexWeight1": 0.25928378105163576,
			"vertexWeight2": 0.6850675940513611,
			"vertexWeight3": 0.055648624897003177
		}
	}
}
```

If successful, the response contains the item ID, item file name and whether or not the item is now pinned.

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "ItemPinResponse",
	"data": {
		"isPinned": true,
		"itemInstanceID": "4a241269394f463ca16b8b21aa636568",
		"itemFileName": "my_test_item_2.png",
	}
}
```

## Get list of post-processing effects and state

**Note:** The terms visual effects, VFX and post-processing effects are used interchangeably in this document.

VTube Studio has built-in post-processing, allowing you to add visual effects directly to the scene. This is available on Windows and macOS. For more information, check the page ["Visual Effects"](https://github.com/DenchiSoft/VTubeStudio/wiki/Visual-Effects).

This request returns the general state of the post-processing system, a list of all existing (user-created) post-processing presets and a list of all available post-processing effects with their current value (current post-processing state).

If you set `fillPostProcessingPresetsArray` to `false`, the `postProcessingPresets` array in the response payload will be empty. Requesting the list of post-processing presets requires reading the preset files from the disk (although they are cached for a while in VTS), which can be slow. If you send this request at higher frequency, make sure `fillPostProcessingPresetsArray` isn't `true`, otherwise it could create lag due to disk I/O.

If you set `fillPostProcessingEffectsArray` to `false`, the `postProcessingEffects` array in the response payload will be empty. If you don't need the full list of post-processing effects and their values, it is recommended to set `fillPostProcessingEffectsArray` to `false` because the response payload can be quite large.

If you are only interested in specific post-processing effects, you can list them in the `effectIDFilter` array. Otherwise, leave the array empty to apply no filter. A list of all current effects can be found here: https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/Effects.cs

**Note:** These IDs are accepted in many different formats, so you can create an enum for them in any enum style you want. They are case-insensitive and `_` or `-` is ignored. For example, that means instead of `ChromaticAberration` you could write `Chromatic_Aberration`, `chromatic_aberration`, `CHROMATIC_ABERRATION` or any other style that works best for you.

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "PostProcessingListRequest",
	"data":
	{
		"fillPostProcessingPresetsArray": true,
		"fillPostProcessingEffectsArray": true,
		"effectIDFilter":
		[
			"ASCII",
			"ColorGrading",
			"WeatherEffects",
			"ChromaticAberration"
		]
	}
}
```


The response contains some general info about the post-processing system state and the `postProcessingEffects` and `postProcessingPresets` arrays if requested.

`postProcessingSupported` checks if the platform supports post-processing, which should always be `true` on Windows and macOS. The `postProcessingActive` field contains whether or not the user has turned post-processing on. Keep in mind that you can turn it on/off via the API as well using the `PostProcessingUpdateRequest` described next. Using the `PostProcessingUpdateRequest` may not be possible in some situations, specifically when some windows or popups related to post-processing configurations are open in VTube Studio. In this case, `canSendPostProcessingUpdateRequestRightNow` will be `false`.

There are some restricted/experimental effects (see ["Restricted/Experimental Effects"](https://github.com/DenchiSoft/VTubeStudio/wiki/Visual-Effects#restrictedexperimental-effects)). The user must explicitly allow those effects to be used. Whether or not the user has allowed these effects to be used is returned in the `restrictedEffectsAllowed` field.

Whether or not a post-processing preset is active is returned in the `presetIsActive` field. If one is active, its name will be in the `activePreset` field, otherwise that field will be empty.

`presetCount` contains the number of post-processing presets in the `postProcessingPresets` array. If you haven't requested the array to be filled, `presetCount` will be 0.

`activeEffectCount` is the number of active post-processing effects. What it means for an effect to be "active" is explained later in this section.

The "effectCount" and "configCount" fields contain the number of effects and total configs for all effects before and after applying the filter (if you requested filtering).

### The `postProcessingEffects` array

The `postProcessingEffects` array contains a list of all effects. Those are the same effects that are shown in the VFX list in VTube Studio. Each effect can have multiple "configs" that configure certain aspects of the effect, for example its strength or a color.

The ID you use to identify an effect is returned in the `enumID` field. There is also the `internalID` field which contains the ID that VTube Studio uses internally for that effect. That's the ID that is used in the post-processing preset JSON files, so they should not be relevant for most use-cases. However, these IDs can also be used in the API to refer to the effects if you want to use them for some reason.

Configs all have one of the following types (returned in `type` field of the config):
* Float
* Int
* Bool
* String
* Color
* SceneItem

The configs for one effect are returned in the `configEntries` array. Each config also has an `internalID` and `enumID`. All config IDs for all effects with explanations can be found here: https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/EffectConfigs.cs

For one config, only the fields that match the type of that config are filled. Other fields will be empty or have a default value and should be ignored. For example, for a float config item fields like `intMin` and `colorValue` are empty (in this case 0 and an empty string). In addition to a default value (which all types have), the `Float` and `Int` configs also have a `min` and `max`.

For fields that contain colors, a string in the RGBA hex format is returned (like "77CCAAFF") and `colorHasAlpha` will tell you whether or not that config actually has alpha. If it's `false`, the alpha will always be `FF`.

Configs of type `SceneItem` are essentially just string configs but the value must be the filename of an item (ending with either .jpg or .png) that exists in the VTube Studio "Items" folder. Those are for example used in the custom particles effect.

### When is an effect considered "active"?

Each effect has at least one float config (but can have multiple) with `activationConfig` set to `true`. If one of those configs for one effect has a value greater than 0, that effect is considered `active`.

For the `ColorGrading` effect for example, that would be the config `ColorGrading_Strength`.

**Note:** The `postProcessingEffects` in this response payload example is shortened by a lot. When no filters are applied, it can be thousands of lines long since there are 250+ effect configs.

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "PostProcessingListResponse",
	"data": {
		"postProcessingSupported": true,
		"postProcessingActive": true,
		"canSendPostProcessingUpdateRequestRightNow": true,
		"restrictedEffectsAllowed": false,
		"presetIsActive": true,
		"activePreset": "some_effects_preset_3",
		"presetCount": 70,
		"activeEffectCount": 5,
		"effectCountBeforeFilter": 29,
		"configCountBeforeFilter": 258,
		"effectCountAfterFilter": 4,
		"configCountAfterFilter": 31,
		"postProcessingEffects": [
			{
				"internalID": "color_grading",
				"enumID": "ColorGrading",
				"explanation": "Color grading",
				"effectIsActive": false,
				"effectIsRestricted": false,
				"configEntries": [
					{
						"internalID": "color_grading-strength",
						"enumID": "ColorGrading_Strength",
						"explanation": "Effect on/off",
						"type": "Float",
						"activationConfig": true,
						"floatValue": 0.0,
						"floatMin": 0.0,
						"floatMax": 1.0,
						"floatDefault": 0.0,
						"intValue": 0,
						"intMin": 0,
						"intMax": 0,
						"intDefault": 0,
						"colorValue": "",
						"colorDefault": "",
						"colorHasAlpha": false,
						"boolValue": false,
						"boolDefault": false,
						"stringValue": "",
						"stringDefault": "",
						"sceneItemValue": "",
						"sceneItemDefault": ""
					},
					{
						"internalID": "color_grading-color_filter",
						"enumID": "ColorGrading_ColorFilter",
						"explanation": "Color filter",
						"type": "color",
						"activationConfig": false,
						"floatValue": 0.0,
						"floatMin": 0.0,
						"floatMax": 0.0,
						"floatDefault": 0.0,
						"intValue": 0,
						"intMin": 0,
						"intMax": 0,
						"intDefault": 0,
						"colorValue": "FFFFFFFF",
						"colorDefault": "FFFFFFFF",
						"colorHasAlpha": false,
						"boolValue": false,
						"boolDefault": false,
						"stringValue": "",
						"stringDefault": "",
						"sceneItemValue": "",
						"sceneItemDefault": ""
					}
				]
			}
		],
		"postProcessingPresets": [
			"My Cool Preset",
			"some_effects_preset_1",
			"some_effects_preset_2",
			"some_effects_preset_3",
			"test asdf 123456",
			"blur and color grading",
		]
	}
}
```

## Set post-processing effects

**Note:** The terms visual effects, VFX and post-processing effects are used interchangeably in this document.

VTube Studio has built-in post-processing, allowing you to add visual effects directly to the scene. This is available on Windows and macOS. For more information, check the page ["Visual Effects"](https://github.com/DenchiSoft/VTubeStudio/wiki/Visual-Effects).

Using the `PostProcessingUpdateRequest`, you can control the post-processing system. You can turn it on/off, load/unload presets or even control individual config items directly and in detail (colors, strengthts, etc.).

This update can only be sent if no windows related to post-processing configuration are open. Otherwise, the error `PostProcessingUpdateReqestCannotUpdateRightNow` will be returned. For all errors this request can return, see ["ErrorsID.cs"](https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/ErrorID.cs).

Use `postProcessingOn` to turn post-processing on or off globally. This does the same as toggling the post-processing toggle on the VTS UI. You can set presets or individual config values even when turning post-processing off with the same request. The values will still be set but nothing will happen on screen. When opening the post-processing config window in VTube Studio, you will see that your requested values have been set and will be visible once post-processing is turned on. Keep in mind that if you set a preset but turn off post-processing with the same request, all values from the preset will still be set but the preset will not be shown as active on the UI because technically it is no longer "active". All values from the preset will be visible once post-processing is turned on again.

You can set values for post-processing config items using two methods:
* Set a post-processing preset: Set `setPostProcessingPreset` to `true` and provide the preset name in the `presetToSet` field (just the preset name without the file extension). If the preset doesn't exist, the error `PostProcessingUpdateRequestPresetFileLoadFailed` is returned.
* Set individual config values: Set `setPostProcessingValues` to `true` and provide a list of config key/values in the `postProcessingValues` array.

You can't do both at the same time: If `setPostProcessingPreset` and `setPostProcessingValues` are both `true`, the error `PostProcessingUpdateRequestLoadingPresetAndValues` will be returned. However, both can be `false`. In that case, no values will be set. That can be useful if you just want to turn post-processing on/off globally without changing anything about the current configuration.

When changing config values directly or via presets, the config values will smoothly fade from the old values to the new ones you provided. The duration of the fade should be provided in the `postProcessingFadeTime` field and has to be between 0 and 2 (seconds). Anything outside that range will return the error `PostProcessingUpdateRequestFadeTimeInvalid`.

When setting individual values, the field `setAllOtherValuesToDefault` determines whether all other values (the ones you didn't put in your payload) will be left unchanged or faded back to their default value, meaning all unmentioned effects will be turned off.

If you want to use any [restricted/experimental Effects](https://github.com/DenchiSoft/VTubeStudio/wiki/Visual-Effects#restrictedexperimental-effects) when setting config values directly, make sure `usingRestrictedEffects` has been set to `true` in your payload. This is just a sanity-check to make sure those effects aren't used accidentally. Otherwise, the error `PostProcessingUpdateRequestTriedToLoadRestrictedEffect` will be returned. This error will also be returned if the user hasn't enabled the usage of those effects in the VTube Studio VFX settings yet. This has to be done manually by the user. If a preset is loaded and it contains restricted effects, it will still fully load and there will not be any error but the restricted effects will not be activated.

You can also request all effect configs to be randomized. This is just for fun. To do that, set `randomizeAll` to `true`. Any config values or presets you send in the payload will be ignored if `randomizeAll` is `true`. When many effects are active at the same time, you end up with just random noise so this makes sure that the number of effects is limited and the config values aren't too crazy. This can be controlled using the `randomizeAllChaosLevel` field, which accepts values between 0 and 1 (higher/lower values are clamped into that range). `0` will only have one or two effects active with mild values while `1` will create complete chaos on screen. `0.4` to `0.5` is the recommended value range for a good effect. Restricted effects will be included in the randomization only if you set `usingRestrictedEffects` to `true` and the user has allowed/enabled the usage of those effects.

### How to set individual config values

When you want to control the post-processing config in detail by setting individual config values, you have to set `setPostProcessingValues` to `true` and set the values via the `postProcessingValues` array. `configID` is the ID of the config effect you want to configure, `configValue` is the value you want to set as a string.

* `configID`: ID of the config you want to configure, see [this list of all config IDs](https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/EffectConfigs.cs). These IDs are accepted in many different formats, so you can create an enum for them in any enum style you want. They are case-insensitive and `_` or `-` is ignored. For example, that means instead of `Backlight_OutlineSize` you could write `Backlight_Outline_Size`, `backlight_outlinesize`, `BACKLIGHT_OUTLINESIZE`, `backlight-outline_size` or any other style that works best for you (see also `enumID` field in the `configEntries` array of the `PostProcessingListResponse`).
* `configValue`: The value to set, as string. For floats or ints, values that are outside of the min/max range of the config will be clamped. Bool values are case-insensitive, so both `"True"` and `"true"` (or `"TRUE"`, etc.) are accepted values.

If you have any duplicate keys in the array, the error `PostProcessingUpdateRequestValueListContainsDuplicates` is returned and if any keys were invalid (not found) or values were invalid (failed to deserialize float, bool, etc., correctly), the error `PostProcessingUpdateRequestValueListInvalid` is returned.

**How to actually turn an effect "on":** Effects can have many config entries. Each effect has at least one config entry (but can have many) that turns the effect "on" if that entry is greater than 0. In the `PostProcessingListResponse` payload, those configs (always float-type configs) are marked using `"activationConfig": true`. You can also look at the list of all effect configs, where those special configs are marked with `sets_active: True`, see: https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/EffectConfigs.cs

### General usage advice

You should not send this request at high frequencies, e.g. every frame. If you want to fade a value, use the `postProcessingFadeTime` field to set the appropriate fade time. Depending on the config combination, frequent updates *can* be okay, but you should carefully test things. The post-processing system is optimized for infrequent config updates, so make sure to check if your plugin causes any lag before publishing it. 

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "PostProcessingUpdateRequest",
	"data":
	{
		"postProcessingOn": true,
		"setPostProcessingPreset": false,
		"setPostProcessingValues": true,
		"presetToSet": "",
		"postProcessingFadeTime": 1.3,
		"setAllOtherValuesToDefault": true,
		"usingRestrictedEffects": false,
		"randomizeAll": false,
		"randomizeAllChaosLevel" : 0.0,
		"postProcessingValues": [
			{
				"configID": "Backlight_Strength",
				"configValue": "0.8"
			},
			{
				"configID": "Bloom_Strength",
				"configValue": "1.0"
			},
			{
				"configID": "Bloom_StreakVertical",
				"configValue": "false"
			},
			{
				"configID": "Bloom_StreakColorTint",
				"configValue": "220308FF"
			}
		]
	}
}
```

If there's no error, you will receive the following response with some general info about the new post-processing state after your requested update.

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "PostProcessingUpdateResponse",
	"data":
	{
		"postProcessingActive": true,
		"presetIsActive": false,
		"activePreset": "",
		"activeEffectCount": 2
	}
}
```

