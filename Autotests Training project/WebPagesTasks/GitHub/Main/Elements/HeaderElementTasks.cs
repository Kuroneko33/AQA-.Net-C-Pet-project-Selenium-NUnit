namespace Autotests_Training_project.WebPagesTasks.GitHub.Main.Elements
{
    using WebPages.GitHub.Main.Elements;
    using WebPages.GitHub.Main;
    using WebPages;
    using HeaderElements;

    public class HeaderElementTasks : ElementTasks<HeaderElement>
    {
        public HeaderElementTasks(HeaderElement element) : base(element) { }

        public string Logo_Link => _element.Logo.GetAttribute("href");
        public MainPageTasks Logo_Click()
        {
            var logo = _element.Logo;
            logo.Click();
            var expectedLink = Logo_Link;
            _element.Wait.Until(condition => _element.Url.Equals(expectedLink));
            MainPage mainPage = new MainPage(_element.Driver, UrlSource.Driver);
            return new MainPageTasks(mainPage);
        }

        public bool ToggleNavigationButton_Displayed => _element.ToggleNavigationButton.Displayed;
        /// <summary>
        /// Displays NavMenu
        /// </summary>
        public NavMenuElementTasks ToggleNavigationButton_Click()
        {
            var toggleNavigationButton = _element.ToggleNavigationButton;
            toggleNavigationButton.Click();
            _element.Wait.Until(condition => NavMenu.Displayed);
            return NavMenu;
        }
        private void _navMenu_display() => ToggleNavigationButton_Click();
        private NavMenuElementTasks navMenu;
        public NavMenuElementTasks NavMenu =>
            navMenu ??= new NavMenuElementTasks(_element.NavMenu, _navMenu_display);

        private void _searchAndSign_display() => ToggleNavigationButton_Click();
        private SearchAndSignElementTasks searchAndSign;
        public SearchAndSignElementTasks SearchAndSign =>
            searchAndSign ??= new SearchAndSignElementTasks(_element.SearchAndSign, _searchAndSign_display);
    }
}
