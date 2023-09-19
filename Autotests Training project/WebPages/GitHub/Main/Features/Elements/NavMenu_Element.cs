using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Main.Features.Elements
{
    using Addons.Selenium;
    using Actions;
    using CodeReview;
    using CodeSearch;
    using CodeSpaces;
    using Copilot;
    using Discussions;
    using Issues;
    using Packages;
    using Security;

    public class NavMenuElement : ElementObject
    {
        public NavMenuElement(IWebDriver driver, IWebElementSafe element) : base(driver, element) { }

        public static class Width_Adaptivity_Boundary
        {
            public const int Collapsing = 1010;
            public const int Dispayling = 1011;
        }

        private ActionsPage actions;
        public ActionsPage Actions => actions ??= new ActionsPage(Driver, UrlSource.PageBaseUrl);

        private PackagesPage packages;
        public PackagesPage Packages => packages ??= new PackagesPage(Driver, UrlSource.PageBaseUrl);

        private SecurityPage security;
        public SecurityPage Security => security ??= new SecurityPage(Driver, UrlSource.PageBaseUrl);

        private CodeSpacesPage codeSpaces;
        public CodeSpacesPage CodeSpaces => codeSpaces ??= new CodeSpacesPage(Driver, UrlSource.PageBaseUrl);

        private CopilotPage copilot;
        public CopilotPage Copilot => copilot ??= new CopilotPage(Driver, UrlSource.PageBaseUrl);

        private CodeReviewPage codeReview;
        public CodeReviewPage CodeReview => codeReview ??= new CodeReviewPage(Driver, UrlSource.PageBaseUrl);

        private CodeSearchPage codeSearch;
        public CodeSearchPage CodeSearch => codeSearch ??= new CodeSearchPage(Driver, UrlSource.PageBaseUrl);

        private IssuesPage issues;
        public IssuesPage Issues => issues ??= new IssuesPage(Driver, UrlSource.PageBaseUrl);

        private DiscussionsPage discussions;
        public DiscussionsPage Discussions => discussions ??= new DiscussionsPage(Driver, UrlSource.PageBaseUrl);
    }
}
