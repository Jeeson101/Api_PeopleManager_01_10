using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleManager.Dto.Requests;
using PeopleManager.Model;
using PeopleManager.Services;

namespace PeopleManager.Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class OrganizationController(OrganizationService organizationService) : ControllerBase
	{
		private readonly OrganizationService _organizationService = organizationService;


		[HttpGet]
		public async Task<IActionResult> Find()
		{
			var organizations = await _organizationService.Find();
			return Ok(organizations);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> Get(int id)
		{
			var organization = await _organizationService.Get(id);
			return Ok(organization);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] OrganizationRequest organization)
		{
			var createdOrganization = await _organizationService.Create(organization);
			return Ok(createdOrganization);
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromRoute] int id,[FromBody] OrganizationRequest organization)
		{
			var updatedOrganization = await _organizationService.Update(id, organization);
			return Ok(updatedOrganization);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _organizationService.Delete(id);
			return Ok();
		}
	}
}
