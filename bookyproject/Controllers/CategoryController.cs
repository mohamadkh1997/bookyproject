using bookyproject.data;
using bookyproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace bookyproject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
         
        public CategoryController(ApplicationDbContext context)
        {
              
             this._context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _context.Categories;
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {

           if(obj.name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("msg1", "The fields name and DisplayOfOrder are the same as eachothers");
            }


            if (ModelState.IsValid)
            {
                _context.Categories.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {   
            if (id == null || id == 0)
                return NotFound();

            var TheCategory = _context.Categories.Find(id);

            if(TheCategory == null)
            {
                return NotFound();
            }

            return View(TheCategory);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {

            if (obj.name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("msg1", "The fields name and DisplayOfOrder are the same as eachothers");
            }


            if (ModelState.IsValid)
            {
                _context.Categories.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Remove(int? id) {
        
            if(id == null || id == 0)
            {
                return NotFound();
            }
         
                var obj = _context.Categories.Find(id);
               if(obj == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");





        }



    }
}
