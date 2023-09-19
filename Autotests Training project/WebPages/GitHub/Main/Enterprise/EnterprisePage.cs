using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Main.Enterprise
{
    public class EnterprisePage : PageObject
    {
        public new const string BaseUrl = MainPage.BaseUrl + "/enterprise";
        public EnterprisePage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public EnterprisePage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public EnterprisePage() : base(BaseUrl) { }


    }
}
