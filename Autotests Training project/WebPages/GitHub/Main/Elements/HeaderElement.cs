using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Main.Elements
{
    using WebPages.GitHub.Main.Elements.HeaderElements;
    using Addons.Selenium;

    public class HeaderElement : ElementObject
    {
        public HeaderElement(IWebDriver driver, IWebElementSafe element) : base(driver, element) { }

        private IWebElementSafe logo;
        public IWebElementSafe Logo => logo ??= Element.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.TagName("a").Attribute("aria-label", "Homepage"),
            By.CssSelector("a[aria-label='Homepage']"),
            By.XPath(".//a[@aria-label='Homepage']")));

        private IWebElementSafe toggleNavigationButton;
        public IWebElementSafe ToggleNavigationButton => toggleNavigationButton ??= Element.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.TagName("button").ClassName("Button--link").Attribute("aria-label", "Toggle navigation"),
            By.CssSelector("button.Button--link[aria-label='Toggle navigation']"),
            By.XPath(".//button[contains(@class, 'Button--link')][@aria-label='Toggle navigation']")));

        private readonly string _navMenuSeleniumSelector = ByCssBuilder.NewInstance.TagName("nav").Attribute("aria-label", "Global").CssSelectorString;
        private readonly string _navMenuCssSelector = "nav[aria-label='Global']";
        private readonly string _navMenuXPathSelector = ".//nav[@aria-label='Global']";
        private NavMenuElement navMenu;
        public NavMenuElement NavMenu => navMenu ??= new NavMenuElement(Driver, Element.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.CssSelector(_navMenuSeleniumSelector),
            By.CssSelector(_navMenuCssSelector),
            By.XPath(_navMenuXPathSelector))));

        private SearchAndSignElement searchAndSign;
        public SearchAndSignElement SearchAndSign => searchAndSign ??= new SearchAndSignElement(Driver, Element.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.CssSelector(_navMenuSeleniumSelector).AdjacentSibling.TagName("div"),
            By.CssSelector(_navMenuCssSelector + "+div"),
            By.XPath(_navMenuXPathSelector + "/following-sibling::div[1]"))));
    }
}
