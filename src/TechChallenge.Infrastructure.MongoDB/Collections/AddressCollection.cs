using MongoDB.Bson.Serialization.Attributes;
using TechChallenge.Domain.ValueObjects;

namespace TechChallenge.Infrastructure.MongoDB.Mappings;

[BsonIgnoreExtraElements]
public record AddressCollection
{
    public required string Street { get; set; }
    public required string Neighborhood { get; set; }
    public required string Number { get; set; }
    public required string City { get; set; }
    public required string ZipCode { get; set; }
    public required string Country { get; set; }

    public Address MapToEntity()
    {
        return new(Street, Neighborhood, Number, City, ZipCode, Country);
    }

    public static AddressCollection MapToCollection(Address address)
    {
        return new()
        {
            Street = address.Street!,
            Neighborhood = address.Neighborhood!,
            Number = address.Number!,
            City = address.City!,
            ZipCode = address.ZipCode!,
            Country = address.Country!
        };
    }
}