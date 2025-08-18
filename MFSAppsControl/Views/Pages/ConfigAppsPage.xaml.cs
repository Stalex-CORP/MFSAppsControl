using MFSAppsControl.Services;
using MFSAppsControl.ViewModels.Pages;
using System.Diagnostics;
using Wpf.Ui;
using Wpf.Ui.Abstractions.Controls;

namespace MFSAppsControl.Views.Pages
{
    public partial class ConfigAppsPage : INavigableView<ConfigAppsViewModel>
    {
        public ConfigAppsViewModel ViewModel { get; }
        private readonly ILoggerService<ConfigAppsPage> logger;
        private readonly MFSEventWatcher watcher;


        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigAppsPage"/> class.
        /// </summary>
        public ConfigAppsPage(
            ConfigAppsViewModel configAppsViewModel,
            ILoggerService<ConfigAppsPage> logger,
            MFSEventWatcher watcher
        )
        {
            this.logger = logger;
            this.watcher = watcher;
            ViewModel = configAppsViewModel;
            DataContext = this;
            InitializeComponent();
            _ = ViewModel.InitializeAsync();
            Loaded += OnLoaded;
            logger.Info("ConfigAppsPage initialized.");
        }


        /// <summary>
        /// Initializes the watcher asynchrone and sets the visibility of the datagrid if success, else display the error message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await watcher.InitializeAsync();
                ViewModel.DatagridVisibility = "Visible";
            }
            catch (InvalidOperationException ex)
            {
                ViewModel.ErrorVisibility = "Visible";
                logger.Error("Failed to initialize the watcher.", ex);
            }
            finally
            {
                ViewModel.LoadingVisibility = "Collapsed";
            }
        }


        /// <summary>
        /// Navigates to the Add App page.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        public void NavigateToNewAddPage(object sender, RoutedEventArgs e)
        {
            var loggerNewAppVM = App.GetRequiredService<ILoggerService<AddAppViewModel>>();
            var languageService = App.GetRequiredService<LanguageService>();
            var snackbarService = App.GetRequiredService<ISnackbarService>();
            var loggerNewAppPage = App.GetRequiredService<ILoggerService<AddAppPage>>();
            var addAppViewModel = new AddAppViewModel(ViewModel, loggerNewAppVM, languageService, snackbarService);
            NavigationService.Navigate(new AddAppPage(addAppViewModel, ViewModel, loggerNewAppPage));
            logger.Info("Navigated to Add App page.");
        }


        /// <summary>
        /// Display/Hide buttons to simulate MFS start and stop following the Test Mode switch state.
        private void TestModeSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            SimulationButtons.Visibility = TestModeSwitch.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
        }


        /// <summary>
        /// Simulates the MFS start event when the start button is clicked.
        /// </summary>
        private void SimulateMfsStart_Click(object sender, RoutedEventArgs e)
        {
            watcher.SimulateMfsStarted();
        }


        /// <summary>
        /// Simulates the MFS stop event when the stop button is clicked.
        /// </summary>
        private void SimulateMfsStop_Click(object sender, RoutedEventArgs e)
        {
            watcher.SimulateMfsStopped();
        }


        /// <summary>
        /// Opens the GitHub new issue page for reporting bug.
        /// </summary>
        private void OpenNewIssue_Click(object sender, RoutedEventArgs e)
        {
            var issuesUrl = "https://github.com/Stalex-CORP/MFSAppsControl/issues/new?template=bug-report.yml";
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
    }
}
