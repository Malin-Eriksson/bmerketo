using bmerketo.Models.Entities;
using Microsoft.EntityFrameworkCore;
using static bmerketo.Models.Entities.ProductEntity;

namespace bmerketo.Contexts;

public class DataContext : DbContext
{

	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}

	public DbSet<ProductEntity> Products { get; set; }
	public DbSet<TagEntity> Tags { get; set; }
	public DbSet<ProductTagEntity> ProductTags { get; set; }

	public DbSet<ContactFormEntity> ContactForm { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		builder.Entity<TagEntity>().HasData(
			new TagEntity { Id = 1, TagName = "new" },
			new TagEntity { Id = 2, TagName = "featured" },
			new TagEntity { Id = 3, TagName = "popular" });
	}
}
