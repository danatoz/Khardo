using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using DAL.DbModels;
using UI.Areas.Public.Models;
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
				var catalog = new CatalogsBL();
				var categoryList = new List<Catalog>();

				if ("Products".Equals(_routeValues["controller"]))
				{
					Product part = null;
					var parts = await new PartsBL().GetSimpleByAliasAsync(alias.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault());
					if (parts != null)
					{
						foreach (var item in parts)
						{
							if (alias == $"{await catalog.GenerateFullUrl(item.CatalogId)}/{item.Alias}")
							{
								part = item;
								break;
							}
						}
					}
					//var product = (await new ProductsBL().GetAsync(new Common.Search.ProductsSearchParams
					//{
					//	ObjectsCount = 1,
					//	Alias = aliasParameter.ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault()
					//})).Objects.FirstOrDefault();

					if (part != null)
						categoryList.AddRange(await catalog.GetParentCategories(part.CatalogId));
				}
				else
				{
					categoryList.AddRange(await catalog.GetParentCategories(aliasParameter.ToString()));
				}

				breadCrumbList.Add(new BreadCrumbModel
				{
					Name = "Каталог",
					Url = "uslugi"
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
