using _3110_Term_Project.Models;

namespace _3110_Term_Project.Services
{
    public interface IEventRepository
    {
        Task<Event> GetById(int id);
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event> CreateEventAsync(Event newEvent);
        Task<Event> AssignUserToEventAsync(int eventId, int userId);
    }
}
