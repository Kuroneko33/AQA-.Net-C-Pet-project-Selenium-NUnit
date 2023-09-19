using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Autotests_Training_project.Configurations
{
    public enum DriverDevToolsConfigValuesEnum
    {
        IsEnabled,
        Mobile,
        Width,
        Height,
        DeviceScaleFactor,
    }
    public static class DriverDevToolsConfigValuesEnumExtension
    {
        public static string GetConfigValue(this DriverDevToolsConfigValuesEnum value)
        {
            Configuration configuration = ConfigurationsEnum.DriverDevTools.GetConfiguration();
            return configuration.AppSettings.Settings[value.ToString()].Value;
        }
    }
}
