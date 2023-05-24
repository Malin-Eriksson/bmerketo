using bmerketo.Contexts;
using bmerketo.Models;
using bmerketo.Models.Entities;
using bmerketo.Repositories;
using bmerketo.ViewModels;
using Microsoft.EntityFrameworkCore;
using static bmerketo.Models.Entities.ProductEntity;

namespace bmerketo.Services;

public class ProductService
{
	private readonly DataContext _context;
	private readonly TagService _categoryService;

	private readonly ProductRepo _productService;
	private readonly IWebHostEnvironment _webHostEnvironment;

	public ProductService(TagService categoryService, DataContext context, IWebHostEnvironment webHostEnvironment, ProductRepo productService)
	{
		_categoryService = categoryService;
		_context = context;
		_webHostEnvironment = webHostEnvironment;
		_productService = productService;
	}



	public async Task<ProductModel> CreateAsync(AddProductFormModel form) 
	{

			//var tag = await _categoryService.GetOrCreateAsync(form.Tag);

			ProductEntity product = form;
			//product.Tag = tag.Id;

			await _productService.AddAsync(product);

			return product;

	}


/*	public async Task<IEnumerable<ProductEntity>> GetAllAsync()
	{
		return await _productRepo.GetAllAsync();
	}*/


	public async Task<bool> UploadImageAsync(ProductModel product, IFormFile image)
	{
		try
		{
			string imagePath = $"{_webHostEnvironment.WebRootPath}/images/products/{product.ImageUrl}";
			await image.CopyToAsync(new FileStream(imagePath, FileMode.Create));
			return true;
		}
		catch { return false; }
	}

	public async Task<IEnumerable<ProductModel>> GetAllAsync()
	{
		var items = await _productService.GetAllAsync();
		var list = new List<ProductModel>();
		foreach (var item in items)		
			list.Add(item);
		return list;
		
	}

}



