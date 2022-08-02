using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;

namespace Services.Extensions
{
    public static class RegisterServicesExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IHeaderService, HeaderService>();
            services.AddScoped<IMainPageService, MainPageService>();

            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IContactService, ContactService>();

            return services;
        }
    }
}
