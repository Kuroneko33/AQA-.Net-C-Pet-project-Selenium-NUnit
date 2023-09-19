using OpenQA.Selenium;
using System.Collections.Generic;

namespace Autotests_Training_project.WebPages.GitHub.Main.Elements.HeaderElements.NavMenuElements
{
    using Addons.Selenium;
    using ProductMenuElements;

    public class ProductMenuElement : ElementObject
    {
        public ProductMenuElement(IWebDriver driver, IWebElementSafe element) : base(driver, element) { }

        private IList<IWebElementSafe> columns;
        private IList<IWebElementSafe> _columns => columns ??= Element.FindElementsSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.Scope.Descendant.TagName("div").Child.TagName("ul"),
            By.CssSelector($":scope div>ul"),
            By.XPath($".//div/ul")));

        private const int _firstColumnIndex = 0;
        private FirstColumnElement firstColumn;
        public FirstColumnElement FirstColumn => firstColumn ??= new FirstColumnElement(Driver, _columns[_firstColumnIndex]);

        private const int _secondColumnIndex = 1;
        private SecondColumnElement secondColumn;
        public SecondColumnElement SecondColumn => secondColumn ??= new SecondColumnElement(Driver, _columns[_secondColumnIndex]);
    }
}
