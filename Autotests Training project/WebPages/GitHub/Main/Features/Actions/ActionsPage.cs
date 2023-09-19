using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Main.Features.Actions
{
    public class ActionsPage : PageObject
    {
        public new const string BaseUrl = FeaturesPage.BaseUrl + "/actions";
        public ActionsPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public ActionsPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public ActionsPage() : base(BaseUrl) { }


    }
}
