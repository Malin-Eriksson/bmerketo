using bmerketo.Contexts;
using bmerketo.Models.Entities;
using static bmerketo.Models.Entities.ProductEntity;

namespace bmerketo.Repositories;

public class TagRepo : Repo<TagEntity>
{
	public TagRepo(DataContext context) : base(context)
	{
	}
}
