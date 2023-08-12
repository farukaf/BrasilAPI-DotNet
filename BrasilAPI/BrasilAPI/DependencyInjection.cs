using Microsoft.Extensions.DependencyInjection; 

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
