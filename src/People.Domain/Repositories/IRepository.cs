namespace People.Domain.Repositories;

public interface IRepository<TEntity, TKey> where TEntity : class
{
	Task AddAsync(TEntity entity);
	Task<IEnumerable<TEntity>> GetAsync();
	Task<TEntity> GetById(TKey id);
	Task RemoveAsync(TKey id);
	Task UpdateAsync(TEntity entity);
}