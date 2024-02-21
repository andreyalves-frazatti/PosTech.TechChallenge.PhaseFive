using Microsoft.Extensions.DependencyInjection;
using TechChallenge.Application.Gateways;
using TechChallenge.Infrastructure.Gateways;

namespace TechChallenge.Infrastructure.Settings;

public static class DependencyInjections
{
    public static IServiceCollection AddGateways(this IServiceCollection services)
    {
        services.AddScoped<ICustomerGateway, CustomerGateway>();

        return services;
    }
}
