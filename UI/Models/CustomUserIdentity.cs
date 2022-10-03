using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using DAL.DbModels;
using Microsoft.VisualStudio.OLE.Interop;

namespace UI.Models
{
    public class CustomUserIdentity : ClaimsIdentity
    {
		public int? Id { get; set; }
		public UserRole Role { get; set; }

		public CustomUserIdentity(BaseUser user, string authenticationType = "Cookie") : base(GetUserClaims(user), authenticationType)
		{
			Id = user?.Id;
			Role = (UserRole)user.Role;
		}

		private static List<Claim> GetUserClaims(BaseUser user)
		{
			if (user == null || user.IsBlocked)
			{
				return new List<Claim>();
			}
			var result = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.Login),
				new Claim(ClaimTypes.Role, user.Role.ToString())
			};

			return result;
		}
	}
}
