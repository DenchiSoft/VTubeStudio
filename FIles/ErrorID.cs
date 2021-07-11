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
    RequestTypeNull = 6,
    RequestTypeUnknown = 7,

    // Errors related to Authentication.
    AuthDenied = 50,
    AuthCurrentlyOngoing = 51,
    AuthPluginNameInvalid = 52,
    AuthDeveloperNameInvalid = 53,
    AuthPluginIconInvalid = 54,
    AuthTokenMissing = 55,

    // Errors related to ModelLoadRequest
    ModelIDMissing = 100,
    ModelIDInvalid = 101,
    ModelIDNotFound = 102,
    ModelLoadCooldownNotOver = 103,
    CannotCurrentlyChangeModel = 104,
}
