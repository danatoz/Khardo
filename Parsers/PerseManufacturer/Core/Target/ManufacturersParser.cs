using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace ParseManufacturer.Core.Target
{
	public class ManufacturersParser : IParser<string[]>
	{
		public string[] ParseHome(IHtmlDocument document)
		{
			var items = document.QuerySelectorAll("div")
				.Where(item => 
					item.ClassName != null && 
					item.ClassName.Contains("col-12 col-sm-6 col-md-4 col-lg-3 mfr-link-cell") &&
					item.ChildElementCount == 1);


			return items.Select(item => item.InnerHtml).ToArray();
		}

		public string? ParseInner(IHtmlDocument document)
		{
			var items = document.QuerySelectorAll("div")
				.FirstOrDefault(item =>
					item.ClassName != null &&
					item.ClassName.Contains("mfr-prop-value col-12 col-sm-6"));

			return items?.TextContent;
		}
	}
}
