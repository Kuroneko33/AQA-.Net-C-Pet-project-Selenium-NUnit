using Autotests_Training_project.WebPages;

namespace Autotests_Training_project.WebPagesTasks
{
    /// <summary>
    /// Declarative interface for PageElements
    /// </summary>
    public class ElementTasks<TElementObject> : PageTasks<TElementObject> 
        where TElementObject: ElementObject
    {
        public ElementTasks(TElementObject element) : base(element)
        {
            _element = element;
        }
        protected virtual TElementObject _element { get; set; }

        public new ElementTasks<ElementObject> BaseTasks => new ElementTasks<ElementObject>(_page);

        public bool Displayed 
        {
            get
            {
                try
                {
                    return _element.Element.Displayed;
                }
                catch (OpenQA.Selenium.WebDriverException)
                {
                    return false;
                }
            }
        }
    }
}
