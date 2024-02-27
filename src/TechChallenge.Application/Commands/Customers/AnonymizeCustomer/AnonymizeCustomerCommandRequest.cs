using MediatR;
using TechChallenge.Domain.Entities.Customers;

namespace TechChallenge.Application.Commands.Customers.AnonymizeCustomer;

public record AnonymizeCustomerCommandRequest(CustomerId CustomerId)
    : IRequest<AnonymizeCustomerCommandResponse>;
