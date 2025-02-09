using CleanBlogMVC7.Data;
using CleanBlogMVC7.Interfaces;
using CleanBlogMVC7.Models;
using CleanBlogMVC7.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanBlogMVC7.Controllers
{
    public class ContactController : Controller
    {
        private readonly CleanBlogDbContext _cleanBlogDbContext;
        private readonly IContactRepository contactRepository;

        public ContactController(CleanBlogDbContext cleanBlogDbContext, IContactRepository contactRepository)
        {
            this._cleanBlogDbContext = cleanBlogDbContext;
            this.contactRepository = contactRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactVM contactVM)
        {
            if(ModelState.IsValid)
            {
                await contactRepository.SendMessage(contactVM);

                //Or
                //var contactUs = new ContactUs()
                //{
                //    Email = contactVM.Email,
                //    Message = contactVM.Message,
                //    Name = contactVM.Name,
                //    Phone = contactVM.Phone,
                //};

                //_cleanBlogDbContext.ContactUs.Add(contactUs);
                //_cleanBlogDbContext.SaveChanges();

                TempData["success"] = "Your Message hae been send";

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
