namespace ACME.LearningCenterPlatform.API.Profiles.Interfaces.REST.Resources;

/// <summary>
/// Profile resource for REST API 
/// </summary>
/// <param name="Id">
/// The unique identifier of the profile
/// </param>
/// <param name="FullName">
/// The full name of the profile
/// </param>
/// <param name="Email">
/// The email address of the profile
/// </param>
/// <param name="StreetAddress">
/// The street address of the profile
/// </param>
public record ProfileResource(int Id, string FullName, string Email, string StreetAddress);