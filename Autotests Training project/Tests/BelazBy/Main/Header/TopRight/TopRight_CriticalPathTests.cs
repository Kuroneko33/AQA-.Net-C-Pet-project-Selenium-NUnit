using NUnit.Framework;

namespace Autotests_Training_project.Tests.BelazBy.Main.Header.TopRight
{
    using Extensions;
    using Addons.NUnit.TestAttributes;
    using WebPagesTasks.BelazBy.Main.HeaderElements;
    using WebPagesTasks.BelazBy.Main;
    using WebPages.BelazBy.Main;
    using System.Text.RegularExpressions;

    [FunctionalTestingLevel(FunctionalTestingLevels.CriticalPath)]
    [TestFixture(Author = Authors.Levizarovich_A_O.ToString)]
    public class TopRight_CriticalPathTests
    {
        [FunctionalTestingLevel(FunctionalTestingLevels.CriticalPath)]
        [SetUpTestSuite(Author = Authors.Levizarovich_A_O.ToString)]
        public class SetUp_TopRightTasks
        {
            private TopRightElementTasks _topRightTasks;
            private MainPage _mainPage;
            [OneTimeSetUp]
            public void OneTimeSetUp()
            {
                // Arrange
                _mainPage = new MainPage();
                _topRightTasks = new MainPageTasks(_mainPage).Header.TopRight;
            }
            [SetUp]
            public void SetUp()
            {
                _topRightTasks.ReloadPage();
            }
            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                _topRightTasks.Dispose();
            }

            [Author(Authors.Levizarovich_A_O.ToString)]
            public class TestCaseSource
            {
                private static string _getExpectedUrl(TopRightElementTasks.MenuItems_With_Link item) =>
                    item == TopRightElementTasks.MenuItems_With_Link.Ru ? string.Empty :
                    item.GetExpectedLang().ToString().ToLower();
                public static object[] TopRight_item_with_link_click_should_direct_to_page_that_contains_lang_in_url
                {
                    get
                    {
                        var topRightMenu_Items_With_Link = EnumExtensions.GetValuesArray<TopRightElementTasks.MenuItems_With_Link>();
                        var testCaseSource = topRightMenu_Items_With_Link.ConvertAll(item => new object[] { item, _getExpectedUrl(item) });
                        return testCaseSource;
                    }
                }

                public static object[] TopRight_country_at_localization_should_be
                {
                    get
                    {
                        var localizations = EnumExtensions.GetValuesArray<MainPage.LangEnum>();
                        var testCaseSource = localizations.ConvertAll(lang => new object[] { lang, lang.GetExpectedCountryText() });
                        return testCaseSource;
                    }
                }
            }

            [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.TopRight_item_with_link_click_should_direct_to_page_that_contains_lang_in_url))]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void TopRight_item_with_link_click_should_direct_to_page_that_contains_lang_in_url(TopRightElementTasks.MenuItems_With_Link topRightMenu_Item, string expected_UrlLang)
            {
                // Arrange
                var topRightTasks = _topRightTasks;
                var findLangBaseRegex = MainPage.BaseUrl + "/.{2}/";

                // Act
                topRightTasks.MenuItem_Click(TopRightElementTasks.MenuItems_With_Link.En);
                var directedPageTasks = topRightTasks.MenuItem_Click(topRightMenu_Item);
                var langBase = Regex.Match(directedPageTasks.Url, findLangBaseRegex).Value;
                var actual_UrlLang = langBase.Replace(MainPage.BaseUrl, string.Empty).Replace("/", string.Empty);

                // Assert
                Assert.AreEqual(expected_UrlLang, actual_UrlLang,
                    $"При клике на меню '{topRightMenu_Item}' открывается страница, не совпадающая с ожидаемой.");
            }

            [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.TopRight_country_at_localization_should_be))]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void TopRight_country_at_localization_should_be(MainPage.LangEnum localization, string expected_Country)
            {
                // Arrange
                var mainPage = _mainPage;
                mainPage.Lang = localization;
                var topRightTasks = _topRightTasks;

                // Act
                var actual_Country = topRightTasks.CountryText;

                // Assert
                Assert.AreEqual(expected_Country, actual_Country,
                    $"При локализации '{localization}' отображается страна, не совпадающая с ожидаемой.");
            }
        }
    }
}
