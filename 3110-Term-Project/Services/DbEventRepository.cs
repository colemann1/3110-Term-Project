using _3110_Term_Project.Models;
using _3110_Term_Project.Data;
using Microsoft.EntityFrameworkCore;

namespace _3110_Term_Project.Services
{
    public class DbEventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _db;

        public DbEventRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<Event> GetById(int id)
        {
            return await _db.Events.FindAsync(id);
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _db.Events.ToListAsync();
        }

        public async Task<Event> CreateEventAsync(Event newEvent)
        {
            _db.Events.Add(newEvent);
            await _db.SaveChangesAsync();
            return newEvent;
        }

        public async Task<Event> AssignUserToEventAsync(int eventId, int userId)
        {
            var @event = await _db.Events.FindAsync(eventId);
            var user = await _db.Persons.FindAsync(userId);
            if (@event != null && user != null)
            {
                @event.Persons.Add(user);
                await _db.SaveChangesAsync();
            }
            return @event;
        }
        public async Task UpdateEventAsync(Event @event)
        {
            _db.Events.Update(@event);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(Event @event)
        {
            _db.Events.Remove(@event);
            await _db.SaveChangesAsync();
        }
    }
}
