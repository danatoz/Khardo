using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Entities.Base;

namespace UI.Models
{
	public class ManufacturerModel : Entity
	{
		public string Name { get; set; }

		public string UrlLogo { get; set; }

		public int CountryId { get; set; }

		public Country Country { get; set; }


		public static Manufacturer ConvertToDal(ManufacturerModel obj)
		{
			var config = new MapperConfiguration(cfg =>
				cfg.CreateMap<ManufacturerModel, Manufacturer>());
			var mapper = new Mapper(config);
			return mapper.Map<ManufacturerModel, Manufacturer>(obj);
		}

		public static ManufacturerModel ConvertFromDal(Manufacturer obj)
		{
			var config = new MapperConfiguration(cfg =>
				cfg.CreateMap<Manufacturer, ManufacturerModel>());
			var mapper = new Mapper(config);
			return mapper.Map<Manufacturer, ManufacturerModel>(obj);
		}

		public static List<ManufacturerModel> ConvertListFromDal(IEnumerable<Manufacturer> obj)
		{
			return obj?.Select(ConvertFromDal).ToList();
		}
		public static List<Manufacturer> ConvertListToDal(IEnumerable<ManufacturerModel> obj)
		{
			return obj?.Select(ConvertToDal).ToList();
		}
	}
}
