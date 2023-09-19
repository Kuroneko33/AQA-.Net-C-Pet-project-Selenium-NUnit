using Autotests_Training_project.WebPages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autotests_Training_project.WebPagesTasks
{
    /// <summary>
    /// Declarative interface for Pages
    /// </summary>
    public class PageTasks<TPageObject> : IDisposable where TPageObject : PageObject
    {
        public PageTasks(TPageObject page)
        {
            _page = page;
        }
        protected virtual TPageObject _page { get; set; }
        public PageTasks<PageObject> BaseTasks => new PageTasks<PageObject>(_page);
        public string Url => _page.Url;
        public string Title => _page.Driver.Title;
        /// <summary>
        /// Перезагрузить страницу используя переданный url
        /// </summary>
        public void ReloadPage(string url) => _page.ReloadPage(url);
        /// <summary>
        /// Перезагрузить страницу по ее изначальному Url
        /// </summary>
        public void ReloadPage() => _page.ReloadPage();
        /// <summary>
        /// Перезагрузить страницу по ее текущему Url
        /// </summary>
        public void RefreshPage() => _page.RefreshPage();

        public void Dispose()
        {
            _page?.Dispose();
        }
    }
}
