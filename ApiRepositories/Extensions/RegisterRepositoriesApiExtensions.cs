using Microsoft.Extensions.DependencyInjection;

namespace ApiRepositories.Extensions
{
    public static class RegisterRepositoriesApiExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services, string hostApi)
        {
            services
                .AddHttpClient("Api", client => client.BaseAddress = new Uri(hostApi))
                .AddTypedClient<ProjectRepositoryApi>();

            return services;
        }
    }
}
