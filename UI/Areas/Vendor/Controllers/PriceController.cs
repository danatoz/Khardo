using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using NLog;
using Tools.RabbitMq;
using UI.Other;

namespace UI.Areas.Vendor.Controllers
{
	[Area("Vendor")]
	public class PriceController : BaseController
	{
		private readonly ApplicationDbContext _context;
		private readonly ILogger<PriceController> _logger;
		private readonly IWebHostEnvironment _environment;
		private readonly IRabbitMqService _mqService;
		private readonly UserManager<User> _userManager;

		public PriceController(ApplicationDbContext context, ILogger<PriceController> logger, IWebHostEnvironment environment, IRabbitMqService mqService, UserManager<User> userManager)
		{
			_context = context;
			_logger = logger;
			_environment = environment;
			_mqService = mqService;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			return View();
		}

		public async Task<IActionResult> Info()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Upload()
		{
			var request = HttpContext.Request;

			if (!request.HasFormContentType ||
				!MediaTypeHeaderValue.TryParse(request.ContentType, out var mediaTypeHeader) ||
				string.IsNullOrEmpty(mediaTypeHeader.Boundary.Value))
			{
				return new UnsupportedMediaTypeResult();
			}

			var reader = new MultipartReader(mediaTypeHeader.Boundary.Value, request.Body);
			var section = await reader.ReadNextSectionAsync();

			while (section != null)
			{
				var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(section.ContentDisposition,
					out var contentDisposition);

				if (hasContentDispositionHeader && contentDisposition.DispositionType.Equals("form-data") &&
					!string.IsNullOrEmpty(contentDisposition.FileName.Value))
				{

					var currentUser = await _userManager.GetUserAsync(User);
					var vendorId = currentUser.Id;
					var path = _environment.WebRootPath + "//Upload//Vendors//" + vendorId;
					var df = new DirectoryInfo(path);
					if (!df.Exists)
						new DirectoryInfo(path).Create();

					var saveToPath = Path.Combine(path, contentDisposition.FileName.Value);

					await using (var targetStream = System.IO.File.Create(saveToPath))
					{
						await section.Body.CopyToAsync(targetStream);
					}

					var priceList = new PriceList()
					{
						UserId = vendorId,
						CreationDate = DateTime.Now,
						PriceStatus = PriceStatus.InProcessing,
						IsPublicate = false,
					};
					await _context.Prices.AddAsync(priceList);
					await _context.SaveChangesAsync();
					var priceId = priceList.Id;
					_mqService.SendMessage(new
					{
						priceId,
						saveToPath
					});

					TempData[nameof(OperationResultType.Success)] = "Прайс загружен и ожидает обработки.";
					return RedirectToAction("Info", "Price", new { Area = "Vendor" });
				}

				section = await reader.ReadNextSectionAsync();
			}

			// If the code runs to this location, it means that no files have been saved
			return BadRequest("No files data in the request.");
		}

	}
}
