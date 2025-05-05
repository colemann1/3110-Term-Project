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

        // GET: /User/
        public async Task<IActionResult> Index()
        {
            var users = await _userRepo.GetAllUsersAsync();
            return View(users);
        }

        // GET: /User/Create
        [HttpGet]
        public IActionResult Create()
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

        // GET: /User/Edit/
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var person = await _userRepo.GetUserByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: /User/Edit/
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(person);
            }

            await _userRepo.UpdateUserAsync(person);
            return RedirectToAction(nameof(Index));
        }

        // GET: /User/Delete/
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await _userRepo.GetUserByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: /User/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _userRepo.GetUserByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            await _userRepo.DeleteUserAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
