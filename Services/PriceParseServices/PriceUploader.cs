using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace PriceParseServices
{
	public class PriceUploader
	{
		public static async Task Upload(UploadedModel model)
		{
			await using var db = new ApplicationDbContext();
			foreach (var priceModel in model.Price)
			{
				//проверить существует ли подобный артикул в шаблонах
				var exists = await db.ProductTemplates.AnyAsync(item => 
					item.VendorCode == priceModel.VendorCode || 
					item.NormalizedVendorCode == priceModel.NormalizedVendorCode);

				//если существует в шаблонах добавить продукт в прайс с ссылкой на шаблон
				if (exists)
				{
					await db.Products.AddAsync(new Product()
					{
						Price = priceModel.Price,
						Amount = priceModel.Amount,
						VendorCode = priceModel.VendorCode,
						VendorId = model.VendorId
					});
					await db.SaveChangesAsync();
				}
				//если отсутствует добавить в шаблоны 
				else
				{
					var newManufacturer = new Manufacturer();
					var manufacturerExists = await db.Manufacturers.FirstOrDefaultAsync(item => item.Name == priceModel.Manufacturer);
					if (manufacturerExists == null)
					{
						newManufacturer = new Manufacturer()
						{
							Name = priceModel.Manufacturer,
							UrlLogo = "",
						};
						await db.Manufacturers.AddAsync(newManufacturer);
						await db.SaveChangesAsync();

						await db.ProductTemplates.AddAsync(new ProductTemplate()
						{
							VendorCode = priceModel.VendorCode,
							NormalizedVendorCode = priceModel.NormalizedVendorCode,
							Name = priceModel.Name,
							ManufacturerId = newManufacturer.Id,

						});
						await db.SaveChangesAsync();
					}
					else
					{
						await db.ProductTemplates.AddAsync(new ProductTemplate()
						{
							VendorCode = priceModel.VendorCode,
							NormalizedVendorCode = priceModel.NormalizedVendorCode,
							Name = priceModel.Name,
							ManufacturerId = manufacturerExists.Id,
							
						});
						await db.SaveChangesAsync();
					}
				}
			}
		}
	}
}
