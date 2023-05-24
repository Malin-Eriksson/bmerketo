using bmerketo.Contexts;
using bmerketo.Models.Entities;

namespace bmerketo.Repositories;

public class ContactFormRepo : Repo<ContactFormEntity>
{
	public ContactFormRepo(DataContext context) : base(context)
	{
	}
}
