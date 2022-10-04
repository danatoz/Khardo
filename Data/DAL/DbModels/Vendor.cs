using Entities;

namespace DAL.DbModels
{
	public class Vendor : BaseUser
	{
		public string NameOrganization { get; set; }

		public int Rating { get; set; }

		public int ResponsibleId { get; set; }

		public string ITN { get; set; }

		public string BIC { get; set; }

		public string PhysicalAdress { get; set; }

		public string LegalAddress { get; set; }

		[ForeignKey("ResponsibleId")]
		public User Responsible { get; set; }

		public List<Product> Products { get; set; }
	}
}
