﻿using SpringBlog.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpringBlog.Areas.Admin.Controllers
{
    public class CommentsController : AdminBaseController
    {
        // GET: Admin/Comments
        public ActionResult Index()
        {
            return View(db.Comments.ToList());
        }
        [HttpPost]
        public ActionResult ChangeState(int id , bool isPublished)
        {
            var comment = db.Comments.Find(id);

            comment.State = isPublished ? Enums.CommentState.Approved : Enums.CommentState.Rejected;
            db.SaveChanges();
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }
    }
}