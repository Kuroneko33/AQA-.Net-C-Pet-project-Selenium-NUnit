using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Resources
{
    public class ResourcesPage : PageObject
    {
        public new const string BaseUrl = "https://resources.github.com";
        public ResourcesPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public ResourcesPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public ResourcesPage() : base(BaseUrl) { }


    }
}
