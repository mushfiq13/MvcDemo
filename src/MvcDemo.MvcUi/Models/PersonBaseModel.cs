namespace People.MvcUi.Models;

public abstract class PersonBaseModel
{
	public Guid Id { get; set; }
	public PersonNameModel Name { get; set; }
	public PersonContactModel Contact { get; set; }
}
