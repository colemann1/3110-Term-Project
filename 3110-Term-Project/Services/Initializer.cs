using _3110_Term_Project.Data;
using _3110_Term_Project.Models;

namespace _3110_Term_Project.Services
{
    public class Initializer
    {
        private readonly ApplicationDbContext _db;

        public Initializer(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task SeedDatabaseAsync()
        {
            _db.Database.EnsureCreated();

            if (_db.Events.Any() == false)
            {
                var events = new List<Event>
                {
                    new() {EventName = "Test Event", EventDate = DateTime.Parse("06/05/2026"), Location="Test Location", Description="This is a test event.", Capacity=100}
                };

            await _db.Events.AddRangeAsync(events);
            await _db.SaveChangesAsync();
            }

            if (_db.Persons.Any() == false)
            {
                var persons = new List<Person>
                {
                    new() {Personname="Test Attendee 2", Email="testuseremail2@testuser.test"}
                };

                await _db.Persons.AddRangeAsync(persons);
                await _db.SaveChangesAsync();
            }
        }
    }
}
