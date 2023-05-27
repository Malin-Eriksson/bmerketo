using bmerketo.Models.Entities;
using bmerketo.Repositories;
using bmerketo.Services;
using bmerketo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller

    {
		private readonly AuthService _auth;
		private readonly UserRepo _userRepo;
		private readonly UserManager<UserEntity> _userManager;
		private readonly UserService _userService;



		public AdminController(AuthService auth, UserRepo userRepo, UserManager<UserEntity> userManager, UserService userService)
		{
			_auth = auth;
			_userRepo = userRepo;
			_userManager = userManager;
			_userService = userService;
		}

		public IActionResult Index()
        {
            return View();
        }

		public IActionResult AdminSignUp()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AdminSignUp(AdminSignUpViewModel model)
		{
			if (ModelState.IsValid)
			{
				if (await _auth.SignUpAsync(model))
					return RedirectToAction("Index");

				ModelState.AddModelError("", "A user with the same email already exists");
			}
			return View(model);
		}


		public IActionResult UserDetails(string userid)
		{
			return View((object)userid);
		}

		[HttpPost]
		public async Task<IActionResult> UserDetails(string userId, string newRole)
		{
			if (string.IsNullOrEmpty(userId))
			{
				ModelState.TryAddModelError("userId", "User not found");
				return View();
			}

			await _userService.UpdateUserRoleAsync(userId, newRole);
			return RedirectToAction("Index");
		}



	}
}
