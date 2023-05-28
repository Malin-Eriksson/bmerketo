using bmerketo.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace bmerketo.Repositories;

public abstract class IdentityRepo<TEntity> where TEntity : class
{
	private readonly IdentityContext _context;

	public IdentityRepo(IdentityContext context)
	{
		_context = context;
	}

	public virtual async Task<TEntity> AddAsync(TEntity entity)
	{
		try
		{
			_context.Set<TEntity>().Add(entity);
			await _context.SaveChangesAsync();

			return entity;
		}
		catch (Exception ex) { Debug.WriteLine(ex.Message); }
			return null!;
	}


	public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
	{
		try
		{
			var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
			if (entity != null)
				return entity!;
		}
		catch (Exception ex) { Debug.WriteLine(ex.Message); }
		return null!;

	}







}
