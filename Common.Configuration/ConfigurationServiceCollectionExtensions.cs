using Common.Configuration.NServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;


namespace Common.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class ConfigurationServiceCollectionExtensions
    {
        public static IServiceCollection AddAppConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<NServiceBusConfiguration>(config.GetSection(nameof(NServiceBusConfiguration)));
            return services;
        }
    }
}
