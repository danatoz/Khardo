using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using System.Linq;
using DAL.DbModels;

namespace UI.Models
{
	public class ProductTemplateModel
	{
		public string VendorCode { get; set; }

		public string Name { get; set; }

		public int CategoryId { get; set; }

		public int ManufacturerId { get; set; }

		public string Description { get; set; }

		public int ManufacturerType { get; set; }


		public ManufacturerModel Manufacturer { get; set; }

		public CategoryModel Category { get; set; }

		public List<ProductPhotoModel> Photos { get; set; }


		public static ProductTemplate ConvertToDal(ProductTemplateModel obj)
		{
			var config = new MapperConfiguration(cfg =>
				cfg.CreateMap<ProductTemplateModel, ProductTemplate>());
			var mapper = new Mapper(config);
			return mapper.Map<ProductTemplateModel, ProductTemplate>(obj);
		}

		public static ProductTemplateModel ConvertFromDal(ProductTemplate obj)
		{
			var config = new MapperConfiguration(cfg =>
				cfg.CreateMap<ProductTemplate, ProductTemplateModel>());
			var mapper = new Mapper(config);
			return mapper.Map<ProductTemplate, ProductTemplateModel>(obj);
		}

		public static List<ProductTemplateModel> ConvertListFromDal(IEnumerable<ProductTemplate> obj)
		{
			return obj?.Select(ConvertFromDal).ToList();
		}
		public static List<ProductTemplate> ConvertListToDal(IEnumerable<ProductTemplateModel> obj)
		{
			return obj?.Select(ConvertToDal).ToList();
		}
	}
}
