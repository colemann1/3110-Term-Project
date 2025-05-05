using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using _3110_Term_Project.Models;
using _3110_Term_Project.Models.ViewModels;
using _3110_Term_Project.Services;

namespace _3110_Term_Project.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepo;
        private readonly IUserRepository _userRepo;

        public EventController(IEventRepository eventRepo, IUserRepository userRepo)
        {
            _eventRepo = eventRepo;
            _userRepo = userRepo;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _eventRepo.GetAllEventsAsync();
            
            return View(events);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("EventName,EventDate,Location,Description,Capacity")] Event @event)
        {
            if (!ModelState.IsValid)
            {// Attempting to catch errors, could not create event.
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(@event);
            }

            try
            {
                await _eventRepo.CreateEventAsync(@event);
                Console.WriteLine("Event added successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding event: " + ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var @event = await _eventRepo.GetById(id);
            if (@event == null)
            {
                return NotFound();
            }

            var vm = new EventDetailsVM
            {
                Id = @event.Id,
                EventName = @event.EventName,
                Description = @event.Description,
                EventDate = @event.EventDate,
                Capacity = @event.Capacity,
            };
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> AssignUser(int eventId, int userId)
        {
            var @event = await _eventRepo.AssignUserToEventAsync(eventId, userId);
            if (@event == null)
            {
                return Json(new { message = "Error assigning user." });
            }
            return Json("Ok");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var @event = await _eventRepo.GetById(id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Event @event)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(@event);
            }

            await _eventRepo.UpdateEventAsync(@event);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var @event = await _eventRepo.GetById(id);
            if (@event == null)
            {
                return NotFound();
            }

            var vm = new EventDetailsVM
            {
                Id = @event.Id,
                EventName = @event.EventName,
                Description = @event.Description,
                EventDate = @event.EventDate,
                Capacity = @event.Capacity,
            };
            return View(vm);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _eventRepo.GetById(id);
            if (@event == null)
            {
                return NotFound();
            }

            await _eventRepo.DeleteEventAsync(@event);
            return RedirectToAction(nameof(Index));
        }
    }
}
