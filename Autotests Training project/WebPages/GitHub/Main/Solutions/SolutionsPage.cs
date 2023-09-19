using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Main.Solutions
{
    public class SolutionsPage : PageObject
    {
        public new const string BaseUrl = MainPage.BaseUrl + "/solutions";
        public SolutionsPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public SolutionsPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public SolutionsPage() : base(BaseUrl) { }


    }
}
