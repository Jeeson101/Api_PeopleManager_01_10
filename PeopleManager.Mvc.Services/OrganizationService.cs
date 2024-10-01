using PeopleManager.Abstractions;
using PeopleManager.Dto.Requests;
using PeopleManager.Dto.Results;

namespace PeopleManager.Services
{
	public class OrganizationService(PeopleManagerDbContext dbContext) : IOrganizationService
	{
		private readonly PeopleManagerDbContext _dbContext = dbContext;

		//Find
		public async Task<IList<OrganizationResult>> Find()
		{
			return await _dbContext.Organizations
				.Select(o => new OrganizationResult
				{
					Id = o.Id,
					Name = o.Name,
					Description = o.Description,
					NumberOfMembers = o.Members.Count
				})
				.ToListAsync();
		}

		//Get (by id)
		public async Task<OrganizationResult?> Get(int id)
		{
			return await _dbContext.Organizations
				.Select(o => new OrganizationResult
				{
					Id = o.Id,
					Name = o.Name,
					Description = o.Description,
					NumberOfMembers = o.Members.Count
				})
				.FirstOrDefaultAsync(o => o.Id == id);
		}

		//Create
		public async Task<OrganizationResult?> Create(OrganizationRequest request)
		{
			var organization = new Organization
			{
				Name = request.Name,
				Description = request.Description

			};


			_dbContext.Organizations.Add(organization);
			await _dbContext.SaveChangesAsync();

			return await Get(organization.Id);
		}

		//Update
		public async Task<OrganizationResult?> Update(int id, OrganizationRequest request)
		{
			var dbOrganization = await _dbContext.Organizations
				.FirstOrDefaultAsync(o => o.Id == id);

			if (dbOrganization is null)
			{
				return null;
			}

			dbOrganization.Name = request.Name;
			dbOrganization.Description = request.Description;

			await _dbContext.SaveChangesAsync();

			return await Get(id);
		}

		//Delete
		public async Task Delete(int id)
		{
			var organization = await _dbContext.Organizations
				.FirstOrDefaultAsync(o => o.Id == id);

			if (organization is null)
			{
				return;
			}

			_dbContext.Organizations.Remove(organization);
			await _dbContext.SaveChangesAsync();
		}

	}
}
