using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpringBlog.Models
{
    public class Post
    {
        public int Id { get; set; }

        [ForeignKey("Author"),Required]
        public string AuthorId { get; set; }

        public int CategoryId { get; set; }

        public string PhotoPath { get; set; }

        [MaxLength(255),Required]
        public string Slug { get; set; }

        [Required,MaxLength(100)]
        public string Title { get; set; }


        public string Content { get; set; }

        [Required]
        public DateTime? CreationTime { get; set; }

        [Required]
        public DateTime? ModificationTime { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual Category Category { get; set; }

    }
}