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
            List<Book> categories = await _context.Books.Include(b => b.Publisher).ToListAsync();

            //foreach (var obj in categories)
            //{
                // if we have the same publisher for three books -> one query -> ef core efficient
                //obj.Publisher = _context.Publishers.Find(obj.Publisher_Id);

                // the same -> explicit loading
                //_context.Entry(obj).Reference(p => p.Publisher).Load();

                // eager loading
            //}
            return View(categories);
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
