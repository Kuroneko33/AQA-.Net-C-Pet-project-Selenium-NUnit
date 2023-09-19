using NUnit.Framework;


namespace Autotests_Training_project.Tests.GitHub.Main.Elements.Header.SearchAndSign
{
    using Addons.NUnit.TestAttributes;
    using WebPages.GitHub.Main;
    using WebPagesTasks.GitHub.Main;
    using WebPagesTasks.GitHub.Main.Elements.HeaderElements;

    [FunctionalTestingLevel(FunctionalTestingLevels.Smoke)]
    [TestFixture(Author = Authors.Levizarovich_A_O.ToString)]
    public class SearchAndSign_SmokeTests
    {
        [SetUpTestSuite(Author = Authors.Levizarovich_A_O.ToString)]
        [FunctionalTestingLevel(FunctionalTestingLevels.Smoke)]
        public class SetUp_SearchAndSignTasks
        {
            private SearchAndSignElementTasks _searchAndSignTasks;
            [OneTimeSetUp]
            public void OneTimeSetUp()
            {
                // Arrange
                _searchAndSignTasks = new MainPageTasks(new MainPage()).Header.SearchAndSign;
            }
            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                _searchAndSignTasks.Dispose();
            }

            [TestCase("Search or jump to...", Author = Authors.Levizarovich_A_O.ToString)]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void Search_input_should_have_placeholder(string expected_placeholder)
            {
                // Arrange
                var searchAndSignTasks = _searchAndSignTasks;

                // Act
                var actual_placeholder = searchAndSignTasks.SearchPlaceholder;

                // Assert
                Assert.AreEqual(expected_placeholder, actual_placeholder,
                    $"'Поле поиска' содержит placeholder, не совпадающий с ожидаемым.");
            }
        }
    }
}
