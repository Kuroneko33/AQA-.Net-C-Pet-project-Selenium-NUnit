using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Docs
{
    public class DocsPage : PageObject
    {
        public new const string BaseUrl = "https://docs.github.com";
        public static DocsPageLang Lang = DocsPageLang.Ru;
        public static string BaseUrl_WithLang = BaseUrl + "/" + Lang.GetValue();
        public DocsPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public DocsPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public DocsPage() : base(BaseUrl) { }


    }
    public enum DocsPageLang
    {
        Ru,
        En
    }
    public static class DocsPageLangExtension
    {
        public static string GetValue(this DocsPageLang lang) =>
            lang == DocsPageLang.Ru ? "ru" :
            lang == DocsPageLang.En ? "en" : throw new System.NotImplementedException();
    }
}
