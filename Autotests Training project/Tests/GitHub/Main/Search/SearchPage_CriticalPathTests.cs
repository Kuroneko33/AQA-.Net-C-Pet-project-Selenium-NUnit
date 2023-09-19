using NUnit.Framework;

namespace Autotests_Training_project.Tests.GitHub.Main.Search
{
    using Addons.NUnit.TestAttributes;
    using WebPages.GitHub.Main;
    using WebPages.GitHub.Main.Search;
    using WebPagesTasks.GitHub.Main;
    using WebPagesTasks.GitHub.Main.Search;
    [FunctionalTestingLevel(FunctionalTestingLevels.CriticalPath)]
    [TestFixture(Author = Authors.Levizarovich_A_O.ToString)]
    public class SearchPage_CriticalPathTests
    {
        [SetUpTestSuite(Author = Authors.Levizarovich_A_O.ToString)]
        [FunctionalTestingLevel(FunctionalTestingLevels.CriticalPath)]
        public class SetUp_SearchPageTasks
        {
            private SearchPageTasks _searchPageTasks;
            [OneTimeSetUp]
            public void OneTimeSetUp()
            {
                // Arrange
                _searchPageTasks = new MainPageTasks(new MainPage()).Search;
            }
            [SetUp]
            public void SetUp()
            {
                _searchPageTasks.ReloadPage();
            }
            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                _searchPageTasks.Dispose();
            }

            [TestCase(Authors.Levizarovich_A_O.GitHub.UserName + " " + Authors.Levizarovich_A_O.GitHub.UserId, SearchPage.BaseUrl, Author = Authors.Levizarovich_A_O.ToString)]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void Search_request_should_direct_to_page_with_request_data_in_url(string searchRequest, string expected_DirectedPage_StartWhith_Url)
            {
                // Arrange
                var searchPageTasks = _searchPageTasks;
                var expected_request_data_in_url = "?q=" + System.Uri.EscapeDataString(searchRequest);

                // Act
                searchPageTasks.Search(searchRequest);
                var actual_DirectedPage_Url = searchPageTasks.Url;

                // Assert
                Assert.That(actual_DirectedPage_Url, Does.StartWith(expected_DirectedPage_StartWhith_Url),
                    $"При поисковом запросе открывается страница, не совпадающая с ожидаемой.");
                Assert.That(actual_DirectedPage_Url, Does.Contain(expected_request_data_in_url),
                    $"При поисковом запросе параметры запроса в url страницы, не совпадают с ожидаемыми.");
            }

            [TestCase("Kuroneko33", "Kuroneko33", Author = Authors.Levizarovich_A_O.ToString)]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void Search_user_request_should_return_search_results_that_contain_searched_user_on_first_page(string searchRequest_UserName, string expected_UserName)
            {
                // Arrange
                var searchPageTasks = _searchPageTasks;

                // Act
                searchPageTasks.Search(searchRequest_UserName);
                var usersTasks = searchPageTasks.SearchResults_Users;
                var actual_UserNames = usersTasks.ConvertAll(item => item.UserId);

                // Assert
                Assert.Contains(expected_UserName, actual_UserNames, "Искомый пользователь не найден на первой странице результатов поиска");
            }
        }
    }
}
