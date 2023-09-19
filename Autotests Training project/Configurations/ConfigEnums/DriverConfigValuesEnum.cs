using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Autotests_Training_project.Configurations
{
    public enum DriverConfigValuesEnum
    {
        DriverType,
        Headless,
        WindowWidth,
        WindowHeight,
        ImplicitWaitTime,
        ExplicitWaitTime,

        EdgeLocation,
        FirefoxLocation,
        ChromeLocation,
    }
    public static class DriverConfigValuesEnumExtension
    {
        public static string GetConfigValue(this DriverConfigValuesEnum value)
        {
            Configuration configuration = ConfigurationsEnum.Driver.GetConfiguration();
            return configuration.AppSettings.Settings[value.ToString()].Value;
        }
    }

    public enum DriverTypeEnum
    {
        Edge,
        Firefox,
        Chrome
    }
}
