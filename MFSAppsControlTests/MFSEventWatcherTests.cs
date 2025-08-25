using MFSAppsControl;
using MFSAppsControl.Services;
using MFSAppsControl.ViewModels.Pages;
using MFSAppsControlTests.Mocks;
using System.Diagnostics;
using Wpf.Ui.Controls;

namespace MFSAppsControlTests
{
    [TestClass]
    public sealed class MFSEventWatcherTests
    {
        private MFSEventWatcher? mfsEventWatcher;
        private ConfigAppsViewModel? configAppsViewModel;
        private LanguageService? languageService;
        private string testConfigPath = "MFSAppsControl_test_config.json";

        [TestInitialize]
        public void Setup()
        {
            var logger = new MockLoggerService<MFSEventWatcher>();
            var snackbar = new MockSnackbarService();
            var loggerConfigViewModel = new MockLoggerService<ConfigAppsViewModel>();
            languageService = new LanguageService();
            var configurationService = new ConfigurationService(testConfigPath);
            configAppsViewModel = new ConfigAppsViewModel(snackbar, loggerConfigViewModel, languageService, configurationService);
            mfsEventWatcher = new MFSEventWatcher(configAppsViewModel, logger);
        }

        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestAppStartAndStop()
        {
            if (configAppsViewModel != null)
            {
                configAppsViewModel.Apps =
                [
                    new MFSAppsControl.Models.ApplicationModel { Name = "Notepad", ExecutablePath = "notepad.exe", AutoStart = true, AutoClose = true },
                    new MFSAppsControl.Models.ApplicationModel { Name = "CalculatorApp", ExecutablePath = "calc.exe", AutoStart = false, AutoClose = true }
                ];

                try
                {
                    mfsEventWatcher?.SimulateMfsStarted();
                    Assert.IsNotNull(mfsEventWatcher?.appsProcesses, "Processes list should not be null.");

                }
                catch (Exception ex)
                {
                    Assert.Fail($"Exception occurred during MFS start simulation: {ex.Message}");
                }

                try
                {
                    mfsEventWatcher.StartProcessByObject(configAppsViewModel.Apps[1].ExecutablePath, configAppsViewModel?.Apps[1].Arguments);
                    mfsEventWatcher.SimulateMfsStopped();
                    Assert.AreEqual(0, mfsEventWatcher.appsProcesses.Count, "Processes list should be empty after MFS stop.");
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Exception during MFS stop simulation: {ex.Message}");
                }
            }
            else
            {
                Assert.Fail("ConfigAppsViewModel is null.");
            }
        }

        [TestMethod]
        public void TestScriptsStartAndStop()
        {
            if (configAppsViewModel != null)
            {
                var mocksDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..", "Mocks"));
                configAppsViewModel.Apps =
                [
                    new MFSAppsControl.Models.ApplicationModel { Name = "test.ps1", ExecutablePath = "powershell.exe", Arguments = $"-ExecutionPolicy Bypass -File \"{Path.Combine(mocksDir, "test.ps1")}\"", AutoStart = true, AutoClose = true },
                    new MFSAppsControl.Models.ApplicationModel { Name = "test2.ps1", ExecutablePath = "powershell.exe", Arguments = $"-ExecutionPolicy Bypass -File \"{Path.Combine(mocksDir, "test2.ps1")}\"", AutoStart = false, AutoClose = true },
                    new MFSAppsControl.Models.ApplicationModel { Name = "test3.ps1", ExecutablePath = "powershell.exe", Arguments = $"-ExecutionPolicy Bypass -File \"{Path.Combine(mocksDir, "test3.ps1")}\"", AutoStart = true, AutoClose = false }
                ];

                try
                {
                    mfsEventWatcher?.SimulateMfsStarted();
                    Assert.IsNotNull(mfsEventWatcher?.appsProcesses, "Processes list should not be null.");
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Exception occurred during MFS start simulation: {ex.Message}");
                }

                try
                {
                    mfsEventWatcher.StartProcessByObject(configAppsViewModel.Apps[1].ExecutablePath, configAppsViewModel.Apps[1].Arguments);
                    mfsEventWatcher.SimulateMfsStopped();
                    Assert.AreEqual(1, mfsEventWatcher.appsProcesses.Count, "Processes list should be one after MFS stop.");
                    configAppsViewModel.Apps[2].AutoClose = true;
                    mfsEventWatcher.SimulateMfsStopped();
                    Assert.AreEqual(0, mfsEventWatcher.appsProcesses.Count, "Processes list should be empty after MFS stop.");

                }
                catch (Exception ex)
                {
                    Assert.Fail($"Exception during MFS stop simulation: {ex.Message}");
                }
            }
            else
            {
                Assert.Fail("ConfigAppsViewModel is null.");
            }
        }
    }
}
