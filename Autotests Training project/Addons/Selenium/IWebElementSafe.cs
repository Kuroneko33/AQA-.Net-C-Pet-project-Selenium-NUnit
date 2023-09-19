using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using OpenQA.Selenium;

namespace Autotests_Training_project.Addons.Selenium
{
    /// <summary>
    /// (LazyElements)
    /// IWebElement wrapper, that lazy init IWebElement and 
    /// if IWebElement was rerendered and changed its id, finds it again
    /// </summary>
    public interface IWebElementSafe : IWebElement
    {
        public By By { get; }
        public IWebElementSafe FindElementSafe(By by);
        public ReadOnlyCollection<IWebElementSafe> FindElementsSafe(By by);
        public ReadOnlyCollection<IWebElementSafe> FindElementsApartSafe(By by);


        [Obsolete("Use FindElementSafe")]
        public new IWebElement FindElement(By by);

        [Obsolete("Use FindElementsSafe")]
        public new ReadOnlyCollection<IWebElement> FindElements(By by);
    }
    public static class ByArrayConverter
    {
        /// <summary>
        /// Converts By selector on list of elements to array of By selectors to each element
        /// </summary>
        /// <param name="byOfElementsArray">By selector on list of elements</param>
        /// <returns>array of By selectors to each element</returns>
        public static By[] ConvertToArray(By byOfElementsArray, int elementsCount)
        {
            By[] byArray = new By[elementsCount];
            for (int i = 0; i < elementsCount; i++)
            {
                By byArrayElement = null;
                if (byOfElementsArray.Mechanism == "css selector")
                    byArrayElement = ByCssBuilder.NewInstance.Chain(byOfElementsArray)[i + 1];
                else if (byOfElementsArray.Mechanism == "xpath")
                    byArrayElement = By.XPath(byOfElementsArray.Criteria + $"[{i + 1}]");
                else
                    throw new Exception("Invalid selector");

                byArray[i] = byArrayElement;
            }
            return byArray;
        }
    }
    public static class IWebElementSafeIWebDriverExtension
    {
        public static IWebElementSafe FindElementSafe(this IWebDriver driver, By by) => new WebElementSafe(driver, by);
        /// <summary>
        /// в качестве источника элементов сохраняет массив и работает с ним
        /// </summary>
        public static ReadOnlyCollection<IWebElementSafe> FindElementsSafe(this IWebDriver driver, By byOfElementsArray)
        {
            ReadOnlyCollection<IWebElement> elementsArray = driver.FindElements(byOfElementsArray);
            var safeElementsArray = new IWebElementSafe[elementsArray.Count];
            for (int i = 0; i < elementsArray.Count; i++)
            {
                safeElementsArray[i] = new WebElementSafe(driver, elementsArray, i, byOfElementsArray);
            }
            return new ReadOnlyCollection<IWebElementSafe>(safeElementsArray);
        }
        /// <summary>
        /// создает индивидуальный локатор для каждого элемента массива добавлением индексации. 
        /// накладывает некоторые ограничения на локаторы, а именно это должен был локатор на элементы первого уровня списка.
        /// </summary>
        public static ReadOnlyCollection<IWebElementSafe> FindElementsApartSafe(this IWebDriver driver, By byOfElementsArray)
        {
            int elementsCount = driver.FindElements(byOfElementsArray).Count;
            var byArray = ByArrayConverter.ConvertToArray(byOfElementsArray, elementsCount);
            var safeElementsArray = byArray.ConvertAll(by => new WebElementSafe(driver, by));
            return new ReadOnlyCollection<IWebElementSafe>(safeElementsArray);
        }
    }

    /// <summary>
    /// (LazyElements)
    /// Class that impliment IWebElementSafe interface:
    /// IWebElement wrapper, that lazy init IWebElement and 
    /// if IWebElement was rerendered and changed its id, finds it again
    /// </summary>
    public class WebElementSafe : IWebElementSafe
    {
        public WebElementSafe(IWebDriver driver, ReadOnlyCollection<IWebElement> collectionSourse, int elementIndex, By byOfCollectionSourse) : this(driver, byOfCollectionSourse) 
        { 
            _collectionSourse = collectionSourse;
            _collectionSourseElementIndex = elementIndex;
        }
        public WebElementSafe(IWebElementSafe parentElement, ReadOnlyCollection<IWebElement> collectionSourse, int elementIndex, By byOfCollectionSourse) : this(parentElement, byOfCollectionSourse)
        {
            _collectionSourse = collectionSourse;
            _collectionSourseElementIndex = elementIndex;
        }
        public WebElementSafe(IWebElementSafe parentElement, By by) : this(by) { _parentElement = parentElement; }
        public WebElementSafe(IWebDriver driver, By by) : this(by) { _driver = driver; }
        private WebElementSafe(By by) { By = by; }
        public By By { get; private set; }
        private readonly IWebDriver _driver;
        private ReadOnlyCollection<IWebElement> _collectionSourse;
        private readonly int _collectionSourseElementIndex;
        private IWebElement collestionSourceElementCache;
        private IWebElement _collestionSourceElement
        {
            get
            {
                if (_collectionSourse is null)
                    return collestionSourceElementCache = null;
                
                if (collestionSourceElementCache is null)
                    collestionSourceElementCache = _collectionSourse[_collectionSourseElementIndex];

                try
                {
                    //Existance check
                    _ = collestionSourceElementCache.Displayed;
                }
                catch (WebDriverException)
                {
                    //find again
                    _collectionSourse = _findThisCollectionSourse(By);
                    collestionSourceElementCache = _collectionSourse[_collectionSourseElementIndex];
                }

                return collestionSourceElementCache;
            }
        }
        private ReadOnlyCollection<IWebElement> _findThisCollectionSourse(By by) => 
            _parentElement != null ? _parentElement.FindElements(by) :
            _driver.FindElements(by);

        private readonly IWebElement _parentElement;
        private IWebElement webElementCache;
        private IWebElement _webElement
        {
            get
            {
                if (webElementCache is null)
                    webElementCache = _findThisElement(By);

                try
                {
                    //Existance check
                    _ = webElementCache.Displayed;
                }
                catch (WebDriverException)
                {
                    //find again
                    webElementCache = _findThisElement(By);
                }

                return webElementCache;
            }
        }

        private IWebElement _findThisElement(By by) =>
            _collectionSourse != null ? _collestionSourceElement :
            _parentElement != null ? _parentElement.FindElement(by) :
            _driver.FindElement(by);

        public IWebElementSafe FindElementSafe(By by) => new WebElementSafe(parentElement: this, by);

        public ReadOnlyCollection<IWebElementSafe> FindElementsSafe(By byOfElementsArray)
        {
            ReadOnlyCollection<IWebElement> elementsArray = _webElement.FindElements(byOfElementsArray);
            var safeElementsArray = new IWebElementSafe[elementsArray.Count];
            for (int i = 0; i < elementsArray.Count; i++)
            {
                safeElementsArray[i] = new WebElementSafe(parentElement: this, elementsArray, i, byOfElementsArray);
            }
            return new ReadOnlyCollection<IWebElementSafe>(safeElementsArray);
        }
        public ReadOnlyCollection<IWebElementSafe> FindElementsApartSafe(By byOfElementsArray)
        {
            int elementsCount = _webElement.FindElements(byOfElementsArray).Count;
            var byArray = ByArrayConverter.ConvertToArray(byOfElementsArray, elementsCount);
            var safeElementsArray = byArray.ConvertAll(by => new WebElementSafe(parentElement: this, by));
            return new ReadOnlyCollection<IWebElementSafe>(safeElementsArray);
        }


        #region IWebElement
        [Obsolete("Use FindElementSafe")]
        public IWebElement FindElement(By by) => _webElement.FindElement(by);

        [Obsolete("Use FindElementsSafe")]
        public ReadOnlyCollection<IWebElement> FindElements(By by) => _webElement.FindElements(by);

        public string TagName => _webElement.TagName;

        public string Text => _webElement.Text;

        public bool Enabled => _webElement.Enabled;

        public bool Selected => _webElement.Selected;

        public Point Location => _webElement.Location;

        public Size Size => _webElement.Size;

        public bool Displayed => _webElement.Displayed;

        public void Clear() => _webElement.Clear();

        public void Click() => _webElement.Click();
        public string GetAttribute(string attributeName) => _webElement.GetAttribute(attributeName);

        public string GetCssValue(string propertyName) => _webElement.GetCssValue(propertyName);

        public string GetDomAttribute(string attributeName) => _webElement.GetDomAttribute(attributeName);

        public string GetDomProperty(string propertyName) => _webElement.GetDomProperty(propertyName);

        public ISearchContext GetShadowRoot() => _webElement.GetShadowRoot();

        public void SendKeys(string text) => _webElement.SendKeys(text);

        public void Submit() => _webElement.Submit();
        #endregion IWebElement
    }
}
