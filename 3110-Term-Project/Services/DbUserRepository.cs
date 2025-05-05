using _3110_Term_Project.Models;
using _3110_Term_Project.Data;
using Microsoft.EntityFrameworkCore;

namespace _3110_Term_Project.Services
{
    public class DbUserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public DbUserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Person>> GetAllUsersAsync()
        {
            return await _db.Persons.ToListAsync();
        }

        public async Task<Person> GetUserByIdAsync(int id)
        {
            return await _db.Persons.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Person> CreateUserAsync(Person person)
        {
            _db.Persons.Add(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public async Task UpdateUserAsync(Person person)
        {
            _db.Entry(person).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var person = await _db.Persons.FindAsync(id);
            if (person != null)
            {
                _db.Persons.Remove(person);
                await _db.SaveChangesAsync();
            }
        }
    }
}
