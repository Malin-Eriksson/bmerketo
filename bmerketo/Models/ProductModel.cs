using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace bmerketo.Models;

public class ProductModel
{
	public string ArticleNumber { get; set; } = null!;
	public string? Name { get; set; } = null!;

	public decimal? Price { get; set; }

	public string? Description { get; set; } = null!;

	public string?[] ProductTags { get; set; } = null!;

	public string? ImageUrl { get; set; }	
}
