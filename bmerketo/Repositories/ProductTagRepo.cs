using bmerketo.Contexts;
using bmerketo.Models.Entities;

namespace bmerketo.Repositories;

public class ProductTagRepo : Repo<ProductTagEntity>
{
	public ProductTagRepo(DataContext context) : base(context)
	{
	}
}
