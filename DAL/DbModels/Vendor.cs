using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DAL.DbModels
{
    public class Vendor : BaseUser
    {
	    public int Rating { get; set; }
	    [ForeignKey("UserId")]
	    public int ResponsibleId { get; set; }
    }
}
