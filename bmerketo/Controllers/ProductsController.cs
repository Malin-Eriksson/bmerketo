using bmerketo.Services;
using bmerketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bmerketo.Controllers
{
	public class ProductsController : Controller
	{

		private readonly ProductService _productService;

		public ProductsController(ProductService productService)
		{
			_productService = productService;
		}

		public IActionResult Index()
		{
			var viewModel = new ProductsIndexViewModel
			{
				All = new GridCollectionViewModel
				{
					Title = "Products",
					Categories = new List<string> { "All", "New", "Popular", "Featured" }
				}
			};
			
			return View(viewModel);
		}

		public IActionResult Search()
		{
			ViewData["Title"] = "Search for products";
			return View();
		}


		public IActionResult AddProduct()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> AddProduct(AddProductViewModel addProductViewModel)
		{
			if (ModelState.IsValid)
			{
				if (await _productService.CreateAsync(addProductViewModel))
					return RedirectToAction("Index", "Products");

				ModelState.AddModelError("", "Something went wrong when creating the product");
			}
			return View();
		}




	}
}
