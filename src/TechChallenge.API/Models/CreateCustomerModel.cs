using System.ComponentModel.DataAnnotations;
using TechChallenge.Application.Commands.Customers.CreateCustomer;

namespace TechChallenge.API.Models;

public record CreateCustomerModel
{
    [Required(AllowEmptyStrings = false)]
    public required string Name { get; init; }

    [Required(AllowEmptyStrings = false)]
    public required string Street { get; init; }

    [Required(AllowEmptyStrings = false)]
    public required string Neighborhood { get; init; }

    [Required(AllowEmptyStrings = false)]
    public required string Number { get; init; }

    [Required(AllowEmptyStrings = false)]
    public required string City { get; init; }

    [Required(AllowEmptyStrings = false)]
    public required string ZipCode { get; init; }

    [Required(AllowEmptyStrings = false)]
    public required string Country { get; init; }

    public CreateCustomerCommandRequest MapToCommand()
    {
        return new(Name, Street, Neighborhood, Number, City, ZipCode, Country);
    }
}
