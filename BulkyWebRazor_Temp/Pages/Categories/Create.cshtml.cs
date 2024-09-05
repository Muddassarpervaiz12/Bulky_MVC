using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    /* [BindProperties]  #if we have more than 1 bin property then on page level we use that to bind all properties*/
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty] /*use for bind the property and "onpost" handler its avaliable*/
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            
        }

        //create category
        public IActionResult OnPost()
        {
            _db.Categories.Add(Category);
            _db.SaveChanges();
            TempData["success"] = "Category create successfully";
            return RedirectToPage("index");
        }
    }
}
