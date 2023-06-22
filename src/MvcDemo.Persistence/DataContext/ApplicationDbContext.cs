using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using People.Domain.Models;

namespace People.Persistence.DataContext;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Person>()
			.Property(p => p.ContactInfo)
			.HasConversion(
				value => JsonConvert.SerializeObject(value),
				value => JsonConvert.DeserializeObject<ContactInfo>(value)
			);
		modelBuilder.Entity<Person>()
			.Property(p => p.Name)
			.HasConversion(
				value => JsonConvert.SerializeObject(value),
				value => JsonConvert.DeserializeObject<PersonName>(value)
			);

		base.OnModelCreating(modelBuilder);
	}

	public DbSet<Person> People { get; set; }
}
