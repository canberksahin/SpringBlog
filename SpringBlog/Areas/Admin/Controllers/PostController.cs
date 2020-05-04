using Microsoft.AspNet.Identity;
using SpringBlog.Areas.Admin.ViewModels;
using SpringBlog.Controllers;
using SpringBlog.Helpers;
using SpringBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SpringBlog.Areas.Admin.Controllers
{
    public class PostController : AdminBaseController
    {
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }
        public ActionResult New()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(x => x.CategoryName).ToList(), "Id", "CategoryName");
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult New(NewPostViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Post post = new Post
                {
                    CategoryId = vm.CategoryId,
                    Title = vm.Title,
                    Content = vm.Content,
                    AuthorId = User.Identity.GetUserId(),
                    Slug = UrlService.URLFriendly(vm.Title),
                    CreationTime = DateTime.Now,
                    ModificationTime = DateTime.Now,
                    PhotoPath = ""
                };
                db.Posts.Add(post);
                db.SaveChanges();
                //to-do past indexe yönlendir.
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(x => x.CategoryName).ToList(), "Id", "CategoryName");
            return View();
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);

            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(x => x.CategoryName).ToList(), "Id", "CategoryName");
            return View(post);
        }

        [ValidateAntiForgeryToken, HttpPost, ValidateInput(false)]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                var postDb = db.Posts.FirstOrDefault(x => x.Id == post.Id);
                postDb.CategoryId = post.CategoryId;
                postDb.Content = post.Content;
                postDb.Title = post.Title;
                postDb.ModificationTime = DateTime.Now;
                db.SaveChanges();
                TempData["SuccessMessage"] = "Post has been updated successfully";
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(x => x.CategoryName).ToList(), "Id", "CategoryName");

            return View(db.Posts.Find(post.Id));
        }

        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult Delete(int Id)
        {
            var post = db.Posts.Find(Id);

            if (post == null)
            {
                return HttpNotFound();
            }

            db.Posts.Remove(post);
            db.SaveChanges();
            TempData["SuccessMessage"] = "The post has been deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}