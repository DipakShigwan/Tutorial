using Microsoft.AspNetCore.Mvc;
using Tutorial.Data;
using Tutorial.Models;

namespace Tutorial.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDBContext _context;

        public CategoryController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _context.Categories;    
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                TempData["Success"] = "Category Created Successfully !";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Category Not Added !";
            return View("Create");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var result = _context.Categories.Find(id);
            if(result == null)
            {
                return NotFound();

            }
                return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                TempData["Success"] = "Category Modified Successfully !";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Category Not Modified !";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var result = _context.Categories.Find(id);
            if(result == null)
            {
                return NotFound();

            }
                return View(result);
        }

        [HttpPost]
        public IActionResult DeleteCategory(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["Error"] = "Category Not Found !";
                return NotFound();

            }
            var result = _context.Categories.Find(id);
            if (result == null)
            {
                TempData["Error"] = "Category Not Found !";
                return NotFound();

            }
            _context.Categories.Remove(result);
            _context.SaveChanges();
            TempData["Success"] = "Category Deleted Successfully !";
            return RedirectToAction("Index");
        }

       
    }
}
