using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringBlog.ViewModels
{
    public class CommentViewModel
    {
        [StringLength(4000),Required]
        public string Content { get; set; }

        public int? ParentId { get; set; }
    }
}