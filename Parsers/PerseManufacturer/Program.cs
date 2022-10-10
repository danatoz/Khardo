using AngleSharp.Html.Parser;
using ParseManufacturer.Core;
using ParseManufacturer.Core.Target;
using ParseManufacturer;
using ParseManufacturer.Model;

var loader = new HtmlLoader(new ManufacturersSettings());
var source = await loader.GetSourceAsync();
var domParser = new HtmlParser();
var document = await domParser.ParseDocumentAsync(source);
var dataCollections = new ManufacturersParser();
var result = dataCollections.ParseHome(document);
var manufacures = new List<string>();
foreach (var item in result)
{
	manufacures.Add(item.Replace("\t", string.Empty).Trim());
}

var array = new List<string[]>();
foreach (var item in manufacures)
{
	array.Add(item.Split("\n\n\n"));
}

var manufacturesModels = new List<ManufacturerModel>();
foreach (var one in array)
{
	foreach (var second in one)
	{
		var startIndexName = second.IndexOf(">") + 1;
		var endIndexName = second.IndexOf("</");
		var startIndexHref = second.IndexOf("href=\"") + 6;
		var endIndexHref = second.IndexOf("\">") - 9;
		manufacturesModels.Add(new ManufacturerModel()
		{
			//<a href="/manufacturers/a-engineering">A-Engineering</a>
			Name = second.Substring(startIndexName, endIndexName - startIndexName),
			Url = "https://пятаяпередача.рф" + second.Substring(startIndexHref, endIndexHref),
			Country = ""
		});
	}
}
var loader2 = new HtmlLoader();
foreach (var item in manufacturesModels)
{
	var innerSource = await loader2.GetSourceAsync(item.Url);
	document = await domParser.ParseDocumentAsync(innerSource);
	var resultCountry = dataCollections.ParseInner(document);
	item.Country = resultCountry;
}

var handler = new ExcelHandler();
handler.CreateDocument(manufacturesModels);

Console.ReadKey();