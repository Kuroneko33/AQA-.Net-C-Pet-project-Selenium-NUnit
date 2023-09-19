using System.Configuration;

namespace Autotests_Training_project.Configurations
{
    public enum ConfigurationsEnum
    {
        Tests,
        Driver,
        DriverDevTools,
        Proxy,
        Addons,
    }
    public static class ConfigurationsEnumExtension
    {
        public static string GetPath(this ConfigurationsEnum config) => $@"Configurations\Config\{config}.config";
        public static Configuration GetConfiguration(this ConfigurationsEnum config)
        {
            Configuration applicationConfiguration = ConfigurationManager.OpenMappedExeConfiguration(
                new ExeConfigurationFileMap() { ExeConfigFilename = config.GetPath() },
                ConfigurationUserLevel.None);
            return applicationConfiguration;
        }
    }
}
