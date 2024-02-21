using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TechChallenge.Application.Queries.Customers.GetCustomer;
namespace TechChallenge.API.Models;
public record GetCustomerModel
{
    [FromQuery]
    [Required(AllowEmptyStrings = false)]
    public required Guid CustomerId { get; init; }

    public GetCustomerQueryRequest MapToQuery()
    {
        return new(new(CustomerId));
    }
}
