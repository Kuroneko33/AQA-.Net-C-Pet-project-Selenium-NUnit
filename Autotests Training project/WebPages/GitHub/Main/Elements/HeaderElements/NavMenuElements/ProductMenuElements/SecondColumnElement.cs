using OpenQA.Selenium;
using System.Collections.Generic;

namespace Autotests_Training_project.WebPages.GitHub.Main.Elements.HeaderElements.NavMenuElements.ProductMenuElements
{
    using Addons.Selenium;
    using Features;
    using Docs;
    using Skills;
    using Blog;

    public class SecondColumnElement : ElementObject
    {
        public SecondColumnElement(IWebDriver driver, IWebElementSafe element) : base(driver, element) { }

        private IList<IWebElementSafe> menuElements;
        private IList<IWebElementSafe> _menuElements => menuElements ??= Element.FindElementsSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.Scope.Child.TagName("li").Child.TagName("a"),
            By.CssSelector($":scope>li>a"),
            By.XPath($"./li/a")));

        private const int _allFeaturesMenuIndex = 0;
        private IWebElementSafe allFeaturesMenu;
        public IWebElementSafe AllFeaturesMenu => allFeaturesMenu ??= _menuElements[_allFeaturesMenuIndex];
        private FeaturesPage allFeatures;
        public FeaturesPage AllFeatures => allFeatures ??= new FeaturesPage(Driver, UrlSource.PageBaseUrl);

        private const int _documentationMenuIndex = 1;
        private IWebElementSafe documentationMenu;
        public IWebElementSafe DocumentationMenu => documentationMenu ??= _menuElements[_documentationMenuIndex];
        private DocsPage documentation;
        public DocsPage Documentation => documentation ??= new DocsPage(Driver, UrlSource.PageBaseUrl);

        private const int _gitHubSkillsMenuIndex = 2;
        private IWebElementSafe gitHubSkillsMenu;
        public IWebElementSafe GitHubSkillsMenu => gitHubSkillsMenu ??= _menuElements[_gitHubSkillsMenuIndex];
        private SkillsPage gitHubSkills;
        public SkillsPage GitHubSkills => gitHubSkills ??= new SkillsPage(Driver, UrlSource.PageBaseUrl);

        private const int _blogMenuIndex = 3;
        private IWebElementSafe blogMenu;
        public IWebElementSafe BlogMenu => blogMenu ??= _menuElements[_blogMenuIndex];
        private BlogPage blog;
        public BlogPage Blog => blog ??= new BlogPage(Driver, UrlSource.PageBaseUrl);
    }
}
