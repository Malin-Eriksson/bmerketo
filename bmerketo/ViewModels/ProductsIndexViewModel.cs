using bmerketo.Models;

namespace bmerketo.ViewModels;

public class ProductsIndexViewModel
{
	public IEnumerable<ProductModel> Products { get; set; } = new List<ProductModel>();
}
