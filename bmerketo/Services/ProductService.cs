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
	private readonly ProductContext _context;
	private readonly ProductCategoryService _categoryService;
	private readonly Repo<ProductEntity> _productService;

	public ProductService(ProductCategoryService categoryService, ProductContext context, Repo<ProductEntity> productService)
	{
		_categoryService = categoryService;
		_context = context;
		_productService = productService;
	}



	public async Task CreateAsync(AddProductFormModel form)
	{

		var category = await _categoryService.GetOrCreateAsync(form.Category);

		ProductEntity product = form;
		product.CategoryId = category.Id;
		
		await _productService.AddAsync(product);		
	}


	public async Task<IEnumerable<ProductEntity>> GetAllAsync()
	{
		return await _productService.GetAllAsync();
	}
}



