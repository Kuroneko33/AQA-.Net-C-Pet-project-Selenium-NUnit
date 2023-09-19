using NUnit.Framework;


namespace Autotests_Training_project.Tests.GitHub.Main.Search
{
    using Addons.NUnit.TestAttributes;
    using WebPages.GitHub.Main;
    using WebPages.GitHub.NotFound;
    using WebPagesTasks.GitHub.Main;
    using WebPagesTasks.GitHub.NotFound;
    using WebPagesTasks.GitHub.Main.Search;

    [FunctionalTestingLevel(FunctionalTestingLevels.Smoke)]
    [TestFixture(Author = Authors.Levizarovich_A_O.ToString)]
    public class SearchPage_SmokeTests
    {
        [SetUpTestSuite(Author = Authors.Levizarovich_A_O.ToString)]
        [FunctionalTestingLevel(FunctionalTestingLevels.Smoke)]
        public class SetUp_SearchPageTasks
        {
            private SearchPageTasks _searchPageTasks;
            [OneTimeSetUp]
            public void OneTimeSetUp()
            {
                // Arrange
                _searchPageTasks = new MainPageTasks(new MainPage()).Search;
            }
            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                _searchPageTasks.Dispose();
            }

            [TestCase(Author = Authors.Levizarovich_A_O.ToString)]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void SearchPage_should_exist()
            {
                // Arrange
                var expected_existenceState = true;
                var searchPageTasks = _searchPageTasks;
                using var gitHub_notFoundPageTasks = new NotFoundPageTasks(new NotFoundPage());

                // Act
                var isSearchPageNotFound = gitHub_notFoundPageTasks.IsPageNotFound(searchPageTasks.BaseTasks);
                var actual_existenceState = !isSearchPageNotFound;

                // Assert
                Assert.AreEqual(expected_existenceState, actual_existenceState, $"Страница не существует.");
            }

            [TestCase("Search GitHub", Author = Authors.Levizarovich_A_O.ToString)]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void Search_input_should_have_placeholder(string expected_placeholder)
            {
                // Arrange
                var searchPageTasks = _searchPageTasks;

                // Act
                var actual_placeholder = searchPageTasks.SearchPlaceholder;

                // Assert
                Assert.AreEqual(expected_placeholder, actual_placeholder,
                    $"'Поле поиска' содержит placeholder, не совпадающий с ожидаемым.");
            }
        }
    }
}
