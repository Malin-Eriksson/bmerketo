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
		private readonly TagService _tagService;

		public ProductsController(ProductService productService, TagService tagService)
		{
			_productService = productService;
			_tagService = tagService;
		}

		public async Task<IActionResult> Index()
		{
			var viewModel = new ProductsIndexViewModel
			{
				Products = await _productService.GetAllAsync()
			};		
			return View(viewModel);
		}

		public IActionResult Details(string articlenumber)
		{
			return View((object)articlenumber);
		}

		public IActionResult Search()
		{
			ViewData["Title"] = "Search for products";
			return View();
		}


		[Authorize(Roles = "admin")]
		public async Task<IActionResult> AddProduct()
		{
			ViewBag.Tags = await _tagService.GetTagsAsync();
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> AddProduct(AddProductFormModel viewModel, string[] tags)
		{
			if (ModelState.IsValid)
			{
				var product = await _productService.CreateAsync(viewModel);
				
					
				if (product != null)
				{
					await _productService.AddProductTagsAsync(viewModel, tags);

					if (viewModel.Image != null)
						await _productService.UploadImageAsync(product, viewModel.Image!);

					return RedirectToAction("Index");
				}

				ModelState.AddModelError("", "Something went wrong!");
				
			}
			ViewBag.Tags = await _tagService.GetTagsAsync(tags);
			return View(viewModel);
		}




	}
}
