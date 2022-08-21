using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UI.Models;
using UI.Models.ViewModels;

namespace UI.Areas.Public.Controllers
{
	[AllowAnonymous]
	public class NewsController : BaseController
    {
		private readonly ILogger<NewsController> _logger;
		private readonly ApplicationDbContext _context;

		public NewsController(ILogger<NewsController> logger, ApplicationDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		public async Task<IActionResult> Index(int page = 1)
		{
			const int objectsPerPage = 20;
			var startIndex = (page - 1) * objectsPerPage;
			var source = _context.News;
			var count = await source.CountAsync();
			var items = await source.Skip(startIndex).Take(objectsPerPage).ToListAsync();

			var viewModel = new SearchResultViewModel<NewsModel>(
				NewsModel.ConvertListFromDal(items), count, startIndex, 20, objectsPerPage);
			return View(viewModel);
		}

		public async Task<IActionResult> Details(int id)
		{
			return Content("");
		}
	}
}
