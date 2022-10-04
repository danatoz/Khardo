using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.Enums;
using DAL.DbModels;
using Entities;

namespace UI.Models
{
    public class UserModel : BaseUser
    {
	    public string FullName
	    {
		    get
		    {
			    var result = LastName + " " + FirstName;
			    if (!string.IsNullOrEmpty(MiddleName))
			    {
				    result += " " + MiddleName;
			    }
			    return result;
		    }
		}
		public UserRole Role { get; set; }
		public int? CityId { get; set; }
		public CityModel City { get; set; }

		public List<VendorModel> Vendors { get; set; }

		public static User ConvertToDal(UserModel obj)
		{
			var config = new MapperConfiguration(cfg =>
				cfg.CreateMap<UserModel, User>());
			var mapper = new Mapper(config);
			return mapper.Map<UserModel, User>(obj);
		}


		public static UserModel ConvertFromDal(User obj)
		{
			var config = new MapperConfiguration(cfg =>
				cfg.CreateMap<User, UserModel>());
			var mapper = new Mapper(config);
			return mapper.Map<User, UserModel>(obj);
		}

		public static List<UserModel> ConvertListFromDal(IEnumerable<User> obj)
		{
			return obj?.Select(ConvertFromDal).ToList();
		}
		public static List<User> ConvertListToDal(IEnumerable<UserModel> obj)
		{
			return obj?.Select(ConvertToDal).ToList();
		}
	}
}
