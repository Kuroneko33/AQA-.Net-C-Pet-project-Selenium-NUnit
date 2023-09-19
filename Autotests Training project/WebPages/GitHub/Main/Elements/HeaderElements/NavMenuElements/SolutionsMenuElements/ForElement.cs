using OpenQA.Selenium;
using System.Collections.Generic;

namespace Autotests_Training_project.WebPages.GitHub.Main.Elements.HeaderElements.NavMenuElements.SolutionsMenuElements
{
    using Addons.Selenium;
    using Enterprise;
    using Team;
    using Enterprise.Startups;
    using Education;

    public class ForElement : ElementObject
    {
        public ForElement(IWebDriver driver, IWebElementSafe element) : base(driver, element) { }

        private IList<IWebElementSafe> menuElements;
        private IList<IWebElementSafe> _menuElements => menuElements ??= Element.FindElementsSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.Scope.Child.TagName("li").Child.TagName("a"),
            By.CssSelector($":scope>li>a"),
            By.XPath($"./li/a")));

        private const int _enterpriseMenuIndex = 0;
        private IWebElementSafe enterpriseMenu;
        public IWebElementSafe EnterpriseMenu => enterpriseMenu ??= _menuElements[_enterpriseMenuIndex];
        private EnterprisePage enterprise;
        public EnterprisePage Enterprise => enterprise ??= new EnterprisePage(Driver, UrlSource.PageBaseUrl);

        private const int _teamMenuIndex = 0;
        private IWebElementSafe teamMenu;
        public IWebElementSafe TeamMenu => teamMenu ??= _menuElements[_teamMenuIndex];
        private TeamPage team;
        public TeamPage Team => team ??= new TeamPage(Driver, UrlSource.PageBaseUrl);

        private const int _startupsMenuIndex = 0;
        private IWebElementSafe startupsMenu;
        public IWebElementSafe StartupsMenu => startupsMenu ??= _menuElements[_startupsMenuIndex];
        private StartupsPage startups;
        public StartupsPage Startups => startups ??= new StartupsPage(Driver, UrlSource.PageBaseUrl);

        private const int _educationMenuIndex = 0;
        private IWebElementSafe educationMenu;
        public IWebElementSafe EducationMenu => educationMenu ??= _menuElements[_educationMenuIndex];
        private EducationPage education;
        public EducationPage Education => education ??= new EducationPage(Driver, UrlSource.PageBaseUrl);
    }
}
