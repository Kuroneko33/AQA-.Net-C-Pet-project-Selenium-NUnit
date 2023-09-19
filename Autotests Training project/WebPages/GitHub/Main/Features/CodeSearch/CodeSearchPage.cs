using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Main.Features.CodeSearch
{
    public class CodeSearchPage : PageObject
    {
        public new const string BaseUrl = FeaturesPage.BaseUrl + "/code-search";
        public CodeSearchPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public CodeSearchPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public CodeSearchPage() : base(BaseUrl) { }


    }
}
