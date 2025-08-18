using MFSAppsControl.Services;

namespace MFSAppsControlTests.Mocks
{
    public class MockLoggerService<T> : ILoggerService<T>
    {
        public void Info(string message) { }
        public void Warn(string message) { }
        public void Error(string message, Exception ex) { }
        public void Fatal(string message, Exception ex) { }
        public void Debug(string property, string value) { }
        public string GetLogFilePath() => string.Empty;
    }
}
