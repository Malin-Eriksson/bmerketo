using bmerketo.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace bmerketo.Models;

public class AddProductFormModel
{
    [Required(ErrorMessage = "You have to enter a product name")]
    [Display(Name = "Product name *")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "You have to enter the product's price")]
    [Display(Name = "Product price *")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }


    [Display(Name = "Product description (optional)")]
    public string? Description { get; set; } = null!;


    [Display(Name = "Product category (optional)")]
    public ProductCategoryModel Category { get; set; } = new ProductCategoryModel();

    public static implicit operator ProductEntity(AddProductFormModel model)
    {
        return new ProductEntity
		{
			Name = model.Name,
			Description = model.Description,
			Price = model.Price,
			
		};

	}

}
