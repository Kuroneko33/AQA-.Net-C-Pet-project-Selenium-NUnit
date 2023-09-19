using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Main.Features.Security
{
    public class SecurityPage : PageObject
    {
        public new const string BaseUrl = FeaturesPage.BaseUrl + "/security";
        public SecurityPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public SecurityPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public SecurityPage() : base(BaseUrl) { }


    }
}
