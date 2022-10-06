using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class User : BaseUser
    {
		public int? CityId { get; set; }

		[ForeignKey("CityId")]
	    public City City { get; set; }

	    public List<Vendor> Vendors { get; set; }
    }
}
