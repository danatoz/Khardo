using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL;
using DAL.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog.Common;
using UI.Enums;
using UI.Models;

namespace UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(AuthenticationSchemes = nameof(AuthScheme.Admin))]
	public class UsersController : BaseController
    {
		private readonly ILogger<HomeController> _logger;
		private ApplicationDbContext _context;
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		public UsersController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
		{
			_logger = logger;
			_context = context;
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[AllowAnonymous]
		public async Task<IActionResult> Login(LoginModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(model.Email);
				var password = await _userManager.CheckPasswordAsync(user, model.Password);

				if (password)
				{
					if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
					{
						await _signInManager.SignInAsync(user, false, nameof(AuthScheme.Admin));
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
