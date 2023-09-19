namespace Autotests_Training_project.WebPagesTasks.GitHub.Main
{
    using WebPages.GitHub.Main;
    using Elements;
    using Search;
    using Pricing;

    public class MainPageTasks : PageTasks<MainPage>
    {
        public MainPageTasks(MainPage page) : base(page) { }

        public string HeadingText => _page.Heading.Text;

        public HeaderElementTasks header;
        public HeaderElementTasks Header =>
            header ??= new HeaderElementTasks(_page.Header);

        private SearchPageTasks search;
        public SearchPageTasks Search => search ??= new SearchPageTasks(_page.Search);

        private PricingPageTasks pricing;
        public PricingPageTasks Pricing => pricing ??= new PricingPageTasks(_page.Pricing);
    }
}
