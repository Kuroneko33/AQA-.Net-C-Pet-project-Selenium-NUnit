using OpenQA.Selenium;

namespace Autotests_Training_project.WebPagesTasks.GitHub.Main.Search
{
    using WebPages.GitHub.Main.Search;

    public class SearchPageTasks : PageTasks<SearchPage>
    {
        public SearchPageTasks(SearchPage page) : base(page) { }

        public void FilterMenu_SelectItem(SearchPage.FilterMenu_Items item)
        {
            _page.GetFilterMenuItem(item).Click();
            _page.Wait.Until(condition => _page.FilterMenuSelectedItem.Text == _page.GetFilterMenuItem(item).Text);
        }

        public string SearchPlaceholder => _page.SearchInput.GetAttribute("placeholder");

        private void _searchResults_MenuItem_display(SearchPage.FilterMenu_Items menuItem)
        {
            if(_page.FilterMenuSelectedItem.Text != _page.GetFilterMenuItem(menuItem).Text)
                FilterMenu_SelectItem(menuItem);
        }

        private void _searchResults_Users_display() => _searchResults_MenuItem_display(SearchPage.FilterMenu_Items.Users);
        private SearchResult_UsersElementTasks[] searchResults_Users;
        public SearchResult_UsersElementTasks[] SearchResults_Users
        {
            get
            {
                _searchResults_Users_display();
                return searchResults_Users ??= _page.SearchResults_Users.ConvertAll(item => new SearchResult_UsersElementTasks(item, _searchResults_Users_display));
            }
        }

        public void Submit()
        {
            var input = _page.SearchInput;
            var text = input.GetAttribute("value");
            input.SendKeys(Keys.Enter);
            var expectedLink = SearchPage.BaseUrl + "?q=" + System.Uri.EscapeDataString(text);
            _page.Wait.Until(condition => _page.Url.StartsWith(expectedLink));
        }
        public void Search(string text)
        {
            var input = _page.SearchInput;
            input.SendKeys(text);
            Submit();
        }
    }
}
