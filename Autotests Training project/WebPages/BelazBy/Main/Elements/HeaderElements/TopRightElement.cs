using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.BelazBy.Main.Elements.HeaderElements
{
    using Addons.Selenium;
    using TopRightElements;

    public class TopRightElement : ElementObject
    {
        public TopRightElement(IWebDriver driver, IWebElementSafe element) : base(driver, element) { }

        private TopCountryElement topCountry;
        public TopCountryElement TopCountry => topCountry ??= new TopCountryElement(Driver, Element.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.Scope.Child.TagName("div").ClassName("header-main__top-country"),
            By.CssSelector(":scope>div.header-main__top-country"),
            By.XPath("./div[@class='header-main__top-country']"))));

        private TopLangElement topLang;
        public TopLangElement TopLang => topLang ??= new TopLangElement(Driver, Element.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.Scope.Child.TagName("div").ClassName("header-main__top-lang__wrapper"),
            By.CssSelector(":scope>div.header-main__top-lang__wrapper"),
            By.XPath("./div[@class='header-main__top-lang__wrapper']"))));
    }
}
