using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;

namespace UI.Extensions
{
	public static class PagedListExtensions
	{
		public static IHtmlContent PagedList(this IHtmlHelper helper, int itemsCount, int itemsPerPage, int currentPage,
			int displayedPages, Func<int, string> generateUrlFunc, PagedListRenderParams renderParams)
		{
			if (itemsCount == 0)
				return new HtmlString("");
			var pagesCount = (itemsCount + itemsPerPage - 1) / itemsPerPage;
			var firstPage = Math.Max(currentPage - displayedPages / 2 + 1 - Math.Max(currentPage + displayedPages - displayedPages / 2 - pagesCount, 0), 1);
			var lastPage = Math.Min(firstPage + displayedPages - 1, pagesCount);
			currentPage = Math.Max(currentPage, 1);
			currentPage = Math.Min(lastPage, currentPage);
			var pages = new List<IHtmlContent>();
			if ((currentPage > 2 || renderParams.DisableUnavailablePages) && renderParams.ShowFirstPage)
			{
				var disablePage = renderParams.DisableUnavailablePages && currentPage == 1;
				var htmlAttributes = new Dictionary<string, object>
				{
					{ "class", renderParams.DefaultPageClass + " " + renderParams.FirstPageClass + (disablePage ? " " + renderParams.DisabledPageClass : "") }
				};
				if (!disablePage)
				{
					htmlAttributes[renderParams.PageNumberAttributeName] = 1;
				}
				pages.Add(BuildPageItem(disablePage ? (int?)null : 1, htmlAttributes, generateUrlFunc, 
					renderParams.LinkClass, string.Format(renderParams.FirstPageLinkFormat, 1), renderParams.EncodeHtmlLinkText, renderParams.ProcessLinkAttributesAction));
			}
			if ((currentPage != firstPage || renderParams.DisableUnavailablePages) && renderParams.ShowPreviousPage)
			{
				var disablePage = renderParams.DisableUnavailablePages && currentPage == 1;
				var htmlAttributes = new Dictionary<string, object>
				{
					{ "class", renderParams.DefaultPageClass + " " + renderParams.PreviousPageClass + (disablePage ? " " + renderParams.DisabledPageClass : "") }
				};
				if (!disablePage)
				{
					htmlAttributes[renderParams.PageNumberAttributeName] = currentPage - 1;
				}
				pages.Add(BuildPageItem(disablePage ? (int?)null : currentPage - 1, htmlAttributes, generateUrlFunc,
					renderParams.LinkClass, string.Format(renderParams.PreviousPageLinkFormat, currentPage - 1), renderParams.EncodeHtmlLinkText, renderParams.ProcessLinkAttributesAction));
			}
			for (var page = firstPage; page <= lastPage; ++page)
			{
				var isCurrent = page == currentPage;
				var attrDictionary = new Dictionary<string, object>
				{
					{ "class", renderParams.DefaultPageClass },
					{ renderParams.PageNumberAttributeName, page }
				};
				if (isCurrent)
					attrDictionary["class"] += " " + renderParams.CurrentPageClass;
				pages.Add(BuildPageItem(page == currentPage && renderParams.RemoveLinkToCurrentPage ? (int?)null : page,
					attrDictionary, generateUrlFunc, renderParams.LinkClass, 
					string.Format(page == currentPage ? renderParams.CurrentPageLinkFormat : renderParams.DefaultPageLinkFormat, page), 
					renderParams.EncodeHtmlLinkText, renderParams.ProcessLinkAttributesAction));
			}
			if ((currentPage != lastPage || renderParams.DisableUnavailablePages) && renderParams.ShowNextPage)
			{
				var disablePage = renderParams.DisableUnavailablePages && currentPage == pagesCount;
				var htmlAttributes = new Dictionary<string, object>
				{
					{ "class", renderParams.DefaultPageClass + " " + renderParams.NextPageClass + (disablePage ? " " + renderParams.DisabledPageClass : "") }
				};
				if (!disablePage)
				{
					htmlAttributes[renderParams.PageNumberAttributeName] = currentPage + 1;
				}
				pages.Add(BuildPageItem(disablePage ? (int?)null : currentPage + 1, htmlAttributes, generateUrlFunc, 
					renderParams.LinkClass, string.Format(renderParams.NextPageLinkFormat, currentPage + 1),
					renderParams.EncodeHtmlLinkText, renderParams.ProcessLinkAttributesAction));
			}
			if ((currentPage < pagesCount - 1 || renderParams.DisableUnavailablePages) && renderParams.ShowLastPage)
			{
				var disablePage = renderParams.DisableUnavailablePages && currentPage == pagesCount;
				var htmlAttributes = new Dictionary<string, object>
				{
					{ "class", renderParams.DefaultPageClass + " " + renderParams.LastPageClass + (disablePage ? " " + renderParams.DisabledPageClass : "") }
				};
				if (!disablePage)
				{
					htmlAttributes[renderParams.PageNumberAttributeName] = pagesCount;
				}
				pages.Add(BuildPageItem(disablePage ? (int?)null : pagesCount, htmlAttributes, generateUrlFunc,
					renderParams.LinkClass, string.Format(renderParams.LastPageLinkFormat, pagesCount), 
					renderParams.EncodeHtmlLinkText, renderParams.ProcessLinkAttributesAction));
			}
			var builder = new TagBuilder("ul");
			builder.MergeAttributes(new RouteValueDictionary(renderParams.PagerAttributes));
			foreach (var page in pages)
			{
				builder.InnerHtml.AppendHtml(page);
			}
			using var resultWriter = new StringWriter();
			builder.WriteTo(resultWriter, HtmlEncoder.Default);
			return new HtmlString(resultWriter.ToString());
		}

		public class PagedListRenderParams
		{
			public object PagerAttributes { get; set; }
			public string FirstPageClass { get; set; } = "first";
			public string PreviousPageClass { get; set; } = "previous";
			public string LastPageClass { get; set; } = "last";
			public string NextPageClass { get; set; } = "next";
			public string CurrentPageClass { get; set; } = "active";
			public string DisabledPageClass { get; set; } = "disabled";
			public string DefaultPageClass { get; set; } = "page-item";
			public string FirstPageLinkFormat { get; set; } = "‹‹";
			public string LastPageLinkFormat { get; set; } = "››";
			public string PreviousPageLinkFormat { get; set; } = "‹";
			public string NextPageLinkFormat { get; set; } = "›";
			public string DefaultPageLinkFormat { get; set; } = "{0}";
			public string CurrentPageLinkFormat { get; set; } = "{0}";
			public string PageNumberAttributeName { get; set; } = "data-page";
			public string LinkClass { get; set; } = "page-link";
			public bool ShowFirstPage { get; set; } = true;
			public bool ShowPreviousPage { get; set; } = true;
			public bool ShowLastPage { get; set; } = true;
			public bool ShowNextPage { get; set; } = true;
			public bool DisableUnavailablePages { get; set; } = true;
			public bool EncodeHtmlLinkText { get; set; } = true;
			public bool RemoveLinkToCurrentPage { get; set; } = true;
			public Action<int?, RouteValueDictionary> ProcessLinkAttributesAction;

			public PagedListRenderParams()
			{
				PagerAttributes = new
				{
					@class = "pagination justify-content-center"
				};
			}
		}

		private static IHtmlContent BuildPageItem(int? page, IDictionary<string, object> pageItemHtmlAttributes, 
			Func<int, string> generateUrlFunc, string linkClass, string linkText, bool encodeHtmlLinkText,
			Action<int?, RouteValueDictionary> processLinkAttributesAction)
		{
			var builder = new TagBuilder("li");
			builder.MergeAttributes(new RouteValueDictionary(pageItemHtmlAttributes));
			var linkAttributes = new RouteValueDictionary
			{
				["class"] = linkClass,
			};
			if (page != null)
			{
				linkAttributes["href"] = generateUrlFunc(page.Value);
			}
			processLinkAttributesAction?.Invoke(page, linkAttributes);
			builder.InnerHtml.AppendHtml(BuildPageLink(linkText, encodeHtmlLinkText, linkAttributes));
			using var resultWriter = new StringWriter();
			builder.WriteTo(resultWriter, HtmlEncoder.Default);
			return new HtmlString(resultWriter.ToString());
		}

		private static IHtmlContent BuildPageLink(string linkText, bool encodeHtml, RouteValueDictionary htmlAttributes)
		{
			var builder = new TagBuilder("a");
			builder.MergeAttributes(htmlAttributes);
			if (encodeHtml)
			{
				builder.InnerHtml.Append(linkText);
			}
			else
			{
				builder.InnerHtml.AppendHtml(linkText);
			}
			using var resultWriter = new StringWriter();
			builder.WriteTo(resultWriter, HtmlEncoder.Default);
			return new HtmlString(resultWriter.ToString());
		}
	}
}