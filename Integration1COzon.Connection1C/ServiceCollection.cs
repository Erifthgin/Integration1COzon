using Integration1COzon.Application.Abstractions.Connection1C;
using Microsoft.Extensions.DependencyInjection;

namespace Integration1COzon.Connection1C
{
    public static class ServiceCollection
    {
        public static void AddInfrastructureConnection1C(this IServiceCollection services)
        {
            services.AddSingleton<IConnection1C, Connection1C>();
        }
    }
}
