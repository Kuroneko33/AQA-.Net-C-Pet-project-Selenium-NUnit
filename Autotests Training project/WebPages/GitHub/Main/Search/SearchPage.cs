using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Autotests_Training_project.WebPages.GitHub.Main.Search
{
    using Addons.Selenium;

    public class SearchPage : PageObject
    {
        public new const string BaseUrl = MainPage.BaseUrl + "/search";
        public SearchPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public SearchPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public SearchPage() : base(BaseUrl) { }

        public enum FilterMenu_Items
        {
            Repositories,
            Users
        }

        private IWebElementSafe searchInput;
        public IWebElementSafe SearchInput => searchInput ??= Driver.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.TagName("input").Attribute("aria-label", "Search GitHub"),
            By.CssSelector("input[aria-label='Search GitHub']"),
            By.XPath(".//input[contains(@aria-label,'Search GitHub')]")));

        private readonly string _menuItemSeleniumSelector = ByCssBuilder.NewInstance.TagName("li").Attribute("data-testid", "kind-group").Descendant.TagName("li").CssSelectorString;
        private readonly string _menuItemCssSelector = "li[data-testid='kind-group'] li";
        private readonly string _menuItemXPathSelector = ".//li[@data-testid='kind-group'//li]"; 

        private IWebElementSafe filterMenuSelectedItem;
        public IWebElementSafe FilterMenuSelectedItem => filterMenuSelectedItem ??= Driver.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.CssSelector(_menuItemSeleniumSelector).ClassName("hupnoO").Descendant.TagName("a"),
            By.CssSelector(_menuItemCssSelector + $".hupnoO a"),
            By.XPath(_menuItemXPathSelector + $"[contains(@class, 'hupnoO')]//a")));

        public IWebElementSafe GetFilterMenuItem(FilterMenu_Items item) => Driver.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.CssSelector(_menuItemSeleniumSelector).Descendant.TagName("a").PartialLinkText(item.GetValue()),
            By.CssSelector(_menuItemCssSelector + $" a[href*='{item.GetValue()}']"),
            By.XPath(_menuItemXPathSelector + $"//a[contains(@href, '{item.GetValue()}')]")));

        private IList<IWebElementSafe> searchResults_Users;
        private IList<IWebElementSafe> _searchResults_Users => searchResults_Users ??= Driver.FindElementsSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.Attribute("data-testid", "results-list"),
            By.CssSelector("[data-testid='results-list']"),
            By.XPath(".//*[@data-testid='results-list']")));
        public SearchResult_UserElement[] SearchResults_Users =>
            _searchResults_Users.ToArray().ConvertAll(item => new SearchResult_UserElement(Driver, item));
    }

    public static class FilterMenuItemsExtension
    {
        public static string GetValue(this SearchPage.FilterMenu_Items item) =>
            item == SearchPage.FilterMenu_Items.Repositories ? "type=repositories" :
            item == SearchPage.FilterMenu_Items.Users ? "type=users" :
            throw new NotImplementedException("Добавьте элемент в FilterMenuItemsExtension.GetValue()");
    }
}
