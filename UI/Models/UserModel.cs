using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using DAL.DbModels;
using Microsoft.AspNetCore.Identity;

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
		public City City { get; set; }

		public List<Vendor> Vendors { get; set; }

		public static User ConvertToDal(UserModel obj)
		{
			return obj == null
				? null
				: new User()
				{
					Id = obj.Id,
					Email = obj.Email,
					FirstName = obj.FirstName,
					MiddleName = obj.MiddleName,
					LastName = obj.LastName,
					Login = obj.Login,
					MobilePhone = obj.MobilePhone,
					Password = obj.Password,
					CityId = obj.CityId,
					Role = (int)obj.Role,
				};
		}


		public static UserModel ConvertFromDal(User obj)
		{
			return obj == null
				? null
				: new UserModel()
				{
					Id = obj.Id,
					Email = obj.Email,
					FirstName = obj.FirstName,
					MiddleName = obj.MiddleName,
					LastName = obj.LastName,
					Login = obj.Login,
					MobilePhone = obj.MobilePhone,
					Password = obj.Password,
					CityId = obj.CityId,
					Role = (UserRole)obj.Role,
				};
		}

		public static List<UserModel> ConvertListFromDal(IEnumerable<User> models)
		{
			return models?.Select(ConvertFromDal).ToList();
		}
		public static List<User> ConvertListToDal(IEnumerable<UserModel> models)
		{
			return models?.Select(ConvertToDal).ToList();
		}
	}
}
