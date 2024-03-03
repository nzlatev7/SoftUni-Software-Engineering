using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_Web.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PublisherController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Publisher> publishers = await _context.Publishers.ToListAsync();
            return View(publishers);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Publisher obj = new();
            if (id == null || id == 0)
            {
                return View(obj);
            }

            obj = await _context.Publishers.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Publisher obj)
        {
            // check category data annotations
            if (ModelState.IsValid)
            {
                if (obj.Publisher_Id == 0)
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

            Publisher obj = await _context.Publishers.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(Publisher obj)
        {
            _context.Remove(obj);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
