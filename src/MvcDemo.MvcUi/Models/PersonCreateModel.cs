namespace People.MvcUi.Models;

public class PersonCreateModel : PersonBaseModel
{
	public PersonCreateModel()
	{
		base.Id = Guid.NewGuid();
	}
}
