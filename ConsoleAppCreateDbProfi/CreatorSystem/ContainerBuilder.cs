using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DbContextProfi;

namespace ConsoleAppCreateDbProfi.CreatorSystem
{
    internal class ContainerBuilder
    {
        internal static IServiceProvider Build(string settingsJson)
        {
            if (string.IsNullOrEmpty(settingsJson) || !File.Exists(settingsJson))
            {
                throw new ApplicationException("Файл с настройками не найден.");
            }

            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                .AddJsonFile(settingsJson)
                .Build();

            string connectionDbString = configuration.GetConnectionString("DataBase");
            if (string.IsNullOrEmpty(connectionDbString))
            {
                throw new ApplicationException("Строка подключения не найдена");
            }

            services.AddDbContext<DbContextProfiСonnector>(options => options.UseSqlServer(connectionDbString));
            services.AddSingleton<CreatorDbProfi>();

            return services.BuildServiceProvider();
        }
    }
}
