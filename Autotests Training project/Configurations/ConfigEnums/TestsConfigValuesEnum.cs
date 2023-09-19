using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Autotests_Training_project.Configurations
{
    public enum TestsConfigValuesEnum
    {

    }
    public static class TestsConfigValuesEnumExtension
    {
        public static string GetConfigValue(this TestsConfigValuesEnum value)
        {
            Configuration configuration = ConfigurationsEnum.Tests.GetConfiguration();
            return configuration.AppSettings.Settings[value.ToString()].Value;
        }
    }
}
