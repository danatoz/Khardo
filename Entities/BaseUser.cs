using Entities.Base;

namespace Entities
{
	public class BaseUser : IdentityUser
	{
		public string LastName { get; set; }

		public string FirstName { get; set; }

		public string MiddleName { get; set; }

	}
}
