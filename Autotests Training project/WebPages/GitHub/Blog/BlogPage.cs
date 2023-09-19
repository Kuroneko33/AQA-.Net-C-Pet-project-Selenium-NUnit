using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Blog
{
    public class BlogPage : PageObject
    {
        public new const string BaseUrl = "https://github.blog";
        public BlogPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public BlogPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public BlogPage() : base(BaseUrl) { }


    }
}