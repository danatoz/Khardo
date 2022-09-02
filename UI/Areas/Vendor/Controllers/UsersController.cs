using System;
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
using Common.Enums;
using UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using UI.Other;

namespace UI.Areas.Vendor.Controllers
{
	[Area("Vendor")]
	[Authorize(AuthenticationSchemes = nameof(AuthScheme.Vendor))]
	public class UsersController : BaseController
    {
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;

		public UsersController(ILogger<HomeController> logger, ApplicationDbContext context)
		{
			_logger = logger;
			_context = context;
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
				var result = _context.Vendors.Any(item => 
					item.Login == model.Login && 
					item.Password == Helpers.GetPasswordHash(model.Password));

				if (result)
				{
					if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
					{
						await Authenticate(model.Login);
						return RedirectToAction("Index", "Home", new { Area = "Vendor" });
					}
					else
					{
						return RedirectToAction("Index", "Home", new { Area = "Vendor" });
					}
				}
			}

			TempData[OperationResultType.Error.ToString()] = "Неправильный логин и (или) пароль";

			return RedirectToAction("Login", "Home", new { Area = "Vendor" });
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(nameof(AuthScheme.Vendor));
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
			var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
			// установка аутентификационных куки
			await HttpContext.SignInAsync(nameof(AuthScheme.Vendor), new ClaimsPrincipal(id));
		}
	}
}
