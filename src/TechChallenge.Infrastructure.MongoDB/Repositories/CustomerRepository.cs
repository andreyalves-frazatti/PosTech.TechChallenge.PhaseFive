using MongoDB.Driver;
using TechChallenge.Domain.Entities.Customers;
using TechChallenge.Infrastructure.MongoDB.Mappings;
using TechChallenge.Infrastructure.Repositories;

namespace TechChallenge.Infrastructure.MongoDB.Repositories;

public class CustomerRepository(IMongoClient mongoClient)
    : ICustomerRepository
{
    private readonly IMongoCollection<CustomerCollection> _customerCollection = mongoClient
            .GetDatabase("TechChallenge")
            .GetCollection<CustomerCollection>(CustomerCollection.CollectionName);

    public async Task<Customer?> FindOneAsync(CustomerId customerId, CancellationToken cancellationToken)
    {
        var filter = Builders<CustomerCollection>
            .Filter
            .Eq(c => c.CustomerId, customerId.Value);

        var customerCollection = await _customerCollection
            .Find(filter)
            .FirstOrDefaultAsync(cancellationToken);

        return customerCollection?.MapToEntity();
    }

    public Task InsertAsync(Customer customer, CancellationToken cancellationToken)
    {
        var customerCollection = CustomerCollection.MapToCollection(customer);

        return _customerCollection.InsertOneAsync(customerCollection, null, cancellationToken);
    }

    public async Task UpdateAsync(Customer customer, CancellationToken cancellationToken)
    {
        var filter = Builders<CustomerCollection>
            .Filter
            .Eq(c => c.CustomerId, customer.CustomerId.Value);

        var customerCollection = CustomerCollection.MapToCollection(customer);

        var update = Builders<CustomerCollection>
            .Update
            .Set(nameof(customer.Name), customerCollection.Name)
            .Set(nameof(customer.Address), customerCollection.Address);

        await _customerCollection.UpdateOneAsync(filter, update, null, cancellationToken);
    }
}
