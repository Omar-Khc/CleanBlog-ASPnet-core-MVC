using CleanBlogMVC7.ViewModels;

namespace CleanBlogMVC7.Interfaces
{
    public interface IContactRepository
    {
        Task SendMessage(ContactVM model);
        Task<List<ContactVM>> GetAllMessages();

        Task ReadMessage(int id);
    }
}
