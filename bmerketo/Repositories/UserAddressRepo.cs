using bmerketo.Contexts;
using bmerketo.Models.Entities;

namespace bmerketo.Repositories;

public class UserAddressRepo : IdentityRepo<UserAddressEntity>
{
	public UserAddressRepo(IdentityContext context) : base(context)
	{
	}
}
