using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.BelazBy.Main.Elements.HeaderElements
{
    using Addons.Selenium;
    using TopLeftElements;

    public class TopLeftElement : ElementObject
    {
        public TopLeftElement(IWebDriver driver, IWebElementSafe element) : base(driver, element) { }

        private TopMenuElement topMenu;
        public TopMenuElement TopMenu => topMenu ??= new TopMenuElement(Driver, Element.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.Scope.Child.TagName("div").ClassName("header-main__top-menu"),
            By.CssSelector(":scope>div.header-main__top-menu"),
            By.XPath("./div[@class='header-main__top-menu']"))));
    }
}
