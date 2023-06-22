using System.Text.Json;
using System.Text.Json.Serialization;
using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using People.Domain.Models;
using People.MvcUi.Models;
using People.Persistence.Services;

namespace People.MvcUi.Controllers;

public class HomeController : Controller
{
	private readonly ILifetimeScope _scope;
	private readonly IMapper _mapper;
	private readonly IPeopleServices _peopleServices;

	public HomeController(ILifetimeScope scope, IMapper mapper, IPeopleServices peopleServices)
	{
		_scope = scope;
		_mapper = mapper;
		_peopleServices = peopleServices;
	}

	public async Task<IActionResult> Index()
	{
		return await Task.Run(View);
	}

	public async Task<JsonResult> GetPeople()
	{
		var data = await _peopleServices.GetAllAsync();
		var options = new JsonSerializerOptions()
		{
			ReferenceHandler = ReferenceHandler.IgnoreCycles
		};

		return Json(new { data }, options);
	}

	public async Task<IActionResult> Create()
	{
		var model = await Task.Run(_scope.Resolve<PersonCreateModel>);

		return View(model);
	}

	[HttpPost, ValidateAntiForgeryToken]
	public async Task<IActionResult> Create(PersonCreateModel model)
	{
		var newStudent = _mapper.Map<Person>(source: model);
		await _peopleServices.AddAsync(newStudent);

		return RedirectToAction("Index");
	}

	[HttpGet]
	public async Task<IActionResult> Delete(Guid id)
	{
		await _peopleServices.RemoveAsync(id);

		return RedirectToAction("Index");
	}

	public async Task<IActionResult> Update(Guid id)
	{
		var person = await _peopleServices.GetByIdAsync(id);
		var model = _mapper.Map<PersonUpdateModel>(person);

		return View(model);
	}

	[HttpPost, ValidateAntiForgeryToken]
	public async Task<IActionResult> Update(PersonUpdateModel model)
	{
		var updatedStudent = _mapper.Map<Person>(source: model);
		await _peopleServices.UpdateAsync(updatedStudent);

		return RedirectToAction("Index");
	}
}