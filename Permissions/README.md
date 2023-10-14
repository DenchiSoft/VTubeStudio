# Permissions

Certain functionality offered by the VTube Studio API is locked behind additional **permissions** that have to be requested by the plugin after authenticating. Like the permissions in iOS and Android, this is to make sure users understand when plugins use functionality that could be considered risky or potentially dangerous, such as loading arbitrary images as items.

When requesting a permission, a popup is shown to the user explaining what the permission does. The user can then choose to grant or deny it. For more information on how to request permissions and what you need them for, check the [permissions page](Permissions/).

[![VTube Studio Permission Request Screen](/Images/vts_api_permissions_1_transparent.png)](Permissions/)

## Available permissions

The following is a list of **all current permissions** including the requests that need them. Use the permission name when requesting them.

* `LoadCustomImagesAsItems`
  * Used in the `ItemLoadRequest`. If you have this permission, you can provide custom PNG/JPG data that will be loaded as item in VTube Studio. Without that permission, you can only load items that the user has already added to VTube Studio. For more info, see explanation for `ItemLoadRequest`, in particular its `customDataBase64` field.
* ...more to come!!
 

## Requesting permissions

You can use the `PermissionRequest` to request permissions or just request a list of all already granted permissions. If you only want to receive the list of currently granted/available permissions for this plugin without actually requesting a permission, send a request with the `requestedPermission` field left empty.

If you pass in a valid permission in the `requestedPermission` field, a popup will be shown to the user containing all info about the permission and your plugin (see image above). Please only request permissions that your plugin really needs.

If your plugin already has been granted the permission before, the response is returned instantly without showing a popup to the user. Once a permission is granted, you cannot revoke it via the API, but the user can revoke it in the VTube Studio API config for your plugin at any time.

An error will be returned if you request an unknown permission. An error is also returned if the user currently has the API config window open or if there are issues reading/writing the plugin config file.

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

The response will contain **ALL permissions** that VTube Studio offers. The `granted` field tells you whether or not your plugin currently has that permission. 

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
				"granted": true
			}
		]
	}
}
```

