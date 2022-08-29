using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DbModels;
using Common.Enums;

namespace UI.Models
{
    public class ProductModel
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string VendorCode { get; set; }
		public string Alias { get; set; }
		public string UrlImage { get; set; }
		public string Description { get; set; }
		public int Amount { get; set; }
		public decimal Price { get; set; }
		public int CatalogId { get; set; }
		public int? ManufacturerId { get; set; }
		public ManufacturerType ManufacturerType { get; set; }

		public CatalogModel Catalog { get; set; }
		public ManufacturerModel Manufacturer { get; set; }
		public static Product ConvertToDal(ProductModel obj)
		{
			return obj == null ? null : new Product
			{
				Id = obj.Id,
				Name = obj.Name,
				VendorCode = obj.VendorCode,
				Alias = obj.Alias,
				Amount = obj.Amount,
				Price = obj.Price,
				CatalogId = obj.CatalogId,
				ManufacturerId = obj.ManufacturerId,
				Description = obj.Description,
				UrlImage = obj.UrlImage,
				ManufacturerType = (int)obj.ManufacturerType,
				Catalog = CatalogModel.ConvertToDal(obj.Catalog),
				Manufacturer = ManufacturerModel.ConvertToDal(obj.Manufacturer)
			};
		}
		public static ProductModel ConvertFromDal(Product obj)
		{
			return obj == null ? null : new ProductModel
			{
				Id = obj.Id,
				Name = obj.Name,
				VendorCode = obj.VendorCode,
				Alias = obj.Alias,
				Amount = obj.Amount,
				Price = obj.Price,
				CatalogId = obj.CatalogId,
				ManufacturerId = obj.ManufacturerId,
				Description = obj.Description,
				UrlImage = obj.UrlImage,
				ManufacturerType = (ManufacturerType)obj.ManufacturerType,
				Catalog = CatalogModel.ConvertFromDal(obj.Catalog),
				Manufacturer = ManufacturerModel.ConvertFromDal(obj.Manufacturer),
			};
		}

		public static List<ProductModel> ConvertListFromDal(IEnumerable<Product> models)
		{
			return models?.Select(ConvertFromDal).ToList();
		}
		public static List<Product> ConvertListToDal(IEnumerable<ProductModel> models)
		{
			return models?.Select(ConvertToDal).ToList();
		}
	}
}
