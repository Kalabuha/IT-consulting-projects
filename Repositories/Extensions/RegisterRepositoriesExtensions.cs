using Microsoft.Extensions.DependencyInjection;
using Repositories.Interfaces;

namespace Repositories.Extensions
{
    public static class RegisterRepositoriesExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IHeaderMenuSetRepository, HeaderMenuSetRepository>();
            services.AddScoped<IHeaderSloganRepository, HeaderSloganRepository>();

            services.AddScoped<IMainPagePresetRepository, MainPagePresetRepository>();
            services.AddScoped<IMainPageActionRepository, MainPageActionRepository>();
            services.AddScoped<IMainPageButtonRepository, MainPageButtonRepository>();
            services.AddScoped<IMainPageImageRepository, MainPageImageRepository>();
            services.AddScoped<IMainPagePhraseRepository, MainPagePhraseRepository>();
            services.AddScoped<IMainPageTextRepository, MainPageTextRepository>();

            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();

            return services;
        }
    }
}
