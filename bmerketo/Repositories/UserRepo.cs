using bmerketo.Contexts;
using bmerketo.Models.Entities;

namespace bmerketo.Repositories;

public class UserRepo : Repo<UserEntity>
{
	public UserRepo(DataContext context) : base(context)
	{
	}
}
