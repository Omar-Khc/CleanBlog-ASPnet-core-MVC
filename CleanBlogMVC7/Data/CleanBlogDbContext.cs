using CleanBlogMVC7.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CleanBlogMVC7.Data
{
    public class CleanBlogDbContext : IdentityDbContext<AppUser>
    {
        public CleanBlogDbContext(DbContextOptions<CleanBlogDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }

    }
}
