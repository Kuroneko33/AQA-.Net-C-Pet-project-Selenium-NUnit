using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Main.Features.Copilot
{
    public class CopilotPage : PageObject
    {
        public new const string BaseUrl = FeaturesPage.BaseUrl + "/copilot";
        public CopilotPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public CopilotPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public CopilotPage() : base(BaseUrl) { }


    }
}
