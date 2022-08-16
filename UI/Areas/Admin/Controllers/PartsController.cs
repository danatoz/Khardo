using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UI.Areas.Admin.Controllers
{
    public class PartsController : BaseController
    {
		private readonly ILogger<PartsController> _logger;

		public PartsController(ILogger<PartsController> logger)
		{
			_logger = logger;
		}

		public async Task<IActionResult> Index()
		{
			return View();
		}
	}
}
