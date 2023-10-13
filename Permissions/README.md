# Permissions

Certain functionality offered by the VTube Studio API is locked behind additional **permissions** that have to be requested by the plugin after authenticating. Like the permissions in iOS and Android, this is to make sure users understand when plugins use functionality that could be considered risky or potentially dangerous, such as loading arbitrary images as items.

When requesting a permission, a popup is shown to the user explaining what the permission does. The user can then choose to grant or deny it. For more information on how to request permissions and what you need them for, check the [permissions page](Permissions/).

[![VTube Studio Permission Request Screen](/Images/vts_api_permissions_1_transparent.png)](Permissions/)

## Available permissions

The following is a list of **all current permissions** including the requests that need them. Use the permission name when requesting them.

* `LoadCustomImagesAsItems`
  * Used in the `ItemLoadRequest`. If you have this permission, you can provide custom PNG/JPG data that will be loaded as item in VTube Studio. Without that permission, you can only load items that the user has already added to VTube Studio. For more info, see explanation for `ItemLoadRequest`, in particular its `customDataBase64` field.
* ...more to come!!
 
The following permissions can be enabled by the user in the API config for your plugin but you can **NOT** request those permissions as they are considered too dangerous. If you really need those permissions, ask the user to turn them on manually.

* `LoadCustomImagesWithoutPreview`
  * Used in the `ItemLoadRequest`. Normally, if you only have the `LoadCustomImagesAsItems` permission, you can load arbitrary JPG/PNG data as item but it will first be shown to the user as a small icon on the UI and the user can then decide whether or not they want to actually load it as item. With this permission, you can completely skip that UI prompt and load any image data directly into the scene without any user input.


## Requesting permissions

You can use the `PermissionRequest` to request permissions. If you only want to receive the list of currently granted/available permissions for this plugin without actually requesting a permission, send a request with the `requestedPermission` field left empty.

If you pass in a valid permission in the `requestedPermission` field, a popup will be shown to the user containing all info about the permission and your plugin (see image above). Please only request permissions that your plugin really needs.

If your plugin already has been granted the permission before, the response is returned instantly without showing a popup to the user. Once a permission is granted, you cannot revoke it via the API, but the user can revoke it in the VTube Studio API config for your plugin at any time.

An error will be returned if you request an unknown permission or a valid permission that plugins aren't allowed to request via this API. An error is also returned if the user currently has the API config window open or if there are issues reading/writing the plugin config file.

All possible error IDs for this request are listed on the page [ErrorsID.cs](https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/ErrorID.cs).


**`REQUEST`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"requestID": "SomeID",
	"messageType": "PermissionRequest",
	"data": {
		"requestedPermission": "LoadCustomImagesAsItems"
	}
}
```

The response will contain **ALL permissions** that VTube Studio offers. The `granted` field tells you whether or not your plugin currently has that permission. The `allowedToRequest` field is `true` for all permissions you can request and `false` for permissions that have to be manually turned on in the API config for your plugin by the user.

In case you actually requested a permission, the `grantSuccess` field will tell you whether or not the user granted the permission for your plugin and the `requestedPermission` field will contain the name of the granted permission.

**`RESPONSE`**
```json
{
	"apiName": "VTubeStudioPublicAPI",
	"apiVersion": "1.0",
	"timestamp": 1625405710728,
	"requestID": "SomeID",
	"messageType": "PermissionResponse",
	"data": {
		"grantSuccess": true,
		"requestedPermission": "LoadCustomImagesAsItems",
		"permissions": [
			{
				"name": "LoadCustomImagesAsItems",
				"granted": true,
				"allowedToRequest": true
			},
			{
				"name": "LoadCustomImagesWithoutPreview",
				"granted": false,
				"allowedToRequest": false
			}
		]
	}
}
```

TODO

`"uptime"` contains the number of milliseconds since VTube Studio has been started. `"framerate"` is the current render FPS value. `"allowedPlugins"` is the number of plugins that the user has currently allowed to use VTube Studio, `"connectedPlugins"` is the number of plugins that are currently connected to the VTube Studio API. `"startedWithSteam"` is true if the app has been started using Steam, false otherwise (if the `.bat` file has been used to start VTS without Steam).

Window width and height is in pixels.
