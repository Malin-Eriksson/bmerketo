using bmerketo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace bmerketo.Contexts;

public class ProductContext : DbContext
{

	public ProductContext(DbContextOptions<ProductContext> options) : base(options)
	{
	}

	public DbSet<ProductEntity> Products { get; set; }

}
