using NUnit.Framework;
using System;

namespace Autotests_Training_project.Addons.NUnit.TestAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class PriorityAttribute : PropertyAttribute
    {
        private static string _name => typeof(PriorityAttribute).Name.Replace("Attribute", string.Empty);
        public PriorityAttribute(PriorityLevel level) :
            base(_name, level.ToString()) { }

    }
    public enum PriorityLevel
    {
        ASAP,
        High,
        Normal,
        Low
    }
}
