using TechChallenge.Domain.Entities.Customers;

namespace TechChallenge.Application.Gateways;

public interface ICustomerGateway
{
    Task AddAsync(Customer customer, CancellationToken cancellationToken);

    Task<Customer?> GetByIdAsync(CustomerId customerId, CancellationToken cancellationToken);

    Task UpdateAsync(Customer customer, CancellationToken cancellationToken);
}
