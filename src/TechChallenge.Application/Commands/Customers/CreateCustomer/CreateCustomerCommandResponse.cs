using FluentValidation.Results;
using TechChallenge.Application.Helpers;
using TechChallenge.Domain.Entities.Customers;

namespace TechChallenge.Application.Commands.Customers.CreateCustomer;

public class CreateCustomerCommandResponse(CustomerId? CustomerId = null)
    : BaseResponse
{
    public CustomerId? CustomerId { get; } = CustomerId;

    public static CreateCustomerCommandResponse WithError(ValidationResult validationResult)
    {
        CreateCustomerCommandResponse response = new();

        response.AddError(validationResult);

        return response;
    }
}
