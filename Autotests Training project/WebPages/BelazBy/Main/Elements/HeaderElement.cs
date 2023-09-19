using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.BelazBy.Main.Elements
{
    using Addons.Selenium;
    using HeaderElements;

    public class HeaderElement : ElementObject
    {
        public HeaderElement(IWebDriver driver, IWebElementSafe element) : base(driver, element) { }

        private IWebElementSafe topInner;
        private IWebElementSafe _topInner => topInner ??= Element.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.TagName("div").ClassName("header-main__top-inner"),
            By.CssSelector("div.header-main__top-inner"),
            By.XPath(".//div[@class='header-main__top-inner']")));

        private TopLeftElement topLeft;
        public TopLeftElement TopLeft => topLeft ??= new TopLeftElement(Driver, _topInner.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.Scope.Child.TagName("div").ClassName("header-main__top-left"),
            By.CssSelector(":scope>div.header-main__top-left"),
            By.XPath("./div[@class='header-main__top-left']"))));

        private TopRightElement topRight;
        public TopRightElement TopRight => topRight ??= new TopRightElement(Driver, _topInner.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.Scope.Child.TagName("div").ClassName("header-main__top-right"),
            By.CssSelector(":scope>div.header-main__top-right"),
            By.XPath("./div[@class='header-main__top-right']"))));
    }
}
