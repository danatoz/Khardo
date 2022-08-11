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
	public class DeliveryController : BaseController
    {
	    private readonly ILogger<DeliveryController> _logger;

	    public DeliveryController(ILogger<DeliveryController> logger)
	    {
		    _logger = logger;
	    }

	    public async Task<IActionResult> Index()
	    {
		    return View();
	    }
	}
}
