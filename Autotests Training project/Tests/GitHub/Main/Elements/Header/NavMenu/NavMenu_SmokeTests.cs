using NUnit.Framework;

namespace Autotests_Training_project.Tests.GitHub.Main.Elements.Header.NavMenu
{
    using Extensions;
    using Addons.NUnit.TestAttributes;
    using WebPages.GitHub.Main;
    using WebPages.GitHub.Main.Elements.HeaderElements;
    using WebPagesTasks.GitHub.Main;
    using WebPagesTasks.GitHub.Main.Elements.HeaderElements;

    [FunctionalTestingLevel(FunctionalTestingLevels.Smoke)]
    [TestFixture(Author = Authors.Levizarovich_A_O.ToString)]
    public class NavMenu_SmokeTests
    {
        public class SetUp_MainPage_WithCustomWidth
        {
            private MainPage _mainPage;
            [OneTimeSetUp]
            public void OneTimeSetUp()
            {
                // Arrange
                _mainPage = new MainPage();
                _mainPage.WebDriverBuilder.IsDevToolsSessionEnabled = true;
            }
            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                _mainPage.Dispose();
            }

            [TestCase(NavMenuElement.Width_Adaptivity_Boundary.Collapsing, false, Author = Authors.Levizarovich_A_O.ToString)]
            [TestCase(NavMenuElement.Width_Adaptivity_Boundary.Dispayling, true, Author = Authors.Levizarovich_A_O.ToString)]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void NavMenu_should_have_widthAdaptive_displaying(int pageWidth, bool expected_DisplayingState)
            {
                // Arrange
                var mainPage = _mainPage;
                mainPage.WebDriverBuilder.DeviceMetrics.Width = pageWidth;
                mainPage.WebDriverBuilder.ApplyDeviceMetrics();
                var navMenuTasks = new MainPageTasks(mainPage).Header.NavMenu;

                // Act
                var actual_DisplayingState = navMenuTasks.Displayed;

                // Assert
                Assert.AreEqual(expected_DisplayingState, actual_DisplayingState,
                    $"Состояние отображения выпадающего меню 'NavMenu', не совпадает с ожидаемым.");
            }
        }

        [FunctionalTestingLevel(FunctionalTestingLevels.Smoke)]
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
            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                _navMenuTasks.Dispose();
            }

            [Author(Authors.Levizarovich_A_O.ToString)]
            public class TestCaseSource
            {
                public static object[] NavMenu_item_with_subMenu_click_should_display_SubMenu
                {
                    get
                    {
                        var navMenu_Items_With_SubMenu = EnumExtensions.GetValuesArray<NavMenuElementTasks.MenuItems_With_SubMenu>();
                        bool expected_DisplayingState = true;
                        var testCaseSource = navMenu_Items_With_SubMenu.ConvertAll(item => new object[] { item, expected_DisplayingState });
                        return testCaseSource;
                    }
                }
                public static object[] NavMenu_item_with_link_should_contain_link
                {
                    get
                    {
                        var navMenu_Items_With_Link = EnumExtensions.GetValuesArray<NavMenuElementTasks.MenuItems_With_Link>();
                        var testCaseSource = navMenu_Items_With_Link.ConvertAll(item => new object[] { item, item.GetExtectedLink() });
                        return testCaseSource;
                    }
                }
            }
            
            [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.NavMenu_item_with_subMenu_click_should_display_SubMenu))]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void NavMenu_item_with_subMenu_click_should_display_SubMenu(NavMenuElementTasks.MenuItems_With_SubMenu navMenu_Item, bool expected_DisplayingState)
            {
                // Arrange
                var navMenuTasks = _navMenuTasks;

                // Act
                var subMenuTasks = navMenuTasks.MenuItem_Click(navMenu_Item);
                var actual_DisplayingState = subMenuTasks.Displayed;

                // Assert
                Assert.AreEqual(expected_DisplayingState, actual_DisplayingState,
                    $"Состояние отображения выпадающего меню '{navMenu_Item}', не совпадает с ожидаемым.");
            }

            [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.NavMenu_item_with_link_should_contain_link))]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void NavMenu_item_with_link_should_contain_link(NavMenuElementTasks.MenuItems_With_Link navMenu_Item, string expected_Link)
            {
                // Arrange
                var navMenuTasks = _navMenuTasks;

                // Act
                var actual_MenuItem_Link = navMenuTasks.MenuItem_GetLink(navMenu_Item);

                // Assert
                Assert.AreEqual(expected_Link, actual_MenuItem_Link,
                    $"Меню '{navMenu_Item}' содержит ссылку, не совпадающую с ожидаемой.");
            }
        }
    }
}
