using NUnit.Framework;

namespace Autotests_Training_project.Tests.GitHub.Main.Elements.Header
{
    using Addons.NUnit.TestAttributes;
    using WebPages.GitHub.Main;
    using WebPages.GitHub.Main.Elements.HeaderElements;
    using WebPagesTasks.GitHub.Main;
    using WebPagesTasks.GitHub.Main.Elements;

    [FunctionalTestingLevel(FunctionalTestingLevels.Smoke)]
    [TestFixture(Author = Authors.Levizarovich_A_O.ToString)]
    public class Header_SmokeTests
    {
        [SetUpTestSuite(Author = Authors.Levizarovich_A_O.ToString)]
        [FunctionalTestingLevel(FunctionalTestingLevels.Smoke)]
        public class SetUp_HeaderTasks
        {
            private HeaderElementTasks _headerTasks;
            [OneTimeSetUp]
            public void OneTimeSetUp()
            {
                // Arrange
                _headerTasks = new MainPageTasks(new MainPage()).Header;
            }
            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                _headerTasks.Dispose();
            }

            [TestCase(MainPage.BaseUrl + "/", Author = Authors.Levizarovich_A_O.ToString)]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void Logo_should_contain_link_to_MainPage(string expected_Logo_Link)
            {
                // Arrange
                var headerTasks = _headerTasks;

                // Act
                var actual_Logo_Link = headerTasks.Logo_Link;

                // Assert
                Assert.AreEqual(expected_Logo_Link, actual_Logo_Link,
                    $"'Лого' содержит ссылку, не совпадающую с ожидаемой.");
            }
        }

        public class SetUp_MainPage_WithCustomWidth
        {
            private MainPage _mainPage;
            [OneTimeSetUp]
            public void OneTimeSetUp()
            {
                // Arrange
                _mainPage = new MainPage();
                _mainPage.WebDriverBuilder.IsDevToolsSessionEnabled = true;
            }
            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                _mainPage.Dispose();
            }

            [TestCase(NavMenuElement.Width_Adaptivity_Boundary.Collapsing, true, Author = Authors.Levizarovich_A_O.ToString)]
            [TestCase(NavMenuElement.Width_Adaptivity_Boundary.Dispayling, false, Author = Authors.Levizarovich_A_O.ToString,
                Category = Categories.DefectDetected)]
            [TestCase(NavMenuElement.Width_Adaptivity_Boundary.Dispayling + 1, false, Author = Authors.Levizarovich_A_O.ToString,
                Category = Categories.DefectResearch, Reason = Reasons.DefectExistence, Description = "Граничное значение окончания дефекта")]
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void ToggleNavigation_button_should_have_widthAdaptive_displaying(int pageWidth, bool expected_DisplayingState)
            {
                // Arrange
                var mainPage = _mainPage;
                mainPage.WebDriverBuilder.DeviceMetrics.Width = pageWidth;
                mainPage.WebDriverBuilder.ApplyDeviceMetrics();
                var headerTasks = new MainPageTasks(mainPage).Header;

                // Act
                var actual_DisplayingState = headerTasks.ToggleNavigationButton_Displayed;

                // Assert
                Assert.AreEqual(expected_DisplayingState, actual_DisplayingState,
                    $"Состояние отображения адаптивной кнопки меню 'ToggleNavigation', не совпадает с ожидаемым.");
            }

            /// <param name="pageWidth">should be less or equal then NavMenuElement.WIDTH_ADAPTIVITY_BOUNDARY.COLLAPSING</param>
            [TestCase(NavMenuElement.Width_Adaptivity_Boundary.Collapsing, true, Author = Authors.Levizarovich_A_O.ToString)] 
            [Test(Author = Authors.Levizarovich_A_O.ToString)]
            public void ToggleNavigation_button_click_should_display_NavMenu(int pageWidth, bool expected_DisplayingState)
            {
                // Arrange
                var mainPage = _mainPage;
                mainPage.WebDriverBuilder.DeviceMetrics.Width = pageWidth;
                mainPage.WebDriverBuilder.ApplyDeviceMetrics();
                var headerTasks = new MainPageTasks(mainPage).Header;

                // Act
                var navMenuTasks = headerTasks.ToggleNavigationButton_Click();
                var actual_DisplayingState = navMenuTasks.Displayed;

                // Assert
                Assert.AreEqual(expected_DisplayingState, actual_DisplayingState,
                    $"Состояние отображения выпадающего меню 'NavMenu', не совпадает с ожидаемым.");
            }
        }
    }
}
