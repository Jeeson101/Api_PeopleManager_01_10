using PeopleManager.Dto.Requests;
using PeopleManager.Dto.Results;

namespace PeopleManager.Abstractions
{
	public interface IPersonService
	{
		Task<IList<PersonResult>> Find();
		Task<PersonResult?> Get(int id);
		Task<PersonResult?> Create(PersonRequest request);
		Task<PersonResult?> Update(int id, PersonRequest request);
		Task Delete(int id);

	}
}
