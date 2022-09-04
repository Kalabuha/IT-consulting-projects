using Microsoft.Extensions.DependencyInjection;
using ServiceInterfaces;

namespace WebServices.Extensions
{
    public static class RegisterWebServicesExtensions
    {
        public static IServiceCollection RegisterWebServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
