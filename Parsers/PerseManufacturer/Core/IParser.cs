using AngleSharp.Html.Dom;

namespace ParseManufacturer.Core
{
	public interface IParser<T>
	{
		T ParseHome(IHtmlDocument document);
	}
}
