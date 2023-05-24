using bmerketo.Contexts;
using bmerketo.Models.Entities;

namespace bmerketo.Repositories;

public class AddressRepo : Repo<AddressEntity>
{
	public AddressRepo(DataContext context) : base(context)
	{
	}
}
