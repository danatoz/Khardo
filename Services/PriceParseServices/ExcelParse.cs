namespace PriceParseServices
{
    public class ExcelParse
    {
	    public static async Task<List<PriceModel>> Parse(MessageModel? model)
	    {
		    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
		    var package = new ExcelPackage();

		    var fileExists = File.Exists(model?.SaveToPath);

		    var priceModels = new List<PriceModel>();
		    if (!fileExists) return priceModels;

		    await using var stream = File.OpenRead(model?.SaveToPath);
		    await package.LoadAsync(stream);

		    var sheet = package.Workbook.Worksheets.First();

		    string? vendorCode = "", manufacturer = "", amount = "", price = "";

		    for (var rowNumber = 2; ; rowNumber++)
		    {
			    vendorCode = (sheet.Cells[rowNumber, 1].Value ?? "")?.ToString()?.Trim();
			    manufacturer = (sheet.Cells[rowNumber, 2].Value ?? "")?.ToString()?.Trim();
			    amount = (sheet.Cells[rowNumber, 3].Value ?? "")?.ToString()?.Trim();
			    price = (sheet.Cells[rowNumber, 4].Value ?? "")?.ToString()?.Trim();

			    if (vendorCode == "" &&
			        manufacturer == "" &&
			        amount == "" &&
			        price == "")
				    break;

			    var priceModel = new PriceModel
			    {
				    VendorCode = vendorCode,
				    Manufacturer = manufacturer,
				    Amount = Int32.Parse(amount),
				    Price = Decimal.Parse(price),
			    };

			    priceModels.Add(priceModel);
		    }

		    return priceModels;
		}
    }
}
