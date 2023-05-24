using bmerketo.Contexts;
using bmerketo.Models.Entities;

namespace bmerketo.Repositories;

public class AddressRepo : IdentityRepo<AddressEntity>
{
	public AddressRepo(IdentityContext context) : base(context)
	{
	}
}
