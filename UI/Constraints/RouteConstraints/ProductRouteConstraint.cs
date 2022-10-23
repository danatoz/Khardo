using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Constraints.RouteConstraints
{
	public class ProductRouteConstraint : RouteConstraint
	{
		protected override bool Validate(string alias, string urlPath)
		{
			try
			{
				if (urlPath != null || urlPath.ToLower().Contains("admin"))
				{
					return false;
				}

				var products = Task.Run(async () => await new ProductTemplateBL().GetSimpleByAliasAsync(alias)).Result;

				if (products != null && products.Any())
				{
					foreach (var product in products)
					{
						var catalogUrl = Task.Run(async () => await new CategoryBL().GenerateFullUrl(product.CategoryId)).Result;
						if ($"{catalogUrl}/{product.Alias}" == urlPath.ToString())
							return true;
					}
				}
			}
			catch (Exception ex)
			{

			}

			return false;
		}
		//protected override bool Validate(string alias, string urlPath)
		//{
		//	throw new NotImplementedException();
		//}
	}
}