using System.ComponentModel.DataAnnotations;

namespace CleanBlogMVC7.ViewModels
{
    public class AddPostVM
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Body { get; set; }

        public DateTime PostDate { get; set; }

        public IFormFile Image { get; set; }

    }
}
