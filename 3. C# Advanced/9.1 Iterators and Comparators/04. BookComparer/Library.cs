using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = books.ToList();
        }

        public void Add(Book book)
        {
            books.Add(book);
        }

        public void SortByNameAndTitle()
        {
            books.Sort();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books.OrderBy(b => b, new BookComparator()).ToList());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;
        private int currentIndex = -1;

        public LibraryIterator(List<Book> books)
        {
            this.books = books;
        }

        public Book Current => books[currentIndex];

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            currentIndex++;

            return currentIndex < books.Count;
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}
