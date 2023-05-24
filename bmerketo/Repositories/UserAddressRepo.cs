using bmerketo.Contexts;
using bmerketo.Models.Entities;

namespace bmerketo.Repositories;

public class UserAddressRepo : Repo<UserAddressEntity>
{
	public UserAddressRepo(DataContext context) : base(context)
	{
	}
}
