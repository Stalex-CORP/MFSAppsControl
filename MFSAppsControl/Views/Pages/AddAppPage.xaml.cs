using MFSAppsControl.Services;
using MFSAppsControl.ViewModels.Pages;
using System.ComponentModel;
using Wpf.Ui.Abstractions.Controls;

namespace MFSAppsControl.Views.Pages
{
    public partial class AddAppPage : INavigableView<AddAppViewModel>
    {
        public AddAppViewModel ViewModel { get; }
        private readonly ConfigAppsViewModel _appsConfigViewModel;
        private readonly ILoggerService<AddAppPage> logger;


        /// <summary>
        /// Initializes a new instance of the <see cref="AddAppPage"/> class.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="appsConfigViewModel"></param>
        public AddAppPage(
            AddAppViewModel viewModel,
            ConfigAppsViewModel appsConfigViewModel,
            ILoggerService<AddAppPage> logger
        )
        {
            this.logger = logger;
            _appsConfigViewModel = appsConfigViewModel;
            ViewModel = viewModel;
            DataContext = this;
            InitializeComponent();
            logger.Info("AddAppPage initialized.");

            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            ViewModel.BackOnAppAdded += BackOnAppAdded;
            logger.Info("AddAppPage ViewModel initialized and event handlers attached.");
        }

        /// <summary>
        /// Navigates back to the apps config view.
        /// </summary>
        private void Back(object? sender, RoutedEventArgs? e)
        {
            var loggerAppsPage = App.GetRequiredService<ILoggerService<ConfigAppsPage>>();
            var watcher = App.GetRequiredService<MFSEventWatcher>();
            NavigationService.Navigate(new ConfigAppsPage(_appsConfigViewModel, loggerAppsPage, watcher));
            logger.Info("Navigated back to ConfigAppsPage from AddAppPage.");
        }


        /// <summary>
        /// Watch for changes in the ViewModel properties.
        /// </summary>
        private void ViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewModel.SelectedApp) && ViewModel.SelectedApp != null)
            {
                logger.Info("Selected app changed");
                // Scroll automatiquement sur l'élément sélectionné
                AppsListView.Dispatcher.Invoke(() =>
                {
                    AppsListView.ScrollIntoView(ViewModel.SelectedApp);
                    logger.Info($"Scrolled into view");
                });
            }
        }


        /// <summary>
        /// Navigates back to the apps config view when an app is added.
        /// </summary>
        private void BackOnAppAdded()
        {
            Back(null, null);
            logger.Info("App added, navigating back to ConfigAppsPage.");
        }
    }
}
