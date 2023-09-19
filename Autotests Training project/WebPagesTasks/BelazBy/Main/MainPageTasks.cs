namespace Autotests_Training_project.WebPagesTasks.BelazBy.Main
{
    using WebPages.BelazBy.Main;

    public class MainPageTasks : PageTasks<MainPage>
    {
        public MainPageTasks(MainPage page) : base(page) { }

        public string HeadingText => _page.Heading.Text;

        public HeaderElementTasks header;
        public HeaderElementTasks Header =>
            header ??= new HeaderElementTasks(_page.Header);
    }
}
