using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Windows;
using System.Runtime.CompilerServices;
using WpfAppForEmployees.ViewModels;
using WpfAppForEmployees.ViewModels.TabViewModels;
using ApiRepositories.Extensions;
using ContentDataServices.Extensions;
using WebAppDataApi.Client;

namespace WpfAppForEmployees
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool IsDesignMode { get; private set; } = true;
        public static string? CurrentDirectory => IsDesignMode ? Path.GetDirectoryName(GetSourceCodePath()) : Environment.CurrentDirectory;

        private static IHost? _host;
        public static IHost Host => _host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        protected override async void OnStartup(StartupEventArgs e)
        {
            IsDesignMode = false;
            var host = Host;
            base.OnStartup(e);

            await host.StartAsync().ConfigureAwait(false);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            var host = Host;
            await host.StopAsync().ConfigureAwait(false);
            host.Dispose();
            _host = null;
        }

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            IConfigurationSection hostUrlSection = host.Configuration.GetSection("Api");

            //ViewModels
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<ApplicationsTabViewModel>();
            services.AddSingleton<ProjectsTabViewModel>();
            services.AddSingleton<BlogsTabViewModel>();
            services.AddSingleton<ServicesTabViewModel>();

            //Repositories
            services.RegisterApiRepositories(hostUrlSection.Value);

            //Services
            services.RegisterContentDataServices();
            services.Configure<ApiOptions>(hostUrlSection);
            services.AddApiClients();
        }

        private static string GetSourceCodePath([CallerFilePath] string path = null!) => path;
    }
}
