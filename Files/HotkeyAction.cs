/// <summary>
/// Enum for the actions that can be triggered by hotkeys.
/// </summary>
public enum HotkeyAction
{
    Unset = -1,                  // Unset.
    TriggerAnimation = 0,        // Play an animation.
    ChangeIdleAnimation = 1,     // Change the idle animation.
    ToggleExpression = 2,        // Toggle an expression.
    RemoveAllExpressions = 3,    // Remove all expressions.
    MoveModel = 4,               // Moves the model to the target position.
    ChangeBackground = 5,        // Change the current background.
    ReloadMicrophone = 6,        // Reload the current microphone.
    ReloadTextures = 7,          // Reload the model texture.
    CalibrateCam = 8,            // Calibrate Camera.
    ChangeVTSModel = 9,          // Change VTS Model.
    TakeScreenshot = 10          // Takes a screenshot with the screenshot settings previously set in the UI.
}
