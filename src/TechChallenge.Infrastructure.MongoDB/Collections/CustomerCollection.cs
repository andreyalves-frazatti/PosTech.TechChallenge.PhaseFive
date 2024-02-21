using MongoDB.Bson.Serialization.Attributes;
using TechChallenge.Domain.Entities.Customers;
using TechChallenge.Domain.ValueObjects;

namespace TechChallenge.Infrastructure.MongoDB.Mappings;

[BsonIgnoreExtraElements]
public record CustomerCollection
{
    public static readonly string CollectionName = "Customers";

    [BsonId]
    public required Guid CustomerId { get; set; }
    public required string Name { get; set; }
    public required AddressCollection Address { get; set; }

    public Customer MapToEntity()
    {
        Address addressEntity = Address.MapToEntity();

        return new(new CustomerId(CustomerId), Name, addressEntity);
    }

    public static CustomerCollection MapToCollection(Customer customer)
    {
        var addressCollection = AddressCollection.MapToCollection(customer.Address);

        return new()
        {
            CustomerId = customer.CustomerId.Value,
            Name = customer.Name,
            Address = addressCollection
        };
    }
}
