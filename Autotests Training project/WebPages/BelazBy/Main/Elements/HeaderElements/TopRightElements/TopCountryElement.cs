using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.BelazBy.Main.Elements.HeaderElements.TopRightElements
{
    using Addons.Selenium;
    
    public class TopCountryElement : ElementObject
    {
        public TopCountryElement(IWebDriver driver, IWebElementSafe element) : base(driver, element) { }

        private IWebElementSafe globe;
        public IWebElementSafe Globe => globe ??= Element.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.Scope.Child.TagName("div").ClassName("header-main__top-country__globe"),
            By.CssSelector(":scope>div.header-main__top-country__globe"),
            By.XPath("./div[@class='header-main__top-country__globe']")));
        
        private IWebElementSafe text;
        public IWebElementSafe Text => text ??= Element.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.TagName("div").ClassName("header-main__top-country__text"),
            By.CssSelector("div.header-main__top-country__text"),
            By.XPath(".//div[@class='header-main__top-country__text']")));
    }
}
