using OpenQA.Selenium;
using System.Collections.Generic;

namespace Autotests_Training_project.WebPages.BelazBy.Main.Elements.HeaderElements.TopRightElements
{
    using Addons.Selenium;

    public class TopLangElement : ElementObject
    {
        public TopLangElement(IWebDriver driver, IWebElementSafe element) : base(driver, element) { }

        private IList<IWebElementSafe> menuElements;
        private IList<IWebElementSafe> _menuElements => menuElements ??= Element.FindElementsSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.Scope.Child.TagName("div").Child.TagName("a"),
            By.CssSelector($":scope>div>a"),
            By.XPath($"./div/a")));

        private const int _ruMenuIndex = 0;
        private IWebElementSafe ruMenu;
        public IWebElementSafe RuMenu => ruMenu ??= _menuElements[_ruMenuIndex];

        private const int _byMenuIndex = 1;
        private IWebElementSafe byMenu;
        public IWebElementSafe ByMenu => byMenu ??= _menuElements[_byMenuIndex];

        private const int _enMenuIndex = 2;
        private IWebElementSafe enMenu;
        public IWebElementSafe EnMenu => enMenu ??= _menuElements[_enMenuIndex];

        private const int _cnMenuIndex = 3;
        private IWebElementSafe cnMenu;
        public IWebElementSafe CnMenu => cnMenu ??= _menuElements[_cnMenuIndex];

    }
}
