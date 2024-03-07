using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using CodingWiki_Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // eager loading
            List<Book> books = await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.BookAuthorMap).ThenInclude(ba => ba.Author)
                .ToListAsync();

            //List<Book> books = _context.Books.ToList();

            //foreach (var obj in books)
            //{
            //    // if we have the same publisher for three books -> one query -> ef core efficient
            //    //obj.Publisher = _context.Publishers.Find(obj.Publisher_Id);

            //    // the same -> explicit loading
            //    _context.Entry(obj).Reference(p => p.Publisher).Load();
            //    // also to load the collection of BookAuthorMap
            //    _context.Entry(obj).Collection(b => b.BookAuthorMap).Load();

            //    // and foreach to load the author!
            //    foreach (var bookAuth in obj.BookAuthorMap)
            //    {
            //        _context.Entry(bookAuth).Reference(b => b.Author).Load();
            //    }
            //}
            return View(books);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            BookVM obj = new();

            obj.PublisherList = _context.Publishers.Select(p => new SelectListItem()
            {
                Text = p.Name,
                Value = p.Publisher_Id.ToString()
            });

            // do i need to make new book?
            obj.Book = new();
            if (id == null || id == 0)
            {
                return View(obj);
            }

            obj.Book = await _context.Books.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(BookVM obj)
        {

            if (obj.Book.BookId == 0)
            {
                await _context.Books.AddAsync(obj.Book);
            }
            else
            {
                _context.Update(obj.Book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {   
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Book obj = await _context.Books.Include(b => b.BookDetail)
                .FirstOrDefaultAsync(b => b.BookId == id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);   
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(Book obj)
        {
            if (obj.BookDetail.BookDetail_Id == 0)
            {
                var book = _context.Books.Find(obj.BookId);
                book.BookDetail = obj.BookDetail;
                _context.Books.Update(book);
            }
            else
            {
                _context.BookDetails.Update(obj.BookDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Book obj = await _context.Books.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(Book obj)
        {
            _context.Books.Remove(obj);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ManageAuthors(int id)
        {
            BookAuthorVM obj = new()
            {
                BookAuthorList = _context.BookAuthorMaps.Include(ba => ba.Author)
                    .Where(ba => ba.Book_Id == id).ToList(),

                BookAuthor = new()
                {
                    Book_Id = id
                },
                Book = _context.Books.Find(id)
            };

            List<int> tempListOfAssignedAuthors = obj.BookAuthorList
                .Select(b => b.Author_Id)
                .ToList();


            // can be done with contains also!
            List<SelectListItem> availableAuthors = _context.Authors
                .Where(a => !tempListOfAssignedAuthors
                    .Any(t => t == a.Author_Id))
                .Select(a => new SelectListItem()
                {
                    Text = a.FullName,
                    Value = a.Author_Id.ToString()
                }).ToList();

            obj.AuthorList = availableAuthors;

            return View(obj);
        }

        [HttpPost]
        public IActionResult ManageAuthors(BookAuthorVM bookAuthorVM)
        {
            // need to exist!
            Book book = _context.Books.Find(bookAuthorVM.BookAuthor.Book_Id);
            if (book == null)
            {
                return NotFound();
            }

            Author author = _context.Authors.Find(bookAuthorVM.BookAuthor.Author_Id);
            if (author == null)
            {
                return NotFound();
            }

            if (bookAuthorVM.BookAuthor.Book_Id != 0 && bookAuthorVM.BookAuthor.Author_Id != 0)
            {
                _context.BookAuthorMaps.Add(bookAuthorVM.BookAuthor);
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction(nameof(ManageAuthors), new { @id = bookAuthorVM.Book.BookId });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAuthors(int? authorId, BookAuthorVM bookAuthorVM)
        {
            var bookAuthor = await _context.BookAuthorMaps
                .FirstOrDefaultAsync(ba => ba.Author_Id == authorId && ba.Book_Id == bookAuthorVM.Book.BookId);

            if (bookAuthor == null)
            {
                return NotFound();
            }

            int bookId = bookAuthor.Book_Id;

            // the same as .BookAuthorMaps.Remove
            _context.Remove(bookAuthor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ManageAuthors), new { @id = bookId });
        }

        public async Task<IActionResult> Playground()
        {
            var bookTemp = _context.Books.FirstOrDefault();
            bookTemp.Price = 100;

            var bookCollection = _context.Books;
            decimal totalPrice = 0;

            foreach (var book in bookCollection)
            {
                totalPrice += book.Price;
            }

            var bookList = _context.Books.ToList();
            foreach (var book in bookList)
            {
                totalPrice += book.Price;
            }

            var bookCollection2 = _context.Books;
            var bookCount1 = bookCollection2.Count();

            var bookCount2 = _context.Books.Count();
            return RedirectToAction(nameof(Index));
        }
    }
}
