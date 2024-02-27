using MediatR;
using TechChallenge.Application.Gateways;

namespace TechChallenge.Application.Commands.Customers.AnonymizeCustomer;

public class AnonymizeCustomerCommandHandler(ICustomerGateway customerGateway)
        : IRequestHandler<AnonymizeCustomerCommandRequest, AnonymizeCustomerCommandResponse>
{
    private readonly ICustomerGateway _customerGateway = customerGateway;

    public async Task<AnonymizeCustomerCommandResponse> Handle(AnonymizeCustomerCommandRequest request, CancellationToken cancellationToken)
    {
        var response = new AnonymizeCustomerCommandResponse();

        var customer = await _customerGateway.GetByIdAsync(request.CustomerId, cancellationToken);

        if (customer is null)
        {
            response.AddError("Customer not found.");
            return response;
        }

        customer.Anonymize();

        await _customerGateway.UpdateAsync(customer, cancellationToken);

        return response;
    }
}
