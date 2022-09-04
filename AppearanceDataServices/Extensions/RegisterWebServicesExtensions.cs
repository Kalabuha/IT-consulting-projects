using Microsoft.Extensions.DependencyInjection;
using ServiceInterfaces;

namespace AppearanceDataServices.Extensions
{
    public static class RegisterAppearanceDataServicesExtensions
    {
        public static IServiceCollection RegisterAppearanceDataServices(this IServiceCollection services)
        {
            services.AddScoped<IHeaderService, HeaderWebService>();
            services.AddScoped<IMainPageService, MainPageWebService>();
            services.AddScoped<IContactService, ContactWebService>();

            return services;
        }
    }
}
