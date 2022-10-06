using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Entities.Base;
using Entities;

namespace UI.Models
{
    public class CityModel : Entity
    {
	    public string Name { get; set; }

	    public static City ConvertToDal(CityModel obj)
	    {
		    var config = new MapperConfiguration(cfg =>
			    cfg.CreateMap<CityModel, City>());
		    var mapper = new Mapper(config);
		    return mapper.Map<CityModel, City>(obj);
	    }

	    public static CityModel ConvertFromDal(City obj)
	    {
		    var config = new MapperConfiguration(cfg =>
			    cfg.CreateMap<City, CityModel>());
		    var mapper = new Mapper(config);
		    return mapper.Map<City, CityModel>(obj);
	    }

	    public static List<CityModel> ConvertListFromDal(IEnumerable<City> obj)
	    {
		    return obj?.Select(ConvertFromDal).ToList();
	    }
	    public static List<City> ConvertListToDal(IEnumerable<CityModel> obj)
	    {
		    return obj?.Select(ConvertToDal).ToList();
	    }
	}
}
