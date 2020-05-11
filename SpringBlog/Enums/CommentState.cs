using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringBlog.Enums
{
    public enum CommentState
    {
        [Display(Name ="Pending Review")]
        Pending,
        [Display(Name ="Published")]
        Approved,
        [Display(Name ="Not Published")]
        Rejected
    }
}