using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.DataStructures
{
    /// <summary>
    /// 数值范围
    /// </summary>
    /// <typeparam name="T">数值类型</typeparam>
    public class Range<T> : IEquatable<Range<T>>, IComparable<Range<T>>, IComparable
    {
        #region Fields

        /// <summary>
        /// 开始数值
        /// </summary>
        private T start;

        /// <summary>
        /// 结束数值
        /// </summary>
        private T end;

        /// <summary>
        /// comparsion
        /// </summary>
        private readonly Comparison<T> comparison;

        /// <summary>
        /// comparer
        /// </summary>
        private readonly IComparer<T> comparer;

        /// <summary>
        /// 空数值范围
        /// </summary>
        private static readonly Range<T> empty;

        #endregion

        #region Properties

        /// <summary>
        /// 获取和设置开始数值
        /// </summary>
        public T Start
        {
            get { return start; }
            set { start = value; }
        }

        /// <summary>
        /// 获取和设置结束数值
        /// </summary>
        public T End
        {
            get { return end; }
            set { end = value; }
        }

        /// <summary>
        /// 空数值范围
        /// </summary>
        public static Range<T> Empty
        {
            get { return empty; }
        }

        #endregion

        #region Constructors

        static Range()
        {
            empty = new Range<T>(default(T), default(T));
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="start">开始数值</param>
        /// <param name="end">结束数值</param>
        public Range(T start, T end)
        {
            this.start = start;
            this.end = end;
        }

        #endregion

        #region Methods

        private int Compare(T xItem, T yItem)
        {
            if (xItem is IComparable<T>)
            {
                return ((IComparable<T>)xItem).CompareTo(yItem);
            }

            if (xItem is IComparable)
            {
                return ((IComparable)xItem).CompareTo(yItem);
            }

            if (comparison != null)
            {
                return comparison(xItem, yItem);
            }

            if (comparer != null)
            {
                return comparer.Compare(xItem, yItem);
            }

            throw new InvalidOperationException("未能比较容器中的两个元素。");
        }

        /// <summary>
        /// 是否无效数值范围
        /// </summary>
        /// <returns>返回是否无效数值范围</returns>
        public bool IsEmpty()
        {
            return start.Equals(default(T)) || end.Equals(default(T)) ? true : Compare(start, end) < 0;
        }

        /// <summary>
        /// 是否包含该数值
        /// </summary>
        /// <param name="value">数值</param>
        /// <returns>返回是否包含该数值</returns>
        public bool Includes(T value)
        {
            return Compare(value, start) >= 0 && Compare(value, end) <= 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="end">结束数值</param>
        /// <returns></returns>
        public Range<T> UpTo(T end)
        {
            return new Range<T>(start, end);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start">开始数值</param>
        /// <returns></returns>
        public Range<T> StartingOn(T start)
        {
            return new Range<T>(start, end);
        }

        /// <summary>
        /// 是否跨越该数值范围
        /// </summary>
        /// <param name="value">数值范围</param>
        /// <returns>返回是否跨越该数值范围</returns>
        public bool Overlaps(Range<T> value)
        {
            return value.Includes(start) || value.Includes(end) || Includes(value);
        }

        /// <summary>
        /// 是否包含该数值范围
        /// </summary>
        /// <param name="value">数值范围</param>
        /// <returns>返回是否包含该数值范围</returns>
        public bool Includes(Range<T> value)
        {
            return Includes(value.start) && Includes(value.end);
        }

        public Range<T> Gap(Range<T> range)
        {
            if (Overlaps(range))
                return empty;

            T lower, higher;
            if (CompareTo(range) < 0)
            {
                lower = start;
                higher = range.end;
            }
            else
            {
                lower = range.start;
                higher = end;
            }
            return new Range<T>(lower, higher);
        }

        public bool Abuts(Range<T> range)
        {
            return !Overlaps(range) && Gap(range).IsEmpty();
        }

        public bool PartitionedBy(Range<T>[] ranges)
        {
            return !IsContiguous(ranges) ? false : Equals(Combine(ranges));
        }

        public void Union(Range<T> other)
        {
            if (Compare(start, other.start) > 0)
            {
                start = other.start;
            }
            if (Compare(end, other.end) < 0)
            {
                end = other.end;
            }
        }

        public void Intersect(Range<T> other)
        {
            if (Compare(start, other.start) < 0)
            {
                start = other.start;
            }
            if (Compare(end, other.end) > 0)
            {
                end = other.end;
            }
        }

        public static Range<T> Combine(Range<T>[] ranges)
        {
            Array.Sort(ranges);
            if (!IsContiguous(ranges))
                throw new ArgumentException("Can't combine these ranges!");
            return new Range<T>(ranges[0].start, ranges[ranges.Length - 1].end);
        }

        public static bool IsContiguous(Range<T>[] ranges)
        {
            Array.Sort(ranges);
            for (int i = 0, j = ranges.Length - 1; i < j; i++)
            {
                if (!ranges[i].Abuts(ranges[i + 1]))
                    return false;
            }
            return true;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", start, end);
        }

        public override int GetHashCode()
        {
            return start.GetHashCode() * 13 + end.GetHashCode() * 37;
        }

        #endregion

        #region Overriden Operator

        public static Range<T> operator &(Range<T> firstRange, Range<T> secondRange)
        {
            Range<T> result = new Range<T>(firstRange.start, firstRange.end);
            result.Union(secondRange);
            return result;
        }

        public static Range<T> operator |(Range<T> firstRange, Range<T> secondRange)
        {
            Range<T> result = new Range<T>(firstRange.start, firstRange.end);
            result.Intersect(secondRange);
            return result;
        }

        #endregion

        #region IEquatable<Range<T>> 成员

        public bool Equals(Range<T> other)
        {
            return Compare(start, other.start) == 0 && Compare(end, other.end) == 0;
        }

        #endregion

        #region IComparable<Range<T>> 成员

        public int CompareTo(Range<T> other)
        {
            if (
                !(other.start.Equals(default(T)) && other.end.Equals(default(T)) && start.Equals(default(T)) &&
                  end.Equals(default(T))))
                return start.Equals(other.start) ? Compare(end, other.end) : Compare(start, other.start);
            return 0;
        }

        #endregion

        #region IComparable 成员

        public int CompareTo(object obj)
        {
            Range<T> other = (Range<T>)obj;
            return CompareTo(other);
        }

        #endregion
    }
}
