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
	public class BasketController : BaseController
    {
	    private readonly ILogger<BaseController> _logger;

	    public BasketController(ILogger<BaseController> logger)
	    {
		    _logger = logger;
	    }

	    public async Task<IActionResult> Index()
	    {
		    var parts = new List<string>();

		    return View();
	    }
    }
}
