using bmerketo.Models;
using bmerketo.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace bmerketo.ViewModels;

public class AddProductViewModel
{

	[Required(ErrorMessage = "You have to enter an article number")]
	[Display(Name = "Article number *")]
	public string ArticleNumber { get; set; } = null!;

	[Required(ErrorMessage = "You have to enter a product name")]
	[Display(Name = "Product name *")]
	public string Name { get; set; } = null!;

	[Required(ErrorMessage = "You have to enter the product's price")]
	[Display(Name = "Product price *")]
	[DataType(DataType.Currency)]
	public decimal Price { get; set; }


	[Display(Name = "Product description (optional)")]
	public string? Description { get; set; } = null!;





	[DataType(DataType.Upload)]
	public IFormFile? Image { get; set; } = null!;

	public static implicit operator ProductEntity(AddProductViewModel model)
	{


		var entity = new ProductEntity
		{
			ArticleNumber = model.ArticleNumber,
			Name = model.Name,
			Description = model.Description,
			Price = model.Price

		};

		if (model.Image != null)
			entity.ImageUrl = $"{Guid.NewGuid()}_{model.Image?.FileName}";

		return entity;

	}




}
