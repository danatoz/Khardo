using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class User : BaseUser
	{
		public string ContactPerson { get; set; }

		public string NameOrganization { get; set; }

		public int? Rating { get; set; }

		public string? ResponsibleId { get; set; }

		public string ITN { get; set; }

		public string BIC { get; set; }

		public string PhysicalAdress { get; set; }

		public string LegalAddress { get; set; }

		[ForeignKey("ResponsibleId")]
		public User? Responsible { get; set; }

		public int? CityId { get; set; }

		[ForeignKey("CityId")]
		public City? City { get; set; }

		[NotMapped]
		public List<User>? Vendors { get; set; }

		public List<Order>? Orders { get; set; }

		public List<Product>? Products { get; set; }
	}
}
