

using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Reflection.Emit;

int a = 10;

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

//AddBook();
//GetAllBooks();
//GetBook();
//SqlInjection();
//GetBySingle();
//EFcoreLike();
//Ordering();

// 1, 2, 3, 4 (per page - 2)
//Pagination(4);

//Update();

//async void Update()
//{
//    using ApplicationDbContext context = new ApplicationDbContext();

//    var book = await context.Books.FindAsync(11);
//    book.Publisher_Id = 1;
//    await context.SaveChangesAsync();
//}


//async void Pagination(int page, int count = 2)
//{
//    using ApplicationDbContext context = new ApplicationDbContext();

//    List<Book> currentPage = await context.Books
//        .Skip((page - 1) * count)
//        .Take(count)
//        .ToListAsync();
//}

//async void Ordering()
//{
//    using ApplicationDbContext context = new ApplicationDbContext();

//    // can use max, min, count
//    List<Book> books = await context.Books.OrderBy(b => b.Title).ThenByDescending(b => b.ISBN)
//        .ToListAsync();

//    foreach (var book in books)
//    {
//        Console.WriteLine(book.ISBN);
//    }

//}

//// deferred execution - when the query gets executed

//async void EFcoreLike()
//{
//    using ApplicationDbContext context = new ApplicationDbContext();

//    // can use max, min, count
//    List<Book> books = await context.Books.Where(b => EF.Functions.Like(b.ISBN, "%b%"))
//        .ToListAsync();

//    ;
//}

//async void GetBySingle()
//{
//    using ApplicationDbContext context = new ApplicationDbContext();

//    // can find it, because it is one
//    Book book = await context.Books.SingleAsync(b => b.Title == "panda");

//    // can not find it, because there are three books
//    Book book3 = await context.Books.SingleAsync(b => b.Title == "new book");

//    // return null
//    Book book3Default = await context.Books.SingleOrDefaultAsync(b => b.Title == "new book");
//}

//// vulnerable to sql injection
//async void SqlInjection()
//{
//    using ApplicationDbContext context = new ApplicationDbContext();

//    var input = "new book' or 1=1--";
//    Book book = await context.Books
//        .FromSqlRaw($"SELECT TOP(1) [b].[Book_Id], [b].[ISBN], [b].[Price], [b].[Publisher_Id], [b].[Title] FROM [Books] AS [b] WHERE [b].[Title] = N'{input}'")
//        .FirstOrDefaultAsync();

//    // ef core parameterized the query
//    Book book2 = await context.Books.FirstOrDefaultAsync(b => b.Title == "new book' or 1=1--");
//}

//async void GetBook()
//{
//    using ApplicationDbContext context = new ApplicationDbContext();

//    // there is no difference
//    // assume we know the "new book"
//    Book book = await context.Books.Where(b => b.Title == "'new book' or 1=1;")
//        .FirstOrDefaultAsync();

//    Book book2 = await context.Books
//        .FirstOrDefaultAsync(b => b.Title == "new book");
//}

//async void GetAllBooks()
//{
//    using ApplicationDbContext context = new ApplicationDbContext();
//    var books = await context.Books.ToListAsync();

//    foreach (var book in books)
//    {
//        Console.WriteLine(book.Title);
//    }
//}

//async void AddBook()
//{
//    // because it it disposable
//    using ApplicationDbContext context = new ApplicationDbContext();

//    Book newBook = new Book() {Title = "new book", ISBN = "123abv",Price = 12.4m, Publisher_Id = 2};
//    await context.Books.AddAsync(newBook);
//    await context.SaveChangesAsync();
//}

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