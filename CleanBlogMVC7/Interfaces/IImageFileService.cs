namespace CleanBlogMVC7.Interfaces
{
    public interface IImageFileService
    {
        Task<string> Upload(IFormFile image);
    }
}
