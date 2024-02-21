using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using TechChallenge.Application.Gateways;

namespace TechChallenge.Application.Commands.Customers.CreateCustomer;

public class CreateCustomerCommandHandler
    (
        IValidator<CreateCustomerCommandRequest> validator,
        ILogger<CreateCustomerCommandHandler> logger,
        ICustomerGateway customerGateway
    ) : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
{
    private readonly IValidator<CreateCustomerCommandRequest> _validator = validator;
    private readonly ILogger<CreateCustomerCommandHandler> _logger = logger;
    private readonly ICustomerGateway _customerGateway = customerGateway;

    public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
    {
        var validation = _validator.Validate(request);

        if (!validation.IsValid)
        {
            _logger.LogError("Invalid customer!");
            return CreateCustomerCommandResponse.WithError(validation);
        }

        var customer = request.MapToCustomer();

        await _customerGateway.AddAsync(customer, cancellationToken);

        return new CreateCustomerCommandResponse(customer.CustomerId);
    }
}
