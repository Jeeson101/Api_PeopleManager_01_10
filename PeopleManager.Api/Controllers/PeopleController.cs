using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleManager.Dto.Requests;
using PeopleManager.Model;
using PeopleManager.Services;

namespace PeopleManager.Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class PeopleController(PersonService personService) : ControllerBase
	{
		private readonly PersonService _personService = personService;


		//Find (more) GET
		[HttpGet]
		public async Task<IActionResult> Find()
		{
			var people = await _personService.Find();
			return Ok(people);
		}

		//Get (one) GET
		[HttpGet("id:int")]
		public async Task<IActionResult> Get(int id)
		{
			var person = await _personService.Get(id);
			return Ok(person);
		}

		//Create POST
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] PersonRequest person)
		{
			var createdPerson = await _personService.Create(person);
			return Ok();
		}

		//Update PUT
		[HttpPut]
		public async Task<IActionResult> Update([FromRoute] int id ,[FromBody] PersonRequest person)
		{
			var updatedPerson = await _personService.Update(id, person);
			return Ok();
		}

		//Delete DELETE
		[HttpDelete("id:int")]
		public async Task<IActionResult> Delete(int id)
		{
			await _personService.Delete(id);
			return Ok();
		}
	}
}
