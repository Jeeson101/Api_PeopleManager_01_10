using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManager.Dto.Results
{
	public class PersonResult
	{
		public int Id { get; set; }
		public string Fullname { get; set; }
		public string? Email { get; set; }
		public int? OrganizationId { get; set; }

		public string? OrganizationName { get; set; }
	}
}
