using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Main.Search
{
    using Addons.Selenium;

    public class SearchResult_UserElement : ElementObject
    {
        public SearchResult_UserElement(IWebDriver driver, IWebElementSafe element) : base(driver, element) { }

        private IWebElementSafe resultContainer;
        private IWebElementSafe _resultContainer => resultContainer ??= Element.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.TagName("div").ClassName("search-title"),
            By.CssSelector("div.search-title"),
            By.XPath(".//div[contains(@class,'search-title')]")));

        private IWebElementSafe userId;
        public IWebElementSafe UserId => userId ??= _resultContainer.FindElementSafe(BySwitcher.SelectFrom(
            By.CssSelector("a:last-child"),
            By.CssSelector("a:last-child"),
            By.XPath(".//a[last()]")));
    }
}
