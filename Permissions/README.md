# Permissions

TODO

## Requesting permissions



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
