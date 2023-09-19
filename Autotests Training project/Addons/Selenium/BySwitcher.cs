using OpenQA.Selenium;
using System;

namespace Autotests_Training_project.Addons.Selenium
{
    using Configurations;

    /// <summary>
    /// Используется для отработки навыка написания разных типов локаторов
    /// </summary>
    public static class BySwitcher
    {
        static BySwitcher()
        {
            _applyConfigurations();
        }
        private static void _applyConfigurations()
        {
            #region Tests.config
            //LocatorType
            try
            {
                string configValue = AddonsConfigValuesEnum.LocatorType.GetConfigValue();
                LocatorTypeEnum locatorType = Enum.Parse<LocatorTypeEnum>(configValue);
                LocatorType = locatorType;
            }
            catch (Exception)
            {
                //default value
                LocatorType = LocatorTypeEnum.CssSelector;
                Console.WriteLine($"Tests.config LocatorType error, using default LocatorType: {LocatorType}");
            }
            #endregion Tests.config
        }
        public static LocatorTypeEnum LocatorType { get; set; }

        /// <summary>
        /// Используется для отработки навыка написания разных типов локаторов
        /// </summary>
        public static By SelectFrom(By selenium, By css, By xPath) =>
            LocatorType == LocatorTypeEnum.Selenium ? selenium :
            LocatorType == LocatorTypeEnum.CssSelector ? css :
            LocatorType == LocatorTypeEnum.XPath ? xPath : 
            null;
    }
}
