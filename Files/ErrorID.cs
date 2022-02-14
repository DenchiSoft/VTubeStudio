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
    HotkeyUnknownExecutionFailure = 206,
    
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
    SetCurrentModelPhysicsRequestDuplicatePhysicsGroupID = 706
}
