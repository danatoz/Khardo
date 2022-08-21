using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UI.Areas.Public.Controllers
{
	[AllowAnonymous]
	public class NewsController : BaseController
    {
		private readonly ILogger<NewsController> _logger;

		public NewsController(ILogger<NewsController> logger)
		{
			_logger = logger;
		}

		public async Task<IActionResult> Index()
		{
			return View();
		}

		public async Task<IActionResult> Details(int id)
		{
			return Content("");
		}
	}
}
