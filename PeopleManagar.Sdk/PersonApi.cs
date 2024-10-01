using PeopleManager.Abstractions;
using PeopleManager.Api.Model;
using PeopleManager.Dto.Requests;
using PeopleManager.Dto.Results;

namespace PeopleManagar.Sdk
{
	public class PersonApi : IPersonService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public PersonApi(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IList<PersonResult>> Find()
		{
			var httpClient = _httpClientFactory.CreateClient(ApiRoutes.Name);
			var route = ApiRoutes.Person.Find;
			var result = await httpClient.GetAsync(route);
			result.EnsureSuccessStatusCode();
			return await result.Content.ReadAsAsync<IList<PersonResult>>();
		}

		public async Task<PersonResult?> Get(int id)
		{
			var httpClient = _httpClientFactory.CreateClient(ApiRoutes.Name);
			var route = ApiRoutes.Person.Get.Replace("{id}", id.ToString());
			var result = await httpClient.GetAsync(route);
			result.EnsureSuccessStatusCode();
			return await result.Content.ReadAsAsync<PersonResult>();
		}

		public async Task<PersonResult?> Create(PersonRequest request)
		{
			var httpClient = _httpClientFactory.CreateClient(ApiRoutes.Name);
			var route = ApiRoutes.Person.Create;
			var result = await httpClient.PostAsJsonAsync(route, request);
			result.EnsureSuccessStatusCode();
			return await result.Content.ReadAsAsync<PersonResult>();
		}

		public async Task<PersonResult?> Update(int id, PersonRequest request)
		{
			var httpClient = _httpClientFactory.CreateClient(ApiRoutes.Name);
			var route = ApiRoutes.Person.Update.Replace("{id}", id.ToString());
			var result = await httpClient.PutAsJsonAsync(route, request);
			result.EnsureSuccessStatusCode();
			return await result.Content.ReadAsAsync<PersonResult>();
		}

		public async Task Delete(int id)
		{
			var httpClient = _httpClientFactory.CreateClient(ApiRoutes.Name);
			var route = ApiRoutes.Person.Delete.Replace("{id}", id.ToString());
			var result = await httpClient.DeleteAsync(route);
			result.EnsureSuccessStatusCode();
		}
	}
}
