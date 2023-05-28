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
	
	private readonly ProductTagRepo _productTagRepo;
	private readonly ProductRepo _productRepo;
	private readonly IWebHostEnvironment _webHostEnvironment;

	public ProductService(IWebHostEnvironment webHostEnvironment, ProductRepo productRepo, ProductTagRepo productTagRepo)
	{

		_webHostEnvironment = webHostEnvironment;
		_productRepo = productRepo;
		_productTagRepo = productTagRepo;
	}



	public async Task<ProductEntity> CreateAsync(ProductEntity entity) 
	{
		var _entity = await _productRepo.GetAsync(x => x.ArticleNumber == entity.ArticleNumber);
		if(_entity == null)
		{
			_entity = await _productRepo.AddAsync(entity);
				
		}
		return entity;
	}


 
    public async Task AddProductTagsAsync(ProductEntity entity, string[] tags)
	{
		foreach (var tag in tags)
		{
			await _productTagRepo.AddAsync(new ProductTagEntity
			{
				ArticleNumber = entity.ArticleNumber,
				TagId = int.Parse(tag)
			});
		}
	}




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
		var items = await _productRepo.GetAllAsync();
		var list = new List<ProductModel>();
		foreach (var item in items)		
			list.Add(item);
		return list;
		
	}

}



