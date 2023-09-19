using System;

namespace Autotests_Training_project.WebPagesTasks.GitHub.Main.Elements.HeaderElements.NavMenuElements.ProductMenuElements
{
    using WebPages.GitHub.Main.Elements.HeaderElements.NavMenuElements.ProductMenuElements;
    using WebPages.GitHub.Main.Features.Actions;
    using WebPages.GitHub.Main.Features.Packages;
    using WebPages.GitHub.Main.Features.Security;
    using WebPages.GitHub.Main.Features.CodeSpaces;
    using WebPages.GitHub.Main.Features.Copilot;
    using WebPages.GitHub.Main.Features.CodeReview;
    using WebPages.GitHub.Main.Features.Issues;
    using WebPages.GitHub.Main.Features.Discussions;
    using WebPages;

    public class FirstColumnElementTasks : ElementTasks_IDisplayable<FirstColumnElement>
    {
        public FirstColumnElementTasks(FirstColumnElement element, Action display) : base(element, display) { }


        public enum MenuItems_With_Link
        {
            Actions,
            Packages,
            Security,
            CodeSpaces,
            Copilot,
            CodeReview,
            Issues,
            Discussions
        }

        public string MenuItem_GetLink(MenuItems_With_Link item) =>
            item == MenuItems_With_Link.Actions ? Actions_Link :
            item == MenuItems_With_Link.Packages ? Packages_Link :
            item == MenuItems_With_Link.Security ? Security_Link :
            item == MenuItems_With_Link.CodeSpaces ? CodeSpaces_Link :
            item == MenuItems_With_Link.Copilot ? Copilot_Link :
            item == MenuItems_With_Link.CodeReview ? CodeReview_Link :
            item == MenuItems_With_Link.Issues ? Issues_Link :
            item == MenuItems_With_Link.Discussions ? Discussions_Link :
            throw new NotImplementedException();
        /// <summary>
        /// returns PageTasksBase<PageObject>
        /// </summary>
        public PageTasks<PageObject> MenuItem_Click(MenuItems_With_Link item) =>
            item == MenuItems_With_Link.Actions ? Actions_Click().BaseTasks :
            item == MenuItems_With_Link.Packages ?  Packages_Click().BaseTasks :
            item == MenuItems_With_Link.Security ? Security_Click().BaseTasks :
            item == MenuItems_With_Link.CodeSpaces ? CodeSpaces_Click().BaseTasks :
            item == MenuItems_With_Link.Copilot ? Copilot_Click().BaseTasks :
            item == MenuItems_With_Link.CodeReview ? CodeReview_Click().BaseTasks :
            item == MenuItems_With_Link.Issues ? Issues_Click().BaseTasks :
            item == MenuItems_With_Link.Discussions ? Discussions_Click().BaseTasks :
            throw new NotImplementedException();

        public string Actions_Link => _element.ActionsMenu.GetAttribute("href").TrimEnd('/') + "/";
        public PageTasks<PageObject> Actions_Click()
        {
            _stateSetUp();
            var actionsMenu = _element.ActionsMenu;
            actionsMenu.Click();
            var expectedLink = MenuItems_With_Link.Actions.GetExtectedDirectedUrl();
            _element.Wait.Until(condition => _element.Url.Equals(expectedLink));
            ActionsPage page = new ActionsPage(_element.Driver, UrlSource.Driver);
            return new PageTasks<PageObject>(page);
        }

        public string Packages_Link => _element.PackagesMenu.GetAttribute("href").TrimEnd('/') + "/";
        public PageTasks<PageObject> Packages_Click()
        {
            _stateSetUp();
            var packagesMenu = _element.PackagesMenu;
            packagesMenu.Click();
            var expectedLink = MenuItems_With_Link.Packages.GetExtectedDirectedUrl();
            _element.Wait.Until(condition => _element.Url.Equals(expectedLink));
            PackagesPage page = new PackagesPage(_element.Driver, UrlSource.Driver);
            return new PageTasks<PageObject>(page);
        }
       
        public string Security_Link => _element.SecurityMenu.GetAttribute("href").TrimEnd('/') + "/";
        public PageTasks<PageObject> Security_Click()
        {
            _stateSetUp();
            var securityMenu = _element.SecurityMenu;
            securityMenu.Click();
            var expectedLink = MenuItems_With_Link.Security.GetExtectedDirectedUrl();
            _element.Wait.Until(condition => _element.Url.Equals(expectedLink));
            SecurityPage page = new SecurityPage(_element.Driver, UrlSource.Driver);
            return new PageTasks<PageObject>(page);
        }

        public string CodeSpaces_Link => _element.CodeSpacesMenu.GetAttribute("href").TrimEnd('/') + "/";
        public PageTasks<PageObject> CodeSpaces_Click()
        {
            _stateSetUp();
            var codespacesMenu = _element.CodeSpacesMenu;
            codespacesMenu.Click();
            var expectedLink = MenuItems_With_Link.CodeSpaces.GetExtectedDirectedUrl();
            _element.Wait.Until(condition => _element.Url.Equals(expectedLink));
            CodeSpacesPage page = new CodeSpacesPage(_element.Driver, UrlSource.Driver);
            return new PageTasks<PageObject>(page);
        }

        public string Copilot_Link => _element.CopilotMenu.GetAttribute("href").TrimEnd('/') + "/";
        public PageTasks<PageObject> Copilot_Click()
        {
            _stateSetUp();
            var copilotMenu = _element.CopilotMenu;
            copilotMenu.Click();
            var expectedLink = MenuItems_With_Link.Copilot.GetExtectedDirectedUrl();
            _element.Wait.Until(condition => _element.Url.Equals(expectedLink));
            CopilotPage page = new CopilotPage(_element.Driver, UrlSource.Driver);
            return new PageTasks<PageObject>(page);
        }

        public string CodeReview_Link => _element.CodeReviewMenu.GetAttribute("href").TrimEnd('/') + "/";
        public PageTasks<PageObject> CodeReview_Click()
        {
            _stateSetUp();
            var codeReviewMenu = _element.CodeReviewMenu;
            codeReviewMenu.Click();
            var expectedLink = MenuItems_With_Link.CodeReview.GetExtectedDirectedUrl();
            _element.Wait.Until(condition => _element.Url.Equals(expectedLink));
            CodeReviewPage page = new CodeReviewPage(_element.Driver, UrlSource.Driver);
            return new PageTasks<PageObject>(page);
        }

        public string Issues_Link => _element.IssuesMenu.GetAttribute("href").TrimEnd('/') + "/";
        public PageTasks<PageObject> Issues_Click()
        {
            _stateSetUp();
            var issuesMenu = _element.IssuesMenu;
            issuesMenu.Click();
            var expectedLink = MenuItems_With_Link.Issues.GetExtectedDirectedUrl();
            _element.Wait.Until(condition => _element.Url.Equals(expectedLink));
            IssuesPage page = new IssuesPage(_element.Driver, UrlSource.Driver);
            return new PageTasks<PageObject>(page);
        }

        public string Discussions_Link => _element.DiscussionsMenu.GetAttribute("href").TrimEnd('/') + "/";
        public PageTasks<PageObject> Discussions_Click()
        {
            _stateSetUp();
            var discussionsMenu = _element.DiscussionsMenu;
            discussionsMenu.Click();
            var expectedLink = MenuItems_With_Link.Discussions.GetExtectedDirectedUrl();
            _element.Wait.Until(condition => _element.Url.Equals(expectedLink));
            DiscussionsPage page = new DiscussionsPage(_element.Driver, UrlSource.Driver);
            return new PageTasks<PageObject>(page);
        }
    }
    public static class FirstColumnMenuItemsExtension
    {
        private static string _getBasePageUrl(FirstColumnElementTasks.MenuItems_With_Link item) =>
            item == FirstColumnElementTasks.MenuItems_With_Link.Actions ? ActionsPage.BaseUrl :
            item == FirstColumnElementTasks.MenuItems_With_Link.Packages ? PackagesPage.BaseUrl :
            item == FirstColumnElementTasks.MenuItems_With_Link.Security ? SecurityPage.BaseUrl :
            item == FirstColumnElementTasks.MenuItems_With_Link.CodeSpaces ? CodeSpacesPage.BaseUrl :
            item == FirstColumnElementTasks.MenuItems_With_Link.Copilot ? CopilotPage.BaseUrl :
            item == FirstColumnElementTasks.MenuItems_With_Link.CodeReview ? CodeReviewPage.BaseUrl :
            item == FirstColumnElementTasks.MenuItems_With_Link.Issues ? IssuesPage.BaseUrl :
            item == FirstColumnElementTasks.MenuItems_With_Link.Discussions ? DiscussionsPage.BaseUrl :
            throw new NotImplementedException();

        public static string GetExtectedLink(this FirstColumnElementTasks.MenuItems_With_Link item) =>
            _getBasePageUrl(item) + "/";
        public static string GetExtectedDirectedUrl(this FirstColumnElementTasks.MenuItems_With_Link item) =>
            _getBasePageUrl(item);
    }
}