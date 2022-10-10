using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UI.Models;
using UI.Models.ViewModels;
using UI.Models.ViewModels.FilterModel;

namespace UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "ADMIN")]
	public class ProductsController : BaseController
    {
		private readonly ILogger<ProductsController> _logger;
		private readonly ApplicationDbContext _context;

		public ProductsController(ILogger<ProductsController> logger, ApplicationDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		public async Task<IActionResult> Index(ProductFilterModel filter, int page = 1)
		{
			const int objectsPerPage = 30;
			var startIndex = (page - 1) * objectsPerPage;
			var source = _context.Products.Where(item => item.Active);
			var count = await source.CountAsync();
			var items = await source.Skip(startIndex).Take(objectsPerPage).ToListAsync();

			var viewModel = new SearchResultViewModel<ProductModel, ProductFilterModel>(ProductModel.ConvertListFromDal(items), filter, count, 1, 1, objectsPerPage);
			return View(viewModel);
		}

		public async Task<IActionResult> Update(int? id)
		{
			//var viewModel = ProductModel.ConvertFromDal(
			//	await _context.Products.FirstOrDefaultAsync(item => item.Id == id)) ?? new ProductModel();

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Update(ProductModel model)
		{
			//if (!ModelState.IsValid)
			//	return View(model);

			//_context.Products.Update(ProductModel.ConvertToDal(model));
			//await _context.SaveChangesAsync();

			return RedirectToAction("Index", "Products", new { Area = "Admin" });
		}

		public async Task<IActionResult> Delete(Guid id)
		{
			try
			{
				var model = await _context.Products.FirstOrDefaultAsync(item => item.Id == id);
				model.Active = false;
				_context.Products.Update(model);
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
