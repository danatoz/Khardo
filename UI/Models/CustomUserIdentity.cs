using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DAL.DbModels;

namespace UI.Models
{
    public class CustomUserIdentity : ClaimsIdentity
    {
		public string Id { get; set; }

		public CustomUserIdentity(User user, string authenticationType = "Cookie") : base(GetUserClaims(user), authenticationType)
		{
			Id = user?.Id;
		}

		private static List<Claim> GetUserClaims(User user)
		{

			var result = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.UserName),
			};

			return result;
		}
	}
}
