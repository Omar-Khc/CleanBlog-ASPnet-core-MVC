using System.ComponentModel.DataAnnotations;

namespace CleanBlogMVC7.Models
{
    public class ContactUs
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }

        [StringLength(400)]
        public string Message { get; set; }

        public DateTime? ReadAt { get; set; }
    }
}
