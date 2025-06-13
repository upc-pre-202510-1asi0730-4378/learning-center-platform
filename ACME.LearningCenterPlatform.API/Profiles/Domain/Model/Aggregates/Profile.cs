using ACME.LearningCenterPlatform.API.Profiles.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Profiles.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Profiles.Domain.Model.Aggregates;

public partial class Profile
{
    public int Id { get; }
    public PersonName Name { get; private set; }
    public EmailAddress Email { get; private set; }
    public StreetAddress Address { get; private set; }

    public string FullName => Name.FullName;
    public string EMailAddress => Email.Address;
    public string StreetAddress => Address.FullAddress;

    public Profile()
    {
        Name = new PersonName();
        Email = new EmailAddress();
        Address = new StreetAddress();
    }
    
    public Profile(string firstName, string lastName, string emailAddress, 
                   string street, string number, string city, string postalCode, string country)
    {
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(emailAddress);
        Address = new StreetAddress(street, number, city, postalCode, country);
    }

    public Profile(CreateProfileCommand command)
        : this(command.FirstName, command.LastName, command.Email,
            command.Street, command.Number, command.City, command.PostalCode, command.Country) { }
    
}