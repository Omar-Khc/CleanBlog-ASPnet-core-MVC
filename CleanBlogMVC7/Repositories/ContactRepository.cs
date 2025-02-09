using CleanBlogMVC7.Data;
using CleanBlogMVC7.Interfaces;
using CleanBlogMVC7.Models;
using CleanBlogMVC7.ViewModels;

namespace CleanBlogMVC7.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly CleanBlogDbContext context;

        public ContactRepository(CleanBlogDbContext context)
        {
            this.context = context;
        }

        public Task<List<ContactVM>> GetAllMessages()
        {
            throw new NotImplementedException();
        }

        public Task ReadMessage(int id)
        {
            throw new NotImplementedException();
        }

        public async Task SendMessage(ContactVM model)
        {
            await context.ContactUs.AddAsync(new ContactUs
            {
                Email = model.Email,
                Phone = model.Phone,
                Name = model.Name,
                Message = model.Message,
            });

            await context.SaveChangesAsync();
        }
    }
}
