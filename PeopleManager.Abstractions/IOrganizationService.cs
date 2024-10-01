using PeopleManager.Dto.Requests;
using PeopleManager.Dto.Results;

namespace PeopleManager.Abstractions
{
	public interface IOrganizationService
	{
		Task<IList<OrganizationResult>> Find();
		Task<OrganizationResult?> Get(int id);
		Task<OrganizationResult?> Create(OrganizationRequest request);
		Task<OrganizationResult?> Update(int id, OrganizationRequest request);
		Task Delete(int id);
	}
}
