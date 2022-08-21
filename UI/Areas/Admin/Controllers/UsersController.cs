﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(AuthenticationSchemes = nameof(AuthScheme.Admin))]
	public class UsersController : BaseController
    {
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		public UsersController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
		{
			_logger = logger;
			_context = context;
			_userManager = userManager;
			_signInManager = signInManager;
		}

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
				var result =
					await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, false);

				if (result.Succeeded)
				{
					if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
					{
						await Authenticate(model.Login);
						//await _signInManager.SignInAsync(user, false, nameof(AuthScheme.Admin));
						return RedirectToAction("Index", "Home", new { Area = "Admin" });
					}
					else
					{
						return RedirectToAction("Index", "Home", new { Area = "Admin" });
					}
				}
			}

			ModelState.AddModelError("", "Неправильный логин и (или) пароль");

			return RedirectToAction("Login", "Home", new { Area = "Admin" });
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(nameof(AuthScheme.Admin));
			return RedirectToAction("Index", "Home", new { Area = "Public" });
		}

		private async Task Authenticate(string userName)
		{
			// создаем один claim
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
			};
			// создаем объект ClaimsIdentity
			ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
			// установка аутентификационных куки
			await HttpContext.SignInAsync(nameof(AuthScheme.Admin), new ClaimsPrincipal(id));
		}
	}
}