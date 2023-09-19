using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Main.Elements.HeaderElements
{
    using Addons.Selenium;

    public class SearchAndSignElement : ElementObject
    {
        public SearchAndSignElement(IWebDriver driver, IWebElementSafe element) : base(driver, element) { }


        private IWebElementSafe signInButton;
        public IWebElementSafe SignInButton => signInButton ??= Element.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.Scope.Child.TagName("div")[2].TagName("a"),
            By.CssSelector(":scope>div:nth-of-type(2)>a"),
            By.XPath("./div[2]/a")));

        private IWebElementSafe searchButton;
        public IWebElementSafe SearchButton => searchButton ??= Element.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.TagName("button").ClassName("header-search-button"),
            By.CssSelector("button.header-search-button"),
            By.XPath(".//button[contains(@class,'header-search-button')]")));

        private IWebElementSafe searchPlaceholder;
        public IWebElementSafe SearchPlaceholder => searchPlaceholder ??= SearchButton.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.TagName("span"),
            By.CssSelector("span"),
            By.XPath(".//span")));

        private IWebElementSafe searchInput;
        public IWebElementSafe SearchInput => searchInput ??= Element.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.TagName("input").Attribute("name", "query-builder-test"),
            By.CssSelector("input[name='query-builder-test']"),
            By.XPath(".//input[@name='query-builder-test']")));
    }
}
