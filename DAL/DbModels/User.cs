using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DAL.DbModels
{
    public class User : BaseUser
    {
	    public int Role { get; set; }
		public int? CityId { get; set; }
		[ForeignKey("CityId")]
	    public City City { get; set; }

	    public List<Vendor> Vendors { get; set; }
    }
}
