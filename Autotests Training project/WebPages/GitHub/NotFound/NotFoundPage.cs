using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.NotFound
{
    public class NotFoundPage : PageObject
    {
        public new const string BaseUrl = "https://github.com//github404PageNotFound404";
        public NotFoundPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public NotFoundPage(IWebDriver driver, string url) : base(driver, url) { }
        public NotFoundPage() : base(BaseUrl) { }

    }
}
