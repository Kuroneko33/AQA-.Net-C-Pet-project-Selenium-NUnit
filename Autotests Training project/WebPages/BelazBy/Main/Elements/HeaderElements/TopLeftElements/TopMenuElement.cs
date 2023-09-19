using OpenQA.Selenium;
using System.Collections.Generic;

namespace Autotests_Training_project.WebPages.BelazBy.Main.Elements.HeaderElements.TopLeftElements
{
    using Addons.Selenium;
    using About;
    using PressCentre;
    using About.BelazGlobal;
    using Sapportal.Irj.Portal;
    using PressCentre.YearsOld;

    public class TopMenuElement : ElementObject
    {
        public TopMenuElement(IWebDriver driver, IWebElementSafe element) : base(driver, element) { }

        private IList<IWebElementSafe> menuElements;
        private IList<IWebElementSafe> _menuElements => menuElements ??= Element.FindElementsSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.Scope.Child.TagName("div").Child.TagName("a"),
            By.CssSelector($":scope>div>a"),
            By.XPath($"./div/a")));

        private const int _companyMenuIndex = 0;
        private IWebElementSafe companyMenu;
        public IWebElementSafe CompanyMenu => companyMenu ??= _menuElements[_companyMenuIndex];
        private AboutPage company;
        public AboutPage Company => company ??= new AboutPage(Driver, UrlSource.PageBaseUrl);

        private const int _pressCentreMenuIndex = 1;
        private IWebElementSafe pressCentreMenu;
        public IWebElementSafe PressCentreMenu => pressCentreMenu ??= _menuElements[_pressCentreMenuIndex];
        private PressCentrePage pressCentre;
        public PressCentrePage PressCentre => pressCentre ??= new PressCentrePage(Driver, UrlSource.PageBaseUrl);
        
        private const int _belazGlobalMenuIndex = 2;
        private IWebElementSafe belazGlobalMenu;
        public IWebElementSafe BelazGlobalMenu => belazGlobalMenu ??= _menuElements[_belazGlobalMenuIndex];
        private BelazGlobalPage belazGlobal;
        public BelazGlobalPage BelazGlobal => belazGlobal ??= new BelazGlobalPage(Driver, UrlSource.PageBaseUrl);
        
        private const int _forTheDealersMenuIndex = 3;
        private IWebElementSafe forTheDealersMenu;
        public IWebElementSafe ForTheDealersMenu => forTheDealersMenu ??= _menuElements[_forTheDealersMenuIndex];
        private PortalPage forTheDealers;
        public PortalPage ForTheDealers => forTheDealers ??= new PortalPage(Driver, UrlSource.PageBaseUrl);

        private const int _yearsOldMenuIndex = 4;
        private IWebElementSafe logobookMenu;
        public IWebElementSafe YearsOldMenu => logobookMenu ??= _menuElements[_yearsOldMenuIndex];
        private YearsOld yearsOld;
        public YearsOld YearsOld => yearsOld ??= new YearsOld(Driver, UrlSource.PageBaseUrl);
    }
}
