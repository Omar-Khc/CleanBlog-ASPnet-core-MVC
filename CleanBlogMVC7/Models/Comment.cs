using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CleanBlogMVC7.Models;

namespace CleanBlogMVC7.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [StringLength(500)]
        public string Text { get; set; }


        [ForeignKey(nameof(User))]
        [StringLength(450)]
        public string UserId { get; set; }
        public AppUser User { get; set; }


        // to add foreign Key
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
