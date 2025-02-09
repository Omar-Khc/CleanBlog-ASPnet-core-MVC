using Microsoft.AspNetCore.Mvc;

namespace CleanBlogMVC7.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
