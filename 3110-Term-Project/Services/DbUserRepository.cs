using _3110_Term_Project.Models;
using _3110_Term_Project.Data;
using Microsoft.EntityFrameworkCore;

namespace _3110_Term_Project.Services
{
    public class DbUserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db; // Use your actual DbContext class

        public DbUserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _db.Users.ToListAsync(); // Assuming your user table is named "Users"
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Id == id); //Match your table and PK columns
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _db.Users.Add(user);  // Match your table and PK columns
            await _db.SaveChangesAsync();
            return user;
        }
    }
}
