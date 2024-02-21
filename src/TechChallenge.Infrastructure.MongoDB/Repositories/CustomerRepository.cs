using MongoDB.Driver;
using TechChallenge.Domain.Entities.Customers;
using TechChallenge.Infrastructure.MongoDB.Mappings;
using TechChallenge.Infrastructure.Repositories;

namespace TechChallenge.Infrastructure.MongoDB.Repositories;

public class CustomerRepository(IMongoClient mongoClient) : ICustomerRepository
{
    private readonly IMongoCollection<CustomerCollection> _customerCollection = mongoClient
            .GetDatabase("TechChallenge")
            .GetCollection<CustomerCollection>(CustomerCollection.CollectionName);

    public async Task<Customer?> FindOneAsync(CustomerId customerId, CancellationToken cancellationToken)
    {
        var filter = Builders<CustomerCollection>.Filter.Eq(c => c.CustomerId, customerId.Value);

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
}
