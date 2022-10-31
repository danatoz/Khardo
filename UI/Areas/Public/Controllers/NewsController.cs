using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OfficeOpenXml.ConditionalFormatting;
using UI.Models;
using UI.Models.ViewModels;

namespace UI.Areas.Public.Controllers
{
	[AllowAnonymous]
	[Area("Public")]
	public class NewsController : BaseController
    {
		private readonly ILogger<NewsController> _logger;
		private readonly AppDbContext _context;

		public NewsController(ILogger<NewsController> logger, AppDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		public async Task<IActionResult> Index(int page = 1)
		{
			const int objectsPerPage = 20;
			var startIndex = (page - 1) * objectsPerPage;
			var bl = new NewsBL();
			var source = await bl.GetAsync();
			var count = source.Count();
			var items = source.Skip(startIndex).Take(objectsPerPage).ToList();

			var viewModel = new SearchResultViewModel<NewsModel>(
				NewsModel.ConvertListFromDal(items), count, startIndex, 20, objectsPerPage);
			return View(viewModel);
		}

		public async Task<IActionResult> Details(string id)
		{
			if (string.IsNullOrEmpty(id))
				return NotFound();
			

			var viewModel = NewsModel.ConvertFromDal(await new NewsBL().GetAsync(Guid.Parse(id)));

			return View(viewModel);
		}

		public async Task<IActionResult> GetLastNews()
		{
			var bl = new NewsBL();
			var viewModel = NewsModel.ConvertListFromDal(await bl.GetAsync());
			return Json(new { News = viewModel.Select(item => new
			{
				item.Id,
				item.Title,
				item.Content,
				item.PublicationDate,
			})});
		}
	}
}
