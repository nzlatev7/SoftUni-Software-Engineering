

using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

//using (ApplicationDbContext context = new ApplicationDbContext())
//{
//    // if not created -> create it
//    context.Database.EnsureCreated();

//    // apply all pending migrations
//    if (context.Database.GetPendingMigrations().Count() > 0)
//    {
//        context.Database.Migrate();
//    }
//}

AddBook();
GetAllBooks();

void GetAllBooks()
{
    using ApplicationDbContext context = new ApplicationDbContext();
    var books = context.Books.ToList();

    foreach (var book in books)
    {
        Console.WriteLine(book.Title);
    }
}

void AddBook()
{
    using ApplicationDbContext context = new ApplicationDbContext();

    Book newBook = new Book() { Title = "new book"};
    context.Books.Add(newBook);
    context.SaveChanges();
}

//string a = null;

//string b = a.Substring(2, 3);
//Author author = new Author();
//author.FirstName = "genata";
//author.LastName = "qvorov";
//author.Location = "male!";
//author.BirthDate = DateTime.Now;

//context.Authors.Add(author);
//context.SaveChanges();

// can not select one prop
//var publishers = context.Publishers
//    .Include(p => p.Books.Select(b => b.Price));


// How this works?
// modelBuilder.Entity<Fluent_BookAuthorMap>().HasKey(b => new { b.Book_Id, b.Author_Id });
//modelBuilder.Entity<>