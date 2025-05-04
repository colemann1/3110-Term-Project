using _3110_Term_Project.Models;
using System.Threading.Tasks;

namespace _3110_Term_Project.Services
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
    }
}
