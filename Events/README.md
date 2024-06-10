# <a href="https://denchisoft.com"><img src="https://raw.githubusercontent.com/DenchiSoft/VTubeStudio/master/Images/vtube_studio_logo_nyan_3.png" width="542" /></a><br> [![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/DenchiSoft/VTubeStudio/blob/master/LICENSE) [![VTube Studio Discord](https://discordapp.com/api/guilds/652602255748497449/widget.png?style=shield)](https://discord.gg/VTubeStudio) [![Stars](https://img.shields.io/github/stars/DenchiSoft/VTubeStudio?style=social)](https://github.com/DenchiSoft/VTubeStudio) [![Twitter Follow](https://img.shields.io/twitter/follow/VTubeStudio.svg?style=social)](https://twitter.com/VTubeStudio)


[![VTube Studio Discord](https://discordapp.com/api/guilds/652602255748497449/widget.png?style=banner2)](https://discord.gg/VTubeStudio)


## Contents

- [General Info](#general-info)
- [Subscribing and unsubscribing](#subscribing-and-unsubscribing)
- [Events](#events)
  - [Test event](#test-event)
  - [Model loaded/unloaded](#model-loadedunloaded)
  - [Lost/Found tracking](#lostfound-tracking)
  - [Background changed](#background-changed)
  - [Model config modified](#model-config-modified)
  - [Model moved/resized/rotated](#model-movedresizedrotated)
  - [Model outline changed](#model-outline-changed)
  - [Hotkey triggered](#hotkey-triggered)
  - [Animation event triggered](#animation-event-triggered)
  - [Item event](#item-event)
  - [Model clicked event](#model-clicked-event)
  - [Post-processing event](#post-processing-event)
  - [Live2D Cubism Editor connected event](#live2d-cubism-editor-connected-event)
 
## General Info

Using the **VTube Studio Event API**, you can subscribe to various events to make sure your plugin gets a message when something happens in VTube Studio. That way, you can for example get notified every time a hotkey is activated, a model/item is loaded/unloaded, the model is clicked and much more.

To receive events of a certain type, you have to **subscribe** to them. When you don't want to receive events anymore, you have to **unsubscribe** from that event or all events. When your plugin disconnects from the VTube Studio API, all events your plugin session is subscribed to are automatically unsubscribed as well.

## Subscribing and unsubscribing

You can subscribe to specific events to get notified every time the event occurs. You subscribe using the `EventSubscriptionRequest`, which will return an `EventSubscriptionResponse` if successful. Once subscribed, you will receive a message every time the event is triggered.

If you subscribe to an event multiple times, the new config you provide will overwrite the old config. You can also unsubscribe multiple times or unsubscribe from an event you're not subscribed to. This will return successfully (no error) but will do nothing.

The following chart explains the subscription/event flow:

#### Subscription Flow
![The VTS Event System Subscription Flow](/Images/events_explanation.png)

You can also unsubscribe at any time if you no longer wish to receive the events.

The request to subscribe/unsubscribe looks like this: (here with the `ModelLoadedEvent` as an example)

**`REQUEST`**
```json
{
    "apiName": "VTubeStudioPublicAPI",
    "apiVersion": "1.0",
    "requestID": "SomeID",
    "messageType": "EventSubscriptionRequest",
    "data": {
        "eventName": "ModelLoadedEvent",
        "subscribe": true,
        "config": {
            
        }
    }
}
```

In the `eventName` field, pass in the name of the event you want to subscribe to. Set `subscribe` to `true` if you want to subscribe to the event or `false` if you want to unsubscribe from it. If you set `subscribe` to `false`, you can also leave out the `eventName` field (or leave it empty) to unsubscribe the current plugin session from all events.

Some events offer extra configuration parameters, which you can specify in the `config` part of the payload. Different events require different parameters there, some may be optional.

The response will contain the number and list of now subscribed events for this plugin session.

If the event type you tried to subscribe to or unsubscribe from is unknown, an error will be returned insted. If any of the config parameters you provided for the specific event are invalid, there will also be an error. All possible error IDs are listed on the page [ErrorsID.cs](https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/ErrorID.cs). Errors related to specific event configs have an offset of `100000`, as you can see on that page.

**`RESPONSE`**
```json
{
    "apiName": "VTubeStudioPublicAPI",
    "apiVersion": "1.0",
    "timestamp": 1625405710728,
    "requestID": "SomeID",
    "messageType": "EventSubscriptionResponse",
    "data": {
        "subscribedEventCount": 2,
        "subscribedEvents": [
            "TestEvent",
            "ModelLoadedEvent"
        ]
    }
}
```


## Events

The following sections describe all available events in detail. For a more compact list of all currently available events, please check the **"Contents"** section at the top of this page.

The payloads listed here only have the relevant section for the event (the `config` part). Some events do not have any config. For those, you can either leave the config section empty or leave it out of the payload altogether.

## Test event

An event for testing the event API.

You can pass in a string in `testMessageForEvent` (optional). It has to be 32 characters or shorter, otherwise an error will be returned (you can use this to test event error handling).

When you're subscribed to this event, the string you provided will be returned every second along with a counter that counts the seconds since VTube Studio has been started (so the counter will be increased by 1 in every event message).

Keep in mind that you can subscribe with a message in `testMessageForEvent` and then subscribe with a different message. This will overwrite the old config and you should receive the new message.

**`CONFIG`**
```json
"eventName": "TestEvent",
"config": {
    "testMessageForEvent": "text the event will return"
}
```

This is what you will receive every time the event is triggered (once a second).

The outer payload will be omitted for the other event payload examples.

**`EVENT`**
```json
{
    "apiName": "VTubeStudioPublicAPI",
    "apiVersion": "1.0",
    "timestamp": 1625405710728,
    "requestID": "SomeID",
    "messageType": "TestEvent",
    "data": {
        "yourTestMessage": "text the event will return",
        "counter": 672
    }
}
```

## Model loaded/unloaded

An event that is triggered every time a VTube Studio model is loaded or unloaded.

You can pass in one or more model IDs in the `modelID` array (optional). If you do, an event will only be sent every time the model with one of the specific IDs is loaded or unloaded. If you pass in model IDs, they all have to have the correct format (32 characters, only hex characters), otherwise an error is returned.

**`CONFIG`**
```json
"eventName": "ModelLoadedEvent",
"config": {
    "modelID": [
      "OPTIONAL_model_ID_to_filter_for",
      "OPTIONAL_some_other_model_ID_to_filter_for"
    ]
}
```

The event will be triggered every time a model (or one of the specified models) is loaded or unloaded. Depending on wether it was loaded or unloaded, `modelLoaded` will be `true` or `false`.

**`EVENT`**
```json
"messageType": "ModelLoadedEvent",
"data": {
    "modelLoaded": true,
    "modelName": "My VTS Model Name",
    "modelID": "165131471d8a4e42aae01a9738f255ef"
}
```

## Lost/Found tracking

An event that is triggered every time the face tracker finds/loses the face or hands.

**`CONFIG`**
```json
"eventName": "TrackingStatusChangedEvent",
"config": { }
```

Every time the face or left hand or right hand is found/lost, an event message like this will be sent:

**`EVENT`**
```json
"messageType": "TrackingStatusChangedEvent",
"data": {
    "faceFound": true,
    "leftHandFound": false,
    "rightHandFound": false
}
```

## Background changed

An event that is triggered every time the background is changed by the user (manually or via hotkey).

**`CONFIG`**
```json
"eventName": "BackgroundChangedEvent",
"config": { }
```

The event will contain the background name (`backgroundName` field), as shown in the background selection list. This is typically the file name without the file extension.

**`EVENT`**
```json
"messageType": "BackgroundChangedEvent",
"data": {
    "backgroundName": "my_cool_background"
}
```

## Model config modified

An event that is triggered every time the user manually changes the the settings/config of the currently loaded VTube Studio model. If the changed config is related to hotkeys, `hotkeyConfigChanged` will be `true` in the event payload.

**`CONFIG`**
```json
"eventName": "ModelConfigChangedEvent",
"config": { }
```

**`EVENT`**
```json
"messageType": "ModelConfigChangedEvent",
"data": {
    "modelID": "UniqueIDToIdentifyThisModelBy",
    "modelName": "My Cool Model",
    "hotkeyConfigChanged": true
}
```

## Model moved/resized/rotated

An event that is triggered every time a model is moved, resized or rotated. This will also be triggered right after subscribing, so it will send you the current position/scale/rotation of the currently loaded model the moment you subscribe (unless no model is loaded) and then send the current position/scale/rotation in every frame when there's a change.

**`CONFIG`**
```json
"eventName": "ModelMovedEvent",
"config": { }
```

The `modelPosition` object in the response contains the model position (`positionX` and `positionY`), the model size (`size`) and the model rotation (`rotation`). This is the exact same object that you receive by polling the `CurrentModelRequest`, so please check that request for how to interpret the `modelPosition` data (see [here](https://github.com/DenchiSoft/VTubeStudio#getting-the-currently-loaded-model)).

For more info about this data and the VTube Studio coordinate system, please check [this link](https://github.com/DenchiSoft/VTubeStudio#the-vts-coordinate-system).

**`EVENT`**
```json
"messageType": "ModelMovedEvent",
"data": {
    "modelID": "UniqueIDToIdentifyThisModelBy",
    "modelName": "My Cool Model",
    "modelPosition": {
        "positionX": -0.20491,
        "positionY": 0.1,
        "size": -74.49664306640625,
        "rotation": 341.3
    }
}
```


## Model outline changed

An event that is triggered at a constant 15 FPS and sends subscribed plugins the model outline. Specifically, it sends an approximated convex polygon based on the bounding-box center points of all (visible) ArtMeshes in the model. If no model is loaded, the event isn't sent.

This makes it possible for plugins to track the model extents within the window somewhat accurately.

You can pass in the `"draw"` parameter as `true` (default if not provided is `false`) to actually draw the outline polygon in VTube Studio. Drawing the outline in VTube Studio may not be performant so you should only do that for debugging purposes or to show the outline to the user for setup purposes. The outline will be drawn if at least one subscribed plugins has set `"draw"` to `true`.

If you turn on the outline, it will be rendered like this:

![Model Debug Outline](/Images/api_outline_ex.png)

**`CONFIG`**
```json
"eventName": "ModelOutlineEvent",
"config": {
    "draw": false
}
```

You will receive the following event 15 times per second.

The `"convexHull"` list contains 2D points describing the rough outline of the model. This list is ordered. The x/y coordinate of each point is it's position within the VTube Studio window, as shown in the picture below. X or Y coordinates may be bigger than 1 or smaller than -1 if an outline point is outside of the window boundaries.

The `"convexHull"` list is guaranteed to have at least 3 entries. There is no limit to how many entries it can have, but for most normal Live2D models, it has between 5 and 25 entries. Please also keep in mind that the number of list entries can (and will most likely) change between events you receive. Do not implement your plugin expecting the number of outline points to remain constant.

The `"convexHullCenter"` parameter is the center/average of all the `"convexHull"` points.

Additionally, the `"windowSize"` parameter contains the current VTube Studio window size.

#### The VTS Coordinate System
![The VTS Coordinate System](/Images/coordinate_explanation.png)


**`EVENT`**
```json
"messageType": "ModelOutlineEvent",
"data": {
    "modelName": "My VTS Model Name",
    "modelID": "165131471d8a4e42aae01a9738f255ef",
    "convexHull": [
        {
            "x": 0.200516939163208,
            "y": 0.8014626502990723
        },
        {
            "x": 0.5141212940216064,
            "y": -0.297398179769516
        },
        {
            "x": 0.28484871983528137,
            "y": -1.1670516729354858
        },
        {
            "x": 0.1435088962316513,
            "y": -0.30985555052757263
        },
        {
            "x": 0.5271111130714417,
            "y": 0.7104558944702148
        },
        {
            "x": 0.28484871983528137,
            "y": -1.1670516729354858
        },
        {
            "x": 0.5141212940216064,
            "y": -0.297398179769516
        }
    ],
    "convexHullCenter": {
        "x": 0.3527252674102783,
        "y": -0.24669097363948822
    },
    "windowSize": {
        "x": 1920,
        "y": 1080
    }
}
```


## Hotkey triggered

An event that is triggered every time a hotkey is triggered manually by the user (keyboard/hand-gesture) or via the hotkey-trigger-API.

You can pass in the `"onlyForAction"` parameter (optional). Valid values are the hotkey actions listed here: ["HotkeyActions.cs"](https://github.com/DenchiSoft/VTubeStudio/blob/master/Files/HotkeyAction.cs).
If you provide that parameter, only hotkeys of the provided type (with the given action) will trigger this event. Otherwise, all hotkey activations will trigger the event.

If you do not want to receive events when a hotkey is triggered by a plugin via the trigger-hotkey-API, you can pass in `ignoreHotkeysTriggeredByAPI` as `true`.

The event is also triggered when a hotkey is triggered for a Live2D item.

**`CONFIG`**
```json
"eventName": "HotkeyTriggeredEvent",
"config": {
    "onlyForAction": "ToggleExpression",
    "ignoreHotkeysTriggeredByAPI": false
}
```

**`EVENT`**
```json
"messageType": "HotkeyTriggeredEvent",
"data": {
    "hotkeyID": "21bf7ade9e664f3ec29d05156e4ce5c1",
    "hotkeyName": "Eyes Cry",
    "hotkeyAction": "ToggleExpression",
    "hotkeyFile": "EyesCry.exp3.json",
    "hotkeyTriggeredByAPI": false,
    "modelID": "d8ee771d2909873b1aa0226d03ef4f51",
    "modelName": "Akari",
    "isLive2DItem": false
}
```

## Animation event triggered

An event that is triggered every time there's an _animation-event_ encountered in an animation playing for any Live2D model in the scene (so for the main model and any Live2D items).

The following _animation-events_ will trigger this event:
- `Start`: An event is triggered when an animation **starts** (idle-animations or normal one-time animations)
- `End`:  An event is triggered when an animation **ends** (idle-animations or normal one-time animations)
- `Custom`:  An event is triggered when a custom event is encountered in the animation. These events can be added at any point in the animation when creating animations in the _Live2D Cubism Animation Editor_. You can find more details about how to create/use those events below.

These events will be triggered for normal one-time animations and for idle animations. If an animation is stopped because the model playing it is unloaded, no event is triggered.

If you don't want to receive events triggered by animations in Live2D items, set `ignoreLive2DItems` to `true`. If you don't want to receive events triggered by any idle animations, set `ignoreIdleAnimations` to `true`. 


**`CONFIG`**
```json
"eventName": "ModelAnimationEvent",
"config": {
    "ignoreLive2DItems": false,
    "ignoreIdleAnimations": false
}
```

The `animationEventType` field contains the source of the event. Possible values are `Start` (an animation started), `End` (an animation ended) and `Custom`. For idle animations, the start/end events will continuously trigger as the animation loops. The `Custom` events are explained in more detail below.

`animationEventTime` is the time in seconds within the animation when the animation-event was encountered. It's between 0 and `animationLength`, which is the length of the animation in seconds.

`animationName` contains the filename of the animation.

If `isIdleAnimation` is `true`, the event was triggered within an idle-animation. If it's `false`, the event was triggered within a normal one-time animation.

**`EVENT`**
```json
"messageType": "ModelAnimationEvent",
"data": {
    "animationEventType": "Custom",
    "animationEventTime": 0.423317,
    "animationEventData": "My Test Event 123456789",
    "animationName": "event_test_anim_4_final.motion3.json",
    "animationLength": 1.6670000553131104,
    "isIdleAnimation": false,
    "modelID": "4a7b131d2394f7ae61b0226d00ef471e",
    "modelName": "Akari",
    "isLive2DItem": false
}
```

#### How to set up custom animation events

_Custom animation events_ can be used to trigger an event to be sent every time an animation reaches a certain timestamp. This works in idle-animations and normal one-time animations.

These events can be added in the _Live2D Cubism Animation Editor_ when creating animations by right-clicking anywhere in the timeling and selecting "Add Event". From there, you can enter text that will be associated with this event and can be used to identify it. This text will be returned in the `animationEventData` parameter when the animation-event is encountered during animation playback.

The text can be up to 256 characters. If the text is longer, the event will not work (it will be ignored). Also, events outside the animation timeline will be ignored (for example if you place the event 1 second after the animation ends).

You also cannot use `Anim_Start` or `Anim_End` as text because those are reserved keywords for the `animationEventData` parameter for the events triggered by an animation starting/ending.

When exporting an animation with _custom animation events_, make sure you have enabled "Export Event" on the animation export dialog in the _Live2D Cubism Animation Editor_.

The following graphic explains all steps required to create an animation event.

<img src="https://raw.githubusercontent.com/DenchiSoft/VTubeStudio/master/Images/api_animation_events_custom_1.png" alt="Setting up custom animation events in the Live2D Cubism Animator" width="750">


## Item event

An event that is triggered every time certain actions are done with/by an item. The item is identified by its `itemInstanceID`.

There are two arrays you can pass in (optional):
* `itemInstanceIDs`: If you pass in a list of item IDs, items with non-matching IDs will not trigger the event.
* `itemFileNames`: If you pass in a list of item filenames, items with non-matching filenames will not trigger the event. This does "contains-matching", so for example if you pass in `"my"`, it will match the item `my_item.png`

If you don't pass in the lists or both lists are empty, all items will trigger events. If you pass in both lists, items will trigger events if they match one list or the other.

The following item event types are currently supported and will be returned in the `itemEventType` field:

* `Added`: Item was added to the scene.
* `Removed`: Item was removed from the scene.
* `DroppedPinned`: Item was dropped on the model and is now pinned.
* `DroppedUnpinned`: Item was dropped but not on the model. It is now unpinned
* `Clicked`: Item was clicked.
* `Locked`: Item was locked.
* `Unlocked`: Item was unlocked.

**`CONFIG`**
```json
"eventName": "ItemEvent",
"config": {
    "itemInstanceIDs": [ "some_item_instance_id_to_match" ],
    "itemFileNames": [ "some_filename_to_match", "some_other_filename_to_match.gif" ]
}
```

The event contains the item instance ID, item file name (including extension if applicable) and the item position in the usual coordinate system.

**`EVENT`**
```json
"messageType": "ItemEvent",
"data": {
    "itemEventType": "ItemClicked",
    "itemInstanceID": "3dcfc2456ac94a37bad369ec1875a15b",
    "itemFileName": "my_item.png",
    "itemPosition": {
        "x": -0.34229445457458496,
        "y": 0.515410304069519
    }
}
```


## Model clicked event

An event that is triggered every time the model is clicked. Depending on the config, it is also triggered when you click anywhere in the VTS window even if the click wasn't on the model.

This contains detailed information on where exactly the model was clicked.

**`CONFIG`**
```json
"eventName": "ModelClickedEvent",
"config": {
    "onlyClicksOnModel": true
}
```

`modelLoaded` will be `true` if a model is currently loaded. If one is loaded, `loadedModelID` will contain its ID and `loadedModelName` will contain the name.

`mouseButtonID` is the ID of the mouse button. `0` is left-click, `1` is right-click and `2` is middle-click (mouse-wheel click). `clickPosition` is the position of the click in the usual coordinate system. If you need the exact pixel position of the click, you can use `windowSize` (current VTS window size in pixels) to calculate that.

If the model was clicked, the number of ArtMeshes at the click position will be returned in the `clickedArtMeshCount` field. The `artMeshHits` array will contain the details of each of those ArtMeshes, including where exactly they were clicked at vertex-level within the mesh. You can use that data to pin items at that position using the `ItemPinRequest`. This array could contain a lot of ArtMeshes since many ArtMeshes might be stacked at one given position of the model.

_Note:_ You can ignore the `angle` and `size` fields for now. They might be relevant in the future but have no purpose at the moment.

Each ArtMesh hit contains info about where that ArtMesh was clicked. `artMeshOrder` is the order in the ArtMesh stack at the click position. The topmost ArtMesh at the click position will have `"artMeshOrder": 0`. This would be the ArtMesh that items pin to when dropped by users at that exact position.

The exact click position within the ArtMesh is given via the `vertexID1`, `vertexID2`, `vertexID3`, `vertexWeight1`, `vertexWeight2`, `vertexWeight3` fields as [barycentric coordinates](https://en.wikipedia.org/wiki/Barycentric_coordinate_system). In short, VTS checks which specific triangle was clicked in the ArtMesh and returns the three vertex IDs that make up this triangle, including the weights that if multiplied with the vertex positions will result in the exact click position within the triangle.

The ArtMesh ID and barycentric coordinates can be used to identify an exact position on the model and can be used to pin an item at that position using the `ItemPinRequest`.

**`EVENT`**
```json
"messageType": "ModelClickedEvent",
"data": {
    "modelLoaded": true,
    "loadedModelID": "d87b771d2902473bbaa0226d03ef4754",
    "loadedModelName": "Akari",
    "modelWasClicked": true,
    "mouseButtonID": 0,
    "clickPosition": {
        "x": -0.15343914926052094,
        "y": 0.34593725204467773
    },
    "windowSize": {
        "x": 2268,
        "y": 1243
    },
    "clickedArtMeshCount": 2,
    "artMeshHits": [
        {
            "artMeshOrder": 0,
            "isMasked": false,
            "hitInfo": {
                "modelID": "d87b771d2902473bbaa0226d03ef4754",
                "artMeshID": "hair_right6",
                "angle": 130.80455017089844,
                "size": 1.0,
                "vertexID1": 80,
                "vertexID2": 76,
                "vertexID3": 75,
                "vertexWeight1": 0.4725686013698578,
                "vertexWeight2": 0.07506437599658966,
                "vertexWeight3": 0.45236700773239136
            }
        },
        {
            "artMeshOrder": 1,
            "isMasked": true,
            "hitInfo": {
                "modelID": "d87b771d2902473bbaa0226d03ef4754",
                "artMeshID": "face_skin",
                "angle": 63.90638732910156,
                "size": 1.0,
                "vertexID1": 75,
                "vertexID2": 71,
                "vertexID3": 70,
                "vertexWeight1": 0.3965734839439392,
                "vertexWeight2": 0.06637920439243317,
                "vertexWeight3": 0.5370473265647888
            }
        }
    ]
}
```


## Post-processing event

An event that is triggered every time the post-processing system is turned on/off or a preset is loaded/unloaded. For more information about post-processing, check the [visual effects page](https://github.com/DenchiSoft/VTubeStudio/wiki/Visual-Effects).

If after receiving this event you want to read the detailed post-processing state including all configs and their values use the `PostProcessingListRequest` and if you want to send post-processing values, use the `PostProcessingUpdateRequest.`

**`CONFIG`**
```json
"eventName": "PostProcessingEvent",
"config": { }
```

**`EVENT`**
```json
"messageType": "PostProcessingEvent",
"data": {
    "currentOnState": true,
    "currentPreset": "my_preset"
}
```


## Live2D Cubism Editor connected event

VTube Studio can communicate directly with the **Live2D Cubism Editor**, which is used to create Live2D models. For more info on how that works, check the page ["Live2D Cubism Editor Communication"](https://github.com/DenchiSoft/VTubeStudio/wiki/Live2D-Cubism-Editor-Communication).

When fully connected, VTube Studio can send tracking data directly to Live2D, which makes testing angles/physics during rigging easier. The following fields are sent:

* `tryingToConnect`: Is VTube Studio trying to connect to Live2D Cubism? True if the `Connect` toggle is turend on in VTS.
* `connected`: Is VTube Studio fully connected to and authenticated with Live2D Cubism?
* `shouldSendParameters`: Has the user turned on the `Send parameters` toggle? If this is on and `connected` is true, VTube Studio is actively sending parameter data into Live2D Cubism.

When VTube Studio is actively sending parameter data into Live2D Cubism, plugins can also send parameter data to VTube Studio which will then be passed on to Live2D Cubism.

**Note:** This event is triggered every time the `Connect`/`Send parameters` toggles are toggled by the user and every time the connection state with the Live2D Cubism API changes. Additionally, the event is also sent exactly once when you first subscribe to the event. That way, you can easily get the initial state.

**`CONFIG`**
```json
"eventName": "Live2DCubismEditorConnectedEvent",
"config": { }
```

**`EVENT`**
```json
"messageType": "Live2DCubismEditorConnectedEvent",
"data": {
    "tryingToConnect": true,
    "connected": true,
    "shouldSendParameters": false
}
```

