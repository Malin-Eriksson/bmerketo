using bmerketo.Models.Entities;
using Microsoft.EntityFrameworkCore;
using static bmerketo.Models.Entities.ProductEntity;

namespace bmerketo.Contexts;

public class ProductContext : DbContext
{

	public ProductContext(DbContextOptions<ProductContext> options) : base(options)
	{
	}

	public DbSet<ProductEntity> Products { get; set; }
	public DbSet<ProductCategoryEntity> ProductCategories { get; set; }

}
