using PeopleManager.Abstractions;
using PeopleManager.Api.Model;
using PeopleManager.Dto.Requests;
using PeopleManager.Dto.Results;

namespace PeopleManagar.Sdk
{
	public class OrganizationApi : IOrganizationService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public OrganizationApi(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IList<OrganizationResult>> Find()
		{
			var httpClient = _httpClientFactory.CreateClient(ApiRoutes.Name);
			var route = ApiRoutes.Organization.Find;
			var result = await httpClient.GetAsync(route);
			result.EnsureSuccessStatusCode();
			return await result.Content.ReadAsAsync<IList<OrganizationResult>>();
		}

		public async Task<OrganizationResult?> Get(int id)
		{
			var httpClient = _httpClientFactory.CreateClient(ApiRoutes.Name);
			var route = ApiRoutes.Organization.Get.Replace("{id}", id.ToString());
			var result = await httpClient.GetAsync(route);
			result.EnsureSuccessStatusCode();
			return await result.Content.ReadAsAsync<OrganizationResult>();
		}

		public async Task<OrganizationResult?> Create(OrganizationRequest request)
		{
			var httpClient = _httpClientFactory.CreateClient(ApiRoutes.Name);
			var route = ApiRoutes.Organization.Create;
			var result = await httpClient.PostAsJsonAsync(route, request);
			result.EnsureSuccessStatusCode();
			return await result.Content.ReadAsAsync<OrganizationResult>();
		}

		public async Task<OrganizationResult?> Update(int id, OrganizationRequest request)
		{
			var httpClient = _httpClientFactory.CreateClient(ApiRoutes.Name);
			var route = ApiRoutes.Organization.Update.Replace("{id}", id.ToString());
			var result = await httpClient.PutAsJsonAsync(route, request);
			result.EnsureSuccessStatusCode();
			return await result.Content.ReadAsAsync<OrganizationResult>();
		}

		public async Task Delete(int id)
		{
			var httpClient = _httpClientFactory.CreateClient(ApiRoutes.Name);
			var route = ApiRoutes.Organization.Delete.Replace("{id}", id.ToString());
			var result = await httpClient.DeleteAsync(route);
			result.EnsureSuccessStatusCode();
		}
	}
}
