using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionLibrary.Common
{
    public static class NativeComparer<T>
    {
        public static int Compare(T x, T y)
        {
            return (x is IComparable<T>)
                       ? ((IComparable<T>) x).CompareTo(y)
                       : ((IComparable) x).CompareTo(y);
        }
    }
}
