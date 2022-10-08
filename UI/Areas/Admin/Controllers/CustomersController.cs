using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Common.Enums;

namespace UI.Areas.Admin.Controllers
{
	[Area("Admin")]
    public class CustomersController : BaseController
    {
	    private readonly ILogger<CustomersController> _logger;

	    public CustomersController(ILogger<CustomersController> logger)
	    {
		    _logger = logger;
	    }

	    public async Task<IActionResult> Index()
	    {
		    return View();
	    }
    }
}
