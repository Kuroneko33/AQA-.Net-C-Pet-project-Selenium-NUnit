using NUnit.Framework;

namespace Autotests_Training_project.Tests.BelazBy.Main.Header.TopLeft.TopMenu
{
    using Extensions;
    using Addons.NUnit.TestAttributes;
    using WebPages.BelazBy.Main;
    using WebPagesTasks.BelazBy.Main;
    using WebPagesTasks.BelazBy.Main.HeaderElements.TopLeftElements;

    [FunctionalTestingLevel(FunctionalTestingLevels.CriticalPath)]
    [TestFixture(Author = Authors.Levizarovich_A_O.ToString)]
    public class TopMenu_CriticalPathTests
    {
        [FunctionalTestingLevel(FunctionalTestingLevels.CriticalPath)]
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
            [SetUp]
            public void SetUp()
            {
                _topMenuTasks.ReloadPage();
            }
            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                _topMenuTasks.Dispose();
            }

            [Author(Authors.Levizarovich_A_O.ToString)]
            public class TestCaseSource
            {
                public static object[] TopMenu_item_with_link_click_should_direct_to_page
                {
                    get
                    {
                        var topMenu_Items_With_Link = EnumExtensions.GetValuesArray<TopMenuElementTasks.MenuItems_With_Link>();
                        var testCaseSource = topMenu_Items_With_Link.ConvertAll(item => new object[] { item, item.GetExtectedDirectedUrl() });
                        return testCaseSource;
                    }
                }
            }

            [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.TopMenu_item_with_link_click_should_direct_to_page), Category = Categories.DefectDetected)]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void TopMenu_item_with_link_click_should_direct_to_page(TopMenuElementTasks.MenuItems_With_Link topMenu_Item, string expected_DirectedPage_Url)
            {
                // Arrange
                var topMenuTasks = _topMenuTasks;

                // Act
                var directedPageTasks = topMenuTasks.MenuItem_Click(topMenu_Item);
                var actual_DirectedPage_Url = directedPageTasks.Url;

                // Assert
                Assert.AreEqual(expected_DirectedPage_Url, actual_DirectedPage_Url,
                    $"При клике на меню '{topMenu_Item}' открывается страница, не совпадающая с ожидаемой.");
            }
        }
    }
}
