namespace ACME.LearningCenterPlatform.API.Profiles.Interfaces.ACL;

/// <summary>
/// Facade for the profiles context 
/// </summary>
public interface IProfilesContextFacade
{
    /// <summary>
    /// Create a profile 
    /// </summary>
    /// <param name="firstName">
    /// First name of the profile
    /// </param>
    /// <param name="lastName">
    /// Last name of the profile
    /// </param>
    /// <param name="email">
    /// Email of the profile
    /// </param>
    /// <param name="street">
    /// Street of the profile
    /// </param>
    /// <param name="number">
    /// Number of the profile
    /// </param>
    /// <param name="city">
    /// City of the profile
    /// </param>
    /// <param name="postalCode">
    /// Postal code of the profile
    /// </param>
    /// <param name="country">
    /// Country of the profile
    /// </param>
    /// <returns>
    /// The id of the created profile if successful, 0 otherwise
    /// </returns>
    Task<int> CreateProfile(string firstName, 
        string lastName, 
        string email, 
        string street, 
        string number,
        string city,
        string postalCode,
        string country);
    
    /// <summary>
    /// Fetch the profile id by email     
    /// </summary>
    /// <param name="email">
    /// Email of the profile to fetch
    /// </param>
    /// <returns>
    /// The id of the profile if found, 0 otherwise
    /// </returns>
    Task<int> FetchProfileIdByEmail(string email);
}