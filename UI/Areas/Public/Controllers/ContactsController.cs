using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UI.Areas.Public.Controllers
{
	[Area("Public")]
	public class ContactsController : BaseController
    {
	    private readonly ILogger<ContactsController> _logger;

	    public ContactsController(ILogger<ContactsController> logger)
	    {
		    _logger = logger;
	    }

	    public async Task<IActionResult> Index()
	    {
		    return View();
	    }
	}
}
