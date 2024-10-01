using Microsoft.Extensions.DependencyInjection;
using PeopleManager.Abstractions;
using PeopleManager.Api.Model;

namespace PeopleManagar.Sdk.Extensions
{
	public static class ServiceExtensions
	{
		public static void AddPeopleManagerApi(this IServiceCollection services, string baseUrl)
		{
			services.AddPeopleManagerApi(new Uri(baseUrl));
		}

		public static void AddPeopleManagerApi(this IServiceCollection services, Uri baseUri)
		{
			services.AddHttpClient(ApiRoutes.Name, (sp, c) =>
			{
				c.BaseAddress = baseUri;
			});

			//Add the Services
			services.AddScoped<IPersonService, PersonApi>();
			services.AddScoped<IOrganizationService, OrganizationApi>();
		}
	}
}
