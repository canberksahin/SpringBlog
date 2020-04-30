using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpringBlog.Areas.Admin.ViewModels
{
    public class NewPostViewModel
    {
        public int CategoryId { get; set; }

        public string PhotoPath { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [AllowHtml,Required]
        public string Content { get; set; }
    }
}