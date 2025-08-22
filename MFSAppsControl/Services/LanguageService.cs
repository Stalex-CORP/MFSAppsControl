using System.Globalization;
using System.Resources;

namespace MFSAppsControl.Services
{
    public class LanguageService
    {
        private readonly ResourceManager resourceManager;
        public CultureInfo currentCulture = CultureInfo.InstalledUICulture;
        public event Action? LanguageChanged;

        /// <summary>
        /// Initializes a new instance with the default culture based on the current system settings.
        /// </summary>
        public LanguageService()
        {
            resourceManager = new ResourceManager("MFSAppsControl.Resources.messages", typeof(LanguageService).Assembly);
        }

        /// <summary>
        /// Gets the localized message for the specified key.
        /// </summary>
        /// <param name="key"> The key for the localized message.</param>
        public string GetMessage(string key)
        {
            return resourceManager.GetString(key, currentCulture)!;
        }


        /// <summary>
        /// Sets the target culture for localization.
        /// </summary>
        /// <param name="cultureCode">The culture code ("en" or "fr").</param>
        public void SetCulture(string cultureCode)
        {
            currentCulture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentUICulture = currentCulture;
            Thread.CurrentThread.CurrentCulture = currentCulture;
            LanguageChanged?.Invoke();
        }
    }
}
