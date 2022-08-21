using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

namespace UI.Models.ViewModels.FilterModel
{
    public class BaseFilterModel
    {
		public RouteValueDictionary Merge(object obj)
		{
			var result = new RouteValueDictionary(this);
			foreach (var item in new RouteValueDictionary(obj))
				result[item.Key] = item.Value;
			return result;
		}
	}
}
