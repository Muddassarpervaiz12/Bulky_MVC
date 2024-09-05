using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class EditModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        [BindProperty] /*use for bind the property and "onpost" handler its avaliable*/
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        //get the id from user on which we need to edit data
        // get data from database
        public void OnGet(int? id)
        {
            if(id != null || id !=0)
            {
                Category = _db.Categories.Find(id);
            }

        }

        //create category
        //add, updata or delete data from database
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["success"] = "Category edit successfully";
                return RedirectToPage("Index");
            }
            //return back to the page
            return Page();
        }
    }
}
