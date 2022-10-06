using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Common.Enums;
using DAL;
using Microsoft.EntityFrameworkCore;
using UI.Models.ViewModels;
using UI.Models.ViewModels.FilterModel;

namespace UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(AuthenticationSchemes = nameof(AuthScheme.Admin))]
	public class VendorsController : BaseController
    {
	    private readonly ApplicationDbContext _context;
	    private readonly ILogger<VendorsController> _logger;

	    public VendorsController(ApplicationDbContext context,ILogger<VendorsController> logger)
	    {
		    _context = context;
		    _logger = logger;
	    }

	    public async Task<IActionResult> Index(VendorFilterModel filterModel, int page = 1)
	    {
		    if (this.GetCurrentUserRole() == UserRole.Manager)
			    filterModel.ResponsibleId = this.GetCurrentUserId();

		    const int objectsPerPage = 20;
		    var startIndex = (page - 1) * objectsPerPage;
		    IQueryable<Entities.Vendor> source = _context.Vendors;
		    if (filterModel.ResponsibleId != null)
		    {
			    source = _context.Vendors.Where(item => item.ResponsibleId == filterModel.ResponsibleId);
		    }
		    var count = await source.CountAsync();
		    var items = await source.Skip(startIndex).Take(objectsPerPage).ToListAsync();

		    var viewModel = new SearchResultViewModel<VendorModel, VendorFilterModel>(
			    VendorModel.ConvertListFromDal(items), filterModel, count, startIndex, 20, objectsPerPage);

			return View(viewModel);
	    }

		[HttpGet]
	    public async Task<IActionResult> Update(int id)
	    {
		    var viewModel = await _context.Vendors.FindAsync(id);
		    if (viewModel == null)
			    return NotFound();

		    return View(viewModel);
	    }

	    [HttpPost]
		public async Task<IActionResult> Update(VendorModel model)
		{
			await _context.Vendors.AddAsync(VendorModel.ConvertToDal(model));
			await _context.SaveChangesAsync();
		    return RedirectToAction("Index", "Vendors", new { Area = "Admin" });
	    }

    }
}
