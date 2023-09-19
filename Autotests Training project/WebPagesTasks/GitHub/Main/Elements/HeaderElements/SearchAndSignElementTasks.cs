using OpenQA.Selenium;
using System;

namespace Autotests_Training_project.WebPagesTasks.GitHub.Main.Elements.HeaderElements
{
    using WebPages.GitHub.Main.Elements.HeaderElements;
    using WebPages.GitHub.Main.Search;
    using WebPages;
    using Search;

    public class SearchAndSignElementTasks : ElementTasks_IDisplayable<SearchAndSignElement>
    {
        public SearchAndSignElementTasks(SearchAndSignElement element, Action display) : base(element, display) { }

        public string SearchPlaceholder
        {
            get
            {
                _stateSetUp();
                return _element.SearchPlaceholder.Text;
            }
        }

        public SearchPageTasks Submit()
        {
            _stateSetUp();
            var input = _element.SearchInput;
            if (!input.Displayed)
                _element.SearchButton.Click();
            _element.Wait.Until(condition => input.Displayed);
            var text = input.GetAttribute("value");
            input.SendKeys(Keys.Enter);
            var expectedLink = SearchPage.BaseUrl + "?q=" + Uri.EscapeDataString(text);
            _element.Wait.Until(condition => _element.Url.StartsWith(expectedLink));
            SearchPage page = new SearchPage(_element.Driver, UrlSource.Driver);
            return new SearchPageTasks(page);
        }
        public SearchPageTasks Search(string text)
        {
            _stateSetUp();
            var input = _element.SearchInput;
            if (!input.Displayed)
                _element.SearchButton.Click();
            _element.Wait.Until(condition => input.Displayed);
            input.SendKeys(text);
            return Submit();
        }
    }
}
