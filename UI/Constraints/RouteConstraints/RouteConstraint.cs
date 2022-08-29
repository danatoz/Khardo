using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Constraints.RouteConstraints
{
	public abstract class RouteConstraint : IRouteConstraint
	{
		public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
		{
			if (values.TryGetValue(routeKey, out object param) && param != null)
			{
				var urlPath = param.ToString().ToLower();
				if (urlPath.StartsWith("~")
				    || urlPath.StartsWith("uploads")
				    || urlPath.StartsWith("admin")
				    || urlPath.StartsWith("o-kompanii")
				    || urlPath.StartsWith("price")
				    || urlPath.StartsWith("dostavka")
				    || urlPath.StartsWith("akcii")
				    || urlPath.StartsWith("contacts")
				    || urlPath.StartsWith("Oformit-zakaz")
				    || urlPath.StartsWith("basketmodal")
				    || urlPath.StartsWith("baskettopinfo")
				    || urlPath.StartsWith("changebasketitem")
				    || urlPath.StartsWith("deletebasketitem")
				    || urlPath.StartsWith("catalog")
				    || urlPath.StartsWith("search"))
					return false;

				var alias = urlPath.ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
				if (!string.IsNullOrWhiteSpace(alias))
					return Validate(alias, urlPath);
			}
			return false;
		}

		protected abstract bool Validate(string alias, string urlPath);
	}
}