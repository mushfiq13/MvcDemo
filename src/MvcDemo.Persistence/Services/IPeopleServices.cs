using People.Domain.Models;

namespace People.Persistence.Services
{
	public interface IPeopleServices
	{
		Task AddAsync(Person student);
		Task<IEnumerable<Person>> GetAllAsync();
		Task<Person> GetByIdAsync(Guid id);
		Task RemoveAsync(Guid id);
		Task UpdateAsync(Person student);
	}
}