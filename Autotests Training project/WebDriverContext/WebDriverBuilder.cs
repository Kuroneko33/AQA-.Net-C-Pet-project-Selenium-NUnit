using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chrome.ChromeDriverExtensions;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using Autotests_Training_project.Configurations;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.DevTools.V115.Emulation;

namespace Autotests_Training_project.WebDriverContext
{
    public class WebDriverBuilder
    {
        public static WebDriverBuilder NewInstance => new WebDriverBuilder();

        public WebDriverBuilder() 
        {
            _applyConfigurations();
        }
        private void _applyConfigurations()
        {
            #region Driver.config
            //DriverType
            try
            {
                string configValue = DriverConfigValuesEnum.DriverType.GetConfigValue();
                DriverTypeEnum driverType = Enum.Parse<DriverTypeEnum>(configValue);
                DriverType = driverType;
            }
            catch (Exception)
            {
                //default value
                DriverType = DriverTypeEnum.Chrome;
                Console.WriteLine($"Driver.config DriverType error, using default DriverType: {DriverType}");
            }

            //Headless
            try
            {
                string configValue = DriverConfigValuesEnum.Headless.GetConfigValue();
                bool headless = Boolean.Parse(configValue);
                Headless = headless;
            }
            catch (Exception)
            {
                //default value
                Headless = false;
                Console.WriteLine($"Driver.config Headless error, using default Headless: {Headless}");
            }

            //WindowWidth
            try
            {
                string configValue = DriverConfigValuesEnum.WindowWidth.GetConfigValue();
                int width = Int32.Parse(configValue);
                WindowWidth = width;
            }
            catch (Exception)
            {
                //default value
                WindowWidth = 1280;
                Console.WriteLine($"Driver.config WindowWidth error, using default WindowWidth: {WindowWidth}");
            }
            //WindowHeight
            try
            {
                string configValue = DriverConfigValuesEnum.WindowHeight.GetConfigValue();
                int width = Int32.Parse(configValue);
                WindowHeight = width;
            }
            catch (Exception)
            {
                //default value
                WindowHeight = 1280;
                Console.WriteLine($"Driver.config WindowHeight error, using default WindowHeight: {WindowHeight}");
            }

            //ImplicitWaitTime
            try
            {
                string configValue = DriverConfigValuesEnum.ImplicitWaitTime.GetConfigValue();
                int time = Int32.Parse(configValue);
                ImplicitWaitTime = TimeSpan.FromMilliseconds(time);
            }
            catch (Exception)
            {
                //default value
                ImplicitWaitTime = TimeSpan.FromMilliseconds(2000);
                Console.WriteLine($"Driver.config ImplicitWaitTime error, using default ImplicitWaitTime.FromMilliseconds: {ImplicitWaitTime.TotalMilliseconds}");
            }
            //ExplicitWaitTime
            try
            {
                string configValue = DriverConfigValuesEnum.ExplicitWaitTime.GetConfigValue();
                int time = Int32.Parse(configValue);
                ExplicitWaitTime = TimeSpan.FromMilliseconds(time);
            }
            catch (Exception)
            {
                //default value
                ExplicitWaitTime = TimeSpan.FromMilliseconds(10000);
                Console.WriteLine($"Driver.config ExplicitWaitTime error, using default ExplicitWaitTime.FromMilliseconds: {ExplicitWaitTime.TotalMilliseconds}");
            }
            #endregion Driver.config

            #region DriverDevTools.config
            #region DeviceModeSetting
            //IsEnabled
            try
            {
                string configValue = DriverDevToolsConfigValuesEnum.IsEnabled.GetConfigValue();
                var isEnabled = Boolean.Parse(configValue);
                IsDevToolsSessionEnabled = isEnabled;
            }
            catch (Exception)
            {
                //default value
                IsDevToolsSessionEnabled = false;
                Console.WriteLine($"DriverDevTools.config IsEnabled error, using default IsEnabled: {IsDevToolsSessionEnabled}");
            }
            if (IsDevToolsSessionEnabled)
            {
                //Mobile
                try
                {
                    string configValue = DriverDevToolsConfigValuesEnum.Mobile.GetConfigValue();
                    var isMobile = Boolean.Parse(configValue);
                    DeviceMetrics.Mobile = isMobile;
                }
                catch (Exception)
                {
                    //default value
                    DeviceMetrics.Mobile = false;
                    Console.WriteLine($"DriverDevTools.config Mobile error, using default Mobile: {DeviceMetrics.Mobile}");
                }

                //Width
                try
                {
                    string configValue = DriverDevToolsConfigValuesEnum.Width.GetConfigValue();
                    var width = Int32.Parse(configValue);
                    DeviceMetrics.Width = width;
                }
                catch (Exception)
                {
                    //default value
                    DeviceMetrics.Width = 1280;
                    Console.WriteLine($"DriverDevTools.config Width error, using default Width: {DeviceMetrics.Width}");
                }

                //Height
                try
                {
                    string configValue = DriverDevToolsConfigValuesEnum.Height.GetConfigValue();
                    var height = Int32.Parse(configValue);
                    DeviceMetrics.Height = height;
                }
                catch (Exception)
                {
                    //default value
                    DeviceMetrics.Height = 1280;
                    Console.WriteLine($"DriverDevTools.config Height error, using default Height: {DeviceMetrics.Height}");
                }

                //DeviceScaleFactor
                try
                {
                    string configValue = DriverDevToolsConfigValuesEnum.DeviceScaleFactor.GetConfigValue();
                    var deviceScaleFactor = Int32.Parse(configValue);
                    DeviceMetrics.DeviceScaleFactor = deviceScaleFactor;
                }
                catch (Exception)
                {
                    //default value
                    DeviceMetrics.DeviceScaleFactor = 75;
                    Console.WriteLine($"DriverDevTools.config DeviceScaleFactor error, using default DeviceScaleFactor: {DeviceMetrics.DeviceScaleFactor}");
                }
            }
            #endregion DeviceModeSetting
            #endregion DriverDevTools.config

            #region Proxy.config
            try
            {
                string enableProxy = ProxyConfigValuesEnum.EnableProxy.GetConfigValue();
                if (string.IsNullOrEmpty(enableProxy))
                    throw new Exception();
                if (Boolean.Parse(enableProxy))
                {
                    string host = ProxyConfigValuesEnum.Host.GetConfigValue();
                    if (string.IsNullOrEmpty(host))
                        throw new Exception();
                    int port = Int32.Parse(ProxyConfigValuesEnum.Port.GetConfigValue());
                    string userName = ProxyConfigValuesEnum.UserName.GetConfigValue();
                    string password = ProxyConfigValuesEnum.Password.GetConfigValue();

                    Proxy = new WebDriverProxy(host, port, userName, password);
                }
                else
                    Proxy = null;
            }
            catch (Exception)
            {
                Console.WriteLine("Proxy.config error, using no proxy");
                Proxy = null;
            }
            #endregion Proxy.config
        }
        public WebDriverProxy Proxy { get; set; }
        public DriverTypeEnum DriverType { get; set; }
        public bool Headless { get; set; }
        public int WindowWidth { get; set; }
        public int WindowHeight { get; set; }
        public TimeSpan ImplicitWaitTime { get; set; }
        public TimeSpan ExplicitWaitTime { get; set; }
        private bool _isDevToolsSessionEnabled;
        public bool IsDevToolsSessionEnabled
        { 
            get
            {
                return _isDevToolsSessionEnabled;
            }
            set
            {
                _isDevToolsSessionEnabled = value;

                if (value)
                {
                    DeviceMetrics = new SetDeviceMetricsOverrideCommandSettings()
                    {
                        Mobile = false,
                        Width = 1280,
                        Height = 1280,
                        DeviceScaleFactor = 75
                    };
                }
                else
                    DeviceMetrics = null;
            }
        }
        private DevToolsSession _devToolsSession;
        public SetDeviceMetricsOverrideCommandSettings DeviceMetrics { get; private set; }
        public void ApplyDeviceMetrics()
        {
            if (IsDevToolsSessionEnabled)
            {
                EmulationAdapter getEmulation() => 
                    _devToolsSession
                    .GetVersionSpecificDomains<OpenQA.Selenium.DevTools.V115.DevToolsSessionDomains>()
                    .Emulation;

                void apply()
                {
                    getEmulation().ClearDeviceMetricsOverride();
                    getEmulation().SetDeviceMetricsOverride(DeviceMetrics);
                }

                try
                {
                    apply();
                }
                catch (Exception)
                {
                    _getDevToolsSession(Driver);
                    apply();
                }
            }
        }
        private void _getDevToolsSession(IWebDriver driver)
        {
            if (driver is FirefoxDriver firefox)
                _devToolsSession = firefox.GetDevToolsSession();
            else if (driver is ChromeDriver chrome)
                _devToolsSession = chrome.GetDevToolsSession();
            else if (driver is EdgeDriver edge)
                _devToolsSession = edge.GetDevToolsSession();
        }

        private FirefoxOptions _firefoxOptions
        {
            get
            {
                var options = new FirefoxOptions();
                if(Headless)
                    options.AddArguments(new List<string>() { "--headless", });

                try
                {
                    string location = DriverConfigValuesEnum.FirefoxLocation.GetConfigValue();
                    if (!string.IsNullOrEmpty(location))
                        options.BrowserExecutableLocation = location;
                }
                catch (Exception)
                {
                    Console.WriteLine("Driver.config FirefoxLocation error");
                }

                if(Proxy != null)
                {
                    Proxy proxy = new Proxy();
                    proxy.Kind = ProxyKind.Manual;
                    proxy.IsAutoDetect = false;
                    proxy.HttpProxy = proxy.SslProxy = $"{Proxy.Host}:{Proxy.Port}";
                    options.Proxy = proxy;
                    options.AddArgument("ignore-certificate-errors");
                    //TODO: Creditionals
                }

                return options;
            }
        }
        private ChromeOptions _chromeOptions
        {
            get
            {
                var options = new ChromeOptions();
                if(Headless)
                    options.AddArguments(new List<string>() { "headless", });

                try
                {
                    string location = DriverConfigValuesEnum.ChromeLocation.GetConfigValue();
                    if (!string.IsNullOrEmpty(location))
                        options.BinaryLocation = location;
                }
                catch (Exception)
                {
                    Console.WriteLine("Driver.config ChromeLocation error");
                }

                if (Proxy != null)
                    options.AddHttpProxy(Proxy.Host, Proxy.Port, Proxy.UserName, Proxy.Password);

                return options;
            }
        }
        private EdgeOptions _edgeOptions
        {
            get
            {
                var options = new EdgeOptions();

                if (Headless)
                    options.AddArguments(new List<string>() { "headless", });

                try
                {
                    string location = DriverConfigValuesEnum.EdgeLocation.GetConfigValue();
                    if (!string.IsNullOrEmpty(location))
                        options.BinaryLocation = location;
                }
                catch (Exception)
                {
                    Console.WriteLine("Driver.config EdgeLocation error");
                }

                if (Proxy != null)
                {
                    //TODO: Proxy
                    string proxyError = "Edge proxy is not implemented, please use another Driver.config DriverType or set Proxy.config EnableProxy to false.";
                    Console.WriteLine(proxyError);
                    throw new NotImplementedException(proxyError);
                }

                return options;
            }
        }

        private IWebDriver driver;
        public IWebDriver Driver
        {
            get
            {
                if (driver != null)
                    return driver;

                driver = 
                    DriverType == DriverTypeEnum.Firefox ? new FirefoxDriver(_firefoxOptions) : 
                    DriverType == DriverTypeEnum.Chrome ? new ChromeDriver(_chromeOptions) :
                    DriverType == DriverTypeEnum.Edge ? new EdgeDriver(_edgeOptions) :
                    new EdgeDriver() as WebDriver;

                driver.Manage().Timeouts().ImplicitWait = ImplicitWaitTime;
                driver.Manage().Window.Size = new System.Drawing.Size(width: WindowWidth, height: WindowHeight);

                if (IsDevToolsSessionEnabled)
                {
                    _getDevToolsSession(driver);

                    _devToolsSession
                        .GetVersionSpecificDomains<OpenQA.Selenium.DevTools.V115.DevToolsSessionDomains>()
                        .Emulation
                        .SetDeviceMetricsOverride(DeviceMetrics);
                }

                return driver;
            }
        }
        public IWebDriver CreateNewDriver()
        {
            driver = null;
            return Driver;
        }
        /// <summary>
        /// ExplicitWait
        /// </summary>
        public static WebDriverWait GetDriverWait(IWebDriver driver, TimeSpan explicitWaitTime) => new WebDriverWait(driver, explicitWaitTime);
        public virtual WebDriverWait GetDriverWait(IWebDriver driver) => GetDriverWait(driver, ExplicitWaitTime);
        public IWebDriver ReloadDriver()
        {
            driver = null;
            return Driver;
        }
    }
}
