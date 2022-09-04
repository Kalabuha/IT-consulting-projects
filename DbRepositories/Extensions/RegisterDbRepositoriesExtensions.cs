using Microsoft.Extensions.DependencyInjection;
using RepositoryInterfaces;

namespace DbRepositories.Extensions
{
    public static class RegisterDbRepositoriesExtensions
    {
        public static IServiceCollection RegisterDbRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserDbRepository>();

            services.AddScoped<IHeaderMenuSetRepository, HeaderMenuSetDbRepository>();
            services.AddScoped<IHeaderSloganRepository, HeaderSloganDbRepository>();

            services.AddScoped<IMainPagePresetRepository, MainPagePresetDbRepository>();
            services.AddScoped<IMainPageActionRepository, MainPageActionDbRepository>();
            services.AddScoped<IMainPageButtonRepository, MainPageButtonDbRepository>();
            services.AddScoped<IMainPageImageRepository, MainPageImageDbRepository>();
            services.AddScoped<IMainPagePhraseRepository, MainPagePhraseDbRepository>();
            services.AddScoped<IMainPageTextRepository, MainPageTextDbRepository>();

            services.AddScoped<IApplicationRepository, ApplicationDbRepository>();
            services.AddScoped<IProjectRepository, ProjectDbRepository>();
            services.AddScoped<IServiceRepository, ServiceDbRepository>();
            services.AddScoped<IBlogRepository, BlogDbRepository>();
            services.AddScoped<IContactRepository, ContactDbRepository>();

            return services;
        }
    }
}
