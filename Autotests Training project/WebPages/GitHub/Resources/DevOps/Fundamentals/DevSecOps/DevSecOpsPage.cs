using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Resources.DevOps.Fundamentals.DevSecOps
{
    public class DevSecOpsPage : PageObject
    {
        public new const string BaseUrl = FundamentalsPage.BaseUrl + "/devsecops";
        public DevSecOpsPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public DevSecOpsPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public DevSecOpsPage() : base(BaseUrl) { }


    }
}
