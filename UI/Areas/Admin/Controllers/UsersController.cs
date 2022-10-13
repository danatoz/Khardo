using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog.Common;
using Common.Enums;
using UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using UI.Other;
using Entities;
using UI.Models.ViewModels;


namespace UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	//[Authorize(Roles = nameof(UserRole.Admin))]
	public class UsersController : BaseController
	{
		private readonly ILogger<HomeController> _logger;
		private readonly SignInManager<User> _signInManager;
		private readonly UserManager<User> _userManager;

		public UsersController(ILogger<HomeController> logger, SignInManager<User> signInManager, UserManager<User> userManager)
		{
			_logger = logger;
			_signInManager = signInManager;
			_userManager = userManager;
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
				var result =
					await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home", new { Area = "Admin" });
				}
			}
			TempData[OperationResultType.Error.ToString()] = "Неверный логин и (или) пароль";

			return RedirectToAction("Login", "Users", new { Area = "Admin" });
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home", new { Area = "Public" });
		}
	}
}
