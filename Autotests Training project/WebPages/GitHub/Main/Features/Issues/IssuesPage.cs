using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Main.Features.Issues
{
    public class IssuesPage : PageObject
    {
        public new const string BaseUrl = FeaturesPage.BaseUrl + "/issues";
        public IssuesPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public IssuesPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public IssuesPage() : base(BaseUrl) { }


    }
}
