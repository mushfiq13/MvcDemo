using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace People.Persistence.DataContext.Extensions;

public static class ServiceProviderExtension
{
	public static void AddApplicationDbContext(this IServiceCollection services, string connectionString)
	{
		services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(ctxBuilder =>
		{
			ctxBuilder.EnableSensitiveDataLogging();
			ctxBuilder.UseSqlServer(connectionString, serverOpt =>
			{
				serverOpt.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName!);
			});
			ctxBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
		});
	}
}
