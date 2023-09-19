using NUnit.Framework;

namespace Autotests_Training_project.Tests.BelazBy.Main.Header.TopRight
{
    using Extensions;
    using Addons.NUnit.TestAttributes;
    using WebPagesTasks.BelazBy.Main.HeaderElements;
    using WebPagesTasks.BelazBy.Main;
    using WebPages.BelazBy.Main;

    [FunctionalTestingLevel(FunctionalTestingLevels.Smoke)]
    [TestFixture(Author = Authors.Levizarovich_A_O.ToString)]
    public class TopRight_SmokeTests
    {
        [FunctionalTestingLevel(FunctionalTestingLevels.Smoke)]
        [SetUpTestSuite(Author = Authors.Levizarovich_A_O.ToString)]
        public class SetUp_TopRightTasks
        {
            private TopRightElementTasks _topRightTasks;
            [OneTimeSetUp]
            public void OneTimeSetUp()
            {
                // Arrange
                _topRightTasks = new MainPageTasks(new MainPage()).Header.TopRight;
            }
            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                _topRightTasks.Dispose();
            }

            [Author(Authors.Levizarovich_A_O.ToString)]
            public class TestCaseSource
            {
                private static string _getExpectedUrl(TopRightElementTasks.MenuItems_With_Link lang) =>
                    lang == TopRightElementTasks.MenuItems_With_Link.Ru ? "javascript:void(0);/" :
                    MainPage.BaseUrl + $"/{lang.ToString().ToLower()}/?redirectcustom=Y/";
                private static object[] _createTestCase(TopRightElementTasks.MenuItems_With_Link lang) =>
                    new object[] { lang, _getExpectedUrl(lang) };
                public static object[] TopRight_item_with_link_should_contain_link
                {
                    get
                    {
                        var topRightMenu_Items_With_Link = EnumExtensions.GetValuesArray<TopRightElementTasks.MenuItems_With_Link>();
                        var testCaseSource = topRightMenu_Items_With_Link.ConvertAll(item => _createTestCase(item));
                        return testCaseSource;
                    }
                }
            }

            [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.TopRight_item_with_link_should_contain_link))]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void TopRight_item_with_link_should_contain_link(TopRightElementTasks.MenuItems_With_Link topRightMenu_Item, string expected_Link)
            {
                // Arrange
                var topRightTasks = _topRightTasks;

                // Act
                var actual_RightItem_Link = topRightTasks.MenuItem_GetLink(topRightMenu_Item);

                // Assert
                Assert.AreEqual(expected_Link, actual_RightItem_Link,
                    $"Меню '{topRightMenu_Item}' содержит ссылку, не совпадающую с ожидаемой.");
            }
        }
    }

}
