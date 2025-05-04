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

        public async Task<List<Person>> GetAllUsersAsync()
        {
            return await _db.Persons.ToListAsync(); // Assuming your user table is named "Users"
        }

        public async Task<Person> GetUserByIdAsync(int id)
        {
            return await _db.Persons.FirstOrDefaultAsync(u => u.Id == id); //Match your table and PK columns
        }

        public async Task<Person> CreateUserAsync(Person person)
        {
            _db.Persons.Add(person);  // Match your table and PK columns
            await _db.SaveChangesAsync();
            return person;
        }
    }
}
