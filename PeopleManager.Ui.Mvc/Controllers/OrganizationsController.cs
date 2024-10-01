using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleManager.Abstractions;
using PeopleManager.Dto.Requests;
using PeopleManager.Dto.Results;


namespace PeopleManager.Ui.Mvc.Controllers
{
    public class OrganizationsController : Controller
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationsController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var organizations = await _organizationService.Find();
            return View(organizations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrganizationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            _organizationService.Create(request);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var organization = await _organizationService.Get(id);

            if (organization is null)
            {
                return RedirectToAction("Index");
            }


			return View(organization);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, [FromForm] OrganizationResult result)
        {
            var request = new OrganizationRequest
			{
				Name = result.Name,
				Description = result.Description
			};

			if (!ModelState.IsValid)
			{
                return View(result);
            }

            _organizationService.Update(id, request);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var organization = await _organizationService.Get(id);

            return View(organization);
        }

        [HttpPost("/[controller]/Delete/{id:int?}"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _organizationService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
