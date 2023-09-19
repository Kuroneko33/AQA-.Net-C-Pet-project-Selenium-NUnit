using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Skills
{
    public class SkillsPage : PageObject
    {
        public new const string BaseUrl = "https://skills.github.com";
        public SkillsPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public SkillsPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public SkillsPage() : base(BaseUrl) { }


    }
}
