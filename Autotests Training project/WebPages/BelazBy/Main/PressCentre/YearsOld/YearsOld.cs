using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.BelazBy.Main.PressCentre.YearsOld
{
    public class YearsOld : PageObject
    {
        public new const string BaseUrl = PressCentrePage.BaseUrl + "/75-years-old";
        public YearsOld(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public YearsOld(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public YearsOld() : base(BaseUrl) { }


    }
}
