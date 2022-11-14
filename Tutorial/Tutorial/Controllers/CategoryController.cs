using Microsoft.AspNetCore.Mvc;
using Tutorial.Data;
using Tutorial.DataAccessLayer.Infrastructure.IRepository;
using Tutorial.Models;

namespace Tutorial.Controllers
{
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _unitOfWork.Category.GetAll();    
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
                _unitOfWork.Category.Add(category);
                _unitOfWork.save();
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
            var result = _unitOfWork.Category.GetT(x=>x.id==id);
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
                _unitOfWork.Category.update(category);
                _unitOfWork.save();
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
            var result = _unitOfWork.Category.GetT(x => x.id == id);
            if (result == null)
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
            var result = _unitOfWork.Category.GetT(x => x.id == id);
            if (result == null)
            {
                TempData["Error"] = "Category Not Found !";
                return NotFound();

            }
            _unitOfWork.Category.Delete(result);
            _unitOfWork.save();
            TempData["Success"] = "Category Deleted Successfully !";
            return RedirectToAction("Index");
        }

       
    }
}
