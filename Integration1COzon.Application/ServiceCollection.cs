using Integration1COzon.Application.Abstractions;
using Integration1COzon.Application.Handler;
using Microsoft.Extensions.DependencyInjection;

namespace Integration1COzon.Application
{
    public static class ServiceCollection
    {
        public static void AddInfrastructureHandler(this IServiceCollection services)
        {
            services.AddSingleton<IIntegrationHandler, IntegrationHandler>();
        }
    }
}
