using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppWebApli.Client
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
