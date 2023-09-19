using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Main.Features.CodeSpaces
{
    public class CodeSpacesPage : PageObject
    {
        public new const string BaseUrl = FeaturesPage.BaseUrl + "/codespaces";
        public CodeSpacesPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public CodeSpacesPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public CodeSpacesPage() : base(BaseUrl) { }


    }
}
