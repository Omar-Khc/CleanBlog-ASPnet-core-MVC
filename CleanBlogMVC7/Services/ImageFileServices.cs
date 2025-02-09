using CleanBlogMVC7.Interfaces;
using Microsoft.AspNetCore.Hosting;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace CleanBlogMVC7.Services
{
    public class ImageFileServices : IImageFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageFileServices(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task ResizeImage(string ImagePath, string ImageName)
        {

            var ThumbFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "Thumbs");
            var NewThumbImage = Path.Combine(ThumbFolder, ImageName);

            using (Image image =  await Image.LoadAsync(ImagePath))
            {
                image.Mutate
                    (x => x.Resize(new ResizeOptions
                    {
                        Mode = ResizeMode.Crop,
                        Size = new Size(700, 330)
                    }));

                await image.SaveAsync(NewThumbImage);
            }
        }

        public async Task<string> Upload(IFormFile Image)
        {
            // Image Logic 
            // 1) How to reach Image Folder
            // _webHostEnvirnment.WebRootPath + "\\Images"
            var uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");

            // 2) File Name
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);

            var filePath = Path.Combine(uploadFolder, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }

            await ResizeImage(filePath, fileName);

            return fileName;
        }
    }
}
