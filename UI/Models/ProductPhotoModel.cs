using AutoMapper;
using DAL.DbModels;
using Entities.Base;
using System.Collections.Generic;
using System.Linq;

namespace UI.Models
{
    public class ProductPhotoModel : Entity
    {
		public string ProductTemplateId { get; set; }

	    public string UrlImage { get; set; }

		public ProductTemplateModel ProductTemplate { get; set; }

		public static ProductPhoto ConvertToDal(ProductPhotoModel obj)
		{
			var config = new MapperConfiguration(cfg =>
				cfg.CreateMap<ProductPhotoModel, ProductPhoto>());
			var mapper = new Mapper(config);
			return mapper.Map<ProductPhotoModel, ProductPhoto>(obj);
		}

		public static ProductPhotoModel ConvertFromDal(ProductPhoto obj)
		{
			var config = new MapperConfiguration(cfg =>
				cfg.CreateMap<ProductPhoto, ProductPhotoModel>());
			var mapper = new Mapper(config);
			return mapper.Map<ProductPhoto, ProductPhotoModel>(obj);
		}

		public static List<ProductPhotoModel> ConvertListFromDal(IEnumerable<ProductPhoto> obj)
		{
			return obj?.Select(ConvertFromDal).ToList();
		}
		public static List<ProductPhoto> ConvertListToDal(IEnumerable<ProductPhotoModel> obj)
		{
			return obj?.Select(ConvertToDal).ToList();
		}

	}
}
