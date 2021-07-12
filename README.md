# <a href="https://denchisoft.com"><img src="https://raw.githubusercontent.com/DenchiSoft/VTubeStudio/master/Images/vtube_studio_logo_nyan_2.png" width="542" /></a><br> [![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/DenchiSoft/VTubeStudio/blob/master/LICENSE) [![VTube Studio Discord](https://discordapp.com/api/guilds/652602255748497449/widget.png?style=shield)](https://discord.gg/VTubeStudio) [![Stars](https://img.shields.io/github/stars/DenchiSoft/VTubeStudio?style=social)](https://github.com/DenchiSoft/VTubeStudio) [![Twitter Follow](https://img.shields.io/twitter/follow/VTubeStudio.svg?style=social)](https://twitter.com/VTubeStudio)


[![VTube Studio Discord](https://discordapp.com/api/guilds/652602255748497449/widget.png?style=banner2)](https://discord.gg/VTubeStudio)

## Contents

- [General Info](#general-info)
- [Status](#status)
- [API Details](#api-details)
  - [Authentication](#authentication)
  - [Getting the currently loaded model](#getting-the-currently-loaded-model)
  - [Getting a list of available VTS models](#getting-a-list-of-available-vts-models)
  - [Loading a VTS model by its ID](#loading-a-vts-model-by-its-id)
  - [Requesting list of hotkeys available in the currently loaded VTS model](#requesting-list-of-hotkeys-available-in-the-currently-loaded-vts-model)
  - [Requesting execution of hotkeys](#requesting-execution-of-hotkeys)
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

## Status

:warning: <b>First draft finished. If you have feedback, please post it in the public API channel in the [VTS Discord](https://discord.gg/VTubeStudio).</b> :warning: 

:warning: <b>None of this is final yet, so if you plan to use this API, you might want to wait a bit before starting with your implementation.</b> :warning: 

# API Details

The VTube Studio websocket server runs on `ws://localhost:8001`. This is the default, but users can also change the port in the app.
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

All possible error IDs are listed on the page "Errors" (will be created later).

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
		"startedWithSteam": true
	}
}
```

`"uptime"` contains the number of milliseconds since VTube Studio has been started. `"framerate"` is the current render FPS value. `"allowedPlugins"` is the number of plugins that the user has currently allowed to use VTube Studio, `"connectedPlugins"` is the number of plugins that are currently connected to the VTube Studio API. `"startedWithSteam"` is true if the app has been started using Steam, false otherwise (if the `.bat` file has been used to start VTS without Steam).

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
		"textureResolution": 4096
	}
}
```

`"modelLoaded"` will be `true` if a model is currently loaded. If no model is loaded or a model is currently in the process of being loaded, this will be false. In this case, all other values will be empty (or zero in case of integers).

`"modelLoadTime"` is the time in milliseconds it took to load the current model. `"timeSinceModelLoaded"` contains the time in milliseconds since the model has been loaded.

`"vtsModelIconPath"` contains the full path to the icon used for this model in the model selection bar in VTube Studio. If the model has no icon set, this will be an empty string.

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

## Requesting list of hotkeys available in the currently loaded VTS model

**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "HotkeysInCurrentModelRequest"
}
```

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
				"file": "myAnimation.anim3.json",
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
			}
		]
	}
}
```

If `"modelLoaded"` is false, the `"availableHotkeys"` array will be empty. The `"file"` field contains the expression/animation/model filename for hotkeys of type `TriggerAnimation`, `ChangeIdleAnimation`, `ToggleExpression`, `ChangeBackground` and `ChangeVTSModel`. For all other types, this contains an empty string.

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
This may return an error if the hotkey ID wasn't found or the hotkey couldn't be executed for some reason.

## Requesting list of available tracking parameters

You can request a list of parameters currently available in VTube Studio.
This includes all regular parameters and all custom parameters created by plugins. Parameters created by plugins will be marked as such when you select them from the parameter list in VTube Studio. It will also show the name of the plugin that created them.


**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "ParameterListRequest"
}
```

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "ParameterListResponse",
	"data": {
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
		"createdBy": "My Plugin Name",
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

These custom parameters you create are stored as part of the VTube Studio configuration in a file called `custom_parameters.json` in the `Config` folder, which is located in the VTube Studio `StreamingAssets` folder.

## Delete custom parameters

You can delete custom parameters. Default parameters cannot be deleted.

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
You have to re-send data for a parameter you want to control with your plugin **at least once every 3 seconds**. Failure to do so will result in the parameter being considered "lost" and it will go back to the value of whatever was controlling it before. If nothing else is controlling it, it will return to its default value. 


