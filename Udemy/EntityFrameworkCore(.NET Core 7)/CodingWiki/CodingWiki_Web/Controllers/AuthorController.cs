using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // get method
        // load the categories
        // called by default
        public async Task<IActionResult> Index()
        {
            List<Author> authors = await _context.Authors.ToListAsync();
            return View(authors);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Author obj = new();
            if (id == null || id == 0)
            {
                return View(obj);
            }

            obj = await _context.Authors.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Author obj)
        {
            // check category data annotations
            if (ModelState.IsValid)
            {
                if (obj.Author_Id == 0)
                {
                    // create request
                    await _context.AddAsync(obj);
                }
                else
                {
                    // update - two approaches (retrieve and update/use update method)
                    _context.Update(obj);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Author obj = await _context.Authors.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(Author obj)
        {
            _context.Remove(obj);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
