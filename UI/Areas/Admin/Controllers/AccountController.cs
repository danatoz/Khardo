using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UI.Models.ViewModels;
using UI.Other;

namespace UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AccountController : BaseController
    {
		private readonly ILogger<AccountController> _logger;
		private readonly SignInManager<User> _signInManager;
		private readonly UserManager<User> _userManager;
		private readonly List<string> _roles;

		public AccountController(ILogger<AccountController> logger, SignInManager<User> signInManager, UserManager<User> userManager)
		{
			_logger = logger;
			_signInManager = signInManager;
			_userManager = userManager;
			_roles = new List<string>() { "admin", "manager" };
		}

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
	        return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
	        if (ModelState.IsValid)
	        {
		        var user = await _userManager.FindByNameAsync(model.UserName);
		        var roles = await _userManager.GetRolesAsync(user);
		        if (!roles.Any(item => _roles.Contains(item)))
		        {
					TempData[OperationResultType.Error.ToString()] = "В доступе отказано!";
					return RedirectToAction("Login", "Account", new { Area = "Admin" });
				}

				var result =
			        await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
		        if (result.Succeeded)
		        {
			        return RedirectToAction("Index", "Home", new { Area = "Admin" });
		        }
	        }
	        TempData[OperationResultType.Error.ToString()] = "Неверный логин и (или) пароль";

	        return RedirectToAction("Login", "Account", new { Area = "Admin" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
	        await _signInManager.SignOutAsync();
	        return RedirectToAction("Index", "Home", new { Area = "Public" });
        }

		[HttpGet]
        [Route("/Account/AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
