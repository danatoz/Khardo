using System.Diagnostics;
using System.Linq;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UI.Models;

namespace UI.Areas.Public.Controllers
{
	[Area("Public")]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			using (var dbContext = new ApplicationDbContext())
			{
				var user = dbContext.Users.Where(item => item.Id == "1");

			}
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
