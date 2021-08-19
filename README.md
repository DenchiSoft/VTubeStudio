# <a href="https://denchisoft.com"><img src="https://raw.githubusercontent.com/DenchiSoft/VTubeStudio/master/Images/vtube_studio_logo_nyan_2.png" width="542" /></a><br> [![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/DenchiSoft/VTubeStudio/blob/master/LICENSE) [![VTube Studio Discord](https://discordapp.com/api/guilds/652602255748497449/widget.png?style=shield)](https://discord.gg/VTubeStudio) [![Stars](https://img.shields.io/github/stars/DenchiSoft/VTubeStudio?style=social)](https://github.com/DenchiSoft/VTubeStudio) [![Twitter Follow](https://img.shields.io/twitter/follow/VTubeStudio.svg?style=social)](https://twitter.com/VTubeStudio)


[![VTube Studio Discord](https://discordapp.com/api/guilds/652602255748497449/widget.png?style=banner2)](https://discord.gg/VTubeStudio)

## Contents

- [General Info](#general-info)
- [Available Plugins and Examples](#available-plugins-and-examples)
- [Status](#status)
- [API Details](#api-details)
  - [Authentication](#authentication)
  - [Getting current VTS statistics](#getting-current-vts-statistics)
  - [Getting list of VTS folders](#getting-list-of-vts-folders)
  - [Getting the currently loaded model](#getting-the-currently-loaded-model)
  - [Getting a list of available VTS models](#getting-a-list-of-available-vts-models)
  - [Loading a VTS model by its ID](#loading-a-vts-model-by-its-id)
  - [Moving the currently loaded VTS model](#moving-the-currently-loaded-vts-model)
  - [Requesting list of hotkeys available in current or other VTS model](#requesting-list-of-hotkeys-available-in-current-or-other-vts-model)
  - [Requesting execution of hotkeys](#requesting-execution-of-hotkeys)
  - [Requesting list of ArtMeshes in current model](#requesting-list-of-artmeshes-in-current-model)
  - [Tint ArtMeshes with color](#tint-artmeshes-with-color)
  - [Requesting list of available tracking parameters](#requesting-list-of-available-tracking-parameters)
  - [Get the value for one specific parameter, default or custom](#get-the-value-for-one-specific-parameter-default-or-custom)
  - [Get the value for all Live2D parameters in the current model](#get-the-value-for-all-live2d-parameters-in-the-current-model)
  - [Adding new tracking parameters ("custom parameters")](#adding-new-tracking-parameters-custom-parameters)
  - [Delete custom parameters](#delete-custom-parameters)
  - [Feeding in data for default or custom parameters](#feeding-in-data-for-default-or-custom-parameters)




## General Info

VTube Studio will get a **public API**. This means you will be able to write plugins/scripts that can trigger hotkeys, feed in face tracking data or receive face tracking data from VTube Studio.

As a first step, a proposal for the API setup and payloads will be published on this page. Once that's available, please review the proposal and leave feedback. After this process, the API will be implemented as documented in this repository.

Afterwards, if you develop a plugin or any app that can be used with VTube Studio, please open a PR and I will add it to the list that will be created on this page.

## Available Plugins and Examples

The following is a list of finished plugins you can use and examples/libraries for you to look at that make it easier to integrate the VTube Studio API into your app. 

:warning: **If you made something you want to have included here, please open a pull request with the modified table!!** :warning:

| Plugin | Developer | Type | Explanation |
| --- | --- | --- | --- |
| [Cheers Bot](https://cheers.hawk.bar/) | [Hawkbar](https://twitter.com/HawkbarGaming) | Plugin | A web-based Twitch integration platform which can trigger actions in VTube Studio when chatters redeem channel points, among many other features. |
| [VTubeStudioJS](https://github.com/Hawkbat/VTubeStudioJS) | [Hawkbar](https://twitter.com/HawkbarGaming) | Library | A JavaScript library for use by other plugin authors which implements the VTube Studio WebSocket API. Compatible with both NodeJS and the browser. 
| [VTS Linker - SMB1](https://github.com/Renpona/VTStudio-Linker-SMB1) | [Renpona](https://twitter.com/renpona) | Example | A prototype for reading data from an emulated copy of Super Mario Bros, and using that data to automatically move and recolor a Live2D model in VTS based on what's happening in the game.
| [VTchaos](https://github.com/Raelice/VTchaos) | [Raelice](https://twitter.com/theraelice) | App | A program that reads YouTube chat to perform functions like model swapping, rotation, and movement in vtube studio through simple chat commands.



## Status

:warning: <b>First draft finished. If you have feedback, please post it in the public API channel in the [VTS Discord](https://discord.gg/VTubeStudio).</b> :warning: 

:warning: <b>None of this is final yet, so if you plan to use this API, you might want to wait a bit before starting with your implementation.</b> :warning: 

# API Details

The VTube Studio websocket server runs on `ws://localhost:8001`. This is the default, but users can also change the port in the app. Websockets in general support `binary` and `text` messages. VTube Studio will always respond with `text` messages and it is recommended to also send `text` messages to the API. You may also send `binary` messages but if you do, make sure they are encoded in UTF-8.

If your plugin cannot connect to the websocket server, tell the users to check if the port is correct or if there are any firewall/antivirus settings that may prevent the connection.
You should also make sure your plugin supports configuring the port used for the connection.

If you can connect, the first thing to do is check if the user has enabled the API. 

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

If the user has turned off the API functionality, all API requests other than the API state request will fail with the following response.

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "APIError",
	"data": {
		"errorID": 1,
		"message": "VTube Studio is running and API is online but user has deactivated API access."
	}
}
```


If this is the case, you should ask the user to `"Allow Plugin API access"` in VTube Studio. It's an option on the main config page in VTS.
If any other API request fails, this payload will also be returned with the respective error ID and message.

All possible error IDs are listed on the page [ErrorsID.cs](https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/ErrorID.cs).

Once connected, the client can poll information about the current app state at any time.

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

The field `"authenticationToken"` contais an ASCII string which will serve as the token for authenticating with the API. It is at most 64 characters in length.
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
		"baseFolder": "C:\\Path\\To\\BaseFolder\\StreamingAssets",
		"models": "C:\\Path\\To\\BaseFolder\\StreamingAssets\\Live2DModels",
		"backgrounds": "C:\\Path\\To\\BaseFolder\\StreamingAssets\\Backgrounds",
		"items": "C:\\Path\\To\\BaseFolder\\StreamingAssets\\Items",
		"config": "C:\\Path\\To\\BaseFolder\\StreamingAssets\\Config",
		"logs": "C:\\Path\\To\\BaseFolder\\StreamingAssets\\Logs"
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
		"vtsModelPath": "C:\\Path\\To\\Model.vtube.json",
		"vtsModelIconPath": "C:\\Path\\To\\ModelIconPNGorJPG.png",
		"live2DModelPath": "C:\\Path\\To\\Model.model3.json",
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

`"vtsModelIconPath"` contains the full path to the icon used for this model in the model selection bar in VTube Studio. If the model has no icon set, this will be an empty string.

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
				"vtsModelPath": "C:\\Path\\To\\Model_1.vtube.json",
				"vtsModelIconPath": "C:\\Path\\To\\ModelIconPNGorJPG_1.png"
			},
			{
				"modelLoaded": true,
				"modelName": "My Second Model",
				"modelID": "UniqueIDToIdentifyThisModelBy2",
				"vtsModelPath": "C:\\Path\\To\\Model_2.vtube.json",
				"vtsModelIconPath": "C:\\Path\\To\\ModelIconPNGorJPG_1.png"
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

This may fail and return an error if the app is currently in a state where no model can be loaded. This includes having config windows open or a model load operation currently already being in progress. There is also a global 2 second cooldown for this requests.

## Moving the currently loaded VTS model

If a model is loaded, this allows you to change its position, rotation and size. If no model is loaded, this will return an error, see [ErrorsID.cs](https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/ErrorID.cs)

The required fields in this request are `"timeInSeconds"` and `"valuesAreRelativeToModel"`. `"timeInSeconds"` is the time in seconds the movement should take and has to be a float value between 0 and 2. If this is set to 0, the model will instantly appear the the given position. A value higher than that will make the model move, rotate and grow/shrink smoothly to the given position (faded in/out). While the movement is going on, the user cannot move the model manually by dragging it. That will be possible again about half a second after the model has finished moving to the destination.

Subsequent `MoveModelRequest` can be sent without waiting for the ongoing one to finish. If one is ongoing, it will be interrupted and replaced by the new one. You can even take complete control over the movement by sending one request each frame with 0 as `"timeInSeconds"`.

The `"size"` is given as a float between -100 (smallest) and +100 (biggest). For `"positionX"`, `"positionY"` and `"rotation"`, please refer to the following image:

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
	}
}
```

The `"modelID"` (and `"data"` object in general here) is optional. If it's not provided, the hotkeys for the current model are returned. If the model ID is provided, the hotkeys of the model with the give model ID are returned. If no model with that ID is found, an error is returned (see [ErrorID.cs](https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/ErrorID.cs), `ModelIDNotFound`).

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
				"file": "myExpression_1.exp3.json",
				"hotkeyID": "SomeUniqueIdToIdentifyHotkeyWith1"
			},
			{
				"name": "My second hotkey",
				"type": "TriggerAnimation",
				"file": "myAnimation.motion3.json",
				"hotkeyID": "SomeUniqueIdToIdentifyHotkeyWith2"
			},
			{
				"name": "My third hotkey",
				"type": "ChangeVTSModel",
				"file": "someOtherModel.vtube.json",
				"hotkeyID": "SomeUniqueIdToIdentifyHotkeyWith3"
			},
			{
				"name": "My fourth hotkey",
				"type": "MoveModel",
				"file": "",
				"hotkeyID": "SomeUniqueIdToIdentifyHotkeyWith4"
			},
			{
				"name": "My fifth hotkey",
				"type": "Unset",
				"file": "",
				"hotkeyID": "SomeUniqueIdToIdentifyHotkeyWith5"
			}
		]
	}
}
```

If no model ID was specified in the request and no model is loaded, `"modelLoaded"` will be false and the `"availableHotkeys"` array will be empty. If an ID was specified, the `"modelLoaded"` field will be `true` or `false` depending on whether or not the model with the given ID is currently loaded.

The `"file"` field contains the expression/animation/model filename for hotkeys of type `TriggerAnimation`, `ChangeIdleAnimation`, `ToggleExpression` and `ChangeVTSModel`. For `ChangeBackground` hotkeys, this contains the backgroudn name without the file extension. For all other types, it contains an empty string.

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
		"hotkeyID": "UniqueIdOfHotkeyToExecute"
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

This may return an error if the hotkey ID wasn't found or the hotkey couldn't be executed for some reason. Reasons include no model being currently loaded or the hotkey cooldown not being over (one specific hotkey can only be triggered once every 5 frames). You may send different hotkeys in quick succession, which will result in them getting queued. Once every 5 frames, one hotkey is take from the queue and executed. The queue holds 32 hotkeys. When the queue is full but you try to send in more hotkeys, an error will be returned.

## Requesting list of ArtMeshes in current model

The API uses the term `ArtMesh Name`, but this actually refers to the ArtMesh ID which will be unique per model as enforced by the Live2D Cubism Editor. `ArtMesh Tags` can be added by selecting an ArtMesh and writing into the UserData field. If you want to use tags, make sure that you check `Export UserData file (userdata3.json)`. You should then include the `.userdata3.json` file when copying the model to the VTube Studio Live2DModels-folder.

ArtMesh tags returned in the `"artMeshTags"` array will not contain duplicate tags.

If no model is loaded, `"modelLoaded"` will be `false` and the arrays will be empty.

**Note about "tags":** Tags can be added to ArtMeshes in the "data" field in the Live2D Cubism Editor. You can add any text into that field in the editor. VTube Studio will split that text at spaces and newline characters. This means if your tag text is "my tag", it will become two tags in VTS: "my" and "tag". You can add as many tags to each ArtMesh as you want.

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
			"colorA": 255
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

**Super secret note:** If you add `"jeb_": true` to the `"colorTint"` object, it'll activate the rainbow animation mode for the matched ArtMeshes.

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

## Requesting list of available tracking parameters

:warning: <b>Not yet implemented</b> :warning: 

You can request a list of parameters currently available in VTube Studio.
This includes all regular parameters and all custom parameters created by plugins. Parameters created by plugins will be marked as such when you select them from the parameter list in VTube Studio. It will also show the name of the plugin that created them.


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

:warning: <b>Not yet implemented</b> :warning: 

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

:warning: <b>Not yet implemented</b> :warning: 

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

You can feed in data for any default or custom parameter like this:

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "InjectParameterDataRequest",
	"data": {
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

If another plugin is already controlling this (default or custom) parameter, an error will be returned.

You can also add an optional `"weight"` parameter between 0 and 1. This can be used used to mix the `"value"` you send in for the parameter with the value that has been set for the parameter from face tracking. You could for example control a parameter 50% with face tracking and 50% using the API. Only one API plugin can write to one parameter at a time though. One use-case for this would be to fade in/out control of a face tracking parameter so it doesn't "jump" the moment you take control of it via the API. If you don't include the `"weight"` parameter in your request for a parameter, it will be considered to have the value 1, meaning the target parameter will instantly be set to the value provided by your plugin.

It should also be noted that these parameters are treated similar to normal tracking parameters. As such, you can select them as normal inputs for VTube Studio parameter mappings and apply smoothing via the sliders on the UI. Deleting custom parameters while they are being used by a model also does not cause any issues and they can be recreated at any time.


