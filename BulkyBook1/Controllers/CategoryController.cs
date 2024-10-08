﻿using BulkyBook1.Data;
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

        //for display or view the data
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
                TempData["success"] = "Create category successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }



        //for edit category View, click on edit button
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // use for getting category 
            Category? cateogryFromDb = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (cateogryFromDb == null) {
                return NotFound();
                    }

            return View(cateogryFromDb);
        }
        //For edit button when click on update button then this post create method call
        [HttpPost]
        public IActionResult Edit(Category obj)
      {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category edit successfully";
                return RedirectToAction("Index");  
            }
            return View(obj);
        }





        //for edit category View, click on edit button
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // use for getting category 
            Category? cateogryFromDb = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (cateogryFromDb == null)
            {
                return NotFound();
            }

            return View(cateogryFromDb);
        }
        //For edit button when click on update button then this post create method call
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null) {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category delete successfully";
            return RedirectToAction("Index");
        }
    }
}
