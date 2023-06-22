using Autofac;
using Autofac.Extensions.DependencyInjection;
using People.MvcUi;
using People.MvcUi.Models;
using People.Persistence.DataContext.Extensions;
using People.Persistence.Repositories;
using People.Persistence.Services;
using People.Persistence.UnitOfWorks;


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<Autofac.ContainerBuilder>(builder =>
{
	builder.RegisterType<PeopleUnitOfWork>()
		.As<IPeopleUnitOfWork>()
		.InstancePerLifetimeScope();
	builder.RegisterType<PeopleRepository>()
		.As<IPeopleRepository>()
		.InstancePerLifetimeScope();
	builder.RegisterType<PeopleServices>()
		.As<IPeopleServices>()
		.InstancePerLifetimeScope();
	builder.RegisterType<PersonCreateModel>()
		.AsSelf()
		.InstancePerLifetimeScope();
	builder.RegisterType<PersonUpdateModel>()
		.AsSelf()
		.InstancePerLifetimeScope();
});

builder.Services.AddControllersWithViews();
builder.Services.AddApplicationDbContext(
	 builder.Configuration["ConnectionStrings:DefaultConnection"]!);
builder.Services.AddAutoMapper(typeof(Profiles));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
