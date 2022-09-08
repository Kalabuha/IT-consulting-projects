using Microsoft.Extensions.DependencyInjection;
using ServiceInterfaces;

namespace AppearanceDataServices.Extensions
{
    public static class RegisterAppearanceDataServicesExtensions
    {
        public static IServiceCollection RegisterAppearanceDataServices(this IServiceCollection services)
        {
            services.AddScoped<IHeaderService, MainPageHeaderDataService>();
            services.AddScoped<IMainPageService, MainPageElementsDataService>();
            services.AddScoped<IContactService, ContactDataService>();

            return services;
        }
    }
}
