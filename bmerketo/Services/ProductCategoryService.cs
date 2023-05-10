using bmerketo.Models;
using bmerketo.Repositories;
using static bmerketo.Models.Entities.ProductEntity;

namespace bmerketo.Services;

public class ProductCategoryService
{
	private readonly Repo<ProductCategoryEntity> _categoryRepo;

	public ProductCategoryService(Repo<ProductCategoryEntity> categoryRepo)
	{
		_categoryRepo = categoryRepo;
	}

	public async Task<ProductCategoryEntity> GetOrCreateAsync(ProductCategoryModel model)
	{
		var categoryEntity = await _categoryRepo.GetAsync(x => x.Id == model.Value);
		categoryEntity ??= await _categoryRepo.AddAsync(new ProductCategoryEntity { CategoryName = model.Name });
		return categoryEntity;
	}
}
