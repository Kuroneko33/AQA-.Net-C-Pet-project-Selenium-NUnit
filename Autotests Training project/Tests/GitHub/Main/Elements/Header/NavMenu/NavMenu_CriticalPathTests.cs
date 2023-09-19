using NUnit.Framework;

namespace Autotests_Training_project.Tests.GitHub.Main.Elements.Header.NavMenu
{
    using Extensions;
    using Addons.NUnit.TestAttributes;
    using WebPages.GitHub.Main;
    using WebPagesTasks.GitHub.Main;
    using WebPagesTasks.GitHub.Main.Elements.HeaderElements;

    [FunctionalTestingLevel(FunctionalTestingLevels.CriticalPath)]
    [TestFixture(Author = Authors.Levizarovich_A_O.ToString)]
    public class NavMenu_CriticalPathTests
    {
        [FunctionalTestingLevel(FunctionalTestingLevels.CriticalPath)]
        [SetUpTestSuite(Author = Authors.Levizarovich_A_O.ToString)]
        public class SetUp_NavMenuTasks
        {
            private NavMenuElementTasks _navMenuTasks;
            [OneTimeSetUp]
            public void OneTimeSetUp()
            {
                // Arrange
                _navMenuTasks = new MainPageTasks(new MainPage()).Header.NavMenu;
            }
            [SetUp]
            public void SetUp()
            {
                _navMenuTasks.ReloadPage();
            }
            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                _navMenuTasks.Dispose();
            }

            [Author(Authors.Levizarovich_A_O.ToString)]
            public class TestCaseSource
            {
                public static object[] NavMenu_item_with_link_click_should_direct_to_page
                {
                    get
                    {
                        var navMenu_Items_With_Link = EnumExtensions.GetValuesArray<NavMenuElementTasks.MenuItems_With_Link>();
                        var testCaseSource = navMenu_Items_With_Link.ConvertAll(item => new object[] { item, item.GetExtectedDirectedUrl() });
                        return testCaseSource;
                    }
                }
            }

            [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.NavMenu_item_with_link_click_should_direct_to_page))]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void NavMenu_item_with_link_click_should_direct_to_page(NavMenuElementTasks.MenuItems_With_Link navMenu_Item, string expected_DirectedPage_Url)
            {
                // Arrange
                var navMenuTasks = _navMenuTasks;

                // Act
                var directedPageTasks = navMenuTasks.MenuItem_Click(navMenu_Item);
                var actual_DirectedPage_Url = directedPageTasks.Url;

                // Assert
                Assert.AreEqual(expected_DirectedPage_Url, actual_DirectedPage_Url,
                    $"При клике на меню '{navMenu_Item}' открывается страница, не совпадающая с ожидаемой.");
            }
        }
    }
}
