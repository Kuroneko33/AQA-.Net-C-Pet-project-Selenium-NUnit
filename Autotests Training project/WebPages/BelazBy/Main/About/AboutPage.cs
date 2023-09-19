using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.BelazBy.Main.About
{
    public class AboutPage : PageObject
    {
        public new const string BaseUrl = MainPage.BaseUrl + "/about";
        public AboutPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public AboutPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public AboutPage() : base(BaseUrl) { }


    }
}
