using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UI.Enums;

namespace UI.Areas.Public.Controllers
{
	[Area("Public")]
	[Authorize(AuthenticationSchemes = nameof(AuthScheme.Public))]
	public class UsersController : BaseController
	{
		private readonly ILogger<UsersController> _logger;

		public UsersController(ILogger<UsersController> logger)
		{
			_logger = logger;
		}
		public async Task<IActionResult> Login()
		{

			return RedirectToAction("Index", "Home", new { Area = "Public" });
		}

		public async Task<IActionResult> Logout()
		{

			return RedirectToAction("Index", "Home", new { Area = "Public" });
		}
	}
}
