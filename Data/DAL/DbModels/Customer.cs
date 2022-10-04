using Entities;

namespace DAL.DbModels
{
    public class Customer : BaseUser
    {
	    public List<Order> Orders { get; set; }
    }
}
