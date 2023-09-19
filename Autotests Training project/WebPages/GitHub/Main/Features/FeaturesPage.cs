using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Main.Features
{
    public class FeaturesPage : PageObject
    {
        public new const string BaseUrl = MainPage.BaseUrl + "/features";
        public FeaturesPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public FeaturesPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public FeaturesPage() : base(BaseUrl) { }


    }
}
