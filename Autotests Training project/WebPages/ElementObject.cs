using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages
{
    using Addons.Selenium;

    public class ElementObject : PageObject
    {
        public ElementObject(IWebDriver driver, IWebElementSafe element) : base(driver, UrlSource.Driver) { Element = element; }
        public virtual IWebElementSafe Element { get; set; }
    }
}
