using System.Diagnostics;
using System.IO;
using System.Management;
using MFSAppsControl.ViewModels.Pages;

namespace MFSAppsControl.Services
{
    public class MFSEventWatcher : IDisposable
    {
        private readonly ConfigAppsViewModel configViewModel;
        private ManagementEventWatcher? startWatcher;
        private ManagementEventWatcher? stopWatcher;
        private readonly Dictionary<string, Process> startedApps = [];
        private readonly ILoggerService<MFSEventWatcher> logger;
        private bool isInitialized = false;

        /// <summary>
        /// Initiate the watcher instance.
        /// </summary>
        /// <param name="configAppsViewModel">The configuration view model containing the applications to manage.</param>
        /// <param name="logger"></param>
        public MFSEventWatcher(
            ConfigAppsViewModel configAppsViewModel,
            ILoggerService<MFSEventWatcher> logger
        )
        {
            this.logger = logger;
            this.configViewModel = configAppsViewModel;
        }


        /// <summary>
        /// Initialize async the MFSEventWatcher to monitor Microsoft Flight Simulator start and stop events with retry mode due to windows constraint.
        /// </summary>
        public async Task InitializeAsync()
        {
            const int maxRetries = 5;
            const int retryDelayMs = 15000;
            int attempt = 0;
            while (attempt < maxRetries && !isInitialized)
            {
                try
                {
                    logger.Info("Initialize MFSEventWatcher ...");
                    var startQuery = new WqlEventQuery(
                        "SELECT * FROM __InstanceCreationEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_Process' AND TargetInstance.Name LIKE 'FlightSimulator%.exe'");
                    logger.Debug("StartQuery", startQuery.QueryString);
                    startWatcher = new ManagementEventWatcher(startQuery);
                    startWatcher.EventArrived += OnMfsStarted;
                    startWatcher.Start();

                    var stopQuery = new WqlEventQuery(
                        "SELECT * FROM __InstanceDeletionEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_Process' AND TargetInstance.Name LIKE 'FlightSimulator%.exe'");
                    logger.Debug("StopQuery", stopQuery.QueryString);
                    stopWatcher = new ManagementEventWatcher(stopQuery);
                    stopWatcher.EventArrived += OnMfsStopped;
                    stopWatcher.Start();
                    logger.Info("MFSEventWatcher initialized successfully.");
                    isInitialized = true;
                    return;
                }
                catch (ManagementException mex) when (mex.Message.Contains("quota", StringComparison.OrdinalIgnoreCase))
                {
                    attempt++;
                    if (attempt < maxRetries)
                    {
                        logger.Warn($"ManagementEventWatcher Quota violation. Retry in {retryDelayMs / 1000} seconds... ({attempt}/{maxRetries})");
                        configViewModel.RetrySeconds = retryDelayMs / 1000;
                        configViewModel.Attempt = attempt;
                        configViewModel.MaxRetries = maxRetries;
                        await Task.Delay(retryDelayMs);
                    }
                    else
                    {
                        throw new InvalidOperationException("Quota violation exceeded.", mex);
                    }
                }
                catch (Exception ex)
                {
                    logger.Fatal("Failed to initialize MFSEventWatcher !", ex);
                    throw new InvalidOperationException("Failed to initialize MFSEventWatcher !", ex);
                }
            }
        }

        /// <summary>
        /// Start apps with To Start config when Microsoft Flight Simulator starts.
        /// </summary>
        /// <param name="e">Event arguments containing the event data.</param>
        /// <param name="sender">Sender of the event, typically the watcher itself.</param>
        private void OnMfsStarted(object? sender, EventArrivedEventArgs? e)
        {
            try
            {
                logger.Info("Microsoft Flight Simulator started, checking for apps to start...");
                foreach (var app in configViewModel.Apps.Where(a => a.AutoStart))
                {
                    logger.Debug("Checking app...", app.Name);
                    if (app.ExecutablePath.Equals("powershell.exe") || app.ExecutablePath.Equals("python.exe") || app.ExecutablePath.Equals("cmd.exe") || !IsProcessRunning(app.ExecutablePath))
                    {
                        try
                        {
                            logger.Info("Starting app");
                            var proc = Process.Start(new ProcessStartInfo
                            {
                                FileName = app.ExecutablePath,
                                Arguments = app.Arguments ?? "",
                                UseShellExecute = true,
                                CreateNoWindow = true
                            });
                            if (proc != null)
                                startedApps[app.ExecutablePath] = proc;

                            logger.Debug("Started app", app.ToString());
                            logger.Info("App started successfully");
                        }
                        catch (Exception ex)
                        {
                            logger.Error("Failed to start app", ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Fatal("Failed to handle MFS start event !", ex);
            }
        }

        /// <summary>
        /// Stop apps with To Close config when Microsoft Flight Simulator stops.
        /// </summary>
        /// <param name="sender"> Sender of the event, typically the watcher itself.</param>
        /// <param name="e">Event arguments containing the event data.</param>
        private void OnMfsStopped(object? sender, EventArrivedEventArgs? e)
        {
            try
            {
                logger.Info("Microsoft Flight Simulator stopped, checking for apps to close...");
                foreach (var app in configViewModel.Apps.Where(a => a.AutoClose))
                {
                    logger.Debug("Checking app", app.Name);
                    if (IsProcessRunning(app.ExecutablePath))
                    {
                        try
                        {
                            logger.Debug("Stopping app...", app.Name);
                            if (startedApps.TryGetValue(app.ExecutablePath, out var proc) && !proc.HasExited)
                            {
                                proc.Kill();
                                startedApps.Remove(app.ExecutablePath);
                                logger.Debug("Stopped app from startedApps", app.ToString());
                                logger.Info("App stopped successfully");
                            }
                            else
                            {
                                var exeName = Path.GetFileNameWithoutExtension(app.ExecutablePath);
                                foreach (var p in Process.GetProcessesByName(exeName))
                                {
                                    try { p.Kill(); } catch { }
                                }
                                logger.Debug("Stopped app from Process.GetProcessesByName", app.ToString());
                                logger.Info("App stopped successfully from Process.GetProcessesByName");
                            }
                        }
                        catch (Exception ex)
                        {
                            logger.Error("Failed to stop app", ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Fatal("Failed to handle MFS stop event !", ex);
            }
        }

        /// <summary>
        /// Check if a process is currently running based on its executable path.
        /// </summary>
        /// <param name="exePath">The full path of the executable to check.</param>
        private bool IsProcessRunning(string exePath)
        {
            try
            {
                logger.Info("Checking if process is running");
                logger.Debug("Checking if process is running", exePath);
                var exeName = Path.GetFileNameWithoutExtension(exePath);
                logger.Debug("Extracted exeName", exeName);
                logger.Debug("Process.GetProcessesByName", Process.GetProcessesByName(exeName).Length.ToString());
                return Process.GetProcessesByName(exeName).Length != 0;
            }
            catch (Exception ex)
            {
                logger.Error("Failed to check if process is running", ex);
                return false;
            }
        }

        /// <summary>
        /// Safely dispose of the watchers and release resources.
        /// </summary>
        public void Dispose()
        {
            try
            {
                logger.Info("Disposing MFSEventWatcher ...");
                startWatcher?.Stop();
                startWatcher?.Dispose();
                stopWatcher?.Stop();
                stopWatcher?.Dispose();
                GC.SuppressFinalize(this);
                logger.Info("MFSEventWatcher disposed successfully.");
            }
            catch (Exception ex)
            {
                logger.Error("Failed to dispose MFSEventWatcher !", ex);
            }
        }


        /// <summary>
        /// Start apps without MFS for testing purposes from the simulation button.
        /// </summary>
        public void SimulateMfsStarted()
        {
            OnMfsStarted(this, null);
        }


        /// <summary>
        /// Stop apps without MFS for testing purposes from the simulation button.
        /// </summary>
        public void SimulateMfsStopped()
        {
            OnMfsStopped(this, null);
        }
    }
}