using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Autotests_Training_project.Configurations
{
    public enum ProxyConfigValuesEnum
    {
        EnableProxy,
        Host,
        Port,
        UserName,
        Password
    }
    public static class ProxyConfigValuesEnumExtension
    {
        public static string GetConfigValue(this ProxyConfigValuesEnum value)
        {
            Configuration configuration = ConfigurationsEnum.Proxy.GetConfiguration();
            return configuration.AppSettings.Settings[value.ToString()].Value;
        }
    }
}
