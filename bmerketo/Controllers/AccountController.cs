using bmerketo.Services;
using bmerketo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _auth;
        private readonly UserService _userService;

		public AccountController(AuthService auth, UserService userService)
		{
			_auth = auth;
			_userService = userService;
		}

		[Authorize]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _auth.SignUpAsync(model);

                if (user != null)
                {
					if (model.ProfilePicture != null)
						await _userService.UploadImageAsync(user, model.ProfilePicture!);

					return RedirectToAction("SignIn");
				}

                ModelState.AddModelError("", "A user with the same email already exists");
            }

            return View(model);
        }


        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _auth.SignInAsync(model))
                    return RedirectToAction("Index");

                ModelState.AddModelError("", "Incorrect email or password");
            }

            return View(model);
        }


        [Authorize]
        public new async Task<IActionResult> SignOut()
        {
            if (await _auth.SignOutAsync(User))
                return LocalRedirect("/");

            return RedirectToAction("Index");
        }


	}

}
