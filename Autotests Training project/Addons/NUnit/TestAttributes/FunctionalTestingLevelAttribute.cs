using NUnit.Framework;
using System;

namespace Autotests_Training_project.Addons.NUnit.TestAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class FunctionalTestingLevelAttribute : PropertyAttribute
    {
        private static string _name => typeof(FunctionalTestingLevelAttribute).Name.Replace("Attribute", string.Empty);
        public FunctionalTestingLevelAttribute(FunctionalTestingLevels level) :
            base(_name, level.ToString()) { }
    }
    public enum FunctionalTestingLevels
    {
        Smoke,
        CriticalPath,
        Regression
    }
}
