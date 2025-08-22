using MFSAppsControl.Converters;
using MFSAppsControl.Models;
using MFSAppsControl.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace MFSAppsControl.ViewModels.Pages
{
    public partial class ConfigAppsViewModel : ObservableObject
    {
        private readonly ILoggerService<ConfigAppsViewModel> logger;
        private readonly ISnackbarService snackbarService;
        private readonly LanguageService languageService;
        private readonly ConfigurationService configurationService;        

        [ObservableProperty]
        public ObservableCollection<ApplicationModel> _apps = [];

        [ObservableProperty]
        private ApplicationModel? _selectedApp;

        [ObservableProperty]
        private string? errorVisibility = "Hidden";

        [ObservableProperty]
        private string loadingVisibility = "Visible";

        [ObservableProperty]
        private string datagridVisibility = "Hidden";

        [ObservableProperty]
        private string loadingTextTemplate;

        [ObservableProperty]
        private string? loadingText;

        [ObservableProperty]
        private int retrySeconds;

        [ObservableProperty]
        private int attempt;

        [ObservableProperty]
        private int maxRetries;

        [ObservableProperty]
        private string managementEventWatcherErrorText;

        [ObservableProperty]
        private string openIssueButtonText;

        [ObservableProperty]
        private string toggleSwitchTestModeText;

        [ObservableProperty]
        private string notificationLoadConfigErrorText;

        [ObservableProperty]
        private string notificationAddAppSuccessText;

        [ObservableProperty]
        private string notificationAddAppErrorText;

        [ObservableProperty]
        private string notificationRemoveAppSuccessText;

        [ObservableProperty]
        private string notificationRemoveAppErrorText;

        [ObservableProperty]
        private string notificationUpdateAppErrorText;


        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigAppsViewModel"/> class.
        /// </summary>
        /// <remarks>This constructor initializes the collection of added applications and subscribes to
        /// property and collection change events to keep the view model state in sync. Upon instantiation, it loads the
        /// current list of added applications and ensures they are sorted.</remarks>
        public ConfigAppsViewModel(
            ISnackbarService snackbarService,
            ILoggerService<ConfigAppsViewModel> logger,
            LanguageService languageService,
            ConfigurationService configurationService
        )
        {
            this.logger = logger;
            this.snackbarService = snackbarService;
            this.languageService = languageService;
            this.configurationService = configurationService;

            LoadingTextTemplate = languageService.GetMessage("Loading_ManagementEventWatcher");
            ManagementEventWatcherErrorText = languageService.GetMessage("Loading_ManagementEventWatcherError");
            OpenIssueButtonText = languageService.GetMessage("Button_OpenIssue");
            ToggleSwitchTestModeText = languageService.GetMessage("Switch_TestMode");
            NotificationLoadConfigErrorText = languageService.GetMessage("Notification_LoadConfigError");
            NotificationAddAppSuccessText = languageService.GetMessage("Notification_AddAppSuccess");
            NotificationAddAppErrorText = languageService.GetMessage("Notification_AddAppError");
            NotificationRemoveAppSuccessText = languageService.GetMessage("Notification_RemoveAppSuccess");
            NotificationRemoveAppErrorText = languageService.GetMessage("Notification_RemoveAppError");
            NotificationUpdateAppErrorText = languageService.GetMessage("Notification_UpdateAppError");
            logger.Info("Initializing ConfigAppsViewModel...");
        }


        /// <summary>
        /// Initializes the ConfigAppsViewModel by loading the applications asynchrone from the configuration file and setting up event handlers.
        /// </summary>
        internal async Task InitializeAsync()
        {
            try
            {
                await LoadConfigurationAsync();
                languageService.LanguageChanged += OnLanguageChanged;

                logger.Info("ConfigAppsViewModel initialized successfully.");
            }
            catch (Exception ex)
            {
                logger.Fatal("Failed to initialize ConfigAppsViewModel", ex);
            }
        }


        /// <summary>
        /// Loads the applications from the JSON configuration file into the Apps collection.
        /// </summary>
        internal async Task LoadConfigurationAsync()
        {
            try
            {
                logger.Info("Reading configuration...");
                var configuration = await configurationService.LoadConfigurationAsync();

                logger.Info("Loading applications into Apps collection...");
                if (configuration != null && configuration.Apps != null)
                {
                    logger.Debug("loaded.Apps", configuration.Apps.ToString() ?? "null");
                    Apps.CollectionChanged -= AppsAdded_CollectionChanged;
                    Apps.Clear();
                    foreach (var app in configuration.Apps.OrderBy(a => a.Name))
                    {
                        app.PropertyChanged += OnAppPropertyChanged;
                        logger.Debug("app", app.ToString() ?? "null");
                        Apps.Add(app);
                        logger.Info("Application added to Apps collection");
                    }
                    Apps.CollectionChanged += AppsAdded_CollectionChanged;
                    SortAppsAdded();
                    logger.Info("Applications loaded successfully.");
                }
            }
            catch (Exception ex)
            {
                snackbarService.Show(
                    NotificationLoadConfigErrorText,
                    ex.Message,
                    ControlAppearance.Danger,
                    new SymbolIcon(SymbolRegular.ErrorCircle24),
                    TimeSpan.FromSeconds(5)
                );
                logger.Error("Failed to load applications from configuration file", ex);
            }
        }

        
        /// <summary>
        /// Saves the current state of the Apps collection to a JSON file.
        /// </summary>
        internal async Task SaveConfigurationSync()
        {
            try
            {
                logger.Info("Saving applications to configuration file...");

               await configurationService.SaveConfigurationAsync(new ConfigurationModel
                {
                    Apps = Apps,
                    Language = languageService.currentCulture.TwoLetterISOLanguageName
               });

                logger.Info("Applications saved successfully.");
            }
            catch (Exception ex)
            {
                logger.Error("Failed to save applications", ex);
                await LoadConfigurationAsync();
            }
        }


        /// <summary>
        /// Adds a new application to the Apps collection and saves the updated configuration.
        /// </summary>
        /// <param name="app" >The app object to add</param>
        internal async Task AddAppAsync(ApplicationModel app)
        {
            try
            {
                if (app == null || Apps.Any(a => a.ExecutablePath.Equals(app.ExecutablePath, StringComparison.OrdinalIgnoreCase)))
                    throw new InvalidDataException("Add seems already present in the list");

                app.PropertyChanged += OnAppPropertyChanged;
                Apps.Add(app);
                await configurationService.SaveConfigurationAsync(new ConfigurationModel
                {
                    Apps = Apps,
                    Language = languageService.currentCulture.TwoLetterISOLanguageName
                });
                SortAppsAdded();

                snackbarService.Show(
                    NotificationAddAppSuccessText,
                    "",
                    ControlAppearance.Success,
                    new SymbolIcon(SymbolRegular.CheckmarkCircle24),
                    TimeSpan.FromSeconds(3)
                );
            }
            catch (Exception ex)
            {
                logger.Error("Failed to add application", ex);
                snackbarService.Show(
                    NotificationAddAppErrorText,
                    ex.Message,
                    ControlAppearance.Danger,
                    new SymbolIcon(SymbolRegular.ErrorCircle24),
                    TimeSpan.FromSeconds(5)
                );
            }
        }


        public ICommand RemoveAppCommand => new RelayCommand<ApplicationModel>(app => RemoveAppCommandImpl(app).ConfigureAwait(false));
        /// <summary>
        /// Removes an application from the Apps collection and configuration file.
        /// </summary>
        /// <param name="app" >The app object to remove.</param>
        [RelayCommand]
        internal async Task RemoveAppCommandImpl(ApplicationModel? app)
        {
            try
            {
                logger.Info($"Attempting to remove application");
                logger.Debug("app", app?.ToString() ?? "null");
                if (app is null)
                {
                    logger.Info("Application is null, cannot remove.");
                    return;
                }

                Apps.Remove(app);
                await configurationService.SaveConfigurationAsync(new ConfigurationModel
                {
                    Apps = Apps,
                    Language = languageService.currentCulture.TwoLetterISOLanguageName
                });

                snackbarService.Show(
                   NotificationRemoveAppSuccessText,
                   "",
                   ControlAppearance.Success,
                   new SymbolIcon(SymbolRegular.CheckmarkCircle24),
                   TimeSpan.FromSeconds(3)
               );

                logger.Info($"Application removed successfully.");
            }
            catch (Exception ex)
            {
                snackbarService.Show(
                    NotificationRemoveAppErrorText,
                    ex.Message,
                    ControlAppearance.Danger,
                    new SymbolIcon(SymbolRegular.ErrorCircle24),
                    TimeSpan.FromSeconds(5)
                );

                logger.Error($"Failed to remove application '{app?.Name ?? "Unknown"}'", ex);
                await LoadConfigurationAsync();
            }
        }


        /// <summary>
        /// Sorts the applications in the Apps collection by their Name property.
        /// </summary>
        internal void SortAppsAdded()
        {
            try
            {
                logger.Info("Sorting applications by name...");
                var sorted = Apps?.OrderBy(a => a?.Name).ToList();
                logger.Debug("sorted", sorted?.ToLogString() ?? string.Empty);
                Apps?.Clear();
                if (sorted != null)
                {
                    foreach (var app in sorted)
                    {
                        if (app == null)
                            continue;
                        logger.Debug("app", app.ToString() ?? string.Empty);
                        app.PropertyChanged -= OnAppPropertyChanged;
                        app.PropertyChanged += OnAppPropertyChanged;
                        Apps?.Add(app);
                    }
                }
                logger.Info("Applications sorted successfully.");
            }
            catch (Exception ex)
            {
                logger.Error("Failed to sort applications", ex);
            }
        }


        /// <summary>
        /// Watches for changes in the Apps collection and updates the property change handlers accordingly.
        /// </summary>
        /// <param name="sender">The sender of the event, typically the Apps collection.</param>
        /// <param name="e">The event arguments containing information about the change.</param>
        private void AppsAdded_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.NewItems != null)
                    foreach (ApplicationModel app in e.NewItems)
                        app.PropertyChanged += OnAppPropertyChanged;

                if (e.OldItems != null)
                    foreach (ApplicationModel app in e.OldItems)
                        app.PropertyChanged -= OnAppPropertyChanged;
            }
            catch (Exception ex)
            {
                logger.Error("Failed to handle collection change in Apps", ex);
            }
        }


        /// <summary>
        /// Watch for property changes in individual applications and save the configuration when a change occurs.
        /// </summary>
        /// <param name="e">The property change event arguments.</param>
        /// <param name="sender">The sender of the event, typically the application model that changed.</param>
        private async void OnAppPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            try
            {
                logger.Info($"Property changed in application model.");
                logger.Debug("property", e.PropertyName ?? "null");
                await configurationService.SaveConfigurationAsync(new ConfigurationModel
                {
                    Apps = Apps,
                    Language = languageService.currentCulture.TwoLetterISOLanguageName
                });
                logger.Info("Configuration saved after application property change.");
            }
            catch (Exception ex)
            {
                snackbarService.Show(
                    NotificationUpdateAppErrorText,
                    "",
                    ControlAppearance.Danger,
                    new SymbolIcon(SymbolRegular.ErrorCircle24),
                    TimeSpan.FromSeconds(5)
                );

                logger.Error("Failed to save applications after property change", ex);
                await LoadConfigurationAsync();
            }
        }


        /// <summary>
        /// Change texts according to the current language.
        /// </summary>
        private void OnLanguageChanged()
        {
            logger.Info("Changing texts according to the current language.");
            LoadingTextTemplate = languageService.GetMessage("Loading_ManagementEventWatcher");
            ManagementEventWatcherErrorText = languageService.GetMessage("Loading_ManagementEventWatcherError");
            OpenIssueButtonText = languageService.GetMessage("Button_OpenIssue");
            ToggleSwitchTestModeText = languageService.GetMessage("Switch_TestMode");
            NotificationLoadConfigErrorText = languageService.GetMessage("Notification_LoadConfigError");
            NotificationAddAppSuccessText = languageService.GetMessage("Notification_AddAppSuccess");
            NotificationAddAppErrorText = languageService.GetMessage("Notification_AddAppError");
            NotificationRemoveAppSuccessText = languageService.GetMessage("Notification_RemoveAppSuccess");
            NotificationRemoveAppErrorText = languageService.GetMessage("Notification_RemoveAppError");
            NotificationUpdateAppErrorText = languageService.GetMessage("Notification_UpdateAppError");
            logger.Info("Texts changed successfully.");
        }


        /// <summary>
        /// Updates the loading text for the management event watcher based on the current retry settings.
        /// </summary>
        private void UpdateLoadingText()
        {
            logger.Info("Updating loading text for management event watcher.");
            LoadingText = string.Format(LoadingTextTemplate, RetrySeconds, Attempt, MaxRetries);
            logger.Debug("LoadingText", LoadingText ?? "null");
            logger.Info("Loading text updated successfully.");
        }


        /// <summary>
        /// Updates the loading text when the properties change.
        /// </summary>
        partial void OnLoadingTextTemplateChanged(string value) => UpdateLoadingText();


        /// <summary>
        /// Updates the loading text when the retry seconds properties change.
        /// </summary>
        /// <param name="value">The new retry seconds value.</param>
        partial void OnRetrySecondsChanged(int value) => UpdateLoadingText();


        /// <summary>
        /// Updates the loading text when the attempt properties change.
        /// </summary>
        /// <param name="value">The new attempt value.</param>
        partial void OnAttemptChanged(int value) => UpdateLoadingText();


        /// <summary>
        /// Updates the loading text when the max retries properties change.
        /// </summary>
        /// <param name="value">The new max retries value.</param>
        partial void OnMaxRetriesChanged(int value) => UpdateLoadingText();
    }
}
