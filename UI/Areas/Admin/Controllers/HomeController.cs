using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UI.Enums;
using UI.Models;

namespace UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(AuthenticationSchemes = nameof(AuthScheme.Admin))]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private ApplicationDbContext _context;
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
		{
			_logger = logger;
			_context = context;
			_userManager = userManager;
			_signInManager = signInManager;
		}
		[AllowAnonymous]
		public IActionResult Index()
		{
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
