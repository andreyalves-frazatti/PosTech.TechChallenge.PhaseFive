namespace TechChallenge.Domain.ValueObjects;

public record Address : IValueObject
{
    public Address(string street, string neighborhood, string number, string city, string zipCode, string country)
    {
        Street = street;
        Neighborhood = neighborhood;
        Number = number;
        City = city;
        ZipCode = zipCode;
        Country = country;
    }

    public string Street { get; private set; }

    public string Neighborhood { get; private set; }

    public string Number { get; private set; }

    public string City { get; private set; }

    public string ZipCode { get; private set; }

    public string Country { get; private set; }

    public void Anonymize()
    {
        Street = Guid.NewGuid().ToString();
        Number = Guid.NewGuid().ToString();
    }
}
