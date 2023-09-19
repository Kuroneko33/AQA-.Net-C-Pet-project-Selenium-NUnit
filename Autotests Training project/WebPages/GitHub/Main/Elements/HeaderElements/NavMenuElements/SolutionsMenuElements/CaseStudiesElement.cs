using OpenQA.Selenium;
using System.Collections.Generic;

namespace Autotests_Training_project.WebPages.GitHub.Main.Elements.HeaderElements.NavMenuElements.SolutionsMenuElements
{
    using Addons.Selenium;
    using CustomerStories;
    using Resources;

    public class CaseStudiesElement : ElementObject
    {
        public CaseStudiesElement(IWebDriver driver, IWebElementSafe element) : base(driver, element) { }

        private IList<IWebElementSafe> menuElements;
        private IList<IWebElementSafe> _menuElements => menuElements ??= Element.FindElementsSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.Scope.Child.TagName("li").Child.TagName("a"),
            By.CssSelector($":scope>li>a"),
            By.XPath($"./li/a")));

        private const int _customerStoriesMenuIndex = 0;
        private IWebElementSafe customerStoriesMenu;
        public IWebElementSafe CustomerStoriesMenu => customerStoriesMenu ??= _menuElements[_customerStoriesMenuIndex];
        private CustomerStoriesPage customerStories;
        public CustomerStoriesPage CustomerStories => customerStories ??= new CustomerStoriesPage(Driver, UrlSource.PageBaseUrl);

        private const int _resourcesMenuIndex = 1;
        private IWebElementSafe resourcesMenu;
        public IWebElementSafe ResourcesMenu => resourcesMenu ??= _menuElements[_resourcesMenuIndex];
        private ResourcesPage resources;
        public ResourcesPage Resources => resources ??= new ResourcesPage(Driver, UrlSource.PageBaseUrl);
    }
}
