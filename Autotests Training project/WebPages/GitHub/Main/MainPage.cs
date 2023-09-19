using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Main
{
    using Addons.Selenium;
    using Elements;
    using Search;
    using Pricing;

    public class MainPage : PageObject
    {
        public new const string BaseUrl = "https://github.com";
        public MainPage(IWebDriver driver, UrlSource urlSource)  : base(driver, urlSource, BaseUrl) { }
        public MainPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public MainPage() : base(BaseUrl) { }

        private IWebElementSafe heading;
        public IWebElementSafe Heading => heading ??= Driver.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.TagName("main").Descendant.TagName("h1"),
            By.CssSelector("main h1"),
            By.XPath("//main//h1")));

        private HeaderElement header;
        public HeaderElement Header => header ??= new HeaderElement(Driver, Driver.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.TagName("header").ClassName("Header-old"),
            By.CssSelector("header.Header-old"),
            By.XPath("//header[contains(@class,'Header-old')]"))));


        private SearchPage search;
        public SearchPage Search => search ??= new SearchPage(Driver, UrlSource.PageBaseUrl);

        private PricingPage pricing;
        public PricingPage Pricing => pricing ??= new PricingPage(Driver, UrlSource.PageBaseUrl);
    }
}