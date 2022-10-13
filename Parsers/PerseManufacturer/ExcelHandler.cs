using DAL;
using Entities;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using ParseManufacturer.Model;

namespace ParseManufacturer
{
	public class ExcelHandler
	{
		public async Task CreateDocument(List<ManufacturerModel> models)
		{
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

			var stream = new MemoryStream();
			using var package = new ExcelPackage(stream);
			var workSheet = package.Workbook.Worksheets.Add("Sheet1");
			workSheet.Cells.LoadFromCollection(models, true);
			package.SaveAs(new FileInfo("./Manufacturers.xlsx"));
		}

		public async Task UploadDataInDb(string path)
		{
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			var package = new ExcelPackage();

			await using var stream = File.OpenRead(path);
			await package.LoadAsync(stream);

			var sheet = package.Workbook.Worksheets.First();

			await using var db = new AppDbContext();

			string? manufactureNameCell = "", countryNameCell = "";
			for (var rowNumber = 2;; rowNumber++)
			{
				manufactureNameCell = (sheet.Cells[rowNumber, 1].Value ?? "")?.ToString()?.Trim();
				countryNameCell = (sheet.Cells[rowNumber, 3].Value ?? "")?.ToString()?.Trim();

				if (manufactureNameCell == "" && countryNameCell == "")
					break;

				var country = await db.Countries.FirstOrDefaultAsync(item =>
					item.Name == countryNameCell || 
					item.NormalizeName == countryNameCell.ToUpper());
				if (country == null)
				{
					country = new Country()
					{
						Name = countryNameCell,
						NormalizeName = countryNameCell?.ToUpper()
					};
					await db.Countries.AddAsync(country);
					await db.SaveChangesAsync();
				}

				var manufacturer = await db.Manufacturers.FirstOrDefaultAsync(item =>
					item.Name == manufactureNameCell ||
					item.NormalizeName == manufactureNameCell.ToUpper());
				if (manufacturer == null)
				{
					manufacturer = new Manufacturer()
					{
						Name = manufactureNameCell,
						NormalizeName = manufactureNameCell?.ToUpper(),
						CountryId = country.Id,
						UrlLogo = ""
					};
					await db.Manufacturers.AddAsync(manufacturer);
					await db.SaveChangesAsync();
				}
			}
		}
	}
}
