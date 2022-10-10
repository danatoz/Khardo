using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
	}
}
