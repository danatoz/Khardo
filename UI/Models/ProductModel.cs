using System.Collections.Generic;
using System.Linq;
using DAL.DbModels;
using Common.Enums;
using AutoMapper;

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
		public int VendorId { get; set; }
		public bool Active { get; set; }
		public ManufacturerType ManufacturerType { get; set; }

		public CatalogModel Catalog { get; set; }
		public ManufacturerModel Manufacturer { get; set; }
		public VendorModel Vendor { get; set; }

		public static Product ConvertToDal(ProductModel obj)
		{
			var config = new MapperConfiguration(cfg => 
				cfg.CreateMap<ProductModel, Product>());
			var mapper = new Mapper(config);
			return mapper.Map<ProductModel, Product>(obj);
		}

		public static ProductModel ConvertFromDal(Product obj)
		{
			var config = new MapperConfiguration(cfg =>
				cfg.CreateMap<Product, ProductModel>());
			var mapper = new Mapper(config);
			return mapper.Map<Product, ProductModel>(obj);
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
