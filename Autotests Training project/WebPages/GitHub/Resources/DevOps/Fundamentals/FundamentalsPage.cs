using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Resources.DevOps.Fundamentals
{
    public class FundamentalsPage : PageObject
    {
        public new const string BaseUrl = DevOpsPage.BaseUrl + "/fundamentals";
        public FundamentalsPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public FundamentalsPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public FundamentalsPage() : base(BaseUrl) { }


    }
}
