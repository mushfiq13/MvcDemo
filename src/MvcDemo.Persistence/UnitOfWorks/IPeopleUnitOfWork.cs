using People.Domain.UnitOfWorks;
using People.Persistence.Repositories;

namespace People.Persistence.UnitOfWorks;

public interface IPeopleUnitOfWork : IUnitOfWork
{
	IPeopleRepository People { get; set; }
}