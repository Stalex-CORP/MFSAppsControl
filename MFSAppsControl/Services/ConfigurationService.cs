using MFSAppsControl.Models;
using System.IO;
using System.Text.Json;

namespace MFSAppsControl.Services
{
    public class ConfigurationService
    {
        private readonly string configFilePath;
        private static readonly JsonSerializerOptions options = new() { WriteIndented = true };

        public ConfigurationService(string? customPath = null)
        {
            configFilePath = customPath ?? Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Stalex", "MFSAppsControl", "config.json"
            );
            var dir = Path.GetDirectoryName(configFilePath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            if (!File.Exists(configFilePath))
            {
                var defaultConfig = new ConfigurationModel { Apps = [], Language = "en" };
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
                configuration.Language ??= "en";
                configuration.Apps ??= [];
            }

            return configuration ?? new ConfigurationModel { Apps = [], Language = "en" };
        }

        public async Task SaveConfigurationAsync(ConfigurationModel configuration)
        {
            var json = JsonSerializer.Serialize(configuration, options);
            await File.WriteAllTextAsync(configFilePath, json);
        }
    }
}
