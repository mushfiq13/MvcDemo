using People.Persistence.DataContext;
using People.Persistence.Repositories;

namespace People.Persistence.UnitOfWorks;

public class PeopleUnitOfWork : UnitOfWork, IPeopleUnitOfWork
{
	public IPeopleRepository People { get; set; }

	public PeopleUnitOfWork(IApplicationDbContext context, IPeopleRepository repository)
		: base(context)
	{
		People = repository;
	}
}
