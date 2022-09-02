using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Models;

namespace UI.Areas.Vendor.Components
{
    public class ResponsibleManager : ViewComponent
    {
	    private readonly ApplicationDbContext _context;
	    public ResponsibleManager(ApplicationDbContext context)
	    {
		    _context = context;
	    }
	    public string Invoke()
	    {
		    
		    var user = User.Identity.Name;
		    var currentVendor = _context.Vendors
			    .Include(item => item.Responsible)
			    .FirstOrDefault(item => item.Login == user);
		    var responsibleManager = UserModel.ConvertFromDal(currentVendor?.Responsible);
		    var result = responsibleManager?.FullName + " звоните по любым вопросам " + responsibleManager?.MobilePhone;
		    return result;
	    }
    }
}
