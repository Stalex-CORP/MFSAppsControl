using Microsoft.Extensions.Hosting;
using Wpf.Ui;
using MFSAppsControl.Views.Windows;

namespace MFSAppsControl.Services
{
    public class ApplicationHostService(IServiceProvider serviceProvider) : IHostedService
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;
        private INavigationWindow? _navigationWindow;
        private readonly ILoggerService<ApplicationHostService> logger = App.GetRequiredService<ILoggerService<ApplicationHostService>>();

        /// <summary>
        /// Triggered when the application host is ready to start the service.
        /// </summary>
        /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await HandleActivationAsync();
        }

        /// <summary>
        /// Triggered when the application host is performing a graceful shutdown.
        /// </summary>
        /// <param name="cancellationToken">Indicates that the shutdown process should no longer be graceful.</param>
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// Creates main window during activation.
        /// </summary>
        private async Task HandleActivationAsync()
        {
            if (!Application.Current.Windows.OfType<MainWindow>().Any())
            {
                _navigationWindow = (
                    _serviceProvider.GetService(typeof(INavigationWindow)) as INavigationWindow
                )!;
                _navigationWindow!.ShowWindow();
                logger.Info("Main window created and displayed.");

                _navigationWindow.Navigate(typeof(Views.Pages.ConfigAppsPage));
                _serviceProvider.GetService(typeof(MFSEventWatcher));
                logger.Info("Navigation to ConfigAppsPage completed.");
            }

            await Task.CompletedTask;
        }
    }
}
