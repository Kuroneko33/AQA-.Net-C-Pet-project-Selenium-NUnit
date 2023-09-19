using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Main.CustomerStories
{
    public class CustomerStoriesPage : PageObject
    {
        public new const string BaseUrl = MainPage.BaseUrl + "/customer-stories";
        public CustomerStoriesPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public CustomerStoriesPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public CustomerStoriesPage() : base(BaseUrl) { }


    }
}
