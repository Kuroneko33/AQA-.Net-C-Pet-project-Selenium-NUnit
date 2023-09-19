using OpenQA.Selenium;
using System;

namespace Autotests_Training_project.Addons.Selenium
{
    /// <summary>
    /// Usage:<br></br>
    /// <br></br>
    /// By by = ByCssBuilder.NewInstance...<br></br>
    /// <br></br>
    /// Example 1<br></br>
    /// ByCssBuilder.NewInstance.TagName("button").ClassName("Button--link").Attribute("aria-label", "Toggle navigation")<br></br>
    /// implicit converts to By:<br></br>
    /// By.CssSelector("button.Button--link[aria-label='Toggle navigation']")<br></br>
    /// <br></br>
    /// Example 2<br></br>
    /// ByCssBuilder.NewInstance.TagName("nav").ClassName("menu").Descendant.TagName("a").PartialLinkText(linkText)<br></br>
    /// implicit converts to By:<br></br>
    /// By.CssSelector($"nav.menu a[href*='{linkText}']"<br></br>
    /// <br></br>
    /// Example 3<br></br>
    /// ByCssBuilder.NewInstance.Scope.Child.TagName("ul").Child.TagName("li")[index]<br></br>
    /// implicit converts to By:<br></br>
    /// By.CssSelector($":scope>ul>li:nth-of-type({index}")<br></br>
    /// </summary>
    public class ByCssBuilder
    {
        [Obsolete("Use: ByCssBuilder.NewInstance")]
        public ByCssBuilder() { }
        /// <summary>
        /// Send null to nullObject to use private constructor
        /// </summary>
        private ByCssBuilder(object nullObject) { }
        public static ByCssBuilder NewInstance => new ByCssBuilder(null);
        public By By { get; private set; }
        public static implicit operator By(ByCssBuilder byBuilder) => byBuilder.By;

        private By _chain(params By[] array)
        {
            var cssSelector = string.Empty;
            foreach (var item in array)
            {
                cssSelector += ExtractCssSelectorString(item);
            }
            return By.CssSelector(cssSelector);
        }
        public ByCssBuilder Chain(By requestBy)
        {
            By = _chain(By, requestBy);
            return this;
        }
        public string ExtractCssSelectorString(By by)
        {
            if (by != null && by.Mechanism == "xpath")
                throw new Exception($"by.Mechanism = \"{by.Mechanism}\" != \"css selector\"");
            if (by != null && by.Mechanism != "css selector")
                throw new Exception($"by.Mechanism = \"{by.Mechanism}\" != \"css selector\", unstable algorithm, needs to be fixed");

            return by?.Criteria.Replace("\\", "");
        }
        public string CssSelectorString => ExtractCssSelectorString(By);

        #region ByBase
        public ByCssBuilder ClassName(string classNameToFind) => Chain(By.ClassName(classNameToFind));
        public ByCssBuilder CssSelector(string cssSelectorToFind) => Chain(By.CssSelector(cssSelectorToFind));
        public ByCssBuilder Id(string idToFind) => Chain(By.Id(idToFind));
        public ByCssBuilder LinkText(string linkTextToFind) => Chain(By.CssSelector($"[href='{linkTextToFind}']"));
        public ByCssBuilder Name(string nameToFind) => Chain(By.Name(nameToFind));
        public ByCssBuilder PartialLinkText(string partialLinkTextToFind) => Chain(By.CssSelector($"[href*='{partialLinkTextToFind}']"));
        public ByCssBuilder TagName(string tagNameToFind) => Chain(By.CssSelector(tagNameToFind));
        #endregion ByBase

        #region ByExtension
        public ByCssBuilder Attribute(string attributeName, string value) => Chain(By.CssSelector($"[{attributeName}='{value}']"));
        /// <summary>
        /// css ":root"
        /// </summary>
        public ByCssBuilder Root => Chain(By.CssSelector(":root"));
        /// <summary>
        /// css ":scope"
        /// </summary>
        public ByCssBuilder Scope => Chain(By.CssSelector(":scope"));
        /// <summary>
        /// css ">" (xpath "/")
        /// </summary>
        public ByCssBuilder Child => Chain(By.CssSelector(">"));
        /// <summary>
        /// css ":first-child"
        /// </summary>
        public ByCssBuilder FirstChild => Chain(By.CssSelector(":first-child"));
        /// <summary>
        /// css ":last-child"
        /// </summary>
        public ByCssBuilder LastChild => Chain(By.CssSelector(":last-child"));
        /// <summary>
        /// css " " - space (xpath "//")
        /// </summary>
        public ByCssBuilder Descendant => Chain(By.CssSelector(" "));
        /// <summary>
        /// css " ~ " (xpath "::following-sibling")
        /// </summary>
        public ByCssBuilder GeneralSibling => Chain(By.CssSelector("~"));
        /// <summary>
        /// css " + " (xpath "::following-sibling[1]")
        /// </summary>  
        public ByCssBuilder AdjacentSibling => Chain(By.CssSelector("+"));
        /// <summary>
        /// css " || "
        /// </summary>
        public ByCssBuilder ColumnCombinator => Chain(By.CssSelector("||"));
        /// <summary>
        /// css "^='{str}'" (xpath "starts-with(str)")
        /// </summary>  
        public ByCssBuilder StartsWith(string str) => Chain(By.CssSelector($"^='{str}'"));
        /// <summary>
        /// css "$='{str}'" (xpath "ends-with(@attribute, 'str')")
        /// </summary>  
        public ByCssBuilder EndsWith(string str) => Chain(By.CssSelector($"$='{str}'"));
        /// <summary>
        /// css "*='{value}'" (xpath "contains(@attribute, 'value')")
        /// </summary>  
        public ByCssBuilder ContainsValue(string value) => Chain(By.CssSelector($"*='{value}'"));
        /// <summary>
        /// css "~='{str}'" (xpath "contains(@attribute, 'str')")
        /// </summary>  
        public ByCssBuilder ContainsWord(string str) => Chain(By.CssSelector($"~='{str}'"));
        /// <summary>
        /// css ":not(cssSelector)" (xpath "not(xPathSelector)")
        /// </summary>
        public ByCssBuilder Not(ByCssBuilder requestBy) => Chain(By.CssSelector($":not({requestBy.CssSelectorString})"));
        /// <summary>
        /// nth-of-type (xpath "[index]")
        /// starts from 1
        /// </summary>
        public ByCssBuilder this[int index] => Chain(By.CssSelector($":nth-of-type({index})"));
        /// <summary>
        /// nth-of-type (xpath "[index]")
        /// starts from 1
        /// </summary>
        public ByCssBuilder NthOfType(int index) => this[index];
        /// <summary>
        /// css ":first-of-type" (xpath "[1]")
        /// </summary>
        public ByCssBuilder FirstOfType(int index) => Chain(By.CssSelector($":first-of-type({index})"));
        /// <summary>
        /// css ":last-of-type" (xpath "[last()]")
        /// </summary>
        public ByCssBuilder LastOfType(int index) => Chain(By.CssSelector($":last-of-type({index})"));
        /// <summary>
        /// css ":checked"
        /// </summary>
        public ByCssBuilder Checked => Chain(By.CssSelector(":checked"));
        /// <summary>
        /// css ":enabled"
        /// </summary>
        public ByCssBuilder Enabled => Chain(By.CssSelector(":enabled"));
        /// <summary>
        /// css ":active"
        /// </summary>
        public ByCssBuilder Active => Chain(By.CssSelector(":active"));
        /// <summary>
        /// css ":focus"
        /// </summary>
        public ByCssBuilder Focus => Chain(By.CssSelector(":focus"));
        #endregion ByExtension
    }
}
