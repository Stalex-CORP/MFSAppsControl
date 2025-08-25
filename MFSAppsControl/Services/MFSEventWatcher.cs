using System.Diagnostics;
using System.Management;
using MFSAppsControl.ViewModels.Pages;

namespace MFSAppsControl.Services
{
    public class MFSEventWatcher : IDisposable
    {
        private readonly ConfigAppsViewModel configViewModel;
        private ManagementEventWatcher? startWatcher;
        private ManagementEventWatcher? stopWatcher;
        internal Dictionary<string, List<int>> appsProcesses = [];
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
            _ = InitializeAsync();
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

                    logger.Info("Checking for running apps to add to appsProcesses...");
                    appsProcesses = GetProcessRunning();

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
        /// Start apps with To Start config when Microsoft Flight Simulator starts or with simulation.
        /// </summary>
        /// <param name="e">Event arguments containing the event data.</param>
        /// <param name="sender">Sender of the event, typically the watcher itself.</param>
        private void OnMfsStarted(object? sender, EventArrivedEventArgs? e)
        {
            try
            {
                appsProcesses = GetProcessRunning();
                logger.Info("Microsoft Flight Simulator started, checking for apps to start...");

                foreach (var app in configViewModel.Apps.Where(a => a.AutoStart))
                {
                    logger.Debug("Checking app", app.Name.ToLower());
                    if (!appsProcesses.ContainsKey(app.Name.ToLower()))
                    {
                        try
                        {
                            StartProcessByObject(app.ExecutablePath, app.Arguments ?? "");
                        }
                        catch (Exception ex)
                        {
                            logger.Error("Failed to start app", ex);
                        }
                    }
                    else
                    {
                        logger.Info("App is already running, skipping...");
                    }
                }

                // Mandatory delay to ensure process is fully started
                Task.Delay(1000).Wait();

                appsProcesses = GetProcessRunning();
            }
            catch (Exception ex)
            {
                logger.Fatal("Failed to handle MFS start event !", ex);
            }
        }

        /// <summary>
        /// Stop apps with To Close config when Microsoft Flight Simulator stops or with simulation.
        /// </summary>
        /// <param name="sender"> Sender of the event, typically the watcher itself.</param>
        /// <param name="e">Event arguments containing the event data.</param>
        private void OnMfsStopped(object? sender, EventArrivedEventArgs? e)
        {
            try
            {
                // Mandatory delay to ensure process is fully loaded
                Task.Delay(1000).Wait();
                appsProcesses = GetProcessRunning();

                logger.Info("Microsoft Flight Simulator stopped, checking for apps to close...");
                foreach (var app in configViewModel.Apps.Where(a => a.AutoClose))
                {
                    logger.Debug("Checking app", app.Name);

                    if (appsProcesses.TryGetValue(app.Name, out List<int>? pids))
                    {
                        logger.Info("App found in appsProcesses, attempting to close...");
                        foreach (var pid in pids)
                        {
                            try
                            {
                                KillProcessById(pid);
                            }
                            catch (Exception ex)
                            {
                                logger.Error("Failed to close process", ex);
                            }
                        }
                    }
                    else
                    {
                        logger.Info("App not found in appsProcesses, skipping...");
                    }
                }

                // Mandatory delay to ensure process is fully terminated
                Task.Delay(1000).Wait();

                appsProcesses = GetProcessRunning();
            }
            catch (Exception ex)
            {
                logger.Fatal("Failed to handle MFS stop event !", ex);
            }
        }


        /// <summary>
        /// Get a dictionary of currently running processes that are marked for auto-start or auto-close in the configuration.
        /// </summary>
        /// <returns>A dictionary where the key is the process name and the value is a list of process IDs.</returns>
        internal Dictionary<string, List<int>> GetProcessRunning()
        {
            Dictionary<string, List<int>> runningProcesses = [];

            logger.Info("Getting currently running processes for auto-start and auto-close apps...");
            foreach (var app in configViewModel.Apps.Where(a => a.AutoStart || a.AutoClose))
            {
                logger.Debug("Checking app", app.Name);

                List<int> ids = [];

                string console = "";
                switch (app.Name.ToLower())
                {
                    case var powershell when app.Name.EndsWith("ps1"):
                        console = "powershell";
                        break;
                    case var batch when app.Name.EndsWith("bat") || app.Name.EndsWith("cmd"):
                        console = "cmd";
                        break;
                    case var python when app.Name.EndsWith("py"):
                        console = "python";
                        break;
                }

                if (!string.IsNullOrEmpty(console))
                {
                    logger.Info("App is a script, checking for running script processes...");
                    try
                    {
                        Process[] consoleProcesses = Process.GetProcessesByName(console);
                        if (consoleProcesses.Length != 0)
                        {
                            foreach (var p in consoleProcesses)
                            {
                                ManagementObjectSearcher processSearch = new($"SELECT CommandLine FROM Win32_Process WHERE ProcessId = {p.Id}");
                                using ManagementObjectCollection processObject = processSearch.Get();
                                string? commandLine = processObject.Cast<ManagementBaseObject>().SingleOrDefault()?["CommandLine"].ToString();

                                if (!string.IsNullOrEmpty(commandLine) && commandLine.Contains(app.Name, StringComparison.OrdinalIgnoreCase))
                                {
                                    logger.Info("Adding running script process to appsProcesses");
                                    ids.Add(p.Id);
                                    logger.Debug("Added process ID", p.Id.ToString());
                                    logger.Info("Running script process added successfully");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Failed to get running script process to appsProcesses", ex);
                    }
                }
                else
                {
                    foreach (var p in Process.GetProcessesByName(app.Name))
                    {
                        try
                        {
                            logger.Info("Adding running process to appsProcesses");
                            ids.Add(p.Id);
                            logger.Debug("Added process ID", p.Id.ToString());
                            logger.Info("Running process added successfully");
                        }
                        catch (Exception ex)
                        {
                            logger.Error("Failed to add running process to appsProcesses", ex);
                        }
                    }
                }
                if (ids.Count > 0)
                {
                    logger.Info("Found running processes for app");
                    runningProcesses.Add(app.Name, ids);
                    logger.Debug("Added to runningProcesses", $"{app.Name}: [{string.Join(", ", ids)}]");
                    logger.Info("App running processes added successfully");
                }
                else
                {
                    logger.Info("No running processes found for app");
                }
            }
            logger.Info("Retrieved running processes successfully.");

            return runningProcesses;
        }


        /// <summary>
        /// Start a process with the specified executable path and arguments.
        /// </summary>
        /// <param name="exePath">The path to the executable to start.</param>
        /// <param name="args">The arguments to pass to the executable.</param>
        internal void StartProcessByObject(string exePath, string? args)
        {
            try
            {
                logger.Info("Starting process");
                var proc = Process.Start(new ProcessStartInfo
                {
                    FileName = exePath,
                    Arguments = args ?? "",
                    UseShellExecute = true,
                    CreateNoWindow = true
                });
                logger.Debug("Started process", proc?.ToString() ?? "null");
                logger.Info("Process started successfully");
            }
            catch (Exception ex)
            {
                logger.Error("Failed to start process", ex);
            }
        }


        /// <summary>
        /// Kill a process by its process ID.
        /// </summary>
        /// <param name="pid">The process ID of the process to kill.</param>
        internal void KillProcessById(int pid)
        {
            var proc = Process.GetProcessById(pid);
            if (!proc.HasExited)
            {
                logger.Info("Closing process");
                logger.Debug("Process details", $"ID: {proc.Id}, Name: {proc.ProcessName}");
                proc.Kill();
                logger.Info("Process closed");
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