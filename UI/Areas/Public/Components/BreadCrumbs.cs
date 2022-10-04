using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using BL;
using UI.Tools;

namespace UI.Areas.Public.Components
{
	public class BreadCrumbs : ViewComponent
	{
		//private readonly IBreadCrumbDataProvider _dataProvider;

		public BreadCrumbs(IBreadCrumbDataProvider dataProvider)
		{
			//_dataProvider = dataProvider;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			//return View(await _dataProvider.GetDataAsync(ViewContext.ViewBag.Title));
			return View();
		}
    }
}