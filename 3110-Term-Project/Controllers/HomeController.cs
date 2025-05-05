using System.Diagnostics;
using _3110_Term_Project.Data;
using _3110_Term_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace _3110_Term_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        // This is the only constructor. It will be used for dependency injection.
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var stats = new StatsView
            {
                TotalPeople = await _context.Persons.CountAsync(),
                TotalEvents = await _context.Events.CountAsync(),
                TotalRegistrations = await _context.Registrations.CountAsync()
            };

            return View(stats); // Pass the stats to the view
        }
    }
}
