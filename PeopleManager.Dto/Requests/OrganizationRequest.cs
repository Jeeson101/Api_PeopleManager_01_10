using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManager.Dto.Requests
{
	public class OrganizationRequest
	{
		[Required]
		public required string name { get; set; }

		public string? description { get; set; }
	}
}
