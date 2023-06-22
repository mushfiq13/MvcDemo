using People.Domain.Models;
using People.Persistence.UnitOfWorks;

namespace People.Persistence.Services;

public class PeopleServices : IPeopleServices
{
	IPeopleUnitOfWork _unitOfWork;

	public PeopleServices(IPeopleUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task AddAsync(Person student)
	{
		await _unitOfWork.People.AddAsync(student);
		await _unitOfWork.SaveAsync();
	}

	public async Task<IEnumerable<Person>> GetAllAsync()
	{
		return await _unitOfWork.People.GetAsync();
	}

	public async Task<Person> GetByIdAsync(Guid id)
	{
		return await _unitOfWork.People.GetById(id);
	}

	public async Task RemoveAsync(Guid id)
	{
		await _unitOfWork.People.RemoveAsync(id);
		await _unitOfWork.SaveAsync();
	}

	public async Task UpdateAsync(Person student)
	{
		await _unitOfWork.People.UpdateAsync(student);
		await _unitOfWork.SaveAsync();
	}
}
