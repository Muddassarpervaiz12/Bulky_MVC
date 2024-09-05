using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties] /*that bind property help in OnPost handler so in our object id also bind*/
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        /*[BindProperty] use for bind the property and "onpost" handler its avaliable*/
        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        //get the id from user on which we need to edit data
        // get data from database
        public void OnGet(int? id)
        {
            if (id != null || id != 0)
            {
                Category = _db.Categories.Find(id);
            }

        }

        //create category
        //add, updata or delete data from database
        public IActionResult OnPost()
        {
            Category? obj = _db.Categories.Find(Category.Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category delete successfully";
            return RedirectToPage("Index");
        }
    }
}
