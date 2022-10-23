using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using UI.Models;

namespace UI.Tools
{
    public class BreadCrumbDataProvider : IBreadCrumbDataProvider
    {
        private readonly RouteValueDictionary _routeValues;

        public BreadCrumbDataProvider(IHttpContextAccessor httpContextAccessor)
        {
			_routeValues = httpContextAccessor.HttpContext.Request.RouteValues;
        }
        public async Task<IEnumerable<BreadCrumbModel>> GetDataAsync(string currentPageTitle)
        {
			var urlBuilder = new StringBuilder();
			var breadCrumbList = new List<BreadCrumbModel>();
			if (_routeValues.TryGetValue("alias", out object aliasParameter)
				&& !string.IsNullOrWhiteSpace(aliasParameter.ToString()))
			{
				var alias = aliasParameter.ToString();
				var catalog = new CategoryBL();
				var categoryList = new List<Category>();

				if ("Products".Equals(_routeValues["controller"]))
				{
					ProductTemplate product = null;
					var products = await new ProductTemplateBL().GetSimpleByAliasAsync(alias.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault());
					if (products != null)
					{
						foreach (var item in products)
						{
							if (alias == $"{await catalog.GenerateFullUrl(item.CategoryId)}/{item.Alias}")
							{
								product = item;
								break;
							}
						}
					}
					if (product != null)
						categoryList.AddRange(await catalog.GetParentCatalogs(product.CategoryId));
				}
				else
				{
					categoryList.AddRange(await catalog.GetParentCatalogs(aliasParameter.ToString()));
				}

				breadCrumbList.Add(new BreadCrumbModel
				{
					Name = "Каталог",
					Url = "catalog"
				});

				foreach (var item in categoryList)
				{
					breadCrumbList.Add(new BreadCrumbModel
					{
						Name = item.Name,
						Url = urlBuilder.AppendFormat("/{0}", item.Alias).ToString().TrimStart('/')
					});
				}

			}

			if (!("Home".Equals(_routeValues["controller"])
				&& "Index".Equals(_routeValues["action"])))
			{
				var breadCrumbElement = breadCrumbList.LastOrDefault();
				if (breadCrumbElement != null && breadCrumbElement.Name == currentPageTitle)
					breadCrumbElement.IsActive = true;
				else
					breadCrumbList.Add(new BreadCrumbModel
					{
						Name = currentPageTitle,
						IsActive = true
					});
			}

			return breadCrumbList;
		}
    }
}
