using MFSAppsControl.Models;
using MFSAppsControl.Services;
using MFSAppsControl.ViewModels.Pages;
using MFSAppsControlTests.Mocks;

namespace MFSAppsControlTests
{
    [TestClass]
    public sealed class AddAppViewModelTests
    {
        private ConfigAppsViewModel? configAppsViewModel;
        private AddAppViewModel? addAppViewModel;
        private LanguageService? languageService;

        [TestInitialize]
        public void Setup()
        {
            var logger = new MockLoggerService<ConfigAppsViewModel>();
            var snackbar = new MockSnackbarService();
            languageService = new LanguageService();
            var configurationService = new ConfigurationService();
            configAppsViewModel = new ConfigAppsViewModel(snackbar, logger, languageService, configurationService);

            var loggerNewApp = new MockLoggerService<AddAppViewModel>();
            var snackbarNewApp = new MockSnackbarService();
            addAppViewModel = new AddAppViewModel(configAppsViewModel, loggerNewApp, languageService, snackbarNewApp);
        }

        [TestMethod]
        public void TestGetExcludedVendorsFromResource()
        {
            var excludedVendors = addAppViewModel!.GetExcludedVendorsFromResource();
            Assert.IsNotNull(excludedVendors, "The list of excluded vendors should not be null.");
            Assert.IsTrue(excludedVendors.Count > 0, "The list of excluded vendors should contain at least one item.");
        }

        [TestMethod]
        public void TestGetInstalledApplicationsInRegistry()
        {
            var installedApps = addAppViewModel!.GetInstalledApplicationsInRegistry();
            Assert.IsNotNull(installedApps, "The list of installed applications should not be null.");
            Assert.IsTrue(installedApps.Count > 0, "The list of installed applications should contain at least one item.");
        }

        [TestMethod]
        public void TestRefreshAppsAvailable()
        {
            addAppViewModel!.RefreshAppsAvailable();
            Assert.IsTrue(addAppViewModel.AppsAvailable.Count > 0, "AppsAvailable should contain at least one item after refresh.");
            // Verify that the list is ordered by name
            for (int i = 0; i < addAppViewModel.AppsAvailable.Count - 1; i++)
            {
                Assert.IsTrue(string.Compare(addAppViewModel.AppsAvailable[i].Name, addAppViewModel.AppsAvailable[i + 1].Name) <= 0,
                    "AppsAvailable should be ordered by name.");
            }
        }

        [TestMethod]
        public void TestCleanAppName()
        {
            string dirtyName = " Python 3.2.0 (64Bits) ";
            string cleanedName = addAppViewModel!.CleanAppName(dirtyName);
            Assert.AreEqual("Python 3.2", cleanedName, "The cleaned app name should not have leading or trailing spaces.");
            dirtyName = " Navigraph 1.0.0 (64 Bits) ";
            cleanedName = addAppViewModel.CleanAppName(dirtyName);
            Assert.AreEqual("Navigraph", cleanedName, "The cleaned app name should not have leading or trailing spaces.");
        }

        [TestMethod]
        public void TestOnSelectedAppChanged()
        {
            addAppViewModel!.Arguments = "test arguments";
            var app = new ApplicationModel
            {
                Name = "Test App",
                ExecutablePath = @"C:\Path\To\TestApp.exe",
                IconPath = @"C:\Path\To\TestAppIcon.ico",
            };
            addAppViewModel!.SelectedApp = app;
            Assert.IsNotNull(addAppViewModel.SelectedApp, "SelectedApp should not be null after selection.");
            Assert.AreEqual("", addAppViewModel.Arguments, "Arguments should be empty when a new app is selected.");
        }

        [TestMethod]
        public void TestOnLanguageChanged()
        {
            languageService!.SetCulture("en");
            Assert.AreEqual("en", languageService._currentCulture.Name, "The current culture should be set to English.");
            languageService!.SetCulture("fr");
            Assert.AreEqual("fr", languageService._currentCulture.Name, "The current culture should be set to French.");
            Assert.AreEqual(languageService!.GetMessage("Button_Browse"), addAppViewModel!.ButtonBrowseText, "The message of browse button should be set to the key Button_Browse of translation file.");
            Assert.AreEqual(languageService!.GetMessage("Button_Add"), addAppViewModel!.ButtonAddText, "The message of add button should be set to the key Button_Add of translation file.");
            Assert.AreEqual(languageService!.GetMessage("Notification_AppAlreadyAdded"), addAppViewModel!.NotificationAppAlreadyAddedText, "The message of App Already Added notificationo should be set to the key Notification_AppAlreadyAdded of the translation file.");
            Assert.AreEqual(languageService!.GetMessage("Notification_LoadInstalledAppError"), addAppViewModel!.NotificationLoadInstalledAppErrorText, "The message of Load Installed App Error notificationo should be set to the key Notification_LoadInstalledAppError of the translation file.");
        }
    }
}
