namespace ACME.LearningCenterPlatform.API.Profiles.Interfaces.REST.Resources;

/// <summary>
/// Resource for creating a new profile 
/// </summary>
/// <param name="FirstName">
/// The first name of the profile
/// </param>
/// <param name="LastName">
/// The last name of the profile
/// </param>
/// <param name="Email">
///  The email of the profile
/// </param>
/// <param name="Street">
/// The street of the profile
/// </param>
/// <param name="Number">
/// The number of the profile
/// </param>
/// <param name="City">
/// The city of the profile
/// </param>
/// <param name="PostalCode">
/// The postal code of the profile
/// </param>
/// <param name="Country">
/// The country of the profile
/// </param>
public record CreateProfileResource(
    string FirstName, 
    string LastName, 
    string Email, 
    string Street, 
    string Number,
    string City, 
    string PostalCode, 
    string Country);