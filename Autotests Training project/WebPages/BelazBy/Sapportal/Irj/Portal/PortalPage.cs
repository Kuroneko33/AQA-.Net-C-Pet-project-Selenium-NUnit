using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.BelazBy.Sapportal.Irj.Portal
{
    public class PortalPage : PageObject
    {
        public new const string BaseUrl = IrjPage.BaseUrl + "/portal";
        public PortalPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public PortalPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public PortalPage() : base(BaseUrl) { }


    }
}
