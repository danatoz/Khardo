using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using System.Linq;
using Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Base;

namespace UI.Models
{
	public class ProductTemplateModel : Entity
	{
		public string VendorCode { get; set; }

		public string NormalizedVendorCode { get; set; }

		public string Name { get; set; }

		public Guid? CategoryId { get; set; }

		public Guid ManufacturerId { get; set; }

		public string Description { get; set; }

		public int ManufacturerType { get; set; }

		public bool Active { get; set; }

		public string ManufacturerName { get; set; }

		private string PhotoUrl { get; set; }

		public string DefaultPhotoUrl
		{
			get { return PhotoUrl ??= "/images/serviceImages/No_image_available.svg"; }
			set => PhotoUrl = value;
		}

		public CategoryModel Category { get; set; }

		public List<ProductPhotoModel> Photos { get; set; }


		public static ProductTemplate ConvertToEntity(ProductTemplateModel obj)
		{
			var config = new MapperConfiguration(cfg =>
				cfg.CreateMap<ProductTemplateModel, ProductTemplate>()
					.ForSourceMember(source => source.Category,
						opt => opt.DoNotValidate())
					.ForMember(src => src.Photos, cfg =>
						cfg.MapFrom(opt => opt.PhotoUrl))
					.ForMember(src => src.Manufacturer, cfg => 
						cfg.MapFrom(opt => opt.ManufacturerName)));
			var mapper = new Mapper(config);
			return mapper.Map<ProductTemplateModel, ProductTemplate>(obj);
		}

		public static ProductTemplateModel ConvertToModel(ProductTemplate obj)
		{
			var config = new MapperConfiguration(cfg =>
				cfg.CreateMap<ProductTemplate, ProductTemplateModel>()
					.ForSourceMember(source =>
						source.Manufacturer, opt =>
						opt.DoNotValidate())
					.ForSourceMember(source => source.Category,
						opt => opt.DoNotValidate())
					.ForMember(src => src.Photos, cfg =>
						cfg.MapFrom(opt => opt.Photos)));
			var mapper = new Mapper(config);
			return mapper.Map<ProductTemplate, ProductTemplateModel>(obj);
		}

		public static List<ProductTemplateModel> ConvertListToModels(IEnumerable<ProductTemplate> obj)
		{
			return obj?.Select(ConvertToModel).ToList();
		}

		public static List<ProductTemplate> ConvertListToEntities(IEnumerable<ProductTemplateModel> obj)
		{
			return obj?.Select(ConvertToEntity).ToList();
		}
	}
}
