namespace Autotests_Training_project.WebPagesTasks.GitHub.Main.Pricing
{
    using WebPages.GitHub.Main.Pricing;
    using Elements;

    public class PricingPageTasks : PageTasks<PricingPage>
    {
        public PricingPageTasks(PricingPage page) : base(page) { }

        public HeaderElementTasks _header;
        public HeaderElementTasks Header =>
            _header ??= new HeaderElementTasks(_page.Header);
    }
}
