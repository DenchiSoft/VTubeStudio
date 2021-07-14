/// <summary>
/// Enum for API-related errors.
/// </summary>
public enum ErrorID
{
    // General errors
    InternalServerError = 0,
    APIAccessDeactivated = 1,
    JSONInvalid = 2,
    APINameInvalid = 3,
    APIVersionInvalid = 4,
    RequestIDInvalid = 5,
    RequestTypeMissingOrEmpty = 6,
    RequestTypeUnknown = 7,
    RequestRequiresAuthetication = 8,

    // Errors related to AuthenticationTokenRequest
    TokenRequestDenied = 50,
    TokenRequestCurrentlyOngoing = 51,
    TokenRequestPluginNameInvalid = 52,
    TokenRequestDeveloperNameInvalid = 53,
    TokenRequestPluginIconInvalid = 54,

    // Errors related to AuthenticationRequest
    AuthenticationTokenMissing = 100,
    AuthenticationPluginNameMissing = 101,
    AuthenticationPluginDeveloperMissing = 102,

    // Errors related to ModelLoadRequest
    ModelIDMissing = 150,
    ModelIDInvalid = 151,
    ModelIDNotFound = 152,
    ModelLoadCooldownNotOver = 153,
    CannotCurrentlyChangeModel = 154,

    // Errors related to HotkeyTriggerRequest
    HotkeyQueueFull = 200, // 
    HotkeyExecutionFailedBecauseNoModelLoaded = 201,
    HotkeyIDNotFoundInModel = 202,
    HotkeyCooldownNotOver = 203, // Individual hotkeys have a global 5 second cooldown
    HotkeyIDFoundButHotkeyDataInvalid = 204, // For example missing files for expression/animation hotkey
    HotkeyExecutionFailedBecauseBadState = 205, // For example when trying to load a model and the user has certain config windows open that temporarily prevent that
    HotkeyUnknownExecutionFailure = 206
}
