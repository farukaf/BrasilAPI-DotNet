using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BrasilAPI.Test")]
 
namespace SDKBrasilAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBrasilApi(this IServiceCollection services)
        {
            services.AddSingleton<IBrasilAPI, BrasilAPI>();

            return services;
        }
    }
}
