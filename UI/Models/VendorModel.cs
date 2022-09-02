using System.Collections.Generic;
using System.Linq;
using DAL.DbModels;

namespace UI.Models
{
    public class VendorModel : BaseUser
    {
	    public int Rating { get; set; }
	    public int ResponsibleId { get; set; }
	    public string ITN { get; set; }
	    public string BIC { get; set; }
	    public string PhysicalAdress { get; set; }
	    public string LegalAddress { get; set; }
	    public UserModel Responsible { get; set; }

	    public static Vendor ConvertToDal(VendorModel obj)
	    {
		    return obj == null
			    ? null
			    : new Vendor()
			    {
					Id = obj.Id,
					Email = obj.Email,
					FirstName = obj.FirstName,
					MiddleName = obj.MiddleName,
					LastName = obj.LastName,
					Login = obj.Login,
					MobilePhone = obj.MobilePhone,
					Password = obj.Password,
					Rating = obj.Rating,
					ResponsibleId = obj.ResponsibleId,
					ITN = obj.ITN,
					BIC = obj.BIC,
					PhysicalAdress = obj.PhysicalAdress,
					LegalAddress = obj.LegalAddress,
			    };
	    }


		public static VendorModel ConvertFromDal(Vendor obj)
	    {
		    return obj == null
			    ? null
			    : new VendorModel()
			    {
				    Id = obj.Id,
				    Email = obj.Email,
				    FirstName = obj.FirstName,
				    MiddleName = obj.MiddleName,
				    LastName = obj.LastName,
				    Login = obj.Login,
				    MobilePhone = obj.MobilePhone,
				    Password = obj.Password,
				    Rating = obj.Rating,
				    ResponsibleId = obj.ResponsibleId,
				    ITN = obj.ITN,
				    BIC = obj.BIC,
				    PhysicalAdress = obj.PhysicalAdress,
				    LegalAddress = obj.LegalAddress,
				};
	    }

		public static List<VendorModel> ConvertListFromDal(IEnumerable<Vendor> models)
	    {
		    return models?.Select(ConvertFromDal).ToList();
	    }
	    public static List<Vendor> ConvertListToDal(IEnumerable<VendorModel> models)
	    {
		    return models?.Select(ConvertToDal).ToList();
	    }
	}
}
