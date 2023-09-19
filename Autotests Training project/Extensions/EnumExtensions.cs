using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autotests_Training_project.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<TEnum> GetValues<TEnum>()
        where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
        }
        public static List<TEnum> GetValuesList<TEnum>()
        where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            return GetValues<TEnum>().ToList();
        }
        public static TEnum [] GetValuesArray<TEnum>()
        where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            return GetValues<TEnum>().ToArray();
        }
    }
}
