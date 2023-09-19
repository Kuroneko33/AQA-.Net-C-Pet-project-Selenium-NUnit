using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.BelazBy.Main.About.BelazGlobal
{
    public class BelazGlobalPage : PageObject
    {
        public new const string BaseUrl = AboutPage.BaseUrl + "/belaz-global";
        public BelazGlobalPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public BelazGlobalPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public BelazGlobalPage() : base(BaseUrl) { }


    }
}
