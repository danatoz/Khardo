using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UI.Areas.Public.Controllers;
using UI.Enums;
using UI.Models;
using UI.Models.ViewModels;

namespace UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(AuthenticationSchemes = nameof(AuthScheme.Admin))]
	public class CatalogsController : BaseController
    {
		private readonly ILogger<CatalogsController> _logger;
		private readonly ApplicationDbContext _context;

		public CatalogsController(ILogger<CatalogsController> logger, ApplicationDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		public async Task<IActionResult> Index(int page = 1)
		{
			const int objectsPerPage = 20;
			var startIndex = (page - 1) * objectsPerPage;
			var source = _context.Catalogs;
			var count = await source.CountAsync();
			var items = await source.Skip(startIndex).Take(objectsPerPage).ToListAsync();
			var viewModel = new SearchResultViewModel<CatalogModel>(CatalogModel.ConvertListFromDal(items), count, 1, 1, objectsPerPage);
			return View(viewModel);
		}

		public async Task<IActionResult> Update(int id)
		{
			return View();
		}

		public async Task<IActionResult> Update(CatalogModel model)
		{
			return View();
		}
	}
}
