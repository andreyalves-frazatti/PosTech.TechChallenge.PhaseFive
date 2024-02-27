using TechChallenge.Application.Gateways;
using TechChallenge.Domain.Entities.Customers;
using TechChallenge.Infrastructure.Repositories;

namespace TechChallenge.Infrastructure.Gateways;

public class CustomerGateway
    (
        ICustomerRepository customerRepository
    ) : ICustomerGateway
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public Task AddAsync(Customer customer, CancellationToken cancellationToken)
        => _customerRepository.InsertAsync(customer, cancellationToken);

    public Task<Customer?> GetByIdAsync(CustomerId customerId, CancellationToken cancellationToken)
        => _customerRepository.FindOneAsync(customerId, cancellationToken);

    public Task UpdateAsync(Customer customer, CancellationToken cancellationToken)
        => _customerRepository.UpdateAsync(customer, cancellationToken);
}
