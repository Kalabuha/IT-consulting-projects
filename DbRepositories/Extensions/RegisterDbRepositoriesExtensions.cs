using Microsoft.Extensions.DependencyInjection;
using RepositoryInterfaces;
using DataModels;

namespace DbRepositories.Extensions
{
    public static class RegisterDbRepositoriesExtensions
    {
        public static IServiceCollection RegisterDbRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserDbRepository>();

            services.AddScoped<IRepository<HeaderMenuDataModel>, HeaderMenuDbRepository>();
            services.AddScoped<IRepository<HeaderSloganDataModel>, HeaderSloganDbRepository>();

            services.AddScoped<IRepository<MainPagePresetDataModel>, MainPagePresetDbRepository>();
            services.AddScoped<IRepository<MainPageActionDataModel>, MainPageActionDbRepository>();
            services.AddScoped<IRepository<MainPageButtonDataModel>, MainPageButtonDbRepository>();
            services.AddScoped<IRepository<MainPageImageDataModel>, MainPageImageDbRepository>();
            services.AddScoped<IRepository<MainPagePhraseDataModel>, MainPagePhraseDbRepository>();
            services.AddScoped<IRepository<MainPageTextDataModel>, MainPageTextDbRepository>();

            services.AddScoped<IRepository<ApplicationDataModel>, ApplicationDbRepository>();
            services.AddScoped<IRepository<ProjectDataModel>, ProjectDbRepository>();
            services.AddScoped<IRepository<ServiceDataModel>, ServiceDbRepository>();
            services.AddScoped<IRepository<BlogDataModel>, BlogDbRepository>();
            services.AddScoped<IRepository<ContactDataModel>, ContactDbRepository>();

            return services;
        }
    }
}
