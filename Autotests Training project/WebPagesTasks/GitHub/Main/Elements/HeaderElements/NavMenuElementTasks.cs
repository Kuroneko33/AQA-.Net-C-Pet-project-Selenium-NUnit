using System;

namespace Autotests_Training_project.WebPagesTasks.GitHub.Main.Elements.HeaderElements
{
    using WebPages.GitHub.Main.Elements.HeaderElements;
    using WebPages.GitHub.Main.Pricing;
    using WebPages;
    using NavMenuElements;
    using Pricing;

    public class NavMenuElementTasks : ElementTasks_IDisplayable<NavMenuElement>
    {
        public NavMenuElementTasks(NavMenuElement element, Action display) : base(element, display) { }

        public enum MenuItems_With_SubMenu
        {
            Product,
            Solutions,
            OpenSourse
        }

        /// <summary>
        /// returns ElementTasksBase<ElementObject>
        /// </summary>
        public ElementTasks<ElementObject> MenuItem_Click(MenuItems_With_SubMenu item) =>
            item == MenuItems_With_SubMenu.Product ? ProductMenu_Click().BaseTasks :
            item == MenuItems_With_SubMenu.Solutions ? SolutionsMenu_Click().BaseTasks :
            item == MenuItems_With_SubMenu.OpenSourse ? OpenSourceMenu_Click().BaseTasks: 
            throw new NotImplementedException();

        public ProductMenuElementTasks ProductMenu_Click()
        {
            _stateSetUp();
            var productMenu = _element.ProductMenu;
            productMenu.Element.Click();
            _element.Wait.Until(condition => ProductMenu.Displayed);
            return ProductMenu;
        }
        private void _productMenu_display() => ProductMenu_Click();
        private ProductMenuElementTasks productMenu;
        public ProductMenuElementTasks ProductMenu =>
            productMenu ??= new ProductMenuElementTasks(_element.ProductMenu, _productMenu_display);

        public SolutionsMenuElementTasks SolutionsMenu_Click()
        {
            _stateSetUp();
            var solutionsMenu = _element.SolutionsMenu;
            solutionsMenu.Element.Click();
            _element.Wait.Until(condition => SolutionMenu.Displayed);
            return SolutionMenu;
        }
        private void _solutionsMenu_display() => SolutionsMenu_Click();
        private SolutionsMenuElementTasks solutionsMenu;
        public SolutionsMenuElementTasks SolutionMenu =>
            solutionsMenu ??= new SolutionsMenuElementTasks(_element.SolutionsMenu, _solutionsMenu_display);

        public OpenSourceMenuElementTasks OpenSourceMenu_Click()
        {
            _stateSetUp();
            var openSourceMenu = _element.OpenSourceMenu;
            openSourceMenu.Element.Click();
            _element.Wait.Until(condition => OpenSourceMenu.Displayed);
            return OpenSourceMenu;
        }
        private void _openSourceMenu_display() => OpenSourceMenu_Click();
        private OpenSourceMenuElementTasks openSourceMenu;
        public OpenSourceMenuElementTasks OpenSourceMenu =>
            openSourceMenu ??= new OpenSourceMenuElementTasks(_element.OpenSourceMenu, _openSourceMenu_display);


        public enum MenuItems_With_Link
        {
            Pricing
        }

        public string MenuItem_GetLink(MenuItems_With_Link item) =>
            item == MenuItems_With_Link.Pricing ? PricingMenu_Link : 
            throw new NotImplementedException();
        /// <summary>
        /// returns PageTasksBase<PageObject>
        /// </summary>
        public PageTasks<PageObject> MenuItem_Click(MenuItems_With_Link item) =>
            item == MenuItems_With_Link.Pricing ? PricingMenu_Click().BaseTasks : 
            throw new NotImplementedException();

        public string PricingMenu_Link => _element.PricingMenuInnerElement.GetAttribute("href").TrimEnd('/') + "/";
        public PricingPageTasks PricingMenu_Click()
        {
            var pricingMenu = _element.PricingMenu;
            pricingMenu.Click();
            var expectedLink = MenuItems_With_Link.Pricing.GetExtectedDirectedUrl();
            _element.Wait.Until(condition => _element.Url.Equals(expectedLink));
            PricingPage page = new PricingPage(_element.Driver, UrlSource.Driver);
            return new PricingPageTasks(page);
        }
        private PricingPageTasks pricing;
        public PricingPageTasks Pricing => pricing ??= new PricingPageTasks(_element.Pricing);
    }

    public static class MenuItemsExtension
    {
        private static string _getBasePageUrl(NavMenuElementTasks.MenuItems_With_Link item) =>
            item == NavMenuElementTasks.MenuItems_With_Link.Pricing ? PricingPage.BaseUrl :
            throw new NotImplementedException();

        public static string GetExtectedLink(this NavMenuElementTasks.MenuItems_With_Link item) =>
            _getBasePageUrl(item) + "/";
        public static string GetExtectedDirectedUrl(this NavMenuElementTasks.MenuItems_With_Link item) =>
            _getBasePageUrl(item);
    }
}
