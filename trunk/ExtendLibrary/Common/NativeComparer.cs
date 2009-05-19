using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.Common
{
    public static class MultiComparison<T>
    {
        public static int Compare(T x, T y)
        {
            return (x is IComparable<T>)
                       ? ((IComparable<T>) x).CompareTo(y)
                       : ((IComparable) x).CompareTo(y);
        }
    }
}
