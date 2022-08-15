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
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;
		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			_logger = logger;
			_context = context;
			_userManager = userManager;
			_signInManager = signInManager;
		}

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
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginModel model)
		{

			if (ModelState.IsValid)
			{
				var user = _context.Users.FirstOrDefaultAsync(item => item.UserName == model.Login).Result;
				var result =
					await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, false);

				if (result.Succeeded)
				{
					if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
					{
						return Redirect(model.ReturnUrl);
					}
					else
					{
						return RedirectToAction("Index", "Home");
					}
				}
			}

			ModelState.AddModelError("", "Неправильный логин и (или) пароль");

			return RedirectToAction("Index", "Home", new { Area = "Admin" });
		}

		public async Task<IActionResult> Logout()
		{

			return RedirectToAction("Index", "Home", new { Area = "Public" });
		}
	}
}
