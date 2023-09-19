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

    [FunctionalTestingLevel(FunctionalTestingLevels.Smoke)]
    [TestFixture(Author = Authors.Levizarovich_A_O.ToString)]
    public class ProductMenu_SmokeTests
    {
        [FunctionalTestingLevel(FunctionalTestingLevels.Smoke)]
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
            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                _productMenuTasks.Dispose();
            }

            [Author(Authors.Levizarovich_A_O.ToString)]
            public class TestCaseSource
            {
                public static object[] FirstColumn_item_with_link_should_contain_link
                {
                    get
                    {
                        var fistColumn_Items_With_Link = EnumExtensions.GetValuesArray<FirstColumnElementTasks.MenuItems_With_Link>();
                        var testCaseSource = fistColumn_Items_With_Link.ConvertAll(item => new object[] { item, item.GetExtectedLink() });
                        return testCaseSource;
                    }
                }
                public static object[] SecondColumn_item_with_link_should_contain_link
                {
                    get
                    {
                        var fistColumn_Items_With_Link = EnumExtensions.GetValuesArray<SecondColumnElementTasks.MenuItems_With_Link>();
                        var testCaseSource = fistColumn_Items_With_Link.ConvertAll(item => new object[] { item, item.GetExtectedLink() });
                        return testCaseSource;
                    }
                }
            }

            [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.FirstColumn_item_with_link_should_contain_link))]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void FirstColumn_item_with_link_should_contain_link(FirstColumnElementTasks.MenuItems_With_Link navMenu_Item, string expected_Link)
            {
                // Arrange
                var firstColumnTasks = _productMenuTasks.FirstColumn;

                // Act
                var actual_MenuItem_Link = firstColumnTasks.MenuItem_GetLink(navMenu_Item);

                // Assert
                Assert.AreEqual(expected_Link, actual_MenuItem_Link,
                    $"Меню '{navMenu_Item}' содержит ссылку, не совпадающую с ожидаемой.");
            }

            [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.SecondColumn_item_with_link_should_contain_link))]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void SecondColumn_item_with_link_should_contain_link(SecondColumnElementTasks.MenuItems_With_Link navMenu_Item, string expected_Link)
            {
                // Arrange
                var secondColumnTasks = _productMenuTasks.SecondColumn;

                // Act
                var actual_MenuItem_Link = secondColumnTasks.MenuItem_GetLink(navMenu_Item);

                // Assert
                Assert.AreEqual(expected_Link, actual_MenuItem_Link,
                    $"Меню '{navMenu_Item}' содержит ссылку, не совпадающую с ожидаемой.");
            }
        }
    }
}
