using Microsoft.AspNetCore.Identity;

namespace DAL.DbModels
{
    public class User : IdentityUser
    {
	    public int CityId { get; set; }
	    public City City { get; set; }
    }
}
