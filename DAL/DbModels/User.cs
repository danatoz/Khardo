using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DAL.DbModels
{
    public class User : IdentityUser
    {
	    public int CityId { get; set; }
		[ForeignKey("CityId")]
	    public City City { get; set; }
    }
}
