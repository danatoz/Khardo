using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UI.Areas.Public.Controllers
{
	[Area("Public")]
	public class HomeController : BaseController
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[AllowAnonymous]
		public async Task<IActionResult> Catalog()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public async Task<IActionResult> Find(string query)
		{
			return Ok();
		}

		public async Task<IActionResult> TypeaheadQuery(string query)
		{
			var bl = new ProductTemplateBL();
			var products = await bl.GetAsync(item => item.Name.StartsWith(query) || item.NormalizedVendorCode.StartsWith(query));
			return Json(products.Select(item =>
				new
				{
					item.Id,
					item.VendorCode,
					item.Name,
					item.Active
				}));
		}

		public async Task<IActionResult> TypeaheadPrefetch()
		{
			var bl = new ProductTemplateBL();
			var products = await bl.GetAsync();
			return Json(products.Select(item => 
				new
				{
					item.Id,
					item.Name,
					item.Active
				}));
		}

	}
}
