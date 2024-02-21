using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TechChallenge.Application.Commands.Customers.CreateCustomer;

namespace TechChallenge.Application.Settings;

public static class DependencyInjections
{
    public static IServiceCollection AddCommands(this IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateCustomerCommandRequest>, CreateCustomerCommandValidator>();

        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(DependencyInjections).Assembly));

        return services;
    }
}
