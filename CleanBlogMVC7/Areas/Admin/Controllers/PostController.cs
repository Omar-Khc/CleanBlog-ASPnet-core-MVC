using CleanBlogMVC7.Interfaces;
using CleanBlogMVC7.Models;
using CleanBlogMVC7.Services;
using CleanBlogMVC7.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

namespace CleanBlogMVC7.Areas.Admin.Controllers
{
    public class PostController : AdminBaseController
    {
        private readonly IPostRepository _postRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IImageFileService _imageFileService;

        public PostController(IPostRepository postRepository,
            IWebHostEnvironment webHostEnvironment,
            IImageFileService imageFileService)
        {
            _postRepository = postRepository;
            _webHostEnvironment = webHostEnvironment;
            _imageFileService = imageFileService;
        }


        public IActionResult Index()
        {
            var posts = _postRepository.GetAll();
            return View(posts);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddPostVM model)
        {

            //// Image Logic 
            //// 1) How to reach Image Folder
            //// _webHostEnvirnment.WebRootPath + "\\Images"
            //var uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");

            //// 2) File Name
            //var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);

            //var filePath = Path.Combine(uploadFolder, fileName);
            //using (var fileStream = new FileStream(filePath, FileMode.Create))
            //{
            //    await Image.CopyToAsync(fileStream);
            //}

            //foreach (var item in User.Claims)
            //{

            //}
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

            if (ModelState.IsValid)
            {
                //Add to DB
                var post = new Post()
                {
                    Title = model.Title,
                    Description = model.Description,
                    AuthorId = userId,
                    ImageName = await _imageFileService.Upload(model.Image),
                    Body = model.Body,
                    PostDate = model.PostDate,
                };

                _postRepository.AddPost(post);
                TempData["success"] = "Add Successfly";
                return RedirectToAction("Index");
            }
            return View();
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = _postRepository.GetById(id);
            if(post != null)
            {
                var postVm = new EditPostVM()
                {
                    ImageName = post.ImageName,
                    Body = post.Body,
                    PostDate = post.PostDate,
                    Description = post.Description,
                    Title = post.Title,
                };
                return View(postVm);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditPostVM editPostVM)
        {
            if (ModelState.IsValid)
            {

                if (editPostVM.Image != null)
                {
                    editPostVM.ImageName = await _imageFileService.Upload(editPostVM.Image);
                }
                _postRepository.UpdatePost(id, editPostVM);

                TempData["edit-success"] = "Edit Successfly";
                return RedirectToAction("Index");
            }

            return View(editPostVM);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _postRepository.DeletePost(id);
            return Ok(new { message = "Post Has been deleted " });
            //return RedirectToAction("Index");
        }
    }
}
