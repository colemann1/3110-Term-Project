using _3110_Term_Project.Models;
using System.Threading.Tasks;

namespace _3110_Term_Project.Services
{
    public interface IUserRepository
    {
        Task<List<Person>> GetAllUsersAsync();
        Task<Person> GetUserByIdAsync(int id);
        Task<Person> CreateUserAsync(Person user);
        Task UpdateUserAsync(Person person);
        Task DeleteUserAsync(int id);
    }
}
