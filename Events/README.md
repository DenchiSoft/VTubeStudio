# <a href="https://denchisoft.com"><img src="https://raw.githubusercontent.com/DenchiSoft/VTubeStudio/master/Images/vtube_studio_logo_nyan_3.png" width="542" /></a><br> [![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/DenchiSoft/VTubeStudio/blob/master/LICENSE) [![VTube Studio Discord](https://discordapp.com/api/guilds/652602255748497449/widget.png?style=shield)](https://discord.gg/VTubeStudio) [![Stars](https://img.shields.io/github/stars/DenchiSoft/VTubeStudio?style=social)](https://github.com/DenchiSoft/VTubeStudio) [![Twitter Follow](https://img.shields.io/twitter/follow/VTubeStudio.svg?style=social)](https://twitter.com/VTubeStudio)


[![VTube Studio Discord](https://discordapp.com/api/guilds/652602255748497449/widget.png?style=banner2)](https://discord.gg/VTubeStudio)


## Contents

- [General Info](#general-info)
- [Subscribing and unsubscribing](#subscribing-and-unsubscribing)
- [Events](#events)
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



## Events

The following sections describe all available events in detail. For a more compact list of all currently available events, please check the **"Contents"** section at the top of this page.

## Model loaded/unloaded

TODO
