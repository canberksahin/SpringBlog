using X.PagedList;
using SpringBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringBlog.ViewModels
{
    public class HomeIndexViewModel
    {
        public Category Category { get; set; }

        public IPagedList<Post> Posts { get; set; }

        public string SearchTerm { get; set; }

        public int? SelectedCategoryId { get; set; }

    }
}