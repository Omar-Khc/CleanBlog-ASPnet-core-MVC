using CleanBlogMVC7.Data;
using CleanBlogMVC7.Interfaces;
using CleanBlogMVC7.Models;
using CleanBlogMVC7.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleanBlogMVC7.Repositories
{
    public class PostRepository : IPostRepository
    {

        private readonly CleanBlogDbContext _cleanBlogDbContext;

        public PostRepository(CleanBlogDbContext cleanBlogDbContext)
        {
            this._cleanBlogDbContext = cleanBlogDbContext;
        }

        public void AddPost(Post post)
        {
            _cleanBlogDbContext.Posts.Add(post);
            _cleanBlogDbContext.SaveChanges();
        }

        public void DeletePost(int id)
        {
            var post = _cleanBlogDbContext.Posts.FirstOrDefault(post => post.Id == id);
            if (post != null)
            {
                _cleanBlogDbContext.Posts.Remove(post);
                _cleanBlogDbContext.SaveChanges();
            }
        }

        public List<Post> GetAll()
        {
            return _cleanBlogDbContext.Posts
                .Include(x => x.Author)
                .OrderByDescending(x => x.PostDate)
                .AsNoTracking()
                .ToList();
        }

        public Post GetById(int id)
        {
            var post = _cleanBlogDbContext.Posts
                .Include(x => x.Author)
                .AsNoTracking()
                .FirstOrDefault(post => post.Id == id);

            if (post != null)
                return post;

            return null;
        }

        public void UpdatePost(int id, EditPostVM post)
        {
            var postExisting = _cleanBlogDbContext.Posts.FirstOrDefault(post => post.Id == id);
            if (postExisting != null)
            {
                postExisting.Title = post.Title;
                postExisting.Description = post.Description;
                postExisting.Body = post.Body;
                if (post.ImageName != null)
                    postExisting.ImageName = post.ImageName;


                _cleanBlogDbContext.SaveChanges();
            }
        }
    }
}
