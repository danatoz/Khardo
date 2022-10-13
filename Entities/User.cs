using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class User : BaseUser
	{
		[DisplayName("Контактное лицо")]
		public string ContactPerson { get; set; }

		[DisplayName("Наименование организации")]
		public string NameOrganization { get; set; }

		[DisplayName("Рейтинг")]
		public int? Rating { get; set; }

		[DisplayName("Ответственный менеджер")]
		public string ResponsibleId { get; set; }

		[DisplayName("ИНН")]
		public string ITN { get; set; }

		[DisplayName("БИК")]
		public string BIC { get; set; }

		[DisplayName("Физический адрес")]
		public string PhysicalAdress { get; set; }

		[DisplayName("Юредический адрес")]
		public string LegalAddress { get; set; }

		[ForeignKey("ResponsibleId")]
		public User Responsible { get; set; }

		[DisplayName("Город")]
		public Guid? CityId { get; set; }

		[ForeignKey("CityId")]
		public City City { get; set; }

		public List<User> Vendors { get; set; }

		public List<Order> Orders { get; set; }

		public List<PriceList> PriceLists { get; set; }
	}
}
