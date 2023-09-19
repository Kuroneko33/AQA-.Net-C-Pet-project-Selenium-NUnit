using System;
using System.Collections.Generic;
using System.Text;

namespace Autotests_Training_project
{
    public static class ArrayExtensions
    {
        public static B[] ConvertAll<A, B>(this A[] array, Converter<A,B> converter) =>
            Array.ConvertAll(array, converter);
    }
}
