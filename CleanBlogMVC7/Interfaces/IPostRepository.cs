using CleanBlogMVC7.Models;
using CleanBlogMVC7.ViewModels;

namespace CleanBlogMVC7.Interfaces
{
    public interface IPostRepository
    {
        void AddPost(Post post);
        Post GetById(int id);
        List<Post> GetAll();
        void UpdatePost(int id, EditPostVM post);
        void DeletePost(int id);
    }
}
