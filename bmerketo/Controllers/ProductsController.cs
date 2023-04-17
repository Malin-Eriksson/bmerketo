using bmerketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo.Controllers
{
	public class ProductsController : Controller
	{
		public IActionResult Index()
		{
			var viewModel = new ProductsIndexViewModel
			{
				All = new GridCollectionViewModel
				{
					Title = "All Products",
					Categories = new List<string> { "All", "News", "Spring favorites" }
				}
			};
			
			return View(viewModel);
		}
		public IActionResult Search()
		{
			ViewData["Title"] = "Search for products";
			return View();
		}
	}
}
