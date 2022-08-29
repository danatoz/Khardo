using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbModels
{
    public class BaseUser
    {
	    public int Id { get; set; }
	    public string LastName { get; set; }
	    public string FirstName { get; set; }
	    public string MiddleName { get; set; }
	    public string MobilePhone { get; set; }
	    public string Email { get; set; }
	    public string Login { get; set; }
	    public string Password { get; set; }
	}
}
