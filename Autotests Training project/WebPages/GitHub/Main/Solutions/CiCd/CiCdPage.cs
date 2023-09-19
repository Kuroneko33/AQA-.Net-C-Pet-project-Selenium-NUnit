using OpenQA.Selenium;


namespace Autotests_Training_project.WebPages.GitHub.Main.Solutions.CiCd
{
    public class CiCdPage : PageObject
    {
        public new const string BaseUrl = SolutionsPage.BaseUrl + "/ci-cd";
        public CiCdPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public CiCdPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public CiCdPage() : base(BaseUrl) { }


    }
}
