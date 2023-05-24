using bmerketo.Repositories;
using bmerketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo.Controllers
{
	public class ContactController : Controller
	{
		private readonly ContactFormRepo _contactFormRepo;

		public ContactController(ContactFormRepo contactFormRepo)
		{
			_contactFormRepo = contactFormRepo;
		}

		public IActionResult Index()
		{
			ViewData["Title"] = "Contact Us";

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(ContactFormViewModel viewModel)
		{	
			if (ModelState.IsValid)
			{
				await _contactFormRepo.AddAsync(viewModel);
				return RedirectToAction("Index");
			}
			return View(viewModel);
		}
	}
}
