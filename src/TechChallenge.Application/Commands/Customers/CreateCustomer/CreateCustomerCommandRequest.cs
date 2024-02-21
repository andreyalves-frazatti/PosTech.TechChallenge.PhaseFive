using MediatR;
using TechChallenge.Domain.Entities.Customers;
using TechChallenge.Domain.ValueObjects;

namespace TechChallenge.Application.Commands.Customers.CreateCustomer;

public record CreateCustomerCommandRequest(
    string Name,
    string Street,
    string Neighborhood,
    string Number,
    string City,
    string ZipCode,
    string Country) : IRequest<CreateCustomerCommandResponse>
{
    public Customer MapToCustomer()
    {
        Address address = new(
            Street,
            Neighborhood,
            Number,
            City,
            ZipCode,
            Country);

        return new Customer(Name, address);
    }
}
