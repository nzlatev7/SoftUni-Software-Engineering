using System;

namespace IteratorsAndComparators
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("Emil ot Lioneberq", 1963, "Astrit Lindgren");
            Book book2 = new Book("Emil ot Lioneberq", 1963, "Astrit Lindgren", "Astrit Lindgren");

            Library books = new Library(book1, book2);

            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
