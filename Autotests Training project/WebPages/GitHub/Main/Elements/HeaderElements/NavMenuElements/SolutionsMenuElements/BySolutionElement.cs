using OpenQA.Selenium;
using System.Collections.Generic;

namespace Autotests_Training_project.WebPages.GitHub.Main.Elements.HeaderElements.NavMenuElements.SolutionsMenuElements
{
    using Addons.Selenium;
    using Solutions.CiCd;
    using Resources.DevOps;
    using Resources.DevOps.Fundamentals.DevSecOps;

    public class BySolutionElement : ElementObject
    {
        public BySolutionElement(IWebDriver driver, IWebElementSafe element) : base(driver, element) { }

        private IList<IWebElementSafe> menuElements;
        private IList<IWebElementSafe> _menuElements => menuElements ??= Element.FindElementsSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.Scope.Child.TagName("li").Child.TagName("a"),
            By.CssSelector($":scope>li>a"),
            By.XPath($"./li/a")));

        private const int _ciCdMenuIndex = 0;
        private IWebElementSafe ciCdMenu;
        public IWebElementSafe CiCdMenu => ciCdMenu ??= _menuElements[_ciCdMenuIndex];
        private CiCdPage ciCd;
        public CiCdPage CiCd => ciCd ??= new CiCdPage(Driver, UrlSource.PageBaseUrl);

        private const int _devOpsMenuIndex = 1;
        private IWebElementSafe devOpsMenu;
        public IWebElementSafe DevOpsMenu => devOpsMenu ??= _menuElements[_devOpsMenuIndex];
        private DevOpsPage devOps;
        public DevOpsPage DevOps => devOps ??= new DevOpsPage(Driver, UrlSource.PageBaseUrl);


        private const int _devSecOpsMenuIndex = 2;
        private IWebElementSafe devSecOpsMenu;
        public IWebElementSafe DevSecOpsMenu => devSecOpsMenu ??= _menuElements[_devSecOpsMenuIndex];
        private DevSecOpsPage devSecOps;
        public DevSecOpsPage DevSecOps => devSecOps ??= new DevSecOpsPage(Driver, UrlSource.PageBaseUrl);
    }
}
