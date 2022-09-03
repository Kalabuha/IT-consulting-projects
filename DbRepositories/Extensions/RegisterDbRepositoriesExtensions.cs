using Microsoft.Extensions.DependencyInjection;
using RepositoryInterfaces;

namespace DbRepositories.Extensions
{
    public static class RegisterDbRepositoriesExtensions
    {
        public static IServiceCollection RegisterDbRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

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
