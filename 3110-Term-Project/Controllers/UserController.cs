using _3110_Term_Project.Models;
using _3110_Term_Project.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using _3110_Term_Project.Services;

namespace _3110_Term_Project.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userRepo.GetAllUsersAsync();

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }

            await _userRepo.CreateUserAsync(person);
            return RedirectToAction(nameof(Index));
        }
    }
}
