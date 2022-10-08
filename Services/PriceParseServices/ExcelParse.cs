namespace PriceParseServices
{
	public class ExcelParse
	{
		public static async Task<UploadedModel> Parse(MessageModel? model)
		{
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			var package = new ExcelPackage();

			var fileExists = File.Exists(model?.SaveToPath);

			var priceModels = new List<PriceModel>();
			if (!fileExists) return new UploadedModel();
			try
			{
				await using var stream = File.OpenRead(model?.SaveToPath);
				await package.LoadAsync(stream);

				var sheet = package.Workbook.Worksheets.First();

				string? vendorCode = "", manufacturer = "", amount = "", price = "", name = "";

				for (var rowNumber = 2; ; rowNumber++)
				{
					vendorCode = (sheet.Cells[rowNumber, 1].Value ?? "")?.ToString()?.Trim();
					name = (sheet.Cells[rowNumber, 2].Value ?? "")?.ToString()?.Trim();
					amount = (sheet.Cells[rowNumber, 3].Value ?? "")?.ToString()?.Trim();
					manufacturer = (sheet.Cells[rowNumber, 4].Value ?? "")?.ToString()?.Trim();
					price = (sheet.Cells[rowNumber, 5].Value ?? "")?.ToString()?.Trim();

					if (vendorCode == "" &&
						manufacturer == "" &&
						amount == "" &&
						price == "" &&
						name == "")
						break;
					int.TryParse(amount, out var safeAmount);
					decimal.TryParse(price, out var safePrice);
					var priceModel = new PriceModel
					{
						VendorCode = vendorCode,
						NormalizedVendorCode = vendorCode.Replace("-", string.Empty),
						Name = name,
						Manufacturer = manufacturer,
						Amount = safeAmount,
						Price = safePrice,
					};

					priceModels.Add(priceModel);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}


			return new UploadedModel() { Price = priceModels, VendorId = model.VendorId };
		}
	}
}
