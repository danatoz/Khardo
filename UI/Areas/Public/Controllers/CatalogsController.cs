using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UI.Models;

namespace UI.Areas.Public.Controllers
{
	[Area("Public")]
	public class CatalogsController : BaseController
    {
		private readonly ILogger<CatalogsController> _logger;

		public CatalogsController(ILogger<CatalogsController> logger)
		{
			_logger = logger;
		}

		public async Task<IActionResult> SubCategoryList(string alias, int page = 1)
		{
			var viewModel = new CategoryModel();

			return View(viewModel);
		}
	}
}
