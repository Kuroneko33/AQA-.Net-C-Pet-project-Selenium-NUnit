using System.Collections.Generic;
using NUnit.Framework;

namespace Autotests_Training_project.Tests.BelazBy.Main.Header.TopLeft.TopMenu
{
    using Extensions;
    using Addons.NUnit.TestAttributes;
    using WebPagesTasks.BelazBy.Main.HeaderElements.TopLeftElements;
    using WebPagesTasks.BelazBy.Main;
    using WebPages.BelazBy.Main;

    [FunctionalTestingLevel(FunctionalTestingLevels.Smoke)]
    [TestFixture(Author = Authors.Levizarovich_A_O.ToString)]
    public class TopMenu_SmokeTests
    {
        [FunctionalTestingLevel(FunctionalTestingLevels.Smoke)]
        [SetUpTestSuite(Author = Authors.Levizarovich_A_O.ToString)]
        public class SetUp_TopMenuTasks
        {
            private TopMenuElementTasks _topMenuTasks;
            [OneTimeSetUp]
            public void OneTimeSetUp()
            {
                // Arrange
                _topMenuTasks = new MainPageTasks(new MainPage()).Header.TopLeft.TopMenu;
            }
            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                _topMenuTasks.Dispose();
            }

            [Author(Authors.Levizarovich_A_O.ToString)]
            public class TestCaseSource
            {
                public static object[] TopMenu_item_with_link_should_contain_link
                {
                    get
                    {
                        var topMenu_Items_With_Link = EnumExtensions.GetValuesArray<TopMenuElementTasks.MenuItems_With_Link>();
                        var testCaseSource = topMenu_Items_With_Link.ConvertAll(item => new object[] { item, item.GetExtectedLink() });
                        return testCaseSource;
                    }
                }
            }

            [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.TopMenu_item_with_link_should_contain_link), Category = Categories.DefectDetected)]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void TopMenu_item_with_link_should_contain_link(TopMenuElementTasks.MenuItems_With_Link topMenu_Item, string expected_Link)
            {
                // Arrange
                var topMenuTasks = _topMenuTasks;

                // Act
                var actual_MenuItem_Link = topMenuTasks.MenuItem_GetLink(topMenu_Item);

                // Assert
                Assert.AreEqual(expected_Link, actual_MenuItem_Link,
                    $"Меню '{topMenu_Item}' содержит ссылку, не совпадающую с ожидаемой.");
            }
        }
    }

}
