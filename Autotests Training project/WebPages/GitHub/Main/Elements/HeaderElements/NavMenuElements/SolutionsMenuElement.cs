using OpenQA.Selenium;
using System.Collections.Generic;

namespace Autotests_Training_project.WebPages.GitHub.Main.Elements.HeaderElements.NavMenuElements
{
    using Addons.Selenium;
    using SolutionsMenuElements;

    public class SolutionsMenuElement : ElementObject
    {
        public SolutionsMenuElement(IWebDriver driver, IWebElementSafe element) : base(driver, element) { }

        private IList<IWebElementSafe> containers;
        private IList<IWebElementSafe> _containers => containers ??= Element.FindElementsSafe(BySwitcher.SelectFrom(
            ByCssBuilder.NewInstance.Scope.Child.TagName("div").Child.TagName("ul"),
            By.CssSelector($":scope>div>ul"),
            By.XPath($"./div/ul")));

        private const int _forIndex = 0;
        private ForElement @for;
        public ForElement For => @for ??= new ForElement(Driver, _containers[_forIndex]);

        private const int _bySolutionIndex = 1;
        private BySolutionElement bySolution;
        public BySolutionElement BySolution => bySolution ??= new BySolutionElement(Driver, _containers[_bySolutionIndex]);

        private const int _caseStudies_Index = 2;
        private CaseStudiesElement caseStudies;
        public CaseStudiesElement CaseStudies => caseStudies ??= new CaseStudiesElement(Driver, _containers[_caseStudies_Index]);
    }
}
