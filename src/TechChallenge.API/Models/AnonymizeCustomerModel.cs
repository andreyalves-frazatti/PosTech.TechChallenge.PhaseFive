using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TechChallenge.API.Models;

public class AnonymizeCustomerModel
{
    [FromQuery]
    [Required(AllowEmptyStrings = false)]
    public required Guid CustomerId { get; init; }
}
