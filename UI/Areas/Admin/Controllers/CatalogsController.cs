using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL;
using DAL.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UI.Areas.Public.Controllers;
using Common.Enums;
using UI.Models;
using UI.Models.ViewModels;
using Hierarchy;
using Newtonsoft.Json;
using UI.TreeModel;
using Microsoft.VisualStudio.GraphModel;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

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
			var test = items.OrderBy(i => i.Id).ThenBy(i => i.ParentId).ToList();
			await InitViewBag(items);

			var treeNodes = CatalogModel.ConvetForTreeList(items)
				.OrderBy(i => i.Id)
				.ToHierarchy(t => t.Id, t => t.ParentId);





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

		private async Task InitViewBag(List<Catalog> items)
		{
			var tree = items.Hierarchize(1, f => f.Id, f => f.ParentId);

			ViewBag.Tree = tree;
		}
	}
}
