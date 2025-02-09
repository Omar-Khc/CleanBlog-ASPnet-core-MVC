using CleanBlogMVC7.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanBlogMVC7.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            this._postRepository = postRepository;
        }

        public IActionResult Details(int id)
        {
            var post = _postRepository.GetById(id);
            return View(post);
        }
    }
}
