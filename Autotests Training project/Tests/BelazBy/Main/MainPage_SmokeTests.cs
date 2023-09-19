using NUnit.Framework;

namespace Autotests_Training_project.Tests.BelazBy.Main
{
    using Addons.NUnit.TestAttributes;
    using WebPages.BelazBy.Main;
    using WebPages.BelazBy.NotFound;
    using WebPagesTasks.BelazBy.Main;
    using WebPagesTasks.BelazBy.NotFound;

    [FunctionalTestingLevel(FunctionalTestingLevels.Smoke)]
    [TestFixture(Author = Authors.Levizarovich_A_O.ToString)]
    public class MainPage_SmokeTests
    {
        [SetUpTestSuite(Author = Authors.Levizarovich_A_O.ToString)]
        [FunctionalTestingLevel(FunctionalTestingLevels.Smoke)]
        public class SetUp_MainPageTasks
        {
            private MainPageTasks _mainPageTasks;
            [OneTimeSetUp]
            public void OneTimeSetUp()
            {
                // Arrange
                _mainPageTasks = new MainPageTasks(new MainPage());
            }
            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                _mainPageTasks.Dispose();
            }

            [TestCase(Author = Authors.Levizarovich_A_O.ToString)]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void MainPage_should_exist()
            {
                // Arrange
                var expected_existenceState = true;
                var mainPageTasks = _mainPageTasks;
                using var gitHub_notFoundPageTasks = new NotFoundPageTasks(new NotFoundPage());

                // Act
                var isMainPageNotFound = gitHub_notFoundPageTasks.IsPageNotFound(mainPageTasks.BaseTasks);
                var actual_existenceState = !isMainPageNotFound;

                // Assert
                Assert.AreEqual(expected_existenceState, actual_existenceState, $"Страница не существует.");
            }

            [TestCase("Техника для высоких достижений", Author = Authors.Levizarovich_A_O.ToString)]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void MainPage_should_have_heading(string expected_HeadingText)
            {
                // Arrange
                var mainPageTasks = _mainPageTasks;

                // Act
                var actual_HeadingText = mainPageTasks.HeadingText;

                // Assert
                Assert.AreEqual(expected_HeadingText, actual_HeadingText, $"Действительный заголовок не совпадает с ожидаемым.");
            }
        }
    }
}