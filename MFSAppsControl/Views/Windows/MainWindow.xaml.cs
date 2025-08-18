using MFSAppsControl.Services;
using MFSAppsControl.ViewModels.Windows;
using System.Diagnostics;
using System.IO;
using Wpf.Ui;
using Wpf.Ui.Abstractions;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace MFSAppsControl.Views.Windows
{
    public partial class MainWindow : INavigationWindow
    {
        public MainWindowViewModel ViewModel { get; }
        private readonly ILoggerService<MainWindow> logger;
        private readonly NotificationService notificationService;
        private bool minimizedNotificationShown = false;


        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        /// <param name="navigationService"> The navigation service to be used for navigating between pages.</param>
        /// <param name="navigationViewPageProvider"> The provider for navigation view pages.</param>
        /// <param name="snackbarService"> The service for displaying snackbars.</param>
        /// <param name="viewModel"> The view model for the main window.</param>
        public MainWindow(
            MainWindowViewModel viewModel,
            INavigationService navigationService,
            INavigationViewPageProvider navigationViewPageProvider,
            ISnackbarService snackbarService,
            ILoggerService<MainWindow> logger,
            NotificationService notificationService
        )
        {
            SystemThemeWatcher.Watch(this);
            this.logger = logger;
            this.notificationService = notificationService;

            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
            _ = ViewModel.InitializeAsync();
            logger.Info("MainWindow initialized.");

            snackbarService.SetSnackbarPresenter(SnackbarPresenter);
            navigationService.SetNavigationControl(RootNavigation);
            SetPageService(navigationViewPageProvider);
            logger.Info("MainWindow ViewModel and services initialized.");
        }


        /// <summary>
        /// Hides the main window when it is minimized to the system tray and shows a notification first time it happens.
        /// </summary>
        /// <param name="sender"> The sender of the event.</param>
        /// <param name="e"> The event arguments for the closing event.</param>
        private void OnWindowStateChanged(object? sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                logger.Info("Window minimized, hiding to tray.");
                if (!minimizedNotificationShown)
                {
                    minimizedNotificationShown = true;
                    logger.Info("Showing minimize to tray notification.");
                    Dispatcher.InvokeAsync(async () =>
                    {
                        await Task.Delay(200);
                        notificationService.ShowMinimizeToTrayNotification();
                    });
                }
                ShowInTaskbar = false;
                Hide();
            }
        }


        /// <summary>
        /// Opens the main window from the system tray.
        /// </summary>
        /// <param name="sender"> The sender of the event.</param>
        /// <param name="e"> The event arguments.</param>
        private void OpenFromTray(object sender, RoutedEventArgs e)
        {
            logger.Info("Opening window from tray.");
            ShowInTaskbar = true;
            Show();
            WindowState = WindowState.Normal;
            Activate();
            logger.Info("Window displayed.");
        }


        /// <summary>
        /// Opens the github issues page when the help option is selected from the system tray menu.
        /// </summary>
        /// <param name="sender"> The sender of the event.</param>
        /// <param name="e"> The event arguments for the click event.</param>
        private void OnTrayMenuHelpClick(object sender, RoutedEventArgs e)
        {
            logger.Info("Tray menu help clicked, open github issues page.");
            // Open the GitHub issues page in the default web browser.
            var issuesUrl = "https://github.com/Stalex-CORP/MFSAppsControl/issues";
            try
            {
                Process.Start(new ProcessStartInfo(issuesUrl) { UseShellExecute = true });
                logger.Info($"Opened issues page: {issuesUrl}");
            }
            catch (Exception ex)
            {
                logger.Error($"Failed to open issues page !", ex);
            }
        }


        private void OnTrayMenuLogClick(object sender, RoutedEventArgs e)
        {
            logger.Info("Tray menu log clicked, opening log file.");
            // Open the log file in the default text editor.
            var logFilePath = logger.GetLogFilePath();
            if (File.Exists(logFilePath))
            {
                try
                {
                    Process.Start(new ProcessStartInfo(logFilePath) { UseShellExecute = true });
                    logger.Info($"Opened log file: {logFilePath}");
                }
                catch (Exception ex)
                {
                    logger.Error($"Failed to open log file !", ex);
                }
            }
            else
            {
                logger.Warn($"Log file does not exist: {logFilePath}");
            }
        }

        /// <summary>
        /// Quits the application when the quit option is selected from the system tray menu.
        /// </summary>
        /// <param name="sender"> The sender of the event.</param>
        /// <param name="e"> The event arguments for the click event.</param>
        private void OnTrayMenuQuitClick(object sender, RoutedEventArgs e)
        {
            logger.Info("Tray menu quit clicked, closing application.");
            OnClosed(null);
        }

        /// <summary>
        /// Opens the latest release page on GitHub when the text block is clicked.
        /// </summary>
        /// <param name="sender"> The sender of the event.</param>
        /// <param name="e"> The event arguments for the click event.</param>
        private void TextBlock_OpenLastRelease(object sender, RoutedEventArgs e)
        {
            logger.Info("TextBlock clicked, opening latest release page on GitHub.");
            var releasesUrl = "https://github.com/Stalex-CORP/MFSAppsControl/releases/latest";
            try
            {
                Process.Start(new ProcessStartInfo(releasesUrl) { UseShellExecute = true });
                logger.Info($"Opened latest release page: {releasesUrl}");
            }
            catch (Exception ex)
            {
                logger.Error("Failed to open the latest release page !", ex);
            }
        }


        /// <summary>
        /// Interface implementation for INavigationWindow.
        /// </summary>
        #region INavigationWindow methods
        public INavigationView GetNavigation() => RootNavigation;

        public bool Navigate(Type pageType) => RootNavigation.Navigate(pageType);

        public void SetPageService(INavigationViewPageProvider navigationViewPageProvider) => RootNavigation.SetPageProviderService(navigationViewPageProvider);

        public void ShowWindow() => Show();

        public void CloseWindow() => Close();

        #endregion INavigationWindow methods


        /// <summary>
        /// Closes the application when the main window is closed.
        /// </summary>
        protected override void OnClosed(EventArgs? e)
        {
            base.OnClosed(e);

            // Make sure that closing this window will begin the process of closing the application.
            Application.Current.Shutdown();
        }


        /// <summary>
        /// Gets the navigation view associated with the current window.
        /// </summary>
        /// <returns>An <see cref="INavigationView"/> instance that provides access to navigation functionality for the window.</returns>
        /// <exception cref="NotImplementedException"></exception>
        INavigationView INavigationWindow.GetNavigation()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Sets the service provider for the current window.
        /// </summary>
        public void SetServiceProvider(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }
    }
}
