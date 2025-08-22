using MFSAppsControl.Services;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Windows.Input;

namespace MFSAppsControl.ViewModels.Windows
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private readonly ILoggerService<MainWindowViewModel> logger;
        private readonly LanguageService languageService;
        private readonly NotificationService notificationService;
        private readonly ConfigurationService configurationService;
        private readonly System.Timers.Timer updateTimer;
        private bool updateNotificationShown = false;

        [ObservableProperty]
        private string currentLanguage = CultureInfo.InstalledUICulture.TwoLetterISOLanguageName == "fr" ? "fr" : "en";

        [ObservableProperty]
        private string applicationTitle = "MFS Apps Control";

        [ObservableProperty]
        private string applicationVersionCopyright = "v{0} By Stalex";

        [ObservableProperty]
        private string updateMessageVisibility = "Collapsed";

        [ObservableProperty]
        private string? updateMessage;

        [ObservableProperty]
        private string? updateUrl;

        [ObservableProperty]
        private string systemNotificationNewUpdateTitle;

        [ObservableProperty]
        private string systemNotificationNewUpdateDescription;


        public MainWindowViewModel(
            ILoggerService<MainWindowViewModel> logger,
            LanguageService languageService,
            NotificationService notificationService,
            ConfigurationService configurationService
        )
        {
            this.logger = logger;
            this.languageService = languageService;
            this.notificationService = notificationService;
            this.configurationService = configurationService;
            SystemNotificationNewUpdateTitle = languageService.GetMessage("SystemNotification_NewUpdateTitle");
            SystemNotificationNewUpdateDescription = languageService.GetMessage("SystemNotification_NewUpdateDescription");

            if (Debugger.IsAttached)
            {
                ApplicationVersionCopyright = String.Format(ApplicationVersionCopyright, Assembly.GetEntryAssembly()!.GetCustomAttribute<AssemblyInformationalVersionAttribute>()!.InformationalVersion.Split(" +").First());
            }
            else
            {
                ApplicationVersionCopyright = String.Format(ApplicationVersionCopyright, Assembly.GetEntryAssembly()!.GetCustomAttribute<AssemblyInformationalVersionAttribute>()!.InformationalVersion[..3]);
            }

            updateTimer = new System.Timers.Timer(TimeSpan.FromHours(1).TotalMilliseconds);
            updateTimer.Elapsed += async (s, e) => await CheckForUpdateAsync();
            updateTimer.AutoReset = true;
            updateTimer.Start();

            languageService.LanguageChanged += OnLanguageChanged;
            
            ToastNotificationManagerCompat.OnActivated += OnToastAction;
        }


        /// <summary>
        /// Initializes the view model by checking for updates and loading the configuration.
        /// </summary>
        internal async Task InitializeAsync()
        {
            try
            {
                await CheckForUpdateAsync();
                var configuration = await configurationService.LoadConfigurationAsync();
                CurrentLanguage = configuration.Language!;
                languageService.SetCulture(CurrentLanguage);
            }
            catch (Exception ex)
            {
                logger.Error("Error during initialization.", ex);
            }
        }


        /// <summary>
        /// Checks for updates by querying the GitHub API for the latest release.
        /// </summary>
        private async Task CheckForUpdateAsync()
        {
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.UserAgent.ParseAdd("MFSAppsControl");
                var response = await client.GetAsync("https://api.github.com/repos/Stalex-CORP/MFSAppsControl/releases/latest");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);
                var latestVersionTag = doc.RootElement.GetProperty("tag_name").GetString();

                logger.Debug("latestVersion", latestVersionTag!);

                if (!string.IsNullOrWhiteSpace(latestVersionTag))
                {
                    var latestVersionStr = latestVersionTag.TrimStart('v', 'V');
                    var currentVersionStr = ApplicationVersionCopyright.TrimStart('v', 'V')[..3];

                    if (Version.TryParse(latestVersionStr, out var latestVersion) &&
                        Version.TryParse(currentVersionStr, out var currentVer))
                    {
                        if (latestVersion > currentVer)
                        {
                            logger.Info($"New update available: {latestVersionTag}");
                            UpdateMessage = $"{languageService.GetMessage("Text_UpdateAvailable")}: {latestVersionTag}";
                            UpdateMessageVisibility = "Visible";
                            if (!updateNotificationShown)
                            {
                                updateNotificationShown = true;
                                notificationService.ShowUpdateAvailableNotification(SystemNotificationNewUpdateTitle, SystemNotificationNewUpdateDescription);
                            }
                        }
                        else
                        {
                            logger.Info("No update available");
                            UpdateMessage = null;
                            UpdateMessageVisibility = "Collapsed";
                        }
                    }
                    else
                    {
                        logger.Warn("Failed to parse version(s) for update check.");
                        UpdateMessage = null;
                        UpdateMessageVisibility = "Collapsed";
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateMessage = null;
                UpdateMessageVisibility = "Collapsed";
                logger.Error("Error checking for updates.", ex);
            }
        }


        public ICommand ChangeLanguageCommand => new RelayCommand(ChangeLanguage);
        /// <summary>
        /// Change the application language between French and English and save it to configuration file.
        /// </summary>
        private async void ChangeLanguage()
        {
            try
            {
                if (CurrentLanguage == "fr")
                {
                    languageService.SetCulture("en");
                    CurrentLanguage = "en";
                }
                else
                {
                    languageService.SetCulture("fr");
                    CurrentLanguage = "fr";
                }
                var configuration = await configurationService.LoadConfigurationAsync();
                configuration.Language = CurrentLanguage;
                await configurationService.SaveConfigurationAsync(configuration);
            }
            catch (Exception ex)
            {
                logger.Error("Error changing language.", ex);
            }
        }


        /// <summary>
        /// Change texts according to the current language.
        /// </summary>
        private void OnLanguageChanged()
        {
            UpdateMessage = languageService.GetMessage("Text_UpdateAvailable");
            SystemNotificationNewUpdateTitle = languageService.GetMessage("SystemNotification_NewUpdateTitle");
            SystemNotificationNewUpdateDescription = languageService.GetMessage("SystemNotification_NewUpdateDescription");
        }


        /// <summary>
        /// Open the latest release page on GitHub when open button is clicked in the notification toast.
        /// Remind the user to check for updates in 1 day when the remind button is clicked in the notification toast.
        /// Else clear the toast notification history.
        /// </summary>
        /// <param name="e">The event arguments for the toast notification activation.</param>
        private void OnToastAction(ToastNotificationActivatedEventArgsCompat e)
        {
            if (e.Argument == "viewRelease")
            {
                var releaseUrl = "https://flightsim.to/file/96593/mfs-apps-control";
                try
                {
                    Process.Start(new ProcessStartInfo(releaseUrl) { UseShellExecute = true });
                    logger.Info($"Opened release page: {releaseUrl}");
                    ToastNotificationManagerCompat.History.Clear();
                }
                catch (Exception ex)
                {
                    logger.Error($"Failed to open release page !", ex);
                }
            }
            else if (e.Argument == "remind")
            {
                _ = Task.Run(async () =>
                {
                    await Task.Delay(TimeSpan.FromDays(1));
                    notificationService.ShowUpdateAvailableNotification(SystemNotificationNewUpdateTitle, SystemNotificationNewUpdateDescription);
                });
            }
            else
            {
                ToastNotificationManagerCompat.History.Clear();
            }
        }
    }
}
