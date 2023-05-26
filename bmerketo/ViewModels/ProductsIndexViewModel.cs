using bmerketo.Models;
using bmerketo.Models.Entities;

namespace bmerketo.ViewModels;

public class ProductsIndexViewModel
{
	public string? Title { get; set; } = "";
	public IEnumerable<TagEntity> ProductTags { get; set; } = new List<TagEntity>();
	public IEnumerable<ProductModel> Products { get; set; } = new List<ProductModel>();

	public bool LoadMore { get; set; } = false;
}
