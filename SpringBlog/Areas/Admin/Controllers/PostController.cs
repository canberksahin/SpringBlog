using Microsoft.AspNet.Identity;
using SpringBlog.Areas.Admin.ViewModels;
using SpringBlog.Controllers;
using SpringBlog.Helpers;
using SpringBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpringBlog.Areas.Admin.Controllers
{
    public class PostController : AdminBaseController
    {

        public ActionResult New()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(x => x.CategoryName).ToList(), "Id", "CategoryName");
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult New(NewPostViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Post post = new Post
                {
                    CategoryId=vm.CategoryId,
                    Title = vm.Title,
                    Content = vm.Content,
                    AuthorId = User.Identity.GetUserId(),
                    Slug=UrlService.URLFriendly(vm.Title),
                    CreationTime=DateTime.Now,
                    ModificationTime = DateTime.Now,
                    PhotoPath=""
                };
                db.Posts.Add(post);
                db.SaveChanges();
                //to-do past indexe yönlendir.
                return RedirectToAction("Index","Dashboard");
            }
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(x => x.CategoryName).ToList(), "Id", "CategoryName");
            return View();
        }
    }
}