using bmerketo.Contexts;
using bmerketo.Models.Entities;

namespace bmerketo.Repositories;

public class UserRepo : IdentityRepo<UserEntity>
{
	public UserRepo(IdentityContext context) : base(context)
	{
	}
}
