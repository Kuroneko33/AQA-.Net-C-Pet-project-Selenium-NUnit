using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Main.Pricing
{
    using WebPages.GitHub.Main.Elements;
    using Addons.Selenium;

    public class PricingPage : PageObject
    {
        public new const string BaseUrl = MainPage.BaseUrl + "/pricing";
        public PricingPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public PricingPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public PricingPage() : base(BaseUrl) { }

        private HeaderElement header;
        public HeaderElement Header => header ??= new HeaderElement(Driver, Driver.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.TagName("header").ClassName("Header-old"),
            By.CssSelector("header.Header-old"),
            By.XPath("//header[contains(@class,'Header-old')]"))));
    }
}
