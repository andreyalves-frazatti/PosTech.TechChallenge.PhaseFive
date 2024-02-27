using TechChallenge.Domain.Entities.Customers;

namespace TechChallenge.Infrastructure.Repositories;

public interface ICustomerRepository
{
    Task InsertAsync(Customer customer, CancellationToken cancellationToken);

    Task<Customer?> FindOneAsync(CustomerId customerId, CancellationToken cancellationToken);

    Task UpdateAsync(Customer customer, CancellationToken cancellationToken);
}
