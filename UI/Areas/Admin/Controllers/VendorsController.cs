using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UI.Models.ViewModels;
using UI.Models.ViewModels.FilterModel;
using UI.Other;

namespace UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class VendorsController : BaseController
    {
	    private readonly ILogger<VendorsController> _logger;
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly ApplicationDbContext _context;
	    public VendorsController(ILogger<VendorsController> logger, UserManager<User> userManager, ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
	    {
		    _logger = logger;
		    _userManager = userManager;
		    _context = context;
		    _roleManager = roleManager;
	    }

	    public async Task<IActionResult> Index(UserFilterModel filterModel, int page = 1)
	    {
		    if (User.IsInRole("manager"))
			    filterModel.ResponsibleId = this.GetCurrentUserId();

		    const int objectsPerPage = 20;
		    var startIndex = (page - 1) * objectsPerPage;
		    var source =  await (from user in _context.Users
			    join userRole in _context.UserRoles
				    on user.Id equals userRole.UserId
			    join role in _context.Roles 
				    on userRole.RoleId equals role.Id
			    where role.Name == "vendor"
			    select user).ToListAsync();
		    if (filterModel.ResponsibleId != null)
		    {
				source = source.Where(item => item.ResponsibleId == filterModel.ResponsibleId).ToList();
			}
			var count = source.Count();
		    var items = source.Skip(startIndex).Take(objectsPerPage);

		    var viewModel = new SearchResultViewModel<User, UserFilterModel>(
			    items, filterModel, count, startIndex, 20, objectsPerPage);

			return View(viewModel);
	    }

		[HttpGet]
	    public async Task<IActionResult> Update(string id)
	    {
		    var viewModel = await _userManager.FindByIdAsync(id);
		    if (viewModel == null)
			    return NotFound();

		    return View(viewModel);
	    }

	    [HttpPost]
		public async Task<IActionResult> Update(User model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByIdAsync(model.Id);
				if (user != null)
				{
					await _userManager.UpdateAsync(user);
				}
				else
				{
					await _userManager.CreateAsync(model);
				}
				TempData[nameof(OperationResultType.Success)] = "Успех!";
			}
			return RedirectToAction("Index", "Vendors", new { Area = "Admin" });
	    }

    }
}
