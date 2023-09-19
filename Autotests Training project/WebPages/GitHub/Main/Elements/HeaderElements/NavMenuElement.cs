using OpenQA.Selenium;
using System.Collections.Generic;

namespace Autotests_Training_project.WebPages.GitHub.Main.Elements.HeaderElements
{
    using WebPages.GitHub.Main.Elements.HeaderElements.NavMenuElements;
    using WebPages.GitHub.Main.Pricing;
    using Addons.Selenium;

    public class NavMenuElement : ElementObject
    {
        public NavMenuElement(IWebDriver driver, IWebElementSafe element) : base(driver, element) { }

        public static class Width_Adaptivity_Boundary
        {
            public const int Collapsing = 1010;
            public const int Dispayling = 1011;
        }

        private IList<IWebElementSafe> menuElements;
        private IList<IWebElementSafe> _menuElements => menuElements ??= Element.FindElementsSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.Scope.Child.TagName("ul").Child.TagName("li"),
            By.CssSelector($":scope>ul>li"),
            By.XPath($"./ul/li")));

        private const int _productMenuIndex = 0;
        private ProductMenuElement productMenu;
        public ProductMenuElement ProductMenu => productMenu ??= new ProductMenuElement(Driver, _menuElements[_productMenuIndex]);

        private const int _solutionsMenuIndex = 1;
        private SolutionsMenuElement solutionsMenu;
        public SolutionsMenuElement SolutionsMenu => solutionsMenu ??= new SolutionsMenuElement(Driver, _menuElements[_solutionsMenuIndex]);

        private const int _openSourceMenuIndex = 2;
        private OpenSourceMenuElement openSourceMenu;
        public OpenSourceMenuElement OpenSourceMenu => openSourceMenu ??= new OpenSourceMenuElement(Driver, _menuElements[_openSourceMenuIndex]);

        private const int _pricingMenuIndex = 3;
        private IWebElementSafe pricingMenu;
        public IWebElementSafe PricingMenu => pricingMenu ??= _menuElements[_pricingMenuIndex];
        public IWebElementSafe pricingMenuInnerElement;
        public IWebElementSafe PricingMenuInnerElement => pricingMenuInnerElement ??= PricingMenu.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.Scope.Child.TagName("a"),
            By.CssSelector($":scope>a"),
            By.XPath($"./a")));
        private PricingPage pricing;
        public PricingPage Pricing => pricing ??= new PricingPage(Driver, UrlSource.PageBaseUrl);
    }
}
