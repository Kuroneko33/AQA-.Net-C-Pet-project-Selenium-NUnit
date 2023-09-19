using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.BelazBy.Main
{
    using Addons.Selenium;
    using Elements;
    using System.Text.RegularExpressions;

    public class MainPage : PageObject
    {
        public new const string BaseUrl = "https://belaz.by";
        public MainPage(IWebDriver driver, UrlSource urlSource)  : base(driver, urlSource, BaseUrl) { }
        public MainPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public MainPage() : base(BaseUrl) { }
        public MainPage(LangEnum lang) : base(BaseUrl + lang.ToUrlValue()) { _lang = lang; }

        public enum LangEnum
        {
            Ru,
            By,
            En,
            Cn
        }
        private LangEnum _lang = LangEnum.Ru;
        public LangEnum Lang
        {
            get => _lang;
            set
            {
                _lang = value;
                var expectedUrl = Driver.Url;
                expectedUrl = Regex.Replace(expectedUrl, BaseUrl + "/.{2}/", BaseUrl + "/");
                expectedUrl = expectedUrl.Replace(BaseUrl + "/", BaseUrl + _lang.ToUrlValue());
                if (Driver.Url != expectedUrl)
                    Driver.Url = expectedUrl;
            }
        }

        private IWebElementSafe heading;
        public IWebElementSafe Heading => heading ??= Driver.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.TagName("h2"),
            By.CssSelector("h2"),
            By.XPath("//h2")));

        private HeaderElement header;
        public HeaderElement Header => header ??= new HeaderElement(Driver, Driver.FindElementSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.TagName("header"),
            By.CssSelector("header"), 
            By.XPath("//header"))));
    }
    public static class LangEnumExtension
    {
        public static string ToUrlValue(this MainPage.LangEnum lang) =>
            lang == MainPage.LangEnum.Ru ? string.Empty :
            "/" + lang.ToString().ToLower();
    }
}