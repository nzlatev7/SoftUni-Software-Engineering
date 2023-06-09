using System;

namespace IteratorsAndComparators
{
    class Program
    {
        static void Main(string[] args)
        {
            Book b1 = new Book("pipi", 2000, "vanq");
            Book b2 = new Book("henzel i gretel", 1799, "vanq", "pencho");
            Book b3 = new Book("gaga", 1999, "vanq", "pencho");
            Book b4 = new Book("angelo", 1999, "vanq", "pencho");

            Library library = new Library(b1, b2, b3, b4);

            library.SortByNameAndTitle();

            foreach (var book in library)
            {
                Console.WriteLine(book);
            }
        }
    }
}
