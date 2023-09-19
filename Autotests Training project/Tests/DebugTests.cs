using Autotests_Training_project.Addons.NUnit.TestAttributes;
using Autotests_Training_project.WebPages;
using Autotests_Training_project.WebPages.GitHub.Main;
using Autotests_Training_project.WebPagesTasks;
using Autotests_Training_project.WebPagesTasks.GitHub.Main;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autotests_Training_project.Tests
{
    [SetUpTestSuite(Author = Authors.Levizarovich_A_O.ToString)]
    public class DebugTests
    {
        [Test]
        public void AuthorsTest()
        {
            var authorStr = Authors.Levizarovich_A_O.ToString;
            Assert.Pass(authorStr);
        }

        [Test]
        public void Test()
        {
            By by = By.XPath(".//input[contains(@class,'header-search-input')]");
            var a = by.Criteria;
            var b = by.Criteria.Replace("\\", "");
            Assert.Pass();
        }
    }
}
