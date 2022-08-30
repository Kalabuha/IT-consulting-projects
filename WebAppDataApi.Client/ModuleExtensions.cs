using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Refit;

namespace WebAppDataApi.Client
{
    public static class ModuleExtensions
    {
        public static IServiceCollection AddApiClients(this IServiceCollection services)
        {
            services
                .AddRefitClient<IApplicationsApi>()
                .ConfigureHttpClient((provider, client) =>
                {
                    var options = provider.GetRequiredService<IOptions<ApiOptions>>();
                    client.BaseAddress = new Uri(options.Value.Url);
                });

            return services;
        }
    }
}
