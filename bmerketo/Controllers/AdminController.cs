using bmerketo.Services;
using bmerketo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller

    {
		private readonly AuthService _auth;


		public AdminController(AuthService auth)
		{
			_auth = auth;

		}

		public IActionResult Index()
        {
            return View();
        }

		public async Task<IActionResult> AdminSignUp()
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
	}
}
