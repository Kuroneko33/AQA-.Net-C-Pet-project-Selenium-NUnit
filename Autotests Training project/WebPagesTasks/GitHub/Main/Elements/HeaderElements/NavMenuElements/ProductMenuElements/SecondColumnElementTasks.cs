using System;
using System.Linq;

namespace Autotests_Training_project.WebPagesTasks.GitHub.Main.Elements.HeaderElements.NavMenuElements.ProductMenuElements
{
    using WebPages.GitHub.Main.Elements.HeaderElements.NavMenuElements.ProductMenuElements;
    using WebPages.GitHub.Main.Features;
    using WebPages.GitHub.Docs;
    using WebPages.GitHub.Skills;
    using WebPages.GitHub.Blog;
    using WebPages;

    public class SecondColumnElementTasks : ElementTasks_IDisplayable<SecondColumnElement>
    {
        public SecondColumnElementTasks(SecondColumnElement element, Action display) : base(element, display) { }

        public enum MenuItems_With_Link
        {
            AllFeatures,
            Documentation,
            GitHubSkills,
            Blog
        }

        public string MenuItem_GetLink(MenuItems_With_Link item) =>
            item == MenuItems_With_Link.AllFeatures ? AllFeatures_Link :
            item == MenuItems_With_Link.Documentation ? Documentation_Link :
            item == MenuItems_With_Link.GitHubSkills ? GitHubSkills_Link :
            item == MenuItems_With_Link.Blog ? Blog_Link :
            throw new NotImplementedException();
        /// <summary>
        /// returns PageTasksBase<PageObject>
        /// </summary>
        public PageTasks<PageObject> MenuItem_Click(MenuItems_With_Link item) =>
            item == MenuItems_With_Link.AllFeatures ? AllFeatures_Click().BaseTasks :
            item == MenuItems_With_Link.Documentation ? Documentation_Click().BaseTasks :
            item == MenuItems_With_Link.GitHubSkills ? GitHubSkills_Click().BaseTasks :
            item == MenuItems_With_Link.Blog ? Blog_Click().BaseTasks :
            throw new NotImplementedException();

        public string AllFeatures_Link => _element.AllFeaturesMenu.GetAttribute("href").TrimEnd('/') + "/";
        public PageTasks<PageObject> AllFeatures_Click()
        {
            _stateSetUp();
            var allFeaturesMenu = _element.AllFeaturesMenu;
            allFeaturesMenu.Click();
            var expectedLink = MenuItems_With_Link.AllFeatures.GetExtectedDirectedUrl();
            _element.Wait.Until(condition => _element.Url.Equals(expectedLink));
            FeaturesPage page = new FeaturesPage(_element.Driver, UrlSource.Driver);
            return new PageTasks<PageObject>(page);
        }

        public string Documentation_Link => _element.DocumentationMenu.GetAttribute("href").TrimEnd('/') + "/";
        public PageTasks<PageObject> Documentation_Click()
        {
            _stateSetUp();
            var documentationMenu = _element.DocumentationMenu;
            documentationMenu.Click();
            var expectedLink = MenuItems_With_Link.Documentation.GetExtectedDirectedUrl();
            _element.Driver.SwitchTo().Window(_element.Driver.WindowHandles.First()).Close();
            _element.Driver.SwitchTo().Window(_element.Driver.WindowHandles.Last());
            _element.Wait.Until(condition => _element.Url.Equals(expectedLink));
            DocsPage page = new DocsPage(_element.Driver, UrlSource.Driver);
            return new PageTasks<PageObject>(page);
        }

        public string GitHubSkills_Link => _element.GitHubSkillsMenu.GetAttribute("href").TrimEnd('/') + "/";
        public PageTasks<PageObject> GitHubSkills_Click()
        {
            _stateSetUp();
            var gitHubSkillsMenu = _element.GitHubSkillsMenu;
            gitHubSkillsMenu.Click();
            var expectedLink = MenuItems_With_Link.GitHubSkills.GetExtectedDirectedUrl();
            _element.Driver.SwitchTo().Window(_element.Driver.WindowHandles.First()).Close();
            _element.Driver.SwitchTo().Window(_element.Driver.WindowHandles.Last());
            _element.Wait.Until(condition => _element.Url.Equals(expectedLink));
            SkillsPage page = new SkillsPage(_element.Driver, UrlSource.Driver);
            return new PageTasks<PageObject>(page);
        }

        public string Blog_Link => _element.BlogMenu.GetAttribute("href").TrimEnd('/') + "/";
        public PageTasks<PageObject> Blog_Click()
        {
            _stateSetUp();
            var blogMenu = _element.BlogMenu;
            blogMenu.Click();
            var expectedLink = MenuItems_With_Link.Blog.GetExtectedDirectedUrl();
            _element.Driver.SwitchTo().Window(_element.Driver.WindowHandles.First()).Close();
            _element.Driver.SwitchTo().Window(_element.Driver.WindowHandles.Last());
            _element.Wait.Until(condition => _element.Url.Equals(expectedLink));
            BlogPage page = new BlogPage(_element.Driver, UrlSource.Driver);
            return new PageTasks<PageObject>(page);
        }
    }
    public static class SecondColumnMenuItemsExtension
    {
        private static string _getBasePageUrl(SecondColumnElementTasks.MenuItems_With_Link item) =>
            item == SecondColumnElementTasks.MenuItems_With_Link.AllFeatures ? FeaturesPage.BaseUrl :
            item == SecondColumnElementTasks.MenuItems_With_Link.Documentation ? DocsPage.BaseUrl :
            item == SecondColumnElementTasks.MenuItems_With_Link.GitHubSkills ? SkillsPage.BaseUrl :
            item == SecondColumnElementTasks.MenuItems_With_Link.Blog ? BlogPage.BaseUrl :
            throw new NotImplementedException();

        public static string GetExtectedLink(this SecondColumnElementTasks.MenuItems_With_Link item) =>
            _getBasePageUrl(item) + "/";
        public static string GetExtectedDirectedUrl(this SecondColumnElementTasks.MenuItems_With_Link item) =>
            item == SecondColumnElementTasks.MenuItems_With_Link.Documentation ? DocsPage.BaseUrl_WithLang :
            item == SecondColumnElementTasks.MenuItems_With_Link.AllFeatures ? _getBasePageUrl(item) :
            _getBasePageUrl(item) + "/";
    }
}
