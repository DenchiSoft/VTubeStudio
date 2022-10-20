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
