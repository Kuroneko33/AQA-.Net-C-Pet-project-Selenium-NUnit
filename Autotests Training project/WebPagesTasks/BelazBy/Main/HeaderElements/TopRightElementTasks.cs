using System;

namespace Autotests_Training_project.WebPagesTasks.BelazBy.Main.HeaderElements
{
    using WebPages.BelazBy.Main.Elements.HeaderElements;
    using WebPages.BelazBy.Main;
    using WebPages;
    using System.Text.RegularExpressions;

    public class TopRightElementTasks : ElementTasks<TopRightElement>
    {
        public TopRightElementTasks(TopRightElement element) : base(element) { }

        public enum MenuItems_With_Link
        {
            Ru,
            By,
            En,
            Cn
        }

        public string MenuItem_GetLink(MenuItems_With_Link item) =>
            item == MenuItems_With_Link.Ru ? Ru_Link :
            item == MenuItems_With_Link.By ? By_Link :
            item == MenuItems_With_Link.En ? En_Link :
            item == MenuItems_With_Link.Cn ? Cn_Link :
            throw new NotImplementedException();
        /// <summary>
        /// returns PageTasksBase<PageObject>
        /// </summary>
        public PageTasks<PageObject> MenuItem_Click(MenuItems_With_Link item) =>
            item == MenuItems_With_Link.Ru ? Ru_Click().BaseTasks :
            item == MenuItems_With_Link.By ? By_Click().BaseTasks :
            item == MenuItems_With_Link.En ? En_Click().BaseTasks :
            item == MenuItems_With_Link.Cn ? Cn_Click().BaseTasks :
            throw new NotImplementedException();

        public string Ru_Link => _element.TopLang.RuMenu.GetAttribute("href").TrimEnd('/') + "/";
        public PageTasks<PageObject> Ru_Click()
        {
            var ruMenu = _element.TopLang.RuMenu;
            _element.Wait.Until(condition => ruMenu.Displayed);
            var expectedLink = _element.Url;
            expectedLink = Regex.Replace(expectedLink, MainPage.BaseUrl + "/.{2}/", MainPage.BaseUrl + "/");
            ruMenu.Click();
            _element.Wait.Until(condition => _element.Url.StartsWith(expectedLink));
            PageObject page = new PageObject(_element.Driver, UrlSource.Driver);
            return new PageTasks<PageObject>(page);
        }

        public string By_Link => _element.TopLang.ByMenu.GetAttribute("href").TrimEnd('/') + "/";
        public PageTasks<PageObject> By_Click()
        {
            var byMenu = _element.TopLang.ByMenu;
            _element.Wait.Until(condition => byMenu.Displayed);
            var expectedLink = _element.Url;
            expectedLink = Regex.Replace(expectedLink, MainPage.BaseUrl + "/.{2}/", MainPage.BaseUrl + "/");
            expectedLink = expectedLink.Replace(MainPage.BaseUrl + "/", MainPage.BaseUrl + "/by/");
            byMenu.Click();
            _element.Wait.Until(condition => _element.Url.StartsWith(expectedLink));
            PageObject page = new PageObject(_element.Driver, UrlSource.Driver);
            return new PageTasks<PageObject>(page);
        }

        public string En_Link => _element.TopLang.EnMenu.GetAttribute("href").TrimEnd('/') + "/";
        public PageTasks<PageObject> En_Click()
        {
            var enMenu = _element.TopLang.EnMenu;
            _element.Wait.Until(condition => enMenu.Displayed);
            var expectedLink = _element.Url;
            expectedLink = Regex.Replace(expectedLink, MainPage.BaseUrl + "/.{2}/", MainPage.BaseUrl + "/");
            expectedLink = expectedLink.Replace(MainPage.BaseUrl + "/", MainPage.BaseUrl + "/en/");
            enMenu.Click();
            _element.Wait.Until(condition => _element.Url.StartsWith(expectedLink));
            PageObject page = new PageObject(_element.Driver, UrlSource.Driver);
            return new PageTasks<PageObject>(page);
        }

        public string Cn_Link => _element.TopLang.CnMenu.GetAttribute("href").TrimEnd('/') + "/";
        public PageTasks<PageObject> Cn_Click()
        {
            var cnMcnu = _element.TopLang.CnMenu;
            _element.Wait.Until(condition => cnMcnu.Displayed);
            var expectedLink = _element.Url;
            expectedLink = Regex.Replace(expectedLink, MainPage.BaseUrl + "/.{2}/", MainPage.BaseUrl + "/");
            expectedLink = expectedLink.Replace(MainPage.BaseUrl + "/", MainPage.BaseUrl + "/cn/");
            cnMcnu.Click();
            _element.Wait.Until(condition => _element.Url.StartsWith(expectedLink));
            PageObject page = new PageObject(_element.Driver, UrlSource.Driver);
            return new PageTasks<PageObject>(page);
        }

        public string CountryText => _element.TopCountry.Text.Text;
    }
    public static class LangEnumExtension
    {
        public static MainPage.LangEnum GetExpectedLang(this TopRightElementTasks.MenuItems_With_Link item) =>
            item == TopRightElementTasks.MenuItems_With_Link.Ru ? MainPage.LangEnum.Ru :
            item == TopRightElementTasks.MenuItems_With_Link.By ? MainPage.LangEnum.By :
            item == TopRightElementTasks.MenuItems_With_Link.En ? MainPage.LangEnum.En :
            item == TopRightElementTasks.MenuItems_With_Link.Cn ? MainPage.LangEnum.Cn :
            throw new NotImplementedException();

        public static string GetExpectedCountryText(this MainPage.LangEnum lang) =>
            lang == MainPage.LangEnum.Ru ? "Республика Беларусь".ToUpper() :
            lang == MainPage.LangEnum.By ? "Рэспубліка Беларусь".ToUpper() :
            lang == MainPage.LangEnum.En ? "Europe".ToUpper() :
            lang == MainPage.LangEnum.Cn ? "China".ToUpper() :
            throw new NotImplementedException();
    }
}
