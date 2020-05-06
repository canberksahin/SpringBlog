using SpringBlog.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpringBlog.Areas.Admin.ViewModels
{
    public class EditPostViewModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [PostedImage]
        public HttpPostedFileBase FeaturedImage { get; set; }

        public string CurrentFeaturedImage { get; set; }

        [Display(Name ="Creation Time")]
        public DateTime CreationTime { get; set; }

        [Display(Name = "Modification Time")]
        public DateTime ModificationTime { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [AllowHtml, Required]
        public string Content { get; set; }

        [Display(Name = "Short URL"), Required, StringLength(200)]
        public string Slug { get; set; }
    }
}