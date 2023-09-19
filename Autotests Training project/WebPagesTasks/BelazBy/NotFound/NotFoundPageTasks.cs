namespace Autotests_Training_project.WebPagesTasks.BelazBy.NotFound
{
    using WebPages;
    using WebPages.BelazBy.NotFound;
    public class NotFoundPageTasks : PageTasks<NotFoundPage>
    {
        public NotFoundPageTasks(NotFoundPage page) : base(page) { }

        public bool IsPageNotFound(PageTasks<PageObject> pageTasks) => pageTasks.Title == Title;
    }
}
