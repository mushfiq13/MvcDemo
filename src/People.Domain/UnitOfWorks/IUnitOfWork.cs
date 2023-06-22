namespace People.Domain.UnitOfWorks;

public interface IUnitOfWork
{
	Task SaveAsync();
}