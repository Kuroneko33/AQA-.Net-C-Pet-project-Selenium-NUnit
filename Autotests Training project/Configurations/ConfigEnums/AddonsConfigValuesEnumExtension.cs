using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Autotests_Training_project.Configurations
{
    public enum AddonsConfigValuesEnum
    {
        LocatorType
    }
    public static class AddonsConfigValuesEnumExtension
    {
        public static string GetConfigValue(this AddonsConfigValuesEnum value)
        {
            Configuration configuration = ConfigurationsEnum.Addons.GetConfiguration();
            return configuration.AppSettings.Settings[value.ToString()].Value;
        }
    }

    public enum LocatorTypeEnum
    {
        Selenium,
        CssSelector,
        XPath
    }
}
