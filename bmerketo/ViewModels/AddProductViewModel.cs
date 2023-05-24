using bmerketo.Models;
using bmerketo.Models.Entities;

namespace bmerketo.ViewModels;

public class AddProductViewModel
{

	public AddProductFormModel Form { get; set; } = new AddProductFormModel();

	public IEnumerable<TagModel> Tags { get; set; } = null!;







/*    [Required(ErrorMessage = "You have to enter a product name")]
    [Display(Name = "Product name *")]
    public string Name { get; set; } = null!;


	[Required(ErrorMessage = "You have to enter the product's price")]
	[Display(Name = "Product price *")]
	[DataType(DataType.Currency)]
	public decimal Price { get; set; }


	[Display(Name = "Product description (optional)")]
    public string? Description { get; set; } = null!;


	[Display(Name = "Product category (optional)")]
	public int? CategoryId { get; set; } 




	public static implicit operator ProductEntity(AddProductViewModel addProductViewModel)
	{
		return new ProductEntity
		{
			Name = addProductViewModel.Name,
			Price = addProductViewModel.Price,
			Description = addProductViewModel.Description,
			CategoryId = addProductViewModel.CategoryId

		};
	}*/




}
