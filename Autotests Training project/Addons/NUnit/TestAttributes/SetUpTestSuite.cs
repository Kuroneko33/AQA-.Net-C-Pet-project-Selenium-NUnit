using NUnit.Framework;
using System;

namespace Autotests_Training_project.Addons.NUnit.TestAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SetUpTestSuite : TestFixtureAttribute
    {
        private static string _name => typeof(SetUpTestSuite).Name.Replace("Attribute", string.Empty);
        public SetUpTestSuite() { Category = _name; }
    }
}
