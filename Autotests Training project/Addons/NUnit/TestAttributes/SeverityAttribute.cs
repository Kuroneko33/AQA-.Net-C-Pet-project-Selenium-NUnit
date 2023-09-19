using NUnit.Framework;
using System;

namespace Autotests_Training_project.Addons.NUnit.TestAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class SeverityAttribute : PropertyAttribute
    {
        private static string _name => typeof(SeverityAttribute).Name.Replace("Attribute", string.Empty);
        public SeverityAttribute(SeverityLevel level) :
            base(_name, level.ToString()) { }

    }
    public enum SeverityLevel
    {
        Critical,
        Major,
        Normal,
        Minor
    }
}
