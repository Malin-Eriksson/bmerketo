using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmerketo.Models;

public class ProductModel
{
	public string? ArticleNumber { get; set; }
	public string? Name { get; set; } = null!;

	public decimal? Price { get; set; }

	public string? Description { get; set; } = null!;

	public int? CategoryId { get; set; }

	
}
