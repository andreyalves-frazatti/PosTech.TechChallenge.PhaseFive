using FluentValidation;

namespace TechChallenge.Application.Commands.Customers.CreateCustomer;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommandRequest>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(c => c.Name).Length(5, 200);
        RuleFor(c => c.Street).NotEmpty();
        RuleFor(c => c.Neighborhood).NotEmpty();
        RuleFor(c => c.Number).NotEmpty();
        RuleFor(c => c.City).NotEmpty();
        RuleFor(c => c.ZipCode).NotEmpty();
        RuleFor(c => c.Street).NotEmpty();
    }
}
