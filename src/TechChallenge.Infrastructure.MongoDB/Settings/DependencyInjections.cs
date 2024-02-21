using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using TechChallenge.Infrastructure.MongoDB.Repositories;
using TechChallenge.Infrastructure.MongoDB.Services;
using TechChallenge.Infrastructure.Repositories;

namespace TechChallenge.Infrastructure.MongoDB.Settings;

public static class DependencyInjections
{
    public static IServiceCollection AddMongoRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MongoDB")!;

        var dataSecuritySettings = configuration
            .GetSection(nameof(DataSecuritySettings))
            .Get<DataSecuritySettings>();

        CustomClassMappings.RegisterCustomClassMappings(new DataSecurityService(dataSecuritySettings!));

        services.AddSingleton<IMongoClient>(new MongoClient(connectionString));
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }
}
