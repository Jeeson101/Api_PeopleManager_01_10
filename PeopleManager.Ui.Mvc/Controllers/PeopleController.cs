using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleManager.Abstractions;
using PeopleManager.Dto.Requests;
using PeopleManager.Dto.Results;

namespace PeopleManager.Ui.Mvc.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IOrganizationService _organizationService;

        public PeopleController(
            IPersonService personService,
            IOrganizationService organizationService)
        {
            _personService = personService;
            _organizationService = organizationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var people = await _personService.Find();

            return View(people);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return CreateEditView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PersonRequest request)
        {
            if (!ModelState.IsValid)
            {
                return CreateEditView(request);
            }

            _personService.Create(request);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute]int id)
        {
            var person = await _personService.Get(id);

            if (person is null)
            {
                return RedirectToAction("Index");
            }

            var personRequest = new PersonRequest
            {
	            FirstName = person.FirstName,
	            LastName = person.LastName,
	            Email = person.Email != null ? person.Email : null,
	            OrganizationId = person.OrganizationId,
			};

			return CreateEditView(personRequest);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute]int id, [FromForm]PersonRequest request)
        {

			if (!ModelState.IsValid)
            {
                return CreateEditView(request);
            }

            await _personService.Update(id, request);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var person = await _personService.Get(id);

            return View(person);
        }

        [HttpPost("/[controller]/Delete/{id:int?}"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _personService.Delete(id);

            return RedirectToAction("Index");
        }
        
        private IActionResult CreateEditView(PersonRequest? request = null)
        {
            var organizations = _organizationService.Find();
            ViewBag.Organizations = organizations;
            return View(request);
        }
    }
}
