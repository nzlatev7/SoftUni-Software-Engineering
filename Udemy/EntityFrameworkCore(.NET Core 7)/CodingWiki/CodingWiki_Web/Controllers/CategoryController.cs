using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // get method
        // load the categories
        // called by default
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            return View(categories);
        }

        // get method (also id!)
        // nullable because create and update use this!
        public async Task<IActionResult> Upsert(int? id)
        {
            Category obj = new();
            if (id == null || id == 0)
            {
                // create
                return View(obj);
            }

            // edit
            // first!
            // we do not update this obj!
            obj = await _context.Categories.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category obj)
        {
            // check category data annotations
            if (ModelState.IsValid)
            {
                if (obj.Category_Id == 0)
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

        // get method for another page
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category obj = await _context.Categories.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(Category obj)
        {
            _context.Remove(obj);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // the same as add, ef core keep track and make AddRange at the end!
        public async Task<IActionResult> CreateMultiple2()
        {
            
            List<Category> categories = new List<Category>();
            for (int i = 0; i <= 1; i++)
            {
                categories.Add(new Category() { CategoryName = Guid.NewGuid().ToString()});  
            }
            await _context.AddRangeAsync(categories);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // the same as add, ef core keep track and make AddRange at the end!
        public async Task<IActionResult> CreateMultiple5()
        {
            for (int i = 0; i <= 4; i++)
            {
                await _context.AddAsync(new Category() { CategoryName = Guid.NewGuid().ToString() });
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> RemoveMultiple2()
        {
            List<Category> categories = _context.Categories
                .OrderByDescending(u => u.Category_Id)
                .Take(2)
                .ToList();


            _context.RemoveRange(categories);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveMultiple5()
        {
            List<Category> categories = _context.Categories
                .OrderByDescending(u => u.Category_Id)
                .Take(5)
                .ToList();

            _context.RemoveRange(categories);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
