using BulkyBook1.Data;
using BulkyBook1.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //getting listod category form database/table
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        //for create category View
        public IActionResult Create()
        {
            return View();
        }


        //For Create button when click on create button then this post create method call
        [HttpPost]
        public IActionResult Create(Category obj)
        {

            //Custom Validation
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Display order cannot excatly match the Name");
            }
            //check the server side validation that are use in models folder 
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
