using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DbModels
{
    public class Vendor : BaseUser
    {
	    public int Rating { get; set; }
	    public int ResponsibleId { get; set; }
	    [ForeignKey("ResponsibleId")]
		public User Responsible { get; set; }

		public string ITN { get; set; }
		public string BIC { get; set; }
		public string PhysicalAdress { get; set; }
		public string LegalAddress { get; set; }
    }
}
