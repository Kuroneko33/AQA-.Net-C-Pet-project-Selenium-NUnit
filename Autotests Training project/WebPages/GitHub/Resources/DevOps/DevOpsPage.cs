using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Resources.DevOps
{
    public class DevOpsPage : PageObject
    {
        public new const string BaseUrl = ResourcesPage.BaseUrl + "/devops";
        public DevOpsPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public DevOpsPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public DevOpsPage() : base(BaseUrl) { }


    }
}
