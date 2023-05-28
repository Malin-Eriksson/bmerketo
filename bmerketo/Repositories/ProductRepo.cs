using bmerketo.Contexts;
using bmerketo.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace bmerketo.Repositories
{
	public class ProductRepo : Repo<ProductEntity>
	{
		private readonly DataContext _context;
		public ProductRepo(DataContext context) : base(context) 
		{
			_context = context;
		}

		public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
		{
			var products = await _context.Products.Include(x => x.ProductTags).ThenInclude(x => x.Tag).ToListAsync();
			return products;
		}

        public override async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> expression)
		{
			var product = await _context.Products.Include(x => x.ProductTags).ThenInclude(x => x.Tag).FirstOrDefaultAsync(expression);
			return product!;
		}
	}
}
