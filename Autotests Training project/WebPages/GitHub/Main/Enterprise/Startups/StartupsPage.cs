using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Main.Enterprise.Startups
{
    public class StartupsPage : PageObject
    {
        public new const string BaseUrl = EnterprisePage.BaseUrl + "/startups";
        public StartupsPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public StartupsPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public StartupsPage() : base(BaseUrl) { }


    }
}
