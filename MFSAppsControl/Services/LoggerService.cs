using log4net;
using log4net.Config;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace MFSAppsControl.Services
{

    /// <summary>
    /// Interface for a generic logger service.
    /// </summary>
    public interface ILoggerService<T>
    {
        void Info(string message);
        void Warn(string message);
        void Error(string message, Exception ex);
        void Fatal(string message, Exception ex);
        void Debug(string property, string value);
        string GetLogFilePath();
    }


    public class LoggerService<T> : ILoggerService<T>
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(T));
        public string logDir;

        /// <summary>
        /// Initializes the logger service, configuring log4net with the specified settings for release and debug.
        /// </summary>
        public LoggerService()
        {
            logDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Stalex",
                "MFSAppsControl"
            );
            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);

            var entryAssembly = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
            var logRepository = LogManager.GetRepository(entryAssembly);
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            var appender = logRepository.GetAppenders().OfType<log4net.Appender.RollingFileAppender>().SingleOrDefault(a => a.Name.Equals("RollingFileAppender"));
            // if (appender != null)
            // {
            //     appender.File = Path.Combine(logDir, "app.log");
            //     appender.ActivateOptions();
            // }


            if (Debugger.IsAttached)
            {
                var deboggerAppender = logRepository.GetAppenders().OfType<log4net.Appender.DebugAppender>().FirstOrDefault();
                var debugAppender = logRepository.GetAppenders().OfType<log4net.Appender.RollingFileAppender>().SingleOrDefault(a => a.Name.Equals("RollingFileAppenderDebug"));
                // if (debugAppender != null)
                // {
                //     debugAppender.File = Path.Combine(logDir, "app-debug.log");
                //     debugAppender.ActivateOptions();
                // }
            }
        }


        /// <summary>
        /// Logs an informational message.
        /// </summary>
        /// <param name="message">Message to logs</param>
        public void Info(string message) => log.Info(message);


        /// <summary>
        /// Logs a warning message.
        /// </summary>
        /// <param name="message">Message to logs</param>
        public void Warn(string message) => log.Warn(message);


        /// <summary>
        /// Logs an error message with his exception.
        /// </summary>
        /// <param name="message">Message to logs</param>
        /// <param name="ex"> Exception to log</param>
        public void Error(string message, Exception ex) => log.Error(message, ex);


        /// <summary>
        /// Logs a fatal error message with his exception.
        /// </summary>
        /// <param name="message">Message to logs</param>
        /// <param name="ex"> Exception to log</param>
        public void Fatal(string message, Exception ex) => log.Fatal(message, ex);


        /// <summary>
        /// Logs a debug message with the property and the value.
        /// </summary>
        /// <param name="property">Property name to log</param>
        /// <param name="value">Property value to log</param>
        public void Debug(string property, string value) => log.Debug($"{property}: {value}");


        /// <summary>
        /// Retrieves the path to the log file.
        /// </summary>
        public string GetLogFilePath()
        {
            return Path.Combine(logDir, "app.log");
        }
    }
}