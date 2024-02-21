using MediatR;
using TechChallenge.Domain.Entities.Customers;

namespace TechChallenge.Application.Queries.Customers.GetCustomer;

public record GetCustomerQueryRequest(CustomerId CustomerId)
    : IRequest<GetCustomerQueryResponse?>;
