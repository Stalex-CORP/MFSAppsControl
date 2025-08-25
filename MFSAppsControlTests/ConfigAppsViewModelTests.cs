using MFSAppsControl.Models;
using MFSAppsControl.Services;
using MFSAppsControl.ViewModels.Pages;
using MFSAppsControlTests.Mocks;
using System.Collections.ObjectModel;

namespace MFSAppsControlTests { 
    [TestClass]
    public sealed class ConfigAppsViewModelTests
    {
        private ConfigAppsViewModel? configAppsViewModel;
        private LanguageService? languageService;
        private string testConfigPath = "MFSAppsControl_test_config.json";

        [TestInitialize]
        public void Setup()
        {
            var logger = new MockLoggerService<ConfigAppsViewModel>();
            var snackbar = new MockSnackbarService();
            languageService = new LanguageService();

            var testName = TestContext.TestName; var configTestsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "ConfigTests");
            Directory.CreateDirectory(configTestsDir);
            testConfigPath = Path.Combine(configTestsDir, $"MFSAppsControl_test_config_{testName}.json");
            File.WriteAllText(testConfigPath, "{}");
            var configurationService = new ConfigurationService(testConfigPath);
            configAppsViewModel = new ConfigAppsViewModel(snackbar, logger, languageService, configurationService);
        }

        public TestContext TestContext { get; set; }

        [TestMethod]
        public async Task TestInitializeAsync()
        {
            await configAppsViewModel!.InitializeAsync();
            Assert.AreEqual(0, configAppsViewModel.Apps.Count, "Apps collection should be empty after initialization.");
        }

        [TestMethod]
        public async Task TestLoadConfigurationAsync()
        {
            await configAppsViewModel!.LoadConfigurationAsync();
            Assert.AreEqual(0, configAppsViewModel.Apps.Count, "Apps collection should be empty.");
        }

        [TestMethod]
        public async Task TestSaveConfigurationSync()
        {
            configAppsViewModel!.Apps =
            [
                new ApplicationModel { Name = "App1", ExecutablePath = @"C:\App1.exe" }
            ];
            await configAppsViewModel.SaveConfigurationSync();
            Assert.IsTrue(configAppsViewModel.Apps.Count > 0, "Apps collection should contain at least one item after save.");
        }

        [TestMethod]
        public async Task TestAddAppAsync()
        {
            var app = new ApplicationModel { Name = "App2", ExecutablePath = @"C:\App2.exe" };
            configAppsViewModel!.Apps.Add(app);
            await configAppsViewModel.SaveConfigurationSync();
            await configAppsViewModel.LoadConfigurationAsync();
            Assert.IsTrue(configAppsViewModel.Apps.Any(a => a.Name == "App2"), "App2 should be added to Apps collection.");
        }

        [TestMethod]
        public async Task TestRemoveAppCommandImpl()
        {
            var app = new ApplicationModel { Name = "App2", ExecutablePath = @"C:\App2.exe" };
            configAppsViewModel!.Apps.Add(app);
            var app2 = new ApplicationModel { Name = "App3", ExecutablePath = @"C:\App3.exe" };
            configAppsViewModel!.Apps.Add(app2);
            await configAppsViewModel.SaveConfigurationSync();
            await configAppsViewModel.LoadConfigurationAsync();
            var appToRemove = configAppsViewModel.Apps.FirstOrDefault(a => a.Name == "App3");
            if (appToRemove != null)
                configAppsViewModel.Apps.Remove(appToRemove);
            await configAppsViewModel.SaveConfigurationSync();
            await configAppsViewModel.LoadConfigurationAsync();
            Assert.IsFalse(configAppsViewModel.Apps.Any(a => a.Name == "App3"), "App3 should be removed from Apps collection.");
        }

        [TestMethod]
        public void TestSortAppsAdded()
        {
            configAppsViewModel!.Apps =
            [
                new ApplicationModel { Name = "Zeta", ExecutablePath = @"C:\Zeta.exe" },
                new ApplicationModel { Name = "Alpha", ExecutablePath = @"C:\Alpha.exe" }
            ];
            configAppsViewModel.SortAppsAdded();
            Assert.AreEqual("Alpha", configAppsViewModel.Apps.First().Name, "Apps should be sorted by name.");
        }

        [TestMethod]
        public void TestOnLanguageChanged()
        {
            languageService!.SetCulture("en");
            configAppsViewModel!.CurrentLanguage = "en";
            Assert.AreEqual("Name", configAppsViewModel.DatagridColumnHeaderApplicationText, "DatagridColumnHeaderApplicationText must be 'Name'.");

            languageService!.SetCulture("de");
            configAppsViewModel!.CurrentLanguage = "de";
            Assert.AreEqual("Anwendungsname", configAppsViewModel.DatagridColumnHeaderApplicationText, "DatagridColumnHeaderApplicationText must be 'Anwendungsname'.");

            languageService!.SetCulture("es");
            configAppsViewModel!.CurrentLanguage = "es";
            Assert.AreEqual("Nombre de aplicación", configAppsViewModel.DatagridColumnHeaderApplicationText, "DatagridColumnHeaderApplicationText must be 'Nombre de aplicación'.");

            languageService!.SetCulture("fr");
            configAppsViewModel!.CurrentLanguage = "fr";
            Assert.AreEqual("Nom", configAppsViewModel.DatagridColumnHeaderApplicationText, "DatagridColumnHeaderApplicationText must be 'Nom'.");

            languageService!.SetCulture("it");
            configAppsViewModel!.CurrentLanguage = "it";
            Assert.AreEqual("Nome applicazione", configAppsViewModel.DatagridColumnHeaderApplicationText, "DatagridColumnHeaderApplicationText must be 'Nome applicazione'.");
        }

        [TestMethod]
        public void TestUpdateLoadingText()
        {
            configAppsViewModel!.LoadingTextTemplate = "Retry in {0} seconds... ({1}/{2})";
            configAppsViewModel.RetrySeconds = 10;
            configAppsViewModel.Attempt = 2;
            configAppsViewModel.MaxRetries = 5;
            configAppsViewModel.GetType().GetMethod("UpdateLoadingText", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!.Invoke(configAppsViewModel, null);
            Assert.AreEqual("Retry in 10 seconds... (2/5)", configAppsViewModel.LoadingText, "LoadingText should be correctly formatted.");
        }
    }
}