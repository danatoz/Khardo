using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UI.Areas.Public.Controllers;
using UI.Models;

namespace UI.Areas.Admin.Controllers
{
    public class CatalogsController : BaseController
    {
		private readonly ILogger<CatalogsController> _logger;

		public CatalogsController(ILogger<CatalogsController> logger)
		{
			_logger = logger;
		}

		public async Task<IActionResult> Index()
		{
			return View();
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
