using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Cosmos;
using AzureBackendApp.Services;
using AzureBackendApp.Models;

namespace AzureBackendApp.Helpers
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton((s) =>
            {
                var connectionString = Environment.GetEnvironmentVariable("CosmosDbConnectionString");
                return new CosmosClient(connectionString);
            });

            services.AddSingleton<ICrudService<TodoItem>, CosmosDbCrudService>();

            return services;
        }
    }
}
