using bmerketo.Contexts;
using bmerketo.Models;
using bmerketo.Models.Entities;
using bmerketo.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace bmerketo.Services;

public class ProductService
{
	private readonly ProductContext _context;

	public ProductService(ProductContext context)
	{
		_context = context;
	}

	public async Task<bool> CreateAsync(AddProductViewModel addProductViewModel)
	{
		try
		{
			ProductEntity productEntity = addProductViewModel;

			_context.Products.Add(productEntity);
			await _context.SaveChangesAsync();
			return true;
		}
		catch
		{
			return false;
		}
		
	}


	public async Task<IEnumerable<ProductModel>> GetAllAsync()
	{
		var products = new List<ProductModel>();
		var items = await _context.Products.ToListAsync();

		foreach (var item in items)
		{
			ProductModel productModel = item;
			products.Add(productModel);
		}

		return products;	
	}
}



