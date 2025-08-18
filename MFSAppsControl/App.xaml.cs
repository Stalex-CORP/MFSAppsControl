using MFSAppsControl.Services;
using MFSAppsControl.ViewModels.Pages;
using MFSAppsControl.ViewModels.Windows;
using MFSAppsControl.Views.Pages;
using MFSAppsControl.Views.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows.Threading;
using Wpf.Ui;
using Wpf.Ui.DependencyInjection;

namespace MFSAppsControl
{
    public partial class App
    {
        private static readonly IHost _host = Host
            .CreateDefaultBuilder()
            .ConfigureAppConfiguration(c => { _ = c.SetBasePath(AppContext.BaseDirectory); })
            .ConfigureServices((_1, services) =>
            {
                _ = services.AddNavigationViewPageProvider();

                _ = services.AddHostedService<ApplicationHostService>();
                _ = services.AddSingleton<IThemeService, ThemeService>();
                _ = services.AddSingleton<ITaskBarService, TaskBarService>();
                _ = services.AddSingleton<INavigationService, NavigationService>();
                _ = services.AddSingleton<MFSEventWatcher>();
                _ = services.AddSingleton<ISnackbarService, SnackbarService>();
                _ = services.AddSingleton(typeof(ILoggerService<>), typeof(LoggerService<>));
                _ = services.AddSingleton<LanguageService>();
                _ = services.AddSingleton<NotificationService>();
                _ = services.AddSingleton<ConfigurationService>();


                _ = services.AddSingleton<INavigationWindow, MainWindow>();
                _ = services.AddSingleton<MainWindowViewModel>();

                _ = services.AddSingleton<ConfigAppsPage>();
                _ = services.AddSingleton<ConfigAppsViewModel>();
                _ = services.AddSingleton<AddAppPage>();
                _ = services.AddSingleton<AddAppViewModel>();
            }).Build();

        /// <summary>
        /// Gets services.
        /// </summary>
        public static T GetRequiredService<T>()
        where T : class
        {
            return _host.Services.GetRequiredService<T>();
        }

        /// <summary>
        /// Occurs when the application is loading.
        /// </summary>
        private void OnStartup(object sender, StartupEventArgs e)
        {
            _host.Start();
        }

        /// <summary>
        /// Occurs when the application is closing.
        /// </summary>
        private void OnExit(object sender, ExitEventArgs e)
        {
            _host.StopAsync().Wait();

            _host.Dispose();
        }

        /// <summary>
        /// Occurs when an exception is thrown by an application but not handled.
        /// </summary>
        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // For more info see https://docs.microsoft.com/en-us/dotnet/api/system.windows.application.dispatcherunhandledexception?view=windowsdesktop-6.0
        }
    }
}
