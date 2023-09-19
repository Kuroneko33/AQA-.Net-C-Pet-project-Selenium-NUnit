using Autotests_Training_project.WebPages;
using System;

namespace Autotests_Training_project.WebPagesTasks
{
    public class ElementTasks_IDisplayable<TElementObject> : ElementTasks<TElementObject> where TElementObject : ElementObject
    {
        public ElementTasks_IDisplayable(TElementObject element, Action display) : base(element)
        {
            _display = display;
        }
        protected Action _display;

        /// <summary>
        /// if (!Displayed) _display();
        /// </summary>
        protected virtual void _stateSetUp()
        {
            if (!Displayed)
                _display();
        }
    }
}
