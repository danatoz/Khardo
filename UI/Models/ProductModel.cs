using System.Collections.Generic;
using System.Linq;
using Entities;
using Common.Enums;
using AutoMapper;

namespace UI.Models
{
    public class ProductModel
    {
	    public long Id { get; set; }

	    public string VendorCode { get; set; }

	    public int VendorId { get; set; }

	    public string Alias { get; set; }

	    public int Amount { get; set; }

	    public decimal Price { get; set; }

	    public bool Active { get; set; }

	    public ProductTemplateModel ProductTemplate { get; set; }

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

		public static List<ProductModel> ConvertListFromDal(IEnumerable<Product> obj)
		{
			return obj?.Select(ConvertFromDal).ToList();
		}
		public static List<Product> ConvertListToDal(IEnumerable<ProductModel> obj)
		{
			return obj?.Select(ConvertToDal).ToList();
		}
	}
}
