using System;

namespace Autotests_Training_project.WebPagesTasks.BelazBy.Main.HeaderElements.TopLeftElements
{
    using WebPages.BelazBy.Main.Elements.HeaderElements.TopLeftElements;
    using WebPages.BelazBy.Main.About;
    using WebPages.BelazBy.Main.PressCentre;
    using WebPages.BelazBy.Main.About.BelazGlobal;
    using WebPages.BelazBy.Main.PressCentre.YearsOld;
    using WebPages.BelazBy.Sapportal.Irj.Portal;
    using WebPages;

    public class TopMenuElementTasks : ElementTasks<TopMenuElement>
    {
        public TopMenuElementTasks(TopMenuElement element) : base(element) { }

        public enum MenuItems_With_Link
        {
            Company,
            PressCentre,
            BelazGlobal,
            ForTheDealers,
            YearsOld
        }

        public string MenuItem_GetLink(MenuItems_With_Link item) =>
            item == MenuItems_With_Link.Company ? Company_Link :
            item == MenuItems_With_Link.PressCentre ? PressCentre_Link :
            item == MenuItems_With_Link.BelazGlobal ? BelazGlobal_Link :
            item == MenuItems_With_Link.ForTheDealers ? ForTheDealers_Link :
            item == MenuItems_With_Link.YearsOld ? YearsOld_Link :
            throw new NotImplementedException();
        /// <summary>
        /// returns PageTasksBase<PageObject>
        /// </summary>
        public PageTasks<PageObject> MenuItem_Click(MenuItems_With_Link item) =>
            item == MenuItems_With_Link.Company ? Company_Click().BaseTasks :
            item == MenuItems_With_Link.PressCentre ? PressCentre_Click().BaseTasks :
            item == MenuItems_With_Link.BelazGlobal ? BelazGlobal_Click().BaseTasks :
            item == MenuItems_With_Link.ForTheDealers ? ForTheDealers_Click().BaseTasks :
            item == MenuItems_With_Link.YearsOld ? YearsOld_Click().BaseTasks :
            throw new NotImplementedException();

        public string Company_Link => _element.CompanyMenu.GetAttribute("href").TrimEnd('/') + "/";
        public PageTasks<PageObject> Company_Click()
        {
            var companyMenu = _element.CompanyMenu;
            _element.Wait.Until(condition => companyMenu.Displayed);
            companyMenu.Click();
            var expectedLink = MenuItems_With_Link.Company.GetExtectedDirectedUrl();
            _element.Wait.Until(condition => _element.Url.Equals(expectedLink));
            AboutPage page = new AboutPage(_element.Driver, UrlSource.Driver);
            return new PageTasks<PageObject>(page);
        }

        public string PressCentre_Link => _element.PressCentreMenu.GetAttribute("href").TrimEnd('/') + "/";
        public PageTasks<PageObject> PressCentre_Click()
        {
            var pressCentreMenu = _element.PressCentreMenu;
            _element.Wait.Until(condition => pressCentreMenu.Displayed);
            pressCentreMenu.Click();
            var expectedLink = MenuItems_With_Link.PressCentre.GetExtectedDirectedUrl();
            _element.Wait.Until(condition => _element.Url.Equals(expectedLink));
            PressCentrePage page = new PressCentrePage(_element.Driver, UrlSource.Driver);
            return new PageTasks<PageObject>(page);
        }
        
        public string BelazGlobal_Link => _element.BelazGlobalMenu.GetAttribute("href").TrimEnd('/') + "/";
        public PageTasks<PageObject> BelazGlobal_Click()
        {
            var belazGlobalMenu = _element.BelazGlobalMenu;
            _element.Wait.Until(condition => belazGlobalMenu.Displayed);
            belazGlobalMenu.Click();
            var expectedLink = MenuItems_With_Link.BelazGlobal.GetExtectedDirectedUrl();
            _element.Wait.Until(condition => _element.Url.Equals(expectedLink));
            BelazGlobalPage page = new BelazGlobalPage(_element.Driver, UrlSource.Driver);
            return new PageTasks<PageObject>(page);
        }
        
        public string ForTheDealers_Link => _element.ForTheDealersMenu.GetAttribute("href").TrimEnd('/') + "/";
        public PageTasks<PageObject> ForTheDealers_Click()
        {
            var forTheDealersMenu = _element.ForTheDealersMenu;
            _element.Wait.Until(condition => forTheDealersMenu.Displayed);
            forTheDealersMenu.Click();
            var expectedLink = MenuItems_With_Link.ForTheDealers.GetExtectedDirectedUrl();
            _element.Wait.Until(condition => _element.Url.Equals(expectedLink));
            PortalPage page = new PortalPage(_element.Driver, UrlSource.Driver);
            return new PageTasks<PageObject>(page);
        }

        public string YearsOld_Link => _element.YearsOldMenu.GetAttribute("href").TrimEnd('/') + "/";
        public PageTasks<PageObject> YearsOld_Click()
        {
            var logobookMenu = _element.YearsOldMenu;
            _element.Wait.Until(condition => logobookMenu.Displayed);
            logobookMenu.Click();
            var expectedLink = MenuItems_With_Link.YearsOld.GetExtectedDirectedUrl();
            _element.Wait.Until(condition => _element.Url.Equals(expectedLink));
            YearsOld page = new YearsOld(_element.Driver, UrlSource.Driver);
            return new PageTasks<PageObject>(page);
        }
    }
    public static class TopMenuItemsExtension
    {
        private static string _getBasePageUrl(TopMenuElementTasks.MenuItems_With_Link item) =>
            item == TopMenuElementTasks.MenuItems_With_Link.Company ? AboutPage.BaseUrl :
            item == TopMenuElementTasks.MenuItems_With_Link.PressCentre ? PressCentrePage.BaseUrl :
            item == TopMenuElementTasks.MenuItems_With_Link.BelazGlobal ? BelazGlobalPage.BaseUrl :
            item == TopMenuElementTasks.MenuItems_With_Link.ForTheDealers ? PortalPage.BaseUrl :
            item == TopMenuElementTasks.MenuItems_With_Link.YearsOld ? YearsOld.BaseUrl :
            throw new NotImplementedException();

        public static string GetExtectedLink(this TopMenuElementTasks.MenuItems_With_Link item) =>
            _getBasePageUrl(item) + "/";
        public static string GetExtectedDirectedUrl(this TopMenuElementTasks.MenuItems_With_Link item) =>
            item == TopMenuElementTasks.MenuItems_With_Link.ForTheDealers ? _getBasePageUrl(item) :
            _getBasePageUrl(item) + "/";
    }
}
