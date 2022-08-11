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
    public class PaymentsController : BaseController
    {
		private readonly ILogger<PaymentsController> _logger;

		public PaymentsController(ILogger<PaymentsController> logger)
		{
			_logger = logger;
		}

		public async Task<IActionResult> Index()
		{
			return View();
		}
	}
}
