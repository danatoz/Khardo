using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BL;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.InMemory.Query.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Logging;
using UI.Models.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace UI.Areas.Public.Controllers
{
	[Area("Public")]
	public class ProductsController : BaseController
	{
		private readonly ILogger<ProductsController> _logger;

		public ProductsController(ILogger<ProductsController> logger)
		{
			_logger = logger;
		}

		public async Task<IActionResult> Details(string query)
		{
			if (string.IsNullOrEmpty(query)) return NotFound();

			var productTemplate = await new ProductTemplateBL().GetAsync(
				filter: item => item.NormalizedVendorCode.Contains(query.CleanVendorCode()) || item.Name.Contains(query),
				pt => pt.Manufacturer, pt => pt.Photos);

			var productModel = await new ProductBL().GetAsync(item =>
				item.ProductTemplateId == productTemplate.FirstOrDefault().Id);

			var viewModel = new ProductViewModel
			{
				ProductModels = ProductModel.ConvertListFromDal(productModel),
				ProductTemplateModel = ProductTemplateModel.ConvertToModel(productTemplate.FirstOrDefault())
			};

			return View(viewModel);
		}
	}
}
