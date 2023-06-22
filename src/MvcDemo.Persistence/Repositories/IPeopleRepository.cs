using People.Domain.Models;
using People.Domain.Repositories;

namespace People.Persistence.Repositories;

public interface IPeopleRepository : IRepository<Person, Guid>
{
}