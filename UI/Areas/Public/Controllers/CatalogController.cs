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
	public class CatalogController : BaseController
    {
		private readonly ILogger<CatalogController> _logger;

		public CatalogController(ILogger<CatalogController> logger)
		{
			_logger = logger;
		}

		public async Task<IActionResult> Index()
		{
			return View();
		}
	}
}
