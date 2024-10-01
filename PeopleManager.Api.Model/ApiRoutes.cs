using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManager.Api.Model
{
	public static class ApiRoutes
	{
		public const string Name = "peopleManager";
		private const string Root = "api";

		public static class Person
		{
			public const string Get = Root + "/PeopleManager-person/{id}";
			public const string Find = Root + "/PeopleManager-person";
			public const string Create = Root + "/PeopleManager-person";
			public const string Update = Root + "/PeopleManager-person/{id}";
			public const string Delete = Root + "/PeopleManager-person/{id}";
		}

		public static class Organization
		{
			public const string Get = Root + "/PeopleManager-organization/{id}";
			public const string Find = Root + "/PeopleManager-organization";
			public const string Create = Root + "/PeopleManager-organization";
			public const string Update = Root + "/PeopleManager-organization/{id}";
			public const string Delete = Root + "/PeopleManager-organization/{id}";
		}
	}
}
