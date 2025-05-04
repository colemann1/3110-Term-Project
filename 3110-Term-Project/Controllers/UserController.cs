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
            var vm = users.Select(u => new UserDetailsVM
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email
            }).ToList();
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            await _userRepo.CreateUserAsync(user);
            return RedirectToAction(nameof(Index));
        }
    }
}
