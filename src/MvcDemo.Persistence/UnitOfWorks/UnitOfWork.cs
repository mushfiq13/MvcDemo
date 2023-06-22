using Microsoft.EntityFrameworkCore;
using People.Domain.UnitOfWorks;
using People.Persistence.DataContext;

namespace People.Persistence.UnitOfWorks;

public abstract class UnitOfWork : IUnitOfWork
{
	private readonly DbContext _context;

	public UnitOfWork(IApplicationDbContext context)
	{
		_context = (context as DbContext)!;
	}

	public async Task SaveAsync() => await (_context?.SaveChangesAsync())!;
}
