using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PeopleManager.Model
{
    public class Person
    {
        public int Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public string? Email { get; set; }

        //Optional
        public int? OrganizationId { get; set; }
        public Organization? Organization { get; set; }
    }
}
