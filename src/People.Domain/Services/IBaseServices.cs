namespace People.Domain.Services;

public interface IBaseServices<TEntity, TKey>
	where TEntity : class
{
	Task AddAsync(TEntity item);
	Task RemoveAsync(Guid id);
	Task UpdateAsync(TEntity item);

	Task<IEnumerable<TEntity>> GetAllAsync();
	Task<TEntity> GetByIdAsync(Guid id);
}
