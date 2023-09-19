using NUnit.Framework;

namespace Autotests_Training_project.Tests.GitHub.Main.Elements.Header
{
    using Addons.NUnit.TestAttributes;
    using WebPages.GitHub.Main;
    using WebPagesTasks.GitHub.Main;

    [FunctionalTestingLevel(FunctionalTestingLevels.CriticalPath)]
    [TestFixture(Author = Authors.Levizarovich_A_O.ToString)]
    public class Header_CriticalPathTests
    {
        [FunctionalTestingLevel(FunctionalTestingLevels.CriticalPath)]
        [SetUpTestSuite(Author = Authors.Levizarovich_A_O.ToString)]
        public class SetUp_MainPageTasks
        {
            private MainPageTasks _mainPageTasks;
            [OneTimeSetUp]
            public void OneTimeSetUp()
            {
                // Arrange
                _mainPageTasks = new MainPageTasks(new MainPage());
            }
            [SetUp]
            public void SetUp()
            {
                _mainPageTasks.ReloadPage();
            }
            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                _mainPageTasks.Dispose();
            }

            [TestCase(MainPage.BaseUrl + "/", Author = Authors.Levizarovich_A_O.ToString)]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void Logo_click_should_direct_to_MainPage(string expected_DirectedPage_Url)
            {
                // Arrange
                var headerTasks = _mainPageTasks.Header;

                // Act
                var directedPageTasks = headerTasks.Logo_Click();
                var actual_DirectedPage_Url = directedPageTasks.Url;

                // Assert
                Assert.AreEqual(expected_DirectedPage_Url, actual_DirectedPage_Url,
                    $"При клике на 'Лого' открывается страница, не совпадающая с ожидаемой.");
            }

            [TestCase(MainPage.BaseUrl + "/", Author = Authors.Levizarovich_A_O.ToString)]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void Logo_click_on_not_MainPage_should_direct_to_MainPage(string expected_DirectedPage_Url)
            {
                // Arrange
                var pricingTasks = _mainPageTasks.Pricing;
                var headerTasks = pricingTasks.Header;

                // Act
                var directedPageTasks = headerTasks.Logo_Click();
                var actual_DirectedPage_Url = directedPageTasks.Url;

                // Assert
                Assert.AreEqual(expected_DirectedPage_Url, actual_DirectedPage_Url,
                    $"При клике на 'Лого' открывается страница, не совпадающая с ожидаемой.");
            }
        }
    }
}
