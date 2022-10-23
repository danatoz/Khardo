using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NLog;
using NLog.Fluent;

namespace UI.Constraints.RouteConstraints
{
	public class CategoryRouteConstraint : RouteConstraint
	{
		private readonly ILogger _logger;
		public CategoryRouteConstraint(ILogger logger)
		{
			_logger = logger;
		}

		public CategoryRouteConstraint()
		{

		}
		protected override bool Validate(string alias, string pathUrl)
		{
			try
			{
				if (pathUrl != null || pathUrl.ToLower().Contains("admin"))
				{
					return false;
				}

				var catalogBL = new CategoryBL();
				var catalog = Task.Run(async () => await catalogBL.GetSimpleByAliasAsync(alias)).Result;
				if (catalog != null)
				{
					var categoryUrl = Task.Run(async () => await catalogBL.GenerateFullUrl(catalog.Id)).Result;
					return categoryUrl == pathUrl;
				}
			}
			catch (Exception ex)
			{

			}

			return false;
		}
	}
}