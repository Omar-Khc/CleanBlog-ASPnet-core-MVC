using System.ComponentModel.DataAnnotations;

namespace CleanBlogMVC7.ViewModels
{
    public class ContactVM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [MaxLength(400)]
        [Required]
        public string Message { get; set; }
    }
}
