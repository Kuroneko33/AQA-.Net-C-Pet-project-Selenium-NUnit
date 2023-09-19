using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Main.Team
{
    public class TeamPage : PageObject
    {
        public new const string BaseUrl = MainPage.BaseUrl + "/team";
        public TeamPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public TeamPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public TeamPage() : base(BaseUrl) { }


    }
}
