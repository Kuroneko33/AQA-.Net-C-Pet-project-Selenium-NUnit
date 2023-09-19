using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.BelazBy.Sapportal.Irj
{
    public class IrjPage : PageObject
    {
        public new const string BaseUrl = "http://sapportal.belaz.minsk.by/irj";
        public IrjPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public IrjPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public IrjPage() : base(BaseUrl) { }


    }
}
