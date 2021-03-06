﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringBlog.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required,StringLength(30,ErrorMessage ="Category Name can have 30 character at most"),Display(Name ="Category Name")]
        public string CategoryName { get; set; }

        [MaxLength(30), Required, Display(Name = "Short URL")]
        public string Slug { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}

