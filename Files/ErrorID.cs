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
    HotkeyQueueFull = 200, // Only a certain amount of hotkey activations can be queued until you have to wait for execution completion.
    HotkeyExecutionFailedBecauseNoModelLoaded = 201,
    HotkeyIDNotFoundInModel = 202,
    HotkeyCooldownNotOver = 203, // Individual hotkeys have a global 5 second cooldown
    HotkeyIDFoundButHotkeyDataInvalid = 204, // For example missing files for expression/animation hotkey
    HotkeyExecutionFailedBecauseBadState = 205, // For example when trying to load a model and the user has certain config windows open that temporarily prevent that
    HotkeyUnknownExecutionFailure = 206,
    HotkeyExecutionFailedBecauseLive2DItemNotFound = 207, // When triggering hotkeys in Live2D items, this will be returned if the requested Live2D item has not been found.
    HotkeyExecutionFailedBecauseLive2DItemsDoNotSupportThisHotkeyType = 208, // Only a subset of hotkey actions are supported in Live2D items, for example Expression hotkeys.
    
    // Errors related to ColorTintRequest
    ColorTintRequestNoModelLoaded = 250,
    ColorTintRequestMatchOrColorMissing = 251,
    ColorTintRequestInvalidColorValue = 252,

    // Errors related to MoveModelRequest
    MoveModelRequestNoModelLoaded = 300,
    MoveModelRequestMissingFields = 301,
    MoveModelRequestValuesOutOfRange = 302,
    
    // Errors related to ParameterCreationRequest
    CustomParamNameInvalid = 350,
    CustomParamValuesInvalid = 351,
    CustomParamAlreadyCreatedByOtherPlugin = 352,
    CustomParamExplanationTooLong = 353,
    CustomParamDefaultParamNameNotAllowed = 354, // When you use names of default param names, like MouthX, FaceAngleZ, MouthSmile, ...
    CustomParamLimitPerPluginExceeded = 355,
    CustomParamLimitTotalExceeded = 356,

    // Errors related to ParameterDeletionRequest
    CustomParamDeletionNameInvalid = 400,
    CustomParamDeletionNotFound = 401, // Trying to delete a parameter that doesn't exist
    CustomParamDeletionCreatedByOtherPlugin = 402, // Trying to delete a parameter created by another plugin
    CustomParamDeletionCannotDeleteDefaultParam = 403,
    
    // Errors related to InjectParameterDataRequest
    InjectDataNoDataProvided = 450,
    InjectDataValueInvalid = 451,
    InjectDataWeightInvalid = 452,
    InjectDataParamNameNotFound = 453, // Trying to send data for parameter that doesn't exist
    InjectDataParamControlledByOtherPlugin = 454, // Only one plugin can send data for a parameter at a time
    InjectDataModeUnknown = 455, // Only "add" and "set" can be used. If no mode is provided, "set" will be used.
    
    // Errors related to ParameterValueRequest
    ParameterValueRequestParameterNotFound = 500,

    // Errors related to NDIConfigRequest
    NDIConfigCooldownNotOver = 550,
    NDIConfigResolutionInvalid = 551,

    // Errors related to ExpressionStateRequest
    ExpressionStateRequestInvalidFilename = 600,
    ExpressionStateRequestFileNotFound = 601,

    // Errors related to ExpressionStateRequest
    ExpressionActivationRequestInvalidFilename = 650,
    ExpressionActivationRequestFileNotFound = 651,
    ExpressionActivationRequestNoModelLoaded = 652,
    
    // Errors related to SetCurrentModelPhysicsRequest
    SetCurrentModelPhysicsRequestNoModelLoaded = 700,
    SetCurrentModelPhysicsRequestModelHasNoPhysics = 701,
    SetCurrentModelPhysicsRequestPhysicsControlledByOtherPlugin = 702, 
    SetCurrentModelPhysicsRequestNoOverridesProvided = 703,
    SetCurrentModelPhysicsRequestPhysicsGroupIDNotFound = 704,
    SetCurrentModelPhysicsRequestNoOverrideValueProvided = 705,
    SetCurrentModelPhysicsRequestDuplicatePhysicsGroupID = 706,
    
    // Errors related to ItemLoadRequest
    ItemFileNameMissing = 750,
    ItemFileNameNotFound = 751,
    ItemLoadLoadCooldownNotOver = 752, // Not used anymore. The cooldown for loading items has been removed.
    CannotCurrentlyLoadItem = 753, // This is usually because the user has menus open that prevent items from being loaded.
    CannotLoadItemSceneFull = 754,
    ItemOrderInvalid = 755,
    ItemOrderAlreadyTaken = 756,
    ItemLoadValuesInvalid = 757, // Invalid values for fields like size, position, ...

    // Errors related to ItemUnloadRequest
    CannotCurrentlyUnloadItem = 800,  // This is usually because the user has menus open that prevent items from being unloaded.

    // Errors related to ItemAnimationControlRequest
    ItemAnimationControlInstanceIDNotFound = 850,
    ItemAnimationControlUnsupportedItemType = 851, // Returned when trying to use this request for Live2D items.
    ItemAnimationControlAutoStopFramesInvalid = 852, // Auto-stop frames indices have to be between 0 and the last frame index of the animated item.
    ItemAnimationControlTooManyAutoStopFrames = 853, // Maximum allowed number per item is 1024.
    ItemAnimationControlSimpleImageDoesNotSupportAnim = 854, // You can set stuff like transparency and brightness for normal PNG/JPG items, but nothing animation-related.

    // Errors related to ItemMoveRequest
    ItemMoveRequestInstanceIDNotFound = 900,
    ItemMoveRequestInvalidFadeMode = 901,
    ItemMoveRequestItemOrderTakenOrInvalid = 902,
    ItemMoveRequestCannotCurrentlyChangeOrder = 903, // Cannot change order when any windows are open.
    
    // Errors related to EventSubscriptionRequest
    EventSubscriptionRequestEventTypeUnknown = 950,
    
    // -------------- EVENT CONFIG ERRORS --------------
    
    EVENT_OFFSET = 100000,

    // Event subscription errors for TestEvent
    Event_TestEvent_TestMessageTooLong = EVENT_OFFSET + 0,

    // Event subscription errors for ModelLoadedEvent
    Event_ModelLoadedEvent_ModelIDInvalid = EVENT_OFFSET + 50
}
