using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmerketo.Models.Entities;

public partial class ProductEntity
{
	[Key]

	public int Id { get; set; }
	public string ArticleNumber { get; set; } = null!;
	public string Name { get; set; } = null!;

	[Column(TypeName = "money")]
	public decimal Price { get; set; }

	public string? Description { get; set; } = null!;

	public string? ImageUrl { get; set; } = null!;



	public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();

	


	public static implicit operator ProductModel(ProductEntity entity)
	{
		return new ProductModel
		{
			Id = entity.Id,
			ArticleNumber = entity.ArticleNumber,
			Name = entity.Name,
			Price = entity.Price,
			Description = entity.Description,
			ImageUrl = entity.ImageUrl
			
		};
	}
	
}
