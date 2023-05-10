using bmerketo.Services;
using bmerketo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace bmerketo.Controllers
{
	public class ProductsController : Controller
	{

		private readonly ProductService _productService;

		public ProductsController(ProductService productService)
		{
			_productService = productService;
		}

		public async Task<IActionResult> Index()
		{
			var products = await _productService.GetAllAsync();			
			return View(products);
		}

		public IActionResult Search()
		{
			ViewData["Title"] = "Search for products";
			return View();
		}


		[Authorize(Roles = "admin")]
		public IActionResult AddProduct()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Add(AddProductViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				await _productService.CreateAsync(viewModel.Form);
				return RedirectToAction("Index");
			}
			return View(viewModel);
		}




	}
}
