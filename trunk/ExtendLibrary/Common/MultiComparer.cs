using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.Common
{
    public class MultiComparer<T>
    {
        #region Fields

        private IComparer<T> comparer;

        private Comparison<T> comparison;

        #endregion

        #region Constructors

        public MultiComparer(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public MultiComparer(Comparison<T> comparison)
        {
            this.comparison = comparison;
        }

        public MultiComparer()
        {
        }

        #endregion

        #region Methods

        public int Compare(T x, T y)
        {
            if (x is IComparable<T>)
            {
                return ((IComparable<T>)x).CompareTo(y);
            }

            if (x is IComparable)
            {
                return ((IComparable)x).CompareTo(y);
            }

            if (comparison != null)
            {
                return comparison(x, y);
            }

            if (comparer != null)
            {
                return comparer.Compare(x, y);
            }

            throw new InvalidOperationException("Can't compare two items.");
        }

        #endregion
    }
}
