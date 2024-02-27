using TechChallenge.Domain.ValueObjects;

namespace TechChallenge.Domain.Entities.Customers;

public class Customer(string name, Address address) : IEntity
{
    public Customer(CustomerId customerId, string name, Address address)
        : this(name, address)
    {
        CustomerId = customerId;
        Name = name;
    }

    public CustomerId CustomerId { get; init; }
        = new CustomerId(Guid.NewGuid());

    public string Name { get; private set; }
        = name;

    public Address Address { get; private set; }
        = address;

    public void Anonymize()
    {
        Name = Guid.NewGuid().ToString();
        Address.Anonymize();
    }
}