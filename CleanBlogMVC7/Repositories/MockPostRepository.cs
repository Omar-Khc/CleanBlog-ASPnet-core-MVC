using CleanBlogMVC7.Models;
using CleanBlogMVC7.Interfaces;
using CleanBlogMVC7.ViewModels;

namespace CleanBlogMVC7.Repositories
{
    // Note this just a dume Data Sourse
    // this senario just if i have many data sourse
    public class MockPostRepository : IPostRepository
    {
        public static List<Post> posts = new List<Post>();

        public MockPostRepository()
        {
            posts.Add(new Post
            {
                Title = "Test 1",
                Author = new AppUser { FirstName = "Omar", LastName = "Berayo" },
                PostDate = DateTime.Now,
            });

            posts.Add(new Post
            {
                Title = "Test 2",
                Author = new AppUser { FirstName = "Wasim", LastName = "Ftawir" },
                PostDate = DateTime.Now,
            });

            posts.Add(new Post
            {
                Title = "Test 3",
                Author = new AppUser { FirstName = "Nemoir", LastName = "Bomba" },
                PostDate = DateTime.Now,
            });
        }

        public void AddPost(Post post)
        {
            posts.Add(post);
        }

        public void DeletePost(int id)
        {
            var post = posts.FirstOrDefault(x => x.Id == id);
            if (post != null)
            {
                posts.Remove(post);
            }
        }

        public List<Post> GetAll()
        {
            return posts;
        }

        public Post GetById(int id)
        {
            var post = posts.FirstOrDefault();
            if (post != null)
            {
                return post;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void UpdatePost(int id, EditPostVM post)
        {
            var postExisted = posts.FirstOrDefault(x => x.Id == id);
            if (postExisted != null)
            {
                postExisted.Title = post.Title;
                postExisted.Description = post.Description;
                postExisted.Body = post.Body;
            }
        }
    }
}
