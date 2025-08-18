using System.Globalization;
using System.Resources;

namespace MFSAppsControl.Services
{
    public class LanguageService
    {
        private readonly ResourceManager _resourceManager;
        public CultureInfo _currentCulture;
        public event Action? LanguageChanged;

        /// <summary>
        /// Initializes a new instance with the default culture based on the current system settings.
        /// </summary>
        public LanguageService()
        {
            _resourceManager = new ResourceManager("MFSAppsControl.Resources.messages", typeof(LanguageService).Assembly);
            _currentCulture = CultureInfo.CurrentCulture;
        }

        /// <summary>
        /// Gets the localized message for the specified key.
        /// </summary>
        /// <param name="key"> The key for the localized message.</param>
        public string GetMessage(string key)
        {
            return _resourceManager.GetString(key, _currentCulture)!;
        }


        /// <summary>
        /// Sets the target culture for localization.
        /// </summary>
        /// <param name="cultureCode">The culture code ("en" or "fr").</param>
        public void SetCulture(string cultureCode)
        {
            _currentCulture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentUICulture = _currentCulture;
            Thread.CurrentThread.CurrentCulture = _currentCulture;
            LanguageChanged?.Invoke();
        }
    }
}
