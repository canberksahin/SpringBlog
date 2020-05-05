using SpringBlog.Controllers;
using SpringBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SpringBlog.Areas.Admin.Controllers
{
    public class CategoriesController : AdminBaseController
    {
        // GET: Admin/Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult New()
        {
            return View();
        }

        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult New(Category cat)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(cat);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Category has been created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category cat = db.Categories.Find(id);

            if (cat == null)
            {
                return HttpNotFound();
            }
            return View(cat);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult Edit(Category cat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cat).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["SuccessMessage"] = "Category has been updated successfully";
                return RedirectToAction("Index");
            }

            return View(db.Categories.Find(cat.Id));
        }

        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult Delete(int Id)
        {
            var category = db.Categories.Find(Id);

            if (category == null)
            {
                return HttpNotFound();
            }
            if (category.Posts.Count>0)
            {
                TempData["ErrorMessage"] = "The category contains posts can not be deleted.";
                return RedirectToAction("Index");
            }

            db.Categories.Remove(category);
            db.SaveChanges();
            TempData["SuccessMessage"] = "The category has been deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
