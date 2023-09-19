using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Main.Features.Discussions
{
    public class DiscussionsPage : PageObject
    {
        public new const string BaseUrl = FeaturesPage.BaseUrl + "/discussions";
        public DiscussionsPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public DiscussionsPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public DiscussionsPage() : base(BaseUrl) { }


    }
}
