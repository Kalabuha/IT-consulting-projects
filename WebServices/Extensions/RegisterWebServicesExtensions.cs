using Microsoft.Extensions.DependencyInjection;
using ServiceInterfaces;

namespace WebServices.Extensions
{
    public static class RegisterWebServicesExtensions
    {
        public static IServiceCollection RegisterWebServices(this IServiceCollection services)
        {
            services.AddScoped<IHeaderService, HeaderWebService>();
            services.AddScoped<IMainPageService, MainPageWebService>();

            services.AddScoped<IApplicationService, ApplicationWebService>();
            services.AddScoped<IProjectService, ProjectWebService>();
            services.AddScoped<IServiceService, ServiceWebService>();
            services.AddScoped<IBlogService, BlogWebService>();
            services.AddScoped<IContactService, ContactWebService>();

            return services;
        }
    }
}
