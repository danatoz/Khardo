using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Entities;

namespace UI.Models
{
    public class VendorModel : BaseUser
    {
	    public string NameOrganization { get; set; }

	    public int Rating { get; set; }

	    public int ResponsibleId { get; set; }

	    public string ITN { get; set; }

	    public string BIC { get; set; }

	    public string PhysicalAdress { get; set; }

	    public string LegalAddress { get; set; }

	    //public UserModel Responsible { get; set; }

	    public List<ProductModel> Products { get; set; }

		public static Vendor ConvertToDal(VendorModel obj)
	    {
		    var config = new MapperConfiguration(cfg =>
			    cfg.CreateMap<VendorModel, Vendor>());
		    var mapper = new Mapper(config);
		    return mapper.Map<VendorModel, Vendor>(obj);
		}


		public static VendorModel ConvertFromDal(Vendor obj)
	    {
		    var config = new MapperConfiguration(cfg =>
			    cfg.CreateMap<Vendor, VendorModel>());
		    var mapper = new Mapper(config);
		    return mapper.Map<Vendor, VendorModel>(obj);
		}

		public static List<VendorModel> ConvertListFromDal(IEnumerable<Vendor> obj)
	    {
		    return obj?.Select(ConvertFromDal).ToList();
	    }
	    public static List<Vendor> ConvertListToDal(IEnumerable<VendorModel> obj)
	    {
		    return obj?.Select(ConvertToDal).ToList();
	    }
	}
}
