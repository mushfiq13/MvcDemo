using Microsoft.EntityFrameworkCore;
using People.Domain.Models;

namespace People.Persistence.DataContext
{
	public interface IApplicationDbContext
	{
		DbSet<Person> People { get; set; }
	}
}