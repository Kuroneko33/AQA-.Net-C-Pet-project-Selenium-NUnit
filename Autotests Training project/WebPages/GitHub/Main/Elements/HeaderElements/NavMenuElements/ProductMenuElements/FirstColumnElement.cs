using OpenQA.Selenium;
using System.Collections.Generic;

namespace Autotests_Training_project.WebPages.GitHub.Main.Elements.HeaderElements.NavMenuElements.ProductMenuElements
{
    using Addons.Selenium;
    using Features.Actions;
    using Features.Packages;
    using Features.Security;
    using Features.CodeSpaces;
    using Features.Copilot;
    using Features.CodeReview;
    using Features.Issues;
    using Features.Discussions;

    public class FirstColumnElement : ElementObject
    {
        public FirstColumnElement(IWebDriver driver, IWebElementSafe element) : base(driver, element) { }

        private IList<IWebElementSafe> menuElements;
        private IList<IWebElementSafe> _menuElements => menuElements ??= Element.FindElementsSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.Scope.Child.TagName("li").Child.TagName("a"),
            By.CssSelector($":scope>li>a"),
            By.XPath($"./li/a")));

        private const int _actionsMenuIndex = 0;
        private IWebElementSafe actionsMenu;
        public IWebElementSafe ActionsMenu => actionsMenu ??= _menuElements[_actionsMenuIndex];
        private ActionsPage actions;
        public ActionsPage Actions => actions ??= new ActionsPage(Driver, UrlSource.PageBaseUrl);

        private const int _packagesMenuIndex = 1;
        private IWebElementSafe packagesMenu;
        public IWebElementSafe PackagesMenu => packagesMenu ??= _menuElements[_packagesMenuIndex];
        private PackagesPage packages;
        public PackagesPage Packages => packages ??= new PackagesPage(Driver, UrlSource.PageBaseUrl);

        private const int _securityMenuIndex = 2;
        private IWebElementSafe securityMenu;
        public IWebElementSafe SecurityMenu => securityMenu ??= _menuElements[_securityMenuIndex];
        private SecurityPage security;
        public SecurityPage Security => security ??= new SecurityPage(Driver, UrlSource.PageBaseUrl);

        private const int _codeSpacesMenuIndex = 3;
        private IWebElementSafe codeSpacesMenu;
        public IWebElementSafe CodeSpacesMenu => codeSpacesMenu ??= _menuElements[_codeSpacesMenuIndex];
        private CodeSpacesPage codeSpaces;
        public CodeSpacesPage CodeSpaces => codeSpaces ??= new CodeSpacesPage(Driver, UrlSource.PageBaseUrl);

        private const int _copilotMenuIndex = 4;
        private IWebElementSafe copilotMenu;
        public IWebElementSafe CopilotMenu => copilotMenu ??= _menuElements[_copilotMenuIndex];
        private CopilotPage copilot;
        public CopilotPage Copilot => copilot ??= new CopilotPage(Driver, UrlSource.PageBaseUrl);

        private const int _codeReviewMenuIndex = 5;
        private IWebElementSafe codeReviewMenu;
        public IWebElementSafe CodeReviewMenu => codeReviewMenu ??= _menuElements[_codeReviewMenuIndex];
        private CodeReviewPage codeReview;
        public CodeReviewPage CodeReview => codeReview ??= new CodeReviewPage(Driver, UrlSource.PageBaseUrl);

        private const int _issuesMenuIndex = 6;
        private IWebElementSafe issuesMenu;
        public IWebElementSafe IssuesMenu => issuesMenu ??= _menuElements[_issuesMenuIndex];
        private IssuesPage issues;
        public IssuesPage Issues => issues ??= new IssuesPage(Driver, UrlSource.PageBaseUrl);

        private const int _discussionsMenuIndex = 7;
        private IWebElementSafe discussionsMenu;
        public IWebElementSafe DiscussionsMenu => discussionsMenu ??= _menuElements[_discussionsMenuIndex];
        private DiscussionsPage discussions;
        public DiscussionsPage Discussions => discussions ??= new DiscussionsPage(Driver, UrlSource.PageBaseUrl);
    }
}