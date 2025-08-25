using MFSAppsControl.Converters;
using MFSAppsControl.Models;
using MFSAppsControl.Services;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace MFSAppsControl.ViewModels.Pages
{
    public partial class AddAppViewModel : ObservableObject
    {
        internal event Action? BackOnAppAdded;
        private readonly ILoggerService<AddAppViewModel> logger;
        private readonly LanguageService LanguageService;
        private readonly ISnackbarService snackbarService;
        private readonly ConfigAppsViewModel configAppsViewModel;

        [ObservableProperty]
        private string currentLanguage;

        [ObservableProperty]
        private ObservableCollection<ApplicationModel> appsAvailable = [];

        [ObservableProperty]
        internal string searchText = string.Empty;

        [ObservableProperty]
        private ApplicationModel? _selectedApp;

        [ObservableProperty]
        private string _arguments = string.Empty;

        [GeneratedRegex(@"\s*\(.*?\)")]
        private static partial Regex RegexBits();

        [GeneratedRegex(@"\s+\d+(\.\d+)+")]
        private static partial Regex RegexAppVersion();

        [GeneratedRegex(@"^(.*?)(?:\s+(\d.\d))?(?:\.\d+)*\s*$")]
        private static partial Regex RegexPythonVersion();

        [ObservableProperty]
        private string buttonBrowseText;

        [ObservableProperty]
        private string buttonAddText;

        [ObservableProperty]
        private string notificationAppAlreadyAddedText;

        [ObservableProperty]
        private string notificationLoadInstalledAppErrorText;

        [ObservableProperty]
        private string datagridArgumentsPlaceHolderText;


        /// <summary>
        /// Initializes a new instance of the <see cref="AddAppViewModel"/> class.
        /// </summary>
        /// <param name="appsViewModel"></param>
        public AddAppViewModel(
            ConfigAppsViewModel appsViewModel,
            ILoggerService<AddAppViewModel> logger,
            LanguageService languageService,
            ISnackbarService snackbarService)
        {
            this.logger = logger;
            this.LanguageService = languageService;
            this.configAppsViewModel = appsViewModel;
            this.snackbarService = snackbarService;
            ButtonBrowseText = LanguageService.GetMessage("Button_Browse");
            ButtonAddText = LanguageService.GetMessage("Button_Add");
            NotificationAppAlreadyAddedText = LanguageService.GetMessage("Notification_AppAlreadyAdded");
            NotificationLoadInstalledAppErrorText = LanguageService.GetMessage("Notification_LoadInstalledAppError");
            DatagridArgumentsPlaceHolderText = LanguageService.GetMessage("Datagrid_Placeholder_Arguments");
            currentLanguage = languageService.currentCulture.TwoLetterISOLanguageName;
            languageService.LanguageChanged += () => CurrentLanguage = languageService.currentCulture.TwoLetterISOLanguageName;

            try
            {
                logger.Info("Initializing AddAppViewModel");
                RefreshAppsAvailable();
                logger.Info("AddAppViewModel initialized successfully");
            }
            catch (Exception ex)
            {
                logger.Fatal("Error initializing AddAppViewModel", ex);
            }
        }


        /// <summary>
        /// Gets the list of excluded vendors from a JSON resource embedded in the assembly to exclude them from the available apps list.
        /// </summary>
        /// <returns>A list of vendor names to exclude.</returns>
        internal List<string> GetExcludedVendorsFromResource()
        {
            logger.Info("Loading excluded vendors from embedded resource");
            var assembly = Assembly.GetExecutingAssembly();
            logger.Debug("Assembly name", assembly.GetName().Name ?? "Unknown");

            var resourceName = "MFSAppsControl.ExcludedVendors.json";
            logger.Debug("Resource name", resourceName);

            using var stream = assembly.GetManifestResourceStream(resourceName);
            logger.Debug("Stream", stream != null ? "Loaded" : "Not found");
            if (stream == null) return [];

            using var reader = new StreamReader(stream);
            var json = reader.ReadToEnd();
            logger.Debug("JSON content", json);
            logger.Info("Excluded vendors loaded successfully");
            return JsonSerializer.Deserialize<List<string>>(json) ?? [];
        }


        /// <summary>
        /// Gets the list of installed applications by searching through the Start Menu shortcuts and Windows registry.
        /// </summary>
        /// <returns>A list of ApplicationModel representing the installed applications.</returns>
        internal List<ApplicationModel> GetInstalledApplicationsInRegistry()
        {
            logger.Info("Getting installed applications from Start Menu and registry");
            var apps = new List<ApplicationModel>();
            var exePaths = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var excludedVendors = GetExcludedVendorsFromResource();

            string[] registryKeys =
            [
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall",
                @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
            ];

            logger.Info("Searching for applications in Windows registry");
            foreach (var root in new[] { Registry.LocalMachine, Registry.CurrentUser })
            {
                logger.Debug("Checking registry root", root.Name);
                foreach (var keyPath in registryKeys)
                {
                    logger.Debug("Checking registry key", keyPath);
                    using var key = root.OpenSubKey(keyPath);
                    if (key == null) continue;
                    logger.Info("Registry key found, enumerating subkeys");

                    foreach (var subKeyName in key.GetSubKeyNames())
                    {
                        logger.Debug("Processing subkey", subKeyName);
                        using var subKey = key.OpenSubKey(subKeyName);
                        if (subKey == null) continue;
                        logger.Debug("Subkey opened", subKeyName);

                        var displayName = subKey.GetValue("DisplayName") as string;
                        logger.Debug("DisplayName", displayName ?? "null");
                        var displayIcon = subKey.GetValue("DisplayIcon") as string;
                        logger.Debug("DisplayIcon", displayIcon ?? "null");
                        var installLocation = subKey.GetValue("InstallLocation") as string;
                        logger.Debug("InstallLocation", installLocation ?? "null");

                        if (string.IsNullOrWhiteSpace(displayName)
                            || excludedVendors.Any(ex => displayName.Contains(ex, StringComparison.InvariantCultureIgnoreCase))
                            || (!string.IsNullOrWhiteSpace(installLocation) && installLocation.Contains("steamapps"))
                            || (!string.IsNullOrWhiteSpace(installLocation) && installLocation.Contains("EpicGames"))
                        )
                        {
                            logger.Info("Skipping application due to exclusion criteria (steam/epic)");
                            continue;
                        }

                        string? exePath = null;

                        if (!string.IsNullOrWhiteSpace(displayIcon))
                        {
                            logger.Info("Processing DisplayIcon");
                            logger.Debug("Processing DisplayIcon", displayIcon);
                            var iconPath = displayIcon.Split(',')[0].Trim();
                            logger.Debug("Icon path", iconPath);

                            if (File.Exists(iconPath) && iconPath.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
                            {
                                exePath = iconPath;
                                logger.Debug("Executable path from DisplayIcon", exePath);
                            }
                            logger.Info("DisplayIcon processed");
                        }

                        if (exePath == null && !string.IsNullOrWhiteSpace(installLocation) && Directory.Exists(installLocation))
                        {
                            logger.Info("Processing InstallLocation");
                            var exes = Directory.GetFiles(installLocation, "*.exe", SearchOption.TopDirectoryOnly)
                                .Where(file =>
                                {
                                    var exeName = Path.GetFileName(file).ToLowerInvariant();
                                    return !exeName.Contains("unins") && !exeName.Contains("setup") && !exeName.Contains("remove");
                                })
                                .ToList();
                            logger.Debug("Found executables in InstallLocation", exes.Count.ToString());
                            logger.Debug("InstallLocation", installLocation);

                            if (exes.Count > 0)
                            {
                                logger.Info("Selecting best executable from InstallLocation");
                                exePath = exes
                                    .OrderByDescending(file => Path.GetFileNameWithoutExtension(file).Equals(displayName, StringComparison.InvariantCultureIgnoreCase))
                                    .ThenByDescending(file => Path.GetFileNameWithoutExtension(file).Contains(displayName, StringComparison.InvariantCultureIgnoreCase))
                                    .ThenByDescending(file => new FileInfo(file).Length)
                                    .FirstOrDefault();
                                logger.Debug("Best executable selected", exePath ?? "null");
                                logger.Info("InstallLocation processed");
                            }
                        }

                        if (string.IsNullOrWhiteSpace(exePath) || !File.Exists(exePath))
                        {
                            logger.Info("Executable path is null or does not exist, skipping application");
                            continue;
                        }

                        if (!exePaths.Add(exePath))
                        {
                            logger.Debug("Executable path added to set", exePath);
                            continue;
                        }

                        var app = new ApplicationModel
                        {
                            Name = CleanAppName(displayName),
                            ExecutablePath = exePath,
                            IconPath = exePath,
                            AutoStart = false,
                            AutoClose = false
                        };

                        apps.Add(app);
                        logger.Debug("Application added", app.ToString() ?? "Unknown");
                        logger.Info("Application added from registry");
                    }
                }
            }

            return apps;
        }

        
        /// <summary>
        /// Refreshes the list of available applications by checking installed applications
        /// </summary>
        internal void RefreshAppsAvailable()
        {
            try
            {
                logger.Info("Refreshing available applications list");
                var installedApps = GetInstalledApplicationsInRegistry()
                    .Where(a =>
                        !configAppsViewModel.Apps.Any(added =>
                            a.ExecutablePath.Equals(added.ExecutablePath, StringComparison.OrdinalIgnoreCase)))
                    .OrderBy(a => a.Name) // Tri alphabétique
                    .ToList();
                logger.Debug("installed apps", installedApps.ToLogString() ?? "");

                AppsAvailable.Clear();
                foreach (var app in installedApps)
                {
                    AppsAvailable.Add(app);
                    logger.Debug("Added application to available list", app.ToString() ?? "Unknown");
                }
                logger.Info("Available applications list refreshed");
            }
            catch (Exception ex)
            {
                logger.Error("Failed to refresh available applications list", ex);
                snackbarService.Show(
                    NotificationLoadInstalledAppErrorText,
                    ex.Message,
                    ControlAppearance.Danger,
                    new SymbolIcon(SymbolRegular.ErrorCircle24),
                    TimeSpan.FromSeconds(5)
                );
            }
        }


        /// <summary>
        /// Filters the available applications based on the search text or returns all applications if the search text is empty.
        /// </summary>
        /// <returns>An enumerable of ApplicationModel.</returns>
        public IEnumerable<ApplicationModel> FilteredAppsAvailable => string.IsNullOrWhiteSpace(SearchText) ? AppsAvailable : AppsAvailable.Where(app => (!string.IsNullOrWhiteSpace(app.Name) && app.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase)));


        /// <summary>
        /// Let the user browse for an application to add when for standalone/scripts.
        /// </summary>
        [RelayCommand]
        private void Browse()
        {
            logger.Info("Opening file dialog to browse for application");
            OpenFileDialog openFileDialog = new()
            {
                Filter = "Executable/Script (*.exe;*.ps1;*.py;*.cmd;*.bat)|*.exe;*.ps1;*.py;*.cmd;*.bat"
            };
            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                logger.Debug("File dialog result", "File selected: " + openFileDialog.FileName);

                ApplicationModel selectedApp = new()
                {
                    Name = CleanAppName(openFileDialog.SafeFileName.Replace(".exe", "")),
                    ExecutablePath = openFileDialog.FileName,
                    IconPath = openFileDialog.FileName,
                };
                logger.Debug("Selected application", selectedApp.ToString() ?? "Unknown");

                if (configAppsViewModel.Apps.Any(app => app.Name.Equals(selectedApp.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    snackbarService.Show(
                        NotificationAppAlreadyAddedText,
                        selectedApp.Name,
                        ControlAppearance.Danger,
                        new SymbolIcon(SymbolRegular.ErrorCircle24),
                        TimeSpan.FromSeconds(5)
                    );
                    return;
                }
                AppsAvailable.Add(selectedApp);

                var sorted = AppsAvailable.OrderBy(a => a.Name).ToList();
                AppsAvailable.Clear();
                foreach (var app in sorted)
                    AppsAvailable.Add(app);

                SelectedApp = selectedApp;
                logger.Info("File dialog closed, application selected");
            }
            else
            {
                logger.Info("File dialog closed without selection");
            }
        }


        /// <summary>
        /// Nettoie le nom d'une application en supprimant les informations de version et d'architecture.
        /// </summary>
        /// <param name="name">Nom original de l'application</param>
        /// <returns>Nom nettoyé</returns>
        internal string CleanAppName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return name;

            var cleaned = RegexBits().Replace(name, "");

            if (cleaned.Contains("Python"))
            {
                var match = RegexPythonVersion().Match(cleaned);
                if (match.Success)
                {
                    var baseName = match.Groups[1].Value.Trim();
                    var major = match.Groups[2].Success ? " " + match.Groups[2].Value : "";
                    return (baseName + major).Trim();
                }
            }
            else
            {
                cleaned = RegexAppVersion().Replace(cleaned, "");
            }

            // Supprime les espaces en fin de chaîne
            return cleaned.Trim();
        }


        /// <summary>
        /// Adds the selected application to the list of added applications if it is not already present.
        /// </summary>
        [RelayCommand]
        internal async Task AddSelectedAppAsync()
        {
            logger.Info("Adding selected application to added apps list");
            if (SelectedApp != null && !configAppsViewModel.Apps.Any(a => a.Name == SelectedApp.Name))
            {
                if (SelectedApp.Name.EndsWith(".ps1"))
                {
                    logger.Info("Selected application is a PowerShell script");
                    SelectedApp.Arguments = $"-ExecutionPolicy Bypass -File \"{SelectedApp.ExecutablePath}\"";
                    SelectedApp.ExecutablePath = "powershell.exe";
                }
                else if (SelectedApp.Name.EndsWith(".py"))
                {
                    logger.Info("Selected application is a Python script");
                    SelectedApp.Arguments = $"\"{SelectedApp.ExecutablePath}\"";
                    SelectedApp.ExecutablePath = "python.exe";
                }
                else if (SelectedApp.Name.EndsWith(".cmd") || SelectedApp.Name.EndsWith(".bat"))
                {
                    logger.Info("Selected application is a CMD/BAT script");
                    SelectedApp.Arguments = $"/c \"{SelectedApp.ExecutablePath}\"";
                    SelectedApp.ExecutablePath = "cmd.exe";
                }
                else
                {
                    logger.Info("Selected application is an installed executable");
                    SelectedApp.Arguments = string.IsNullOrWhiteSpace(Arguments) ? string.Empty : Arguments.Trim();
                }
                    logger.Debug("Selected application", SelectedApp.ToString() ?? "");

                await configAppsViewModel.AddAppAsync(SelectedApp);
                logger.Info("Application added to the added apps list");

                AppsAvailable.Remove(SelectedApp);
                logger.Info("Application removed from the installed list.");

                BackOnAppAdded?.Invoke();
                logger.Info("Application added successfully");
            }
        }


        /// <summary>
        /// Empty argument field when the selected application changed.
        /// </summary>
        /// <param name="value">The new selected application.</param>
        partial void OnSelectedAppChanged(ApplicationModel? value)
        {
            logger.Info("Selected application changed, clearing arguments field");
            Arguments = string.Empty;
            logger.Info("Arguments field cleared");
        }


        partial void OnSearchTextChanged(string value)
        {
            OnPropertyChanged(nameof(FilteredAppsAvailable));
        }


        /// <summary>
        /// Update texts when current language change.
        /// </summary>
        /// <param name="value">value of current language.</param>
        partial void OnCurrentLanguageChanged(string value)
        {
            ButtonBrowseText = LanguageService.GetMessage("Button_Browse");
            ButtonAddText = LanguageService.GetMessage("Button_Add");
            NotificationAppAlreadyAddedText = LanguageService.GetMessage("Notification_AppAlreadyAdded");
            NotificationLoadInstalledAppErrorText = LanguageService.GetMessage("Notification_LoadInstalledAppError");
            DatagridArgumentsPlaceHolderText = LanguageService.GetMessage("Datagrid_Placeholder_Arguments");
        }
    }
}
