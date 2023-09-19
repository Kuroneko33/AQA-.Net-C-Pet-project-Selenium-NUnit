using NUnit.Framework;


namespace Autotests_Training_project.Tests.GitHub.Main.Elements.Header.SearchAndSign
{
    using Autotests_Training_project.WebPages.GitHub.Main.Search;
    using Addons.NUnit.TestAttributes;
    using WebPages.GitHub.Main;
    using WebPagesTasks.GitHub.Main;
    using WebPagesTasks.GitHub.Main.Elements.HeaderElements;

    [FunctionalTestingLevel(FunctionalTestingLevels.CriticalPath)]
    [TestFixture(Author = Authors.Levizarovich_A_O.ToString)]
    public class SearchAndSign_CriticalPathTests
    {
        [SetUpTestSuite(Author = Authors.Levizarovich_A_O.ToString)]
        [FunctionalTestingLevel(FunctionalTestingLevels.CriticalPath)]
        public class SetUp_SearchAndSignTasks
        {
            private SearchAndSignElementTasks _searchAndSignTasks;
            [OneTimeSetUp]
            public void OneTimeSetUp()
            {
                // Arrange
                _searchAndSignTasks = new MainPageTasks(new MainPage()).Header.SearchAndSign;
            }
            [SetUp]
            public void SetUp()
            {
                _searchAndSignTasks.ReloadPage();
            }
            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                _searchAndSignTasks.Dispose();
            }

            [TestCase(SearchPage.BaseUrl, Author = Authors.Levizarovich_A_O.ToString)]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void Search_input_submit_should_direct_to_page(string expected_DirectedPage_StartWhith_Url)
            {
                // Arrange
                var searchAndSignTasks = _searchAndSignTasks;

                // Act
                var searchPageTasks = searchAndSignTasks.Submit();
                var actual_DirectedPage_Url = searchPageTasks.Url;

                // Assert
                Assert.That(actual_DirectedPage_Url, Does.StartWith(expected_DirectedPage_StartWhith_Url),
                    $"При подтверждении ввода в 'поле поиска' открывается страница, не совпадающая с ожидаемой.");
            }

            [TestCase(Authors.Levizarovich_A_O.GitHub.UserName + " " + Authors.Levizarovich_A_O.GitHub.UserId, SearchPage.BaseUrl, Author = Authors.Levizarovich_A_O.ToString)]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void Search_request_should_direct_to_page_with_request_data_in_url(string searchRequest, string expected_DirectedPage_StartWhith_Url)
            {
                // Arrange
                var searchAndSignTasks = _searchAndSignTasks;
                var expected_request_data_in_url = "?q=" + System.Uri.EscapeDataString(searchRequest);

                // Act
                var searchPageTasks = searchAndSignTasks.Search(searchRequest);
                var actual_DirectedPage_Url = searchPageTasks.Url;

                // Assert
                Assert.That(actual_DirectedPage_Url, Does.StartWith(expected_DirectedPage_StartWhith_Url),
                    $"При поисковом запросе открывается страница, не совпадающая с ожидаемой.");
                Assert.That(actual_DirectedPage_Url, Does.Contain(expected_request_data_in_url),
                    $"При поисковом запросе параметры запроса в url страницы, не совпадают с ожидаемыми.");
            }
        }
    }
}