using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Autotests_Training_project.WebPages
{
    using WebDriverContext;

    public class PageObject : IDisposable
    {
        /// <summary>
        /// Базовый Url страницы
        /// </summary>
        public const string BaseUrl = "";
        public PageObject(IWebDriver driver, UrlSource urlSource, string pageBaseUrl = null)
        {
            this.driver = driver;
            if (urlSource == UrlSource.PageBaseUrl)
            {
                _urlToLoad = pageBaseUrl;
                _needsLazyReload = true;
            }
            else if (urlSource == UrlSource.Driver)
            {
                _urlToLoad = driver.Url;
                _needsLazyReload = false;
            }
        }
        public PageObject(string pageBaseUrl)
        {
            _urlToLoad = pageBaseUrl;
            _needsLazyReload = true;
        }
        public PageObject(IWebDriver driver, string customUrl)
        {
            this.driver = driver;
            _urlToLoad = customUrl;
            _needsLazyReload = true;
        }

        /// <summary>
        /// Url, используемый для (пере)загрузки страницы
        /// </summary>
        private string _urlToLoad = BaseUrl;
        /// <summary>
        /// Если в конструктор передан url, то страница нуждается в (пере)загрузке
        /// Если используется url переданного драйвера, то не нуждается
        /// </summary>
        private bool _needsLazyReload = false;

        private WebDriverBuilder webDriverBuilder;
        public WebDriverBuilder WebDriverBuilder { get => webDriverBuilder ??= new WebDriverBuilder(); set => webDriverBuilder = value; }
        private IWebDriver driver;
        public virtual IWebDriver Driver
        {
            get
            {
                if (driver is null)
                    CreateNewDriver();

                if (_needsLazyReload)
                {
                    driver.Navigate().GoToUrl(_urlToLoad);
                    _needsLazyReload = false;
                }

                return driver;
            }
        }
        public void CreateNewDriver()
        {
            driver = WebDriverBuilder.Driver;
            _needsLazyReload = true;
        }
        public void CreateNewDriver(WebDriverBuilder webDriverBuilder)
        {
            WebDriverBuilder = webDriverBuilder;
            CreateNewDriver();
        }
        /// <summary>
        /// Перезагрузить страницу используя переданный url
        /// </summary>
        public void ReloadPage(string url) => Driver.Navigate().GoToUrl(url);
        /// <summary>
        /// Перезагрузить страницу по ее изначальному Url
        /// </summary>
        public void ReloadPage()
        {
            ReloadPage(_urlToLoad);
            _needsLazyReload = false;
        }
        /// <summary>
        /// Перезагрузить страницу по ее текущему Url
        /// </summary>
        public void RefreshPage() => Driver.Navigate().Refresh();
        /// <summary>
        /// ExplicitWait
        /// </summary>
        public virtual WebDriverWait Wait => WebDriverBuilder.GetDriverWait(Driver);
        public string Url => Driver.Url;
        public virtual void Dispose()
        {
            driver?.Dispose();
        }
    }
    public enum UrlSource
    {
        PageBaseUrl,
        Driver
    }
}
