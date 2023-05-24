using bmerketo.Models;
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
			var viewModel = new ProductsIndexViewModel
			{
				Products = await _productService.GetAllAsync()
			};		
			return View(viewModel);
		}

		public IActionResult Details(int id)
		{
			return View(id);
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
		public async Task<IActionResult> AddProduct(AddProductFormModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var product = await _productService.CreateAsync(viewModel);
				if (product != null)
				{
					if (viewModel.Image != null)
						await _productService.UploadImageAsync(product, viewModel.Image!);

					return RedirectToAction("Index");
				}

				ModelState.AddModelError("", "Something went wrong!");
				
			}
			return View(viewModel);
		}




	}
}
