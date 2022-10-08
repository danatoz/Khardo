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

namespace UI.Areas.Vendor.Controllers
{
	[Area("Vendor")]
	public class UsersController : BaseController
    {
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;
		private readonly SignInManager<User> _signInManager;

		public UsersController(ILogger<HomeController> logger, ApplicationDbContext context, SignInManager<User> signInManager)
		{
			_logger = logger;
			_context = context;
			_signInManager = signInManager;
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult Login(string returnUrl)
		{
			return View(new LoginModel { ReturnUrl = returnUrl });
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[AllowAnonymous]
		public async Task<IActionResult> Login(LoginModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home", new { Area = "Vendor" });
				}
			}

			TempData[OperationResultType.Error.ToString()] = "Неверный логин и (или) пароль";

			return RedirectToAction("Login", "Home", new { Area = "Vendor" });
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
