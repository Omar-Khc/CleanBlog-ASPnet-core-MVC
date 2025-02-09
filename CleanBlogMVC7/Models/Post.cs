using CleanBlogMVC7.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanBlogMVC7.Models
{
    public class Post
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public string Body { get; set; }

        public DateTime PostDate { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;

        [StringLength(255)]
        public string ImageName { get; set; }


        [ForeignKey("Author")]
        [StringLength(450)]
        public string AuthorId { get; set; }
        public AppUser Author { get; set; }
    }
}
