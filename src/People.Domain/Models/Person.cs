namespace People.Domain.Models;

public class Person
{
	public Guid Id { get; set; }
	public PersonName Name { get; set; }
	public ContactInfo ContactInfo { get; set; }
}
