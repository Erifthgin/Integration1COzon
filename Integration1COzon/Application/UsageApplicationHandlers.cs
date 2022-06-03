using Integration1COzon.Application.Abstractions;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Threading;


namespace Integration1COzon.Application
{
    public static class UsageApplicationHandlers
    {
        /// <summary>
        /// Запуск хендлера с интеграцией
        /// </summary>
        /// <param name="application"></param>
        /// <param name="handle"></param>
        public static void UseIntegration(this IApplicationBuilder application, Action<IIntegrationHandler> handle)
        {
            Thread thread = new Thread(() =>
            {
                var service = application.ApplicationServices.GetRequiredService<IIntegrationHandler>();
                handle.Invoke(service);
            });
            thread.Start();
        }
    }
}
