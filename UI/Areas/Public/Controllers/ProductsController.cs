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
	public class ProductsController : BaseController
    {
	    private readonly ILogger<ProductsController> _logger;

	    public ProductsController(ILogger<ProductsController> logger)
	    {
		    _logger = logger;
	    }

	    public async Task<IActionResult> Details(string alias)
	    {

		    return View();
	    }
    }
}
