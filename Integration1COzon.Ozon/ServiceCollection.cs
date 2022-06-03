using Integration1COzon.Application.Abstractions.Ozon;
using Microsoft.Extensions.DependencyInjection;

namespace Integration1COzon.Ozon
{
    public static class ServiceCollection
    {
        public static void AddInfrastructureOzon(this IServiceCollection services)
        {
            services.AddSingleton<IOzonHandlerFactory, OzonHandlerFactory>();
        }
    }
}
