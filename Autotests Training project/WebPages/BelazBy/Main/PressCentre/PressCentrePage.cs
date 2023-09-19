using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.BelazBy.Main.PressCentre
{
    public class PressCentrePage : PageObject
    {
        public new const string BaseUrl = MainPage.BaseUrl + "/press-centre";
        public PressCentrePage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public PressCentrePage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public PressCentrePage() : base(BaseUrl) { }


    }
}
