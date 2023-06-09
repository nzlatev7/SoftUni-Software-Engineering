using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    class BookComparator : IComparer<Book>
    {
        public int Compare([AllowNull] Book x, [AllowNull] Book y)
        {
            int yearComparison = x.Title.CompareTo(y.Title);

            if (yearComparison == 0)
            {
                return y.Year.CompareTo(x.Year);
            }

            return yearComparison;
        }
    }
}
