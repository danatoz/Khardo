using Common;
using Common.Enums;
using DAL;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace PriceParseServices
{
	public class PriceUploader
	{
		public static async Task Upload(UploadedModel model)
		{
			await using var db = new AppDbContext();
			foreach (var priceModel in model.Price)
			{
				//проверить существует ли подобный артикул в шаблонах
				var productTemplate = await db.ProductTemplates.FirstOrDefaultAsync(item => 
					item.VendorCode == priceModel.VendorCode || 
					item.NormalizedVendorCode == priceModel.VendorCode.CleanVendorCode());

				//если существует в шаблонах добавить продукт в прайс с ссылкой на шаблон
				if (productTemplate != null)
				{
					await db.Products.AddAsync(new Product()
					{
						Price = priceModel.Price,
						Amount = priceModel.Amount,
						ProductTemplateId = productTemplate.Id,
						PriceId = model.PriceId
					});
					await db.SaveChangesAsync();
				}
				//если отсутствует добавить в шаблоны 
				else
				{
					await AddNewProductTemplate(model, db, priceModel);
				}
			}

			var priceList = await db.Prices.FindAsync(model.PriceId);
			if (priceList != null)
			{
				priceList.PriceStatus = PriceStatus.Moderation;
				db.Prices.Update(priceList);
				await db.SaveChangesAsync();
			}

			var currentPrice = await CurrentPrice(model, db);
			Console.WriteLine($"Загружен прайс: {currentPrice?.Vendor.NameOrganization} {DateTime.Now.ToString("dd-MM-yy HH:mm")}");
		}

		private static async Task AddNewProductTemplate(UploadedModel model, AppDbContext db, PriceModel priceModel)
		{
			var manufacturer =
				await db.Manufacturers.FirstOrDefaultAsync(item => item.Name == priceModel.Manufacturer) ??
				new Manufacturer();
			var newProductTemplate = new ProductTemplate()
			{
				VendorCode = priceModel.VendorCode,
				NormalizedVendorCode = priceModel.NormalizedVendorCode.CleanVendorCode(),
				Name = priceModel.Name,
				Alias = priceModel.Name.Translit()
			};
			if (manufacturer.Id == Guid.Empty)
			{
				manufacturer = new Manufacturer()
				{
					Name = priceModel.Manufacturer,
					UrlLogo = "",
				};
				await db.Manufacturers.AddAsync(manufacturer);
				await db.SaveChangesAsync();

				newProductTemplate.ManufacturerId = manufacturer.Id;

				await db.ProductTemplates.AddAsync(newProductTemplate);
				await db.SaveChangesAsync();
			}
			else
			{
				newProductTemplate.ManufacturerId = manufacturer.Id;
				await db.ProductTemplates.AddAsync(newProductTemplate);
				await db.SaveChangesAsync();
			}

			await db.Products.AddAsync(new Product()
			{
				Price = priceModel.Price,
				Amount = priceModel.Amount,
				ProductTemplateId = newProductTemplate.Id,
				PriceId = model.PriceId
			});
			await db.SaveChangesAsync();
		}

		private static async Task<PriceList?> CurrentPrice(UploadedModel model, AppDbContext db)
		{
			IQueryable<PriceList> queryAsync = db.Prices.Include(item => item.Vendor);
			var currentPrice = await queryAsync.FirstOrDefaultAsync(item => item.Id == model.PriceId);
			if (currentPrice != null)
			{
				var oldPublicationPrice =
					await db.Prices.FirstOrDefaultAsync(item => item.UserId == currentPrice.UserId && item.IsPublicate);
				if (oldPublicationPrice != null)
				{
					oldPublicationPrice.IsPublicate = false;
					db.Update(oldPublicationPrice);
				}

				await db.SaveChangesAsync();
			}

			return currentPrice;
		}
	}
}
