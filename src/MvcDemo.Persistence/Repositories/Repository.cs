using Microsoft.EntityFrameworkCore;
using People.Domain.Repositories;
using People.Persistence.DataContext;

namespace People.Persistence.Repositories;

public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
	where TEntity : class
{
	protected readonly DbSet<TEntity> _dbSet;

	protected Repository(ApplicationDbContext context)
	{
		_dbSet = context.Set<TEntity>();
	}

	public async Task AddAsync(TEntity entity)
	{
		await _dbSet.AddAsync(entity);
	}

	public async Task RemoveAsync(TKey id)
	{
		var removeableEntity = await GetById(id);

		_dbSet.Remove(removeableEntity);
	}

	public async Task UpdateAsync(TEntity entity)
	{
		await Task.Run(() => _dbSet.Update(entity));
	}

	public virtual async Task<IEnumerable<TEntity>> GetAsync()
	{
		return await _dbSet.ToListAsync();
	}

	public async Task<TEntity> GetById(TKey id)
	{
		return (await _dbSet.FindAsync(id))!;
	}
}
