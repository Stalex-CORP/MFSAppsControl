using MFSAppsControl.Models;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text.Json;

namespace MFSAppsControl.Services
{
    public class ConfigurationService
    {
        private readonly string configFilePath;
        private static readonly JsonSerializerOptions options = new() { WriteIndented = true };
        private static readonly string systemLanguage = CultureInfo.InstalledUICulture.TwoLetterISOLanguageName == "fr" ? "fr" : "en";
        private static readonly ConfigurationModel defaultConfig = new() { Apps = [], Language = systemLanguage };

        public ConfigurationService(string? customPath = null)
        {
            configFilePath = customPath ?? Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Stalex", "MFSAppsControl", "config.json"
            );

            if (Debugger.IsAttached)
                configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "config.json");

            var dir = Path.GetDirectoryName(configFilePath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            if (!File.Exists(configFilePath))
            {
                var json = JsonSerializer.Serialize(defaultConfig, options);
                File.WriteAllText(configFilePath, json);
            }
        }

        public async Task<ConfigurationModel> LoadConfigurationAsync()
        {
            var fileContent = await File.ReadAllTextAsync(configFilePath);
            var configuration = JsonSerializer.Deserialize<ConfigurationModel>(fileContent, options);

            if (configuration != null)
            {
                configuration.Language ??= systemLanguage;
                configuration.Apps ??= [];
                await SaveConfigurationAsync(configuration);
                return configuration;
            }

            await SaveConfigurationAsync(defaultConfig);
            return defaultConfig;
        }

        public async Task SaveConfigurationAsync(ConfigurationModel configuration)
        {
            var json = JsonSerializer.Serialize(configuration, options);
            await File.WriteAllTextAsync(configFilePath, json);
        }
    }
}
