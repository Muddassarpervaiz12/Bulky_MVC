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
    }
}
