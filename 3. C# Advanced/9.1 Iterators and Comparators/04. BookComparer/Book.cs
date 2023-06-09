using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors) // or = null
        {
            Title = title;
            Year = year;
            Authors = authors.ToList();
        }

        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Authors { get; set; }

        public int CompareTo([AllowNull] Book other)
        {
            int yearComparison = Year.CompareTo(other.Year);

            if (yearComparison == 0)
            {
                return Title.CompareTo(other.Title);
            }

            return yearComparison;
        }

        public override string ToString()
        {
            return $"{Title} - {Year}";
        }
    }
}
