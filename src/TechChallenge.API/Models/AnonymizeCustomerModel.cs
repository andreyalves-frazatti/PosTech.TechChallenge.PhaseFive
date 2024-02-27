using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TechChallenge.Application.Commands.Customers.AnonymizeCustomer;

namespace TechChallenge.API.Models;

public class AnonymizeCustomerModel
{
    [FromQuery]
    [Required(AllowEmptyStrings = false)]
    public required Guid CustomerId { get; init; }

    public AnonymizeCustomerCommandRequest MapToCommand()
    {
        return new(new(CustomerId));
    }
}
