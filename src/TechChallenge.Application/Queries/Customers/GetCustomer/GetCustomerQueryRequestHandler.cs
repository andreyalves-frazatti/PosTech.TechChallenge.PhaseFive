using MediatR;
using TechChallenge.Application.Gateways;

namespace TechChallenge.Application.Queries.Customers.GetCustomer;

public class GetCustomerQueryRequestHandler
    (
        ICustomerGateway customerGateway
    )
    : IRequestHandler<GetCustomerQueryRequest, GetCustomerQueryResponse?>
{
    private readonly ICustomerGateway _customerGateway = customerGateway;
    public async Task<GetCustomerQueryResponse?> Handle(GetCustomerQueryRequest request, CancellationToken cancellationToken)
    {
        var customer = await _customerGateway.GetByIdAsync(request.CustomerId, cancellationToken);

        return customer is not null
            ? new GetCustomerQueryResponse(customer)
            : default;
    }
}
