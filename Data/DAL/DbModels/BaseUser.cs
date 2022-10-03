using Common.Enums;

namespace DAL.DbModels
{
    public class BaseUser : Entity
    {
	    public string LastName { get; set; }
	    public string FirstName { get; set; }
	    public string MiddleName { get; set; }
	    public string MobilePhone { get; set; }
	    public string Email { get; set; }
	    public string Login { get; set; }
	    public string Password { get; set; }
	    public int Role { get; set; }
	    public bool IsBlocked { get; set; }
	}
}
