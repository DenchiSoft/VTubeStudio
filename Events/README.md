# <a href="https://denchisoft.com"><img src="https://raw.githubusercontent.com/DenchiSoft/VTubeStudio/master/Images/vtube_studio_logo_nyan_3.png" width="542" /></a><br> [![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/DenchiSoft/VTubeStudio/blob/master/LICENSE) [![VTube Studio Discord](https://discordapp.com/api/guilds/652602255748497449/widget.png?style=shield)](https://discord.gg/VTubeStudio) [![Stars](https://img.shields.io/github/stars/DenchiSoft/VTubeStudio?style=social)](https://github.com/DenchiSoft/VTubeStudio) [![Twitter Follow](https://img.shields.io/twitter/follow/VTubeStudio.svg?style=social)](https://twitter.com/VTubeStudio)


[![VTube Studio Discord](https://discordapp.com/api/guilds/652602255748497449/widget.png?style=banner2)](https://discord.gg/VTubeStudio)


## Contents

- [General Info](#general-info)
- [Subscribing and unsubscribing](#subscribing-and-unsubscribing)
- [Events](#events)
  - [Test event](#test-event)
  - [Model loaded/unloaded](#model-loadedunloaded)

## General Info

Using the **VTube Studio Event API**, you can subscribe to various events to make sure your plugin gets a message when something happens in VTube Studio. That way, you can for example get notified every time a hotkey is activated, a model/item is loaded/unloaded, the model is clicked and much more.

To receive events of a certain type, you have to **subscribe** to them. When you don't want to receive events anymore, you have to **unsubscribe**. When your plugin disconnects from the VTube Studio API, all events your plugin had subscribed to are automatically unsubscribed as well.

## Subscribing and unsubscribing

You can subscribe to specific events to get notified every time the event occurs. You subscribe using the `EventSubscriptionRequest`, which will return an `EventSubscriptionResponse` if successful. Once subscribed, you will receive a message every time the event is triggered.

The following chart explains the subscription flow:

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
        "subscribedEventCount": 3,
        "subscribedEvents": [
            "TestEvent",
            "ModelLoadedEvent"
        ]
    }
}
```


## Events

The following sections describe all available events in detail. For a more compact list of all currently available events, please check the **"Contents"** section at the top of this page.

## Test event

TODO

## Model loaded/unloaded

TODO
