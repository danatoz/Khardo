using Common.Enums;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UI.Models.ViewModels.FilterModel;
using UI.Models.ViewModels;
using Entities;
using Microsoft.AspNetCore.Identity;


namespace UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "admin")]
	public class ProductTemplateController : Controller
	{
		private readonly ILogger<ProductTemplateController> _logger;
		private readonly ApplicationDbContext _context;
		private readonly UserManager<User> _userManager;

		public ProductTemplateController(ILogger<ProductTemplateController> logger, ApplicationDbContext context, UserManager<User> userManager)
		{
			_logger = logger;
			_context = context;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index(ProductTemplateFilterModel filter, int page = 1)
		{
			const int objectsPerPage = 30;
			var startIndex = (page - 1) * objectsPerPage;
			IQueryable<ProductTemplate> source = _context.ProductTemplates;
			source = source.Where(item => item.Active);
			var count = await source.CountAsync();
			var items = await source.Skip(startIndex).Take(objectsPerPage).ToListAsync();

			var viewModel = new SearchResultViewModel<ProductTemplateModel, ProductTemplateFilterModel>(ProductTemplateModel.ConvertListFromDal(items), filter, count, 1, 1, objectsPerPage);
			return View(viewModel);
		}

		public async Task<IActionResult> Update(string id)
		{
			//var viewModel = ProductTemplateModel.ConvertFromDal(
			//	await _context.ProductTemplates.FirstOrDefaultAsync(item => item.VendorCode == id)) ?? new ProductTemplateModel();

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Update(ProductTemplateModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			_context.ProductTemplates.Update(ProductTemplateModel.ConvertToDal(model));
			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "Products", new { Area = "Admin" });
		}

		public async Task<IActionResult> Delete(string id)
		{
			try
			{
				var model = await _context.ProductTemplates.FirstOrDefaultAsync(item => item.VendorCode == id);
				model.Active = false;
				_context.ProductTemplates.Update(model);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				_logger.LogError($"{ex}");
			}

			return RedirectToAction("Index", "Products", new { Area = "Admin" });
		}
	}
}
