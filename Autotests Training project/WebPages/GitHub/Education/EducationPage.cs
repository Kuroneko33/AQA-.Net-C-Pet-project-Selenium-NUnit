using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Education
{
    public class EducationPage : PageObject
    {
        public new const string BaseUrl = "https://education.github.com/";
        public EducationPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public EducationPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public EducationPage() : base(BaseUrl) { }


    }
}
