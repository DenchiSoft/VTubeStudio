/// <summary>
/// Enum for the actions that can be triggered by hotkeys.
/// </summary>
public enum HotkeyAction
{
    Unset = -1,                       // Unset.
    TriggerAnimation = 0,             // Play an animation.
    ChangeIdleAnimation = 1,          // Change the idle animation.
    ToggleExpression = 2,             // Toggle an expression.
    RemoveAllExpressions = 3,         // Remove all expressions.
    MoveModel = 4,                    // Moves the model to the target position.
    ChangeBackground = 5,             // Change the current background.
    ReloadMicrophone = 6,             // Reload the current microphone.
    ReloadTextures = 7,               // Reload the model texture.
    CalibrateCam = 8,                 // Calibrate Camera.
    ChangeVTSModel = 9,               // Change VTS Model.
    TakeScreenshot = 10,              // Take a screenshot with the previous settings.
    ScreenColorOverlay = 11,          // Activates/Deactivates model screen color overlay.
    RemoveAllItems = 12,              // Removes all items from the scene.
    ToggleItemScene = 13,             // Loads an item scene.
    DownloadRandomWorkshopItem = 14,  // Downloads a random item from the Steam Workshop and attempts to load it into the scene.
    ExecuteItemAction = 15,           // Executes a hotkey in the given Live2D item.
    ArtMeshColorPreset = 16,          // Loads the recorded ArtMesh multiply/screen color preset.
    ToggleTracker = 17,               // Toggles the tracking on/off. Can be webcam or USB/WiFi connected phone.
    ToggleTwitchFeature = 18,         // Toggles a Twitch feature (for example Emote Dropper) on/off.
    LoadEffectPreset = 19,            // Loads post processing effect preset.
    ToggleLive2DEditorAPI = 20,       // Toggles Live2D Editor API parameter sync on/off.
    WebItemAction = 21                // Triggers Web Item action.
}
