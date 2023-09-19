using NUnit.Framework;


namespace Autotests_Training_project.Tests.GitHub.Main.Elements.Header.NavMenu.ProductMenu
{
    using Extensions;
    using Addons.NUnit.TestAttributes;
    using WebPages.GitHub.Main;
    using WebPagesTasks.GitHub.Main;
    using WebPagesTasks.GitHub.Main.Elements.HeaderElements;
    using WebPagesTasks.GitHub.Main.Elements.HeaderElements.NavMenuElements;
    using WebPagesTasks.GitHub.Main.Elements.HeaderElements.NavMenuElements.ProductMenuElements;

    [FunctionalTestingLevel(FunctionalTestingLevels.CriticalPath)]
    [TestFixture(Author = Authors.Levizarovich_A_O.ToString)]
    public class ProductMenu_CriticalPathTests
    {
        [FunctionalTestingLevel(FunctionalTestingLevels.CriticalPath)]
        [SetUpTestSuite(Author = Authors.Levizarovich_A_O.ToString)]
        public class SetUp_ProductMenuTasks
        {
            private ProductMenuElementTasks _productMenuTasks;
            [OneTimeSetUp]
            public void OneTimeSetUp()
            {
                // Arrange
                _productMenuTasks = new MainPageTasks(new MainPage()).Header.NavMenu.ProductMenu;
            }
            [SetUp]
            public void SetUp()
            {
                _productMenuTasks.ReloadPage();
            }
            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                _productMenuTasks.Dispose();
            }

            [Author(Authors.Levizarovich_A_O.ToString)]
            public class TestCaseSource
            {
                public static object[] FirstColumn_item_with_link_click_should_direct_to_page
                {
                    get
                    {
                        var secondColumn_Items_With_Link = EnumExtensions.GetValuesArray<FirstColumnElementTasks.MenuItems_With_Link>();
                        var testCaseSource = secondColumn_Items_With_Link.ConvertAll(item => new object[] { item, item.GetExtectedDirectedUrl() });
                        return testCaseSource;
                    }
                }
                public static object[] SecondColumn_item_with_link_click_should_direct_to_page
                {
                    get
                    {
                        var fistColumn_Items_With_Link = EnumExtensions.GetValuesArray<SecondColumnElementTasks.MenuItems_With_Link>();
                        var testCaseSource = fistColumn_Items_With_Link.ConvertAll(item => new object[] { item, item.GetExtectedDirectedUrl() });
                        return testCaseSource;
                    }
                }
            }

            [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.FirstColumn_item_with_link_click_should_direct_to_page))]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void FirstColumn_item_with_link_click_should_direct_to_page(FirstColumnElementTasks.MenuItems_With_Link navMenu_Item, string expected_DirectedPage_Url)
            {
                // Arrange
                var firstColumnTasks = _productMenuTasks.FirstColumn;

                // Act
                var directedPageTasks = firstColumnTasks.MenuItem_Click(navMenu_Item);
                var actual_DirectedPage_Url = directedPageTasks.Url;

                // Assert
                Assert.AreEqual(expected_DirectedPage_Url, actual_DirectedPage_Url,
                    $"При клике на меню '{navMenu_Item}' открывается страница, не совпадающая с ожидаемой.");
            }

            [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.SecondColumn_item_with_link_click_should_direct_to_page))]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void SecondColumn_item_with_link_click_should_direct_to_page(SecondColumnElementTasks.MenuItems_With_Link navMenu_Item, string expected_DirectedPage_Url)
            {
                // Arrange
                var secondColumnTasks = _productMenuTasks.SecondColumn;

                // Act
                var directedPageTasks = secondColumnTasks.MenuItem_Click(navMenu_Item);
                var actual_DirectedPage_Url = directedPageTasks.Url;

                // Assert
                Assert.AreEqual(expected_DirectedPage_Url, actual_DirectedPage_Url,
                    $"При клике на меню '{navMenu_Item}' открывается страница, не совпадающая с ожидаемой.");
            }
        }
    }
}
