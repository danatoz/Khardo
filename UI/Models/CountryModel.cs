using AutoMapper;
using DAL.DbModels;
using Entities.Base;
using System.Collections.Generic;
using System.Linq;

namespace UI.Models
{
	public class CountryModel : Entity
	{
		public string Name { get; set; }


		public static Country ConvertToDal(CountryModel obj)
		{
			var config = new MapperConfiguration(cfg =>
				cfg.CreateMap<CountryModel, Country>());
			var mapper = new Mapper(config);
			return mapper.Map<CountryModel, Country>(obj);
		}

		public static CountryModel ConvertFromDal(Country obj)
		{
			var config = new MapperConfiguration(cfg =>
				cfg.CreateMap<Country, CountryModel>());
			var mapper = new Mapper(config);
			return mapper.Map<Country, CountryModel>(obj);
		}

		public static List<CountryModel> ConvertListFromDal(IEnumerable<Country> obj)
		{
			return obj?.Select(ConvertFromDal).ToList();
		}
		public static List<Country> ConvertListToDal(IEnumerable<CountryModel> obj)
		{
			return obj?.Select(ConvertToDal).ToList();
		}
	}
}
