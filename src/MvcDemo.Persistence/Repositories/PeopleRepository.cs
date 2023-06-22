using People.Domain.Models;
using People.Persistence.DataContext;

namespace People.Persistence.Repositories;

public class PeopleRepository : Repository<Person, Guid>, IPeopleRepository
{
	public PeopleRepository(IApplicationDbContext context)
		: base((ApplicationDbContext)context)
	{
	}
}
