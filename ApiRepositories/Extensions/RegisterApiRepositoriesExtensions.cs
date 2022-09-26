using Microsoft.Extensions.DependencyInjection;
using RepositoryInterfaces;

namespace ApiRepositories.Extensions
{
    public static class RegisterApiRepositoriesExtensions
    {
        public static IServiceCollection RegisterApiRepositories(this IServiceCollection services, string hostApi)
        {
            services
                .AddHttpClient("Api", client => client.BaseAddress = new Uri(hostApi))
                .AddTypedClient<IApplicationRepository, ApplicationApiRepository>()
                .AddTypedClient<IRepository, ProjectApiRepository>()
                .AddTypedClient<IServiceRepository, ServiceApiRepository>()
                .AddTypedClient<IBlogRepository, BlogApiRepository>();

            return services;
        }
    }
}
