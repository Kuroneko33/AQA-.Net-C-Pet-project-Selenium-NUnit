using OpenQA.Selenium;

namespace Autotests_Training_project.WebPages.GitHub.Main.Features.CodeReview
{

    public class CodeReviewPage : PageObject
    {
        public new const string BaseUrl = FeaturesPage.BaseUrl + "/code-review";
        public CodeReviewPage(IWebDriver driver, UrlSource urlSource) : base(driver, urlSource, BaseUrl) { }
        public CodeReviewPage(IWebDriver driver, string customUrl) : base(driver, customUrl) { }
        public CodeReviewPage() : base(BaseUrl) { }


    }
}
